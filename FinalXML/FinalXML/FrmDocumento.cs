using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Net.Http;
using FinalXML;
using FinalXML.Properties;
using FinalXML.Informes;
using DevComponents.DotNetBar;
using FinalXML.Administradores;
using FinalXML.Entidades;
using System.Text.RegularExpressions;
using Tesseract;
using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using WinApp.API;
using WinApp.Comun.Dto.Intercambio;
using WinApp.Comun.Dto.Modelos;
using WinApp.Firmado;
using WinApp.Servicio;
using WinApp.Servicio.Soap;
using WinApp.Comun;


namespace FinalXML
{
    public partial class FrmDocumento : PlantillaBase
    {

        #region Variables

        public static BindingSource data = new BindingSource();
        String filtro = String.Empty;

        List<clsProducto> listaProducto = new List<clsProducto>();
        IntRange red = new IntRange(0, 255);
        IntRange green = new IntRange(0, 255);
        IntRange blue = new IntRange(0, 255);
        SunatRuc MyInfoSunat;
        Reniec MyInfoReniec;
        string Texto = string.Empty;
        #endregion
        #region Variables Privadas
        private readonly DocumentoElectronico _documento;
        public DocumentoElectronico _documento2;
        
        #endregion
        public string TramaXmlSinFirma { get; set; }
        #region Propiedades
        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        #endregion
        public string numeracion;
        Conversion ConvertLetras = new Conversion();
        //ConvertThis ConvertLetras2 = new ConvertThis();
        clsAdmNumeracion AdmNumera = new clsAdmNumeracion();
        clsNumeracion Numera = new clsNumeracion();
        public clsCliente cliente { get; set; }
        private clsAdmCliente admcliente = new clsAdmCliente();
        private DataTable placas_cliente = null;
        private clsAdmPlaca admplaca = new clsAdmPlaca();
        public Exportacion expor;
        private const string FormatoFecha = "yyyy-MM-dd";
        private clsDetalleComprobante _detcomprobante;
        int codigo = 0;
        private clsAdmCliente admcli = new clsAdmCliente();

        public FrmDocumento()
        {
            InitializeComponent();
            Numera = AdmNumera.BuscaNumeracionFac();
            string str = Convert.ToString(Numera.Numeracion);
            char pad = '0';

            _documento = new DocumentoElectronico
            {
                FechaEmision = DateTime.Today.ToShortDateString(),
                //IdDocumento = Numera.Serie+ "-" + str.PadLeft(8, pad)
            };
            Inicializar();
            if (_documento.Receptor != null)
            {
                txtNroDocRec.Text = _documento.Receptor.NroDocumento;
                txtNombreLegalRec.Text = _documento.Receptor.NombreLegal;
                txtDirRec.Text = _documento.Receptor.Direccion;
            }
        }
        private void Inicializar()
        {
            documentoElectronicoBindingSource.DataSource = _documento;
            documentoElectronicoBindingSource.ResetBindings(false);

            emisorBindingSource.DataSource = _documento.Emisor;
            emisorBindingSource.ResetBindings(false);

            receptorBindingSource.DataSource = _documento.Receptor;
            receptorBindingSource.ResetBindings(false);
        }
        private void FrmDocumento_Load(object sender, EventArgs e)
        {

            try
            {
                Cursor = Cursors.WaitCursor;

                // dgvDetalle.DataSource = null;


                CargarNumeracion();
                CargarProductos();

                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoDocumentoBindingSource.DataSource = ctx.TipoDocumentos.ToList();
                    tipoDocumentoBindingSource.ResetBindings(false);

                    tipoDocumentoContribuyenteBindingSource.DataSource = ctx.TipoDocumentoContribuyentes.ToList();
                    tipoDocumentoContribuyenteBindingSource.ResetBindings(false);

                    /*Verificar*/
                    discrepanciasBindingSource.DataSource = ctx.TipoDiscrepancias.ToList();
                    discrepanciasBindingSource.ResetBindings(false);

                    tipoDocumentoAnticipoBindingSource.DataSource = ctx.TipoDocumentoAnticipos.ToList();
                    tipoDocumentoAnticipoBindingSource.ResetBindings(false);

                    tipoOperacionBindingSource.DataSource = ctx.TipoOperaciones.ToList();
                    tipoOperacionBindingSource.ResetBindings(false);

                    monedaBindingSource.DataSource = ctx.Monedas.ToList();
                    monedaBindingSource.ResetBindings(false);
                }

                if (_documento.TipoDocumento != null)
                {
                    cboTipoDoc.SelectedValue = _documento.TipoDocumento;
                    String dato;
                    dato = Convert.ToString(cboTipoDoc.SelectedValue);
                    Numera = AdmNumera.BuscaNumeracion(Convert.ToString(dato));
                    string str = Convert.ToString(Numera.Numeracion);
                    char pad = '0';
                    numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                    textBox17.Text = numeracion.ToString();
                    _documento.IdDocumento = numeracion;


                }
                else
                {
                    cboTipoDoc.SelectedIndex = -1;
                }

                comboBox1.SelectedIndex = -1;
                cboTipoDocRec.SelectedIndex = -1;
                cboTipoDocRec2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;

                cboMoneda2.SelectedIndex = 0;


                cargarCorrelativoRetencion();
                cargarCorrelativoPercepcion();
                //txtCorrelativo3.Text = "R001-0001";
                cliente = new clsCliente() { Documento = "00000000" };
                //cboTipoDocRec.SelectedIndex = 1;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        public void cargarCorrelativoPercepcion()
        {


            Numera = AdmNumera.BuscaNumeracion("40");
            string str = Convert.ToString(Numera.Numeracion);
            char pad = '0';

            numeracion = Numera.Serie + "-" + str.PadLeft(4, pad);

            //_documento.IdDocumento = numeracion.ToString();
            txtCorrelativo4.Text = numeracion.ToString();

            //txtCorrelativo3.Text = "R001-0001";
        }

        public void cargarCorrelativoRetencion()
        {


            Numera = AdmNumera.BuscaNumeracion("20");
            string str = Convert.ToString(Numera.Numeracion);
            char pad = '0';

            numeracion = Numera.Serie + "-" + str.PadLeft(4, pad);

            // _documento.IdDocumento = numeracion.ToString();
            txtCorrelativo3.Text = numeracion.ToString();

            //txtCorrelativo3.Text = "R001-0001";
        }

        public FrmDocumento(DocumentoElectronico documento)
        {
            InitializeComponent();
            _documento = documento;
            txtSerie.Text = "B002";
            txtCorrel.Text = "1";
            CargaNumDocBaja();
            Inicializar();

        }

        public void CargarProductos()
        {
            try
            {
                clsAdmProducto admProducto = new clsAdmProducto();

                dgvProductos.AutoGenerateColumns = false;
                dgvProductos.DataSource = admProducto.Listar();
                dgvProductos.ClearSelection();
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CargarNumeracion()
        {
            try
            {
                clsAdmNumeracion admNumeracion = new clsAdmNumeracion();

                dgvNumeracion.AutoGenerateColumns = false;
                dgvNumeracion.DataSource = admNumeracion.Listar();
                dgvNumeracion.ClearSelection();



            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalcularTotales()
        {
            // Realizamos los cálculos respectivos.


            _documento.Gravadas = _documento.DescuentoGlobal > 0 && _documento.Items.Where(y => y.TipoImpuesto.StartsWith("1")).Any() ? (_documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.SubTotalVenta) - _documento.DescuentoGlobal) : _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.SubTotalVenta);

            _documento.Exoneradas = _documento.DescuentoGlobal > 0 && _documento.Items.Where(y => y.TipoImpuesto.Contains("20")).Any() ? (_documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma) - _documento.DescuentoGlobal) : _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.DescuentoGlobal > 0 && _documento.Items.Where(y => y.TipoImpuesto.StartsWith("3") || y.TipoImpuesto.Contains("40")).Any() ? (_documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma) - _documento.DescuentoGlobal) : _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma);

            _documento.Gratuitas = _documento.Items
                .Where(d => d.TipoImpuesto.Contains("21"))
                .Sum(d => d.Suma);

            _documento.LineCountNumeric = Convert.ToString(_documento.Items.Count());

            _documento.TotalIgv = _documento.DescuentoGlobal > 0 ? ((_documento.Gravadas) * (_documento.CalculoIgv == 0 ? 0.18m : 0.18m)) : _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);

            // Cuando existe ISC se debe recalcular el IGV.
            if (_documento.TotalIsc > 0)
            {
                _documento.TotalIgv = (_documento.Gravadas + _documento.TotalIsc) * _documento.CalculoIgv;
                // Se recalcula nuevamente el Total de Venta.
            }


            _documento.TotalVenta = _documento.Gravadas + _documento.Exoneradas + _documento.Inafectas +
                                    _documento.TotalIgv + _documento.TotalIsc + _documento.TotalOtrosTributos;
            if (_documento.CalculoIgv > 0)
            {
                _documento.SubTotalVenta = _documento.TotalVenta - _documento.TotalIgv;
            }
            else
            {
                _documento.SubTotalVenta = _documento.TotalVenta;
            }

            _documento.MontoEnLetras = Conversion.Enletras(_documento.TotalVenta); //Monto en letras agregado

            documentoElectronicoBindingSource.ResetBindings(false);

        }

        private async void toolGenerar_Click(object sender, EventArgs e)
        {

            try
            {


               

                if (cboTipoDoc.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de Documento Factura/Boleta");
                    return;
                }
                if (cboTipoDocRec.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un tipo de Documento para el Cliente..!");
                    return;
                }

                if (txtNroDocRec.Text == "")
                {
                    MessageBox.Show("Ingrese Documento Cliente");
                    txtNroDocRec.Focus();
                    return;
                }
                if (txtNombreLegalRec.Text == "")
                {
                    MessageBox.Show("Ingrese Nombre Legal Cliente");
                    txtNombreLegalRec.Focus();
                    return;
                }
                if (cboTipoDocRec.SelectedValue.ToString() == "1")
                {
                    cboTipoDocRec.MaxLength = 8;
                    if ((txtNroDocRec.Text.Length) < 8)
                    {
                        MessageBox.Show("Ingrese DNI Correcto");
                        txtNroDocRec.Focus();
                        return;
                    }
                }
                if (cboTipoDocRec.SelectedValue.ToString() == "6")
                {
                    cboTipoDocRec.MaxLength = 11;
                    if ((txtNroDocRec.Text.Length) < 11)
                    {
                        MessageBox.Show("Ingrese RUC Correcto");
                        txtNroDocRec.Focus();
                        return;
                    }
                }

                if (txtDirRec.Text == "")
                {
                    MessageBox.Show("Ingrese Dirección de Cliente..!");
                    txtDirRec.Focus();
                    return;
                }
                if (textBox17.Text == "")
                {
                    MessageBox.Show("Ingrese Correlativo del Documento..!");
                    textBox17.Focus();
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                emisorBindingSource.ResetBindings(false);
                _documento.Receptor.TipoDocumento = cboTipoDocRec.SelectedValue.ToString();
                _documento.IssueTime = String.Format("{0:HH:mm:ss}", DateTime.Now);
                documentoElectronicoBindingSource.EndEdit();
                totalVentaTextBox.Focus();
                _documento.CalculoIgv = _documento.Items.Where(a => a.TipoImpuesto == "10").Any() ? 0.18m : 0.00m;
                _documento.NumGuia = txtNumGuia.Text;
                _documento.Glosa = txtGlosa.Text;
                _documento.Receptor.NroDocumento = txtNroDocRec.Text;
                _documento.PuestoOrigen = txtPuertoOrigen.Text;
                _documento.PuestoDestino = txtPuertoDestino.Text;
                _documento.BL = txtBL.Text;
                _documento.Poliza = txtPoliza.Text;
                _documento.CondicionVenta = txtCondiVenta.Text;
                _documento.Booking = txtBooking.Text;              
                _documento.Drawback = txtDrawback.Text;
                _documento.Cajas = txtContenedores.Text;
                IdDocumento = _documento.IdDocumento;
               // _documento.Imcoterm = _documento.TipoOperacion == "0200" ? _documento.BL : ""; //Si TipoOperacion es exportacion se agrega tipo de IMCOTERMS
                //_documento.OrderReference = "OC01-123";
                if (_documento.TipoOperacion == "0200")
                {
                    var dato = _documento.Items.Where(x => x.ItemClassificationCode == null).Any();
                    if (dato)
                    {
                        MessageBox.Show("El tipo de operación es EXPORTACION, por favor agregar un código de producto según SUNAT");
                        return;
                    }
                }

                ISerializador serializador = new Serializador();
                DocumentoResponse response = new DocumentoResponse
                {
                    Exito = false
                };
              



                switch (_documento.TipoDocumento)
                {
                    case "07":
                        response = await new GenerarNotaCredito(serializador).Post(_documento);

                        if (!response.Exito)
                            MessageBox.Show(response.MensajeError);

                        RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                        $"{_documento.IdDocumento}.xml");
                        File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));

                        break;
                    case "08":
                        //GenerarNotaDebito
                        //var notaDebito = GeneradorXML.GenerarDebitNote(_documento);
                        //var serializador2 = new Serializador();
                        //TramaXmlSinFirma = serializador2.GenerarXml(notaDebito);
                        break;
                    default:

                        response = await new GenerarFactura(serializador).Post(_documento);

                        if (!response.Exito)
                            MessageBox.Show(response.MensajeError);

                        RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                        $"{_documento.IdDocumento}.xml");
                        File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));

                        break;
                }

               

                _documento2 = _documento;


                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private void btnGuia_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var datosGuia = _documento.DatosGuiaTransportista ?? new DatosGuia();

                using (var frm = new FrmDatosGuia(datosGuia))
                {
                    if (frm.ShowDialog(this) != DialogResult.OK) return;

                    _documento.DatosGuiaTransportista = datosGuia;
                    documentoElectronicoBindingSource.ResetBindings(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        private static Contribuyente CrearEmisor()
        {
            return new Contribuyente
            {
                NroDocumento = "20600121066",
                TipoDocumento = "6",
                Direccion = "CAL.GERMAN SCHREIBER NRO. 276 LIMA - LIMA - SAN ISIDRO",
                Departamento = "LIMA",
                Provincia = "LIMA",
                Distrito = "SAN ISIDRO",
                NombreLegal = "DISTRIBUIDORA EDSON S.R.L.",
                NombreComercial = "",
                Ubigeo = "150131",
                CodDomicilioFiscal = "0000"

            };
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                //AQUI GENERABA EL RESUMEN

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void cboTipoDoc_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            String dato;
            dato = Convert.ToString(cboTipoDoc.SelectedValue);
            Numera = AdmNumera.BuscaNumeracion(Convert.ToString(dato));


            string str = Convert.ToString(Numera.Numeracion);
            char pad = '0';
            cb_lista_placa.DataSource = null;

            if (Convert.ToDouble(dato) == 01)
            {

                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                txtNroDocRec.Text = "";
                txtNombreLegalRec.Text = "";
                txtDirRec.Text = "";
                cboTipoDocRec.SelectedIndex = 3;

            }
            else if (Convert.ToDouble(dato) == 03)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                txtNroDocRec.Text = "";
                txtNombreLegalRec.Text = "";
                txtDirRec.Text = "";
                cboTipoDocRec.SelectedIndex = 1;
            }
            else if (Convert.ToDouble(dato) == 07)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                txtNroDocRec.Text = "";
                txtNombreLegalRec.Text = "";
                txtDirRec.Text = "";
            }
            else if (Convert.ToDouble(dato) == 08)
            {
                numeracion = Numera.Serie + "-" + str.PadLeft(8, pad);
                txtNroDocRec.Text = "";
                txtNombreLegalRec.Text = "";
                txtDirRec.Text = "";
            }
            _documento.IdDocumento = numeracion.ToString();
            textBox17.Text = numeracion.ToString();
        }

        Int32 counter2 = 1;

        private async  void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dglista2.Rows.Count > 0)
                {
                    var correl = txtcorrelativo2.Text;
                    var documentoBaja = new ComunicacionBaja
                    {

                        IdDocumento = string.Format("RA-{0:yyyyMMdd}-" + correl, DateTime.Today),
                        FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                        FechaReferencia = DateTime.Today.ToString("yyyy-MM-dd"),//DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
                        Emisor = CrearEmisor(),
                        Bajas = new List<DocumentoBaja>()

                    };
                    var nomdoc = "RA-" + string.Format("{0:yyyyMMdd}-" + correl, DateTime.Today);
                    foreach (DataGridViewRow row in dglista2.Rows)
                    {
                        DocumentoBaja baja = new DocumentoBaja();
                        baja.Id = Convert.ToInt32(row.Cells[0].Value);
                        baja.TipoDocumento = Convert.ToString(row.Cells[1].Value);
                        baja.Serie = Convert.ToString(row.Cells[2].Value);
                        baja.Correlativo = Convert.ToString(row.Cells[3].Value);
                        baja.MotivoBaja = Convert.ToString(row.Cells[4].Value);

                        documentoBaja.Bajas.Add(baja);

                    }
                  
                    ISerializador serializador = new Serializador();
                    DocumentoResponse response = new DocumentoResponse
                    {
                        Exito = false
                    };
                    response = await new GenerarComunicacionBaja(serializador).Post(documentoBaja);

                    if (!response.Exito)
                        throw new ApplicationException(response.MensajeError);

              
                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{documentoBaja.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
                    IdDocumento = nomdoc;

                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("No hay Registros para Generar Documento");
                    return;
                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private async void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {

                clsAdmTipoCambio admTipoCambio = new clsAdmTipoCambio();
                clsTipoCambio oTipoCambio = null;
                var DocumentoRetencion = new DocumentoRetencion
                {
                    DocumentosRelacionados = new List<ItemRetencion>(),
                    IdDocumento = txtCorrelativo3.Text
                };
                DocumentoRetencion.DocumentosRelacionados.Clear();
                _documento.DocumentoRetencion.DocumentosRelacionados.Clear();
                _documento.IdDocumento = txtCorrelativo3.Text;

                if (cboTipoDocRec2.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione tipo de documento", "Documento Retención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtNroCliente.Text == "")
                {
                    MessageBox.Show("Ingrese nº documento cliente", "Documento Retención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtNomCliente.Text == "")
                {
                    MessageBox.Show("Ingrese razón social", "Documento Retención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (dgreten.Rows.Count > 0)
                {

                    _documento.DocumentoRetencion.Receptor.NroDocumento = txtNroCliente.Text;
                    _documento.DocumentoRetencion.Receptor.TipoDocumento = cboTipoDocRec2.SelectedValue.ToString();
                    _documento.DocumentoRetencion.Receptor.NombreLegal = txtNomCliente.Text;
                    _documento.DocumentoRetencion.IdDocumento = txtCorrelativo3.Text;
                    _documento.DocumentoRetencion.FechaEmision = DateTime.Today.ToString(FormatoFecha);
                    _documento.DocumentoRetencion.Moneda = cboMoneda2.SelectedValue.ToString();
                    _documento.DocumentoRetencion.RegimenRetencion = "01";
                    _documento.DocumentoRetencion.TasaRetencion = 3;

                    //_documento.DocumentoRetencion.TasaRetencion = Convert.ToDecimal(txtValorReten.Text);


                    Decimal ImporteRetenido = 0, ImportePagado = 0;
                    foreach (DataGridViewRow row in dgreten.Rows)
                    {
                        ItemRetencion retencion = new ItemRetencion();
                        retencion.NroDocumento = row.Cells[1].Value.ToString();
                        retencion.TipoDocumento = "01";
                        retencion.MonedaDocumentoRelacionado = row.Cells[3].Value.ToString();
                        retencion.FechaEmision = dtpFecha3.Value.Date.ToString("yyyy-MM-dd");//DateTime.Today.ToString(dtpFecha3.Value.Date);
                        retencion.ImporteTotal = Convert.ToDecimal(row.Cells[4].Value);
                        retencion.FechaPago = row.Cells[2].Value.ToString();
                        retencion.NumeroPago = Convert.ToInt32(row.Cells[0].Value);

                        //retencion.ImporteSinRetencion = Convert.ToDecimal(row.Cells[4].Value) - Convert.ToDecimal(row.Cells[5].Value);
                        //retencion.ImporteRetenido = Convert.ToDecimal(row.Cells[5].Value);

                        retencion.ImporteSinRetencion = Convert.ToDecimal(row.Cells[4].Value);
                        retencion.ImporteRetenido = Convert.ToDecimal(row.Cells[5].Value);
                        retencion.FechaRetencion = row.Cells[2].Value.ToString();

                        //retencion.ImporteTotalNeto = Convert.ToDecimal(row.Cells[4].Value);

                        retencion.ImporteTotalNeto = Convert.ToDecimal(row.Cells[4].Value) - Convert.ToDecimal(row.Cells[5].Value);


                        oTipoCambio = admTipoCambio.CargaTipoCambio(Convert.ToDateTime(DateTime.Today.ToString(FormatoFecha)), 2);
                        if (oTipoCambio == null)
                        {
                            MessageBox.Show("No existe tipo de cambio para la fecha del documento retenido");
                            return;
                        }

                        retencion.TipoCambio = Convert.ToDecimal(oTipoCambio.Venta);

                        retencion.FechaTipoCambio = DateTime.Today.ToString(FormatoFecha);


                        ImporteRetenido += Convert.ToDecimal(row.Cells[5].Value);
                        //ImportePagado += Convert.ToDecimal(row.Cells[4].Value);
                        ImportePagado += Convert.ToDecimal(retencion.ImporteTotalNeto);
                        _documento.DocumentoRetencion.DocumentosRelacionados.Add(retencion);


                        //documentoReten.DocumentosRelacionados.Add(retencion);

                    }

                    _documento.DocumentoRetencion.ImporteTotalPagado = ImportePagado;
                    _documento.DocumentoRetencion.ImporteTotalRetenido = ImporteRetenido;
                    _documento.DocumentoRetencion.Emisor = CrearEmisor();
                    _documento.MontoEnLetras =Conversion.Enletras(Convert.ToDecimal( _documento.DocumentoRetencion.ImporteTotalRetenido));

                  
                    ISerializador serializador = new Serializador();
                    DocumentoResponse response = new DocumentoResponse
                    {
                        Exito = false
                    };
                    response = await new GenerarRetencion(serializador).Post(_documento.DocumentoRetencion);

                    if (!response.Exito)
                        throw new ApplicationException(response.MensajeError);



                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{_documento.DocumentoRetencion.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
                    IdDocumento = _documento.DocumentoRetencion.IdDocumento;
                    _documento2 = _documento;
                    DialogResult = DialogResult.OK;


                }
                else
                {
                    MessageBox.Show("No hay Registros para Generar Documento");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        Int32 j = 1;
        private void txtMontoPago_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }


        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            double dato;

            dato = Convert.ToDouble(comboBox1.SelectedValue);
            if (dato == 01)
            {
                //MessageBox.Show(dato.ToString());
                numeracion = "F002";
            }
            else if (dato == 03)
            {
                numeracion = "B002";
            }
            textBox7.Text = numeracion;
        }


        Int32 counter = 1;

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (tbPaginas.SelectedIndex)
                {
                    case 0:
                        var detalle = new DetalleDocumento();
                        var detcomprobante = new clsDetalleComprobante();

                        using (var frm = new FrmDetalleDocumento(detalle, _documento))
                        {
                            if (frm.ShowDialog(this) != DialogResult.Cancel) return;

                            if (detalle.Descripcion != null)
                            {
                                if (detalle.Descripcion != string.Empty)
                                {
                                    if (decimal.Parse(detalle.PrecioUnitario.ToString()) > 0 && decimal.Parse(detalle.Cantidad.ToString()) > 0)
                                    {
                                        if (detalle.TipoImpuesto.StartsWith("1") && _documento.CalculoIgv == 0)
                                        {
                                            MessageBox.Show("Un producto gravado debe tener calculo de IGV \n Por favor agregar cálculo de IGV a la aplicación.");
                                            return;
                                        }
                                        _documento.Items.Add(detalle);
                                        CalcularTotales();
                                    }

                                }
                            }
                        }
                        break;
                    case 1:
                        var datoAdicional = new DatoAdicional();
                        using (var frm = new FrmDatosAdicionales(datoAdicional))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.DatoAdicionales.Add(datoAdicional);
                        }
                        break;
                    case 2:
                        var documentoRelacionado = new DocumentoRelacionado();
                        using (var frm = new FrmDocumentoRelacionado(documentoRelacionado))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Relacionados.Add(documentoRelacionado);
                        }
                        break;
                    case 3:
                        var discrepancia = new Discrepancia();
                        using (var frm = new FrmDiscrepancia(discrepancia, _documento.TipoDocumento))
                        {
                            if (frm.ShowDialog(this) != DialogResult.OK) return;

                            _documento.Discrepancias.Add(discrepancia);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                tipoDocumentoContribuyenteBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnDuplicar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                var registro = detallesBindingSource.Current as DetalleDocumento;
                if (registro == null) throw new ArgumentNullException(nameof(registro));

                var copia = new DetalleDocumento
                {
                    Id = registro.Id,
                    Cantidad = registro.Cantidad,
                    CodigoItem = registro.CodigoItem,
                    Descripcion = registro.Descripcion,
                    PrecioUnitario = registro.PrecioUnitario,
                    PrecioReferencial = registro.PrecioReferencial,
                    UnidadMedida = registro.UnidadMedida,
                    Impuesto = registro.Impuesto,
                    ImpuestoSelectivo = registro.ImpuestoSelectivo,
                    TipoImpuesto = registro.TipoImpuesto,
                    TipoPrecio = registro.TipoPrecio,
                    TotalVenta = registro.TotalVenta,
                    Suma = registro.Suma,
                    OtroImpuesto = registro.OtroImpuesto
                };

                copia.Id = copia.Id + 1;
                _documento.Items.Add(copia);

                CalcularTotales();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (tbPaginas.SelectedIndex)
                {
                    case 0:
                        var registro = detallesBindingSource.Current as DetalleDocumento;
                        if (registro == null) return;

                        _documento.Items.Remove(registro);

                        CalcularTotales();
                        break;
                    case 1:
                        var docAdicional = datoAdicionalesBindingSource.Current as DatoAdicional;
                        if (docAdicional == null) return;

                        _documento.DatoAdicionales.Remove(docAdicional);
                        break;
                    case 2:
                        var docRelacionado = relacionadosBindingSource.Current as DocumentoRelacionado;
                        if (docRelacionado == null) return;

                        _documento.Relacionados.Remove(docRelacionado);
                        break;
                    case 3:
                        var discrepancia = discrepanciasBindingSource.Current as Discrepancia;
                        if (discrepancia == null) return;

                        _documento.Discrepancias.Remove(discrepancia);
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            finally
            {
                documentoElectronicoBindingSource.ResetBindings(false);
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnCalcDetraccion_Click_1(object sender, EventArgs e)
        {
            //_documento.MontoDetraccion = _documento.Gravadas * _documento.CalculoDetraccion;
            _documento.MontoDetraccion = _documento.TotalVenta * _documento.CalculoDetraccion;

            documentoElectronicoBindingSource.ResetBindings(false);
        }

        private void btnAgregarLista_Click(object sender, EventArgs e)
        {
            if (txtCorrel.Text == "")
            {
                MessageBox.Show("Ingrese Correlativo para el Documento");
                txtCorrel.Text = "001";
                txtCorrel.Focus();
                return;
            }
            if (txtDocInicio.Text == "")
            {
                MessageBox.Show("Ingrese Documento Inicio");
                txtDocInicio.Focus();
                return;
            }
            if (txtDocFin.Text == "")
            {
                MessageBox.Show("Ingrese Documento Final");
                txtDocFin.Focus();
                return;
            }
            if (txtTotVenta.Text == "")
            {
                MessageBox.Show("Ingrese Total Venta");
                txtTotVenta.Focus();
                return;
            }
            if (txtIGV.Text == "")
            {
                MessageBox.Show("Ingrese IGV");
                txtIGV.Focus();
                return;
            }
            if (txtTotVentaGraba.Text == "")
            {
                MessageBox.Show("Ingrese Total Ventas Grabadas");
                txtTotVentaGraba.Focus();
                return;
            }
            dglista.Rows.Add(counter, "03", txtSerie.Text, txtDocInicio.Text, txtDocFin.Text, cbmoneda.SelectedValue, txtTotVenta.Text,
                txtIGV.Text, txtTotVentaGraba.Text);
            counter++;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (dglista.Rows.Count > 0)
            {
                dglista.Rows.RemoveAt(dglista.CurrentRow.Index);
            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                MessageBox.Show("Ingrese Serie");
                textBox7.Focus();
                return;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingrese Numeración");
                textBox1.Focus();
                return;
            }
            if (txtmotivo.Text == "")
            {
                MessageBox.Show("Ingrese Motivo de Anulación");
                txtmotivo.Focus();
                return;
            }

            dglista2.Rows.Add(counter2, comboBox1.SelectedValue, textBox7.Text, textBox1.Text, txtmotivo.Text);
            counter2++;
            textBox1.Text = "";
            txtmotivo.Text = "";
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            if (dglista2.Rows.Count > 0)
            {
                dglista2.Rows.RemoveAt(dglista2.CurrentRow.Index);

            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (txtNum.Text == "")
            {
                MessageBox.Show("Ingrese Numeración");
                txtNum.Focus();
                return;
            }
            if (txtMontoPago.Text == "")
            {
                MessageBox.Show("Ingrese Monto del Pago");
                txtMontoPago.Focus();
                return;
            }
            if (txtNroCliente.Text == "")
            {
                MessageBox.Show("Ingrese numero de documento");
                txtNroCliente.Focus();
                return;
            }



            Double reten;
            reten = Math.Round(Convert.ToDouble(txtMontoPago.Text) * Convert.ToDouble(txtValorReten.Text), 2);
            if (dgreten.Rows.Count == 0)
            {
                j = 1;
            }
            dgreten.Rows.Add(j, txtNum.Text, dtpFecha3.Value.ToString("yyyy-MM-dd"), cboMoneda2.SelectedValue.ToString(), Math.Round(Convert.ToDouble(txtMontoPago.Text), 2), Math.Round(Convert.ToDouble(reten), 2));// DateTime.Today.ToString("yyyy-MM-dd")
            j++;
            txtNum.Text = "";
            txtMontoPago.Text = "";
            txtNum.Focus();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {

            if (dgreten.Rows.Count > 0)
            {
                dgreten.Rows.RemoveAt(dgreten.CurrentRow.Index);

            }
            else
            {
                MessageBox.Show("No hay registros por eliminar");
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            try
            {
                cboTipoDocRec.SelectedIndex = -1;
                txtNroDocRec.Text = "";
                txtNombreLegalRec.Text = "";
                txtDirRec.Text = "";
                montoPercepcionTextBox.Text = "";
                montoDetraccionTextBox.Text = "";
                montoEnLetrasTextBox.Text = "";
                descuentoGlobalTextBox.Text = "";
                _documento.Items.Clear();
                _documento.Relacionados.Clear();
                _documento.DatoAdicionales.Clear();
                _documento.Discrepancias.Clear();
                _documento.Receptor.NroDocumento = "";
                _documento.Receptor.NombreLegal = "";
                _documento.Receptor.NombreComercial = "";
                _documento.Receptor.Direccion = "";
                dgvDetalle.Rows.Clear();
                datoAdicionalesDataGridView.Rows.Clear();
                relacionadosDataGridView.Rows.Clear();
                discrepanciasDataGridView.Rows.Clear();
                CalcularTotales();
                dglista.Rows.Clear();
                dglista2.Rows.Clear();

            }
            catch (Exception a) { MessageBox.Show(a.Message); }

            // _documento.TipoDocumento = "";
            // _documento.IdDocumento = "";
        }

        #region metodos Sunat
        private void CargarImagenSunat()
        {
            try
            {
                if (MyInfoSunat == null)
                    MyInfoSunat = new SunatRuc();
                this.pictureCapcha.Image = MyInfoSunat.GetCapcha;
                LeerCaptchaSunat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar con SUNAT, sírvase Ingresar los datos manualmente...");
            }
        }
        private void LeerCaptchaSunat()
        {
            using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
            {
                using (var image = new System.Drawing.Bitmap(pictureCapcha.Image))
                {
                    using (var pix = PixConverter.ToPix(image))
                    {
                        using (var page = engine.Process(pix))
                        {
                            var Porcentaje = String.Format("{0:P}", page.GetMeanConfidence());
                            string CaptchaTexto = page.GetText();
                            char[] eliminarChars = { '\n', ' ' };
                            CaptchaTexto = CaptchaTexto.TrimEnd(eliminarChars);
                            CaptchaTexto = CaptchaTexto.Replace(" ", string.Empty);
                            CaptchaTexto = Regex.Replace(CaptchaTexto, "[^a-zA-Z]+", string.Empty);
                            if (CaptchaTexto != string.Empty & CaptchaTexto.Length == 4)
                                txttexto.Text = CaptchaTexto.ToUpper();
                            else
                                CargarImagenSunat();
                        }
                    }
                }

            }

        }

        private void LeerDatos()
        {
            //llamamos a los metodos de la libreria ConsultaReniec...
            MyInfoSunat.GetInfo(this.txtNroDocRec.Text, this.txttexto.Text);
            switch (MyInfoSunat.GetResul)
            {
                case SunatRuc.Resul.Ok:
                    limpiarSunat();
                    txtNroDocRec.Text = MyInfoSunat.Ruc;
                    txtDirRec.Text = MyInfoSunat.Direcion.Normalize(NormalizationForm.FormD);
                    txtDirRec.Text = txtDirRec.Text.Replace("<TD>", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("<TD>", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("</TD>", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("<TR>", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("</TR>", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("TD", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("TR", "");
                    txtDirRec.Text = txtDirRec.Text.Replace("----", "");
                    if (txtDirRec.Text.Contains(">"))
                    {

                        txtDirRec.Text = "-";
                    }


                    txtNombreLegalRec.Text = MyInfoSunat.RazonSocial;

                    //ASIGNA DATOS AL CONTRIBUYENTE
                    _documento.Receptor.NroDocumento = MyInfoSunat.Ruc;
                    _documento.Receptor.NombreLegal = MyInfoSunat.RazonSocial;
                    _documento.Receptor.Direccion = MyInfoSunat.Direcion.Normalize(NormalizationForm.FormD);

                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("<TD>", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("</TD>", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("<TR>", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("</TR>", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("TD", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("TR", "");
                    _documento.Receptor.Direccion = _documento.Receptor.Direccion.Replace("----", "");
                    if (_documento.Receptor.Direccion.Contains("PROFESION U OCUPACION NO ESPECIFICADA"))
                    {

                        _documento.Receptor.Direccion = "-";
                    }


                    break;
                case SunatRuc.Resul.NoResul:
                    limpiarSunat();
                    MessageBox.Show("No Existe RUC");
                    break;
                case SunatRuc.Resul.ErrorCapcha:
                    limpiarSunat();
                    MessageBox.Show("Ingrese imagen correctamente");
                    break;
                default:
                    MessageBox.Show("Error Desconocido");
                    break;
            }
            CargarImagenSunat();
        }


        private void limpiarSunat()
        {
            txtNroDocRec.Text = string.Empty;
            txtNombreLegalRec.Text = string.Empty;
            txtDirRec.Text = string.Empty;
            txttexto.Text = string.Empty;
        }
        private void CargaRUC()
        {
            if (txtNroDocRec.TextLength < 11)
            {
                MessageBox.Show("Ingrese RUC Correcto");
                return;
            }
            else
            {
                if (txtNroDocRec.TextLength == 11)
                {
                    LeerDatos();
                }
            }
        }
        #endregion

        private void txtNroDocRec_KeyPress(object sender, KeyPressEventArgs e)
        {
            int id = -1;
            try
            {
                Cursor = Cursors.WaitCursor;
                if ((int)e.KeyChar == (int)Keys.Enter)
                {
                    //aqui codigo
                    if (cboTipoDocRec.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione Tipo de Documento");
                        return;
                    }
                    else
                    {
                        if (txtNroDocRec.Text.Length > 0)
                        {
                            cb_lista_placa.DataSource = null;

                            cliente = new clsCliente()
                            {

                                Documento = txtNroDocRec.Text
                            };

                            cliente = admcliente.buscar_clientexnumerodocumento(cliente);

                            if (cliente != null)
                            {

                                txtNroDocRec.Text = cliente.Documento;
                                txtNombreLegalRec.Text = cliente.Nombreyapellido;
                                txtDirRec.Text = cliente.Direccion.Trim();

                                if (cliente.Documento.Length == 8)
                                {

                                    cboTipoDocRec.SelectedIndex = 1;
                                }

                                if (cliente.Documento.Length == 11)
                                {

                                    cboTipoDocRec.SelectedIndex = 3;
                                }

                                if (_documento != null)
                                {
                                    _documento.Receptor.NroDocumento = txtNroDocRec.Text;
                                    _documento.Receptor.NombreLegal = txtNombreLegalRec.Text;
                                    _documento.Receptor.Direccion = txtDirRec.Text;
                                }

                                placas_cliente = admplaca.listar_placa_xidcliente(cliente);

                                if (placas_cliente != null)
                                {

                                    if (placas_cliente.Rows.Count > 0)
                                    {

                                        cb_lista_placa.DataSource = placas_cliente;
                                        cb_lista_placa.DisplayMember = "Numero";
                                        cb_lista_placa.ValueMember = "Numero";
                                    }
                                }

                            }
                            else
                            {

                                if (cboTipoDocRec.SelectedIndex == 3)
                                {
                                    CargaRUC();
                                    if (txtNroDocRec.Text.Length > 0 && txtNombreLegalRec.Text.Length > 0 && txtDirRec.Text.Length > 0)
                                    {

                                        id = admcliente.registrar_cliente(new clsCliente()
                                        {
                                            Tipodocumentoidentidad = new clsTipoDocumentoIdentidad()
                                            {
                                                Idtipodocumentoidentidad = 2
                                            },
                                            Nombreyapellido = txtNombreLegalRec.Text,
                                            Documento = txtNroDocRec.Text,
                                            Direccion = txtDirRec.Text.Trim()
                                        });

                                        if (id == -1) { MessageBox.Show("Problemas para registrar cliente...", "Advertencia"); }
                                        else
                                        {

                                            if (_documento != null)
                                            {
                                                _documento.Receptor.NroDocumento = txtNroDocRec.Text;
                                                _documento.Receptor.NombreLegal = txtNombreLegalRec.Text;
                                                _documento.Receptor.Direccion = txtDirRec.Text;
                                            }
                                        }
                                    }

                                }
                                else
                                {
                                    if (cboTipoDocRec.SelectedIndex == 1)
                                    {
                                        MessageBox.Show("Presione F1, para registrar cliente...", "Información");
                                    }
                                    else
                                    {

                                        MessageBox.Show("Tipo de documento es diferente de RUC/DNI...", "Información");
                                    }
                                }
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Consultar RUC");
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void cboTipoDocRec_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*txtNroDocRec.Text = "";
            txtNombreLegalRec.Text = "";
            txtDirRec.Text = "";*/
            /* _documento.Receptor.NroDocumento = "";
             _documento.Receptor.NombreLegal = "";
             _documento.Receptor.NombreComercial = "";
             _documento.Receptor.Direccion = "";*/
        }
        private void CargaNumDocBaja()
        {

            Numera = AdmNumera.BuscaNumeracion("RA");
            string str = Convert.ToString(Numera.Numeracion);
            //char pad = '0';
            //numeracion = str.PadLeft(8, pad);
            txtcorrelativo2.Text = str.ToString();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {

            var documentoBaja = new ComunicacionBaja
            {

                IdDocumento = "",
                FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                FechaReferencia = "",//DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"),
                Emisor = CrearEmisor(),
                Bajas = new List<DocumentoBaja>()

            };
            documentoBaja.Bajas.Clear();

            comboBox1.SelectedIndex = -1;
            textBox1.Text = "";
            txtmotivo.Text = "";
            dglista2.Rows.Clear();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                FormProducto frmProducto = new FormProducto();
                frmProducto.ShowDialog();

                clsProducto oProducto = null;


                if (frmProducto.oProducto != null)
                {
                    oProducto = frmProducto.oProducto;
                    CargarProductos();

                    /*
                    dgvProductos.Rows.Add(oProducto.IdProducto, oProducto.Referencia, oProducto.Descripcion, oProducto.Precio);
                    dgvProductos.Refresh();
                    dgvProductos.ClearSelection();*/
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int codigo;

                clsAdmProducto admProducto = new clsAdmProducto();

                if (dgvProductos.SelectedRows.Count > 0 && dgvProductos.Rows.Count > 0)
                {

                    codigo = Convert.ToInt32(dgvProductos.SelectedRows[0].Cells["IdProducto"].Value.ToString());


                    admProducto.Eliminar(codigo);
                    CargarProductos();

                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Seleccione un registro", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int codigo;

                clsAdmProducto admProducto = new clsAdmProducto();

                if (dgvProductos.SelectedRows.Count > 0 && dgvProductos.Rows.Count > 0)
                {

                    DataGridViewRow row = new DataGridViewRow();
                    clsProducto oProducto = new clsProducto();

                    row = dgvProductos.Rows[e.RowIndex];

                    oProducto.IdProducto = Convert.ToInt32(row.Cells[0].Value);
                    oProducto.Referencia = row.Cells[1].Value.ToString();
                    oProducto.Descripcion = row.Cells[2].Value.ToString();
                    oProducto.Precio = Convert.ToDecimal(row.Cells[3].Value);

                    oProducto = admProducto.Actualizar(oProducto);

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvProductos_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsAdmProducto admProducto = new clsAdmProducto();

                if (codigo > 0 && dgvProductos.Rows.Count > 0)
                {
                    admProducto.Eliminar(codigo);
                    CargarProductos();
                    codigo = 0;
                }

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CargarProductos();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            try
            {

                if (e.KeyChar == (char)Keys.Enter)
                {
                    clsAdmProducto admProducto = new clsAdmProducto();

                    dgvProductos.DataSource = admProducto.Busqueda(txtBuscar.Text.Trim());
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvProductos.Rows.Count > 0 && dgvProductos.SelectedRows.Count > 0)
            {
                codigo = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);
            }
        }

        private void btnListarN_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CargarNumeracion();

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvNumeracion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int codigo;

                clsAdmNumeracion admNumeracion = new clsAdmNumeracion();

                if (dgvNumeracion.SelectedRows.Count > 0 && dgvNumeracion.Rows.Count > 0)
                {

                    DataGridViewRow row = new DataGridViewRow();
                    clsNumeracion oNumeracion = new clsNumeracion();

                    row = dgvNumeracion.Rows[e.RowIndex];

                    oNumeracion.TipoDocumento = row.Cells[1].Value.ToString();
                    oNumeracion.Numeracion = Convert.ToInt32(row.Cells[4].Value);

                    admNumeracion.ActualizaNumeracion(oNumeracion);

                    this.Cursor = Cursors.Default;
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        int per = 1;
        private void kryptonButton7_Click(object sender, EventArgs e)
        {
            if (txtNumDocFac.Text == "")
            {
                MessageBox.Show("Ingrese Numeración");
                txtNumDocFac.Focus();
                return;
            }
            if (txtMontoPagoPercep.Text == "")
            {
                MessageBox.Show("Ingrese Monto del Pago");
                txtMontoPagoPercep.Focus();
                return;
            }
            if (txtNumDocCliPercep.Text == "")
            {
                MessageBox.Show("Ingrese numero de documento");
                txtNumDocCliPercep.Focus();
                return;
            }

            Double Percep;
            Percep = Convert.ToDouble(txtMontoPagoPercep.Text) * Convert.ToDouble(txtvalorPercep.Text);
            if (dgreten.Rows.Count == 0)
            {
                per = 1;
            }
            dgvPercepcion.Rows.Add(per, txtNumDocFac.Text, dtpFecha4.Value.ToString("yyyy-MM-dd"), cboMoneda3.SelectedValue.ToString(), Math.Round(Convert.ToDouble(txtMontoPagoPercep.Text), 2), Math.Round(Convert.ToDouble(Percep), 2),
                Math.Round(Convert.ToDouble(txtMontoPagoPercep.Text) + Convert.ToDouble(Percep), 2));// DateTime.Today.ToString("yyyy-MM-dd")
            per++;
            txtNumDocFac.Text = "";
            txtMontoPagoPercep.Text = "";
            txtNumDocFac.Focus();
        }

        private async void toolStripGenerarPercepcion_Click(object sender, EventArgs e)
        {
            try
            {

                clsAdmTipoCambio admTipoCambio = new clsAdmTipoCambio();
                clsTipoCambio oTipoCambio = null;


                var DocumentoPercepcion = new DocumentoPercepcion
                {
                    DocumentosRelacionados = new List<ItemPercepcion>(),
                    IdDocumento = txtCorrelativo4.Text
                };
                DocumentoPercepcion.DocumentosRelacionados.Clear();
                _documento.DocumentoPercepcion.DocumentosRelacionados.Clear();
                _documento.IdDocumento = txtCorrelativo4.Text;
                if (cboTipoDocRec3.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione tipo de documento", "Documento Percepción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (txtNumDocCliPercep.Text == "")
                {
                    MessageBox.Show("Ingrese nº documento cliente", "Documento Percepción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (txtNomCliPercep.Text == "")
                {
                    MessageBox.Show("Ingrese razón social", "Documento Percepción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (dgvPercepcion.Rows.Count > 0)
                {

                    _documento.DocumentoPercepcion.Receptor.NroDocumento = txtNumDocCliPercep.Text;
                    _documento.DocumentoPercepcion.Receptor.TipoDocumento = cboTipoDocRec3.SelectedValue.ToString();
                    _documento.DocumentoPercepcion.Receptor.NombreLegal = txtNomCliPercep.Text;
                    _documento.DocumentoPercepcion.IdDocumento = txtCorrelativo4.Text;
                    _documento.DocumentoPercepcion.FechaEmision = DateTime.Today.ToString(FormatoFecha);
                    _documento.DocumentoPercepcion.Moneda = cboMoneda3.SelectedValue.ToString();
                    _documento.DocumentoPercepcion.RegimenPercepcion = "01";
                    _documento.DocumentoPercepcion.TasaPercepcion = 2;



                    Decimal ImportePercibido = 0, ImportePagado = 0, ImporteTotalCobrado = 0;
                    foreach (DataGridViewRow row in dgvPercepcion.Rows)
                    {
                        ItemPercepcion percepcion = new ItemPercepcion();
                        percepcion.NroDocumento = row.Cells[1].Value.ToString();
                        percepcion.TipoDocumento = "01"; //mejorar para la otras versiones
                        percepcion.MonedaDocumentoRelacionado = row.Cells[3].Value.ToString();
                        percepcion.FechaEmision = dtpFecha4.Value.Date.ToString();//DateTime.Today.ToString(FormatoFecha);                        
                        percepcion.FechaPago = row.Cells[2].Value.ToString();
                        percepcion.NumeroPago = Convert.ToInt32(row.Cells[0].Value);
                        percepcion.ImporteSinPercepcion = Convert.ToDecimal(row.Cells[4].Value);
                        percepcion.ImportePercibido = Convert.ToDecimal(row.Cells[5].Value);
                        percepcion.ImporteTotal = Convert.ToInt32(row.Cells[4].Value);
                        percepcion.FechaPercepcion = row.Cells[2].Value.ToString();
                        percepcion.ImporteTotalNeto = Convert.ToDecimal(percepcion.ImporteSinPercepcion + percepcion.ImportePercibido);

                        oTipoCambio = admTipoCambio.CargaTipoCambio(Convert.ToDateTime(DateTime.Today.ToString(FormatoFecha)), 2);
                        if (oTipoCambio == null)
                        {
                            MessageBox.Show("No existe tipo de cambio para la fecha del documento percibido");
                            return;
                        }
                        percepcion.TipoCambio = Convert.ToDecimal(oTipoCambio.Venta);

                        percepcion.FechaTipoCambio = DateTime.Today.ToString(FormatoFecha);

                        ImporteTotalCobrado += Convert.ToDecimal(percepcion.ImporteSinPercepcion + percepcion.ImportePercibido);
                        ImportePercibido += Convert.ToDecimal(row.Cells[5].Value);

                        ImportePagado += Convert.ToDecimal(percepcion.ImporteTotal);

                        _documento.DocumentoPercepcion.DocumentosRelacionados.Add(percepcion);




                    }

                    _documento.DocumentoPercepcion.ImporteTotalCobrado = ImporteTotalCobrado;
                    _documento.DocumentoPercepcion.ImporteTotalPagado = ImportePagado;
                    _documento.DocumentoPercepcion.ImporteTotalPercibido = ImportePercibido;
                    _documento.DocumentoPercepcion.Emisor = CrearEmisor();
                    _documento.MontoEnLetras = Conversion.Enletras(_documento.DocumentoPercepcion.ImporteTotalPercibido);

               


                    ISerializador serializador = new Serializador();
                    DocumentoResponse response = new DocumentoResponse
                    {
                        Exito = false
                    };
                    response = await new GenerarPercepcion(serializador).Post(_documento.DocumentoPercepcion);

                    if (!response.Exito)
                        throw new ApplicationException(response.MensajeError);

                    

                    RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Documentos\\" +
                     $"{_documento.DocumentoPercepcion.IdDocumento}.xml");
                    File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
                    IdDocumento = _documento.DocumentoPercepcion.IdDocumento;
                    _documento2 = _documento;
                    DialogResult = DialogResult.OK;


                }
                else
                {
                    MessageBox.Show("No hay Registros para Generar Documento");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }



        }

        private void kryptonButton9_Click(object sender, EventArgs e)
        {
            try
            {
                var documentoTen = new DocumentoRetencion
                {
                    IdDocumento = "",
                    FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                    Emisor = CrearEmisor(),
                    DocumentosRelacionados = new List<ItemRetencion>()

                };
                _documento.DocumentoRetencion.DocumentosRelacionados.Clear();
                j = 1;
                dgreten.Rows.Clear();
                txtNroCliente.Text = "";
                txtNomCliente.Text = "";

            }
            catch (Exception a) { MessageBox.Show(a.Message); }

        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {
            try
            {
                var documentoPer = new DocumentoPercepcion
                {
                    IdDocumento = "",
                    FechaEmision = DateTime.Today.ToString("yyyy-MM-dd"),
                    Emisor = CrearEmisor(),
                    DocumentosRelacionados = new List<ItemPercepcion>()

                };
                _documento.DocumentoPercepcion.DocumentosRelacionados.Clear();
                j = 1;
                dgvPercepcion.Rows.Clear();
                txtNroCliente.Text = "";
                txtNomCliente.Text = "";

            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void kryptonButton8_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPercepcion.Rows.Count > 0)
                {
                    dgvPercepcion.Rows.RemoveAt(dgreten.CurrentRow.Index);
                    per--;
                }
                else
                {
                    MessageBox.Show("No hay registros por eliminar");
                    per = 1;
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreLegalRec_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtDirRec_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNombreLegalRec_TextChanged(object sender, EventArgs e)
        {
            txtNombreLegalRec.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDirRec_TextChanged(object sender, EventArgs e)
        {
            txtDirRec.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmCliente"] != null)
            {
                Application.OpenForms["FrmCliente"].Activate();
            }
            else
            {
                cliente = null;
                FrmCliente frm_cliente = new FrmCliente();
                frm_cliente.frm_documento = this;
                frm_cliente.ShowDialog();

                cb_lista_placa.DataSource = null;

                if (cliente == null)
                {
                    txtNroDocRec.Text = string.Empty;
                    txtNombreLegalRec.Text = string.Empty;
                    txtDirRec.Text = string.Empty;
                }
                else
                {

                    txtNroDocRec.Text = cliente.Documento;
                    txtNombreLegalRec.Text = cliente.Nombreyapellido;
                    txtDirRec.Text = cliente.Direccion;

                    if (cliente.Documento.Length == 8)
                    {

                        cboTipoDocRec.SelectedIndex = 1;
                    }

                    if (cliente.Documento.Length == 11)
                    {

                        cboTipoDocRec.SelectedIndex = 3;
                    }

                    _documento.Receptor.NroDocumento = txtNroDocRec.Text;
                    _documento.Receptor.NombreLegal = txtNombreLegalRec.Text;
                    _documento.Receptor.Direccion = txtDirRec.Text;

                    placas_cliente = admplaca.listar_placa_xidcliente(cliente);

                    if (placas_cliente != null)
                    {

                        if (placas_cliente.Rows.Count > 0)
                        {

                            cb_lista_placa.DataSource = placas_cliente;
                            cb_lista_placa.DisplayMember = "Numero";
                            cb_lista_placa.ValueMember = "Numero";
                        }
                    }

                }

            }
        }

        private void txtNroDocRec_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btn_cliente.PerformClick();
            }
        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            txt_numero.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_numero_KeyDown(object sender, KeyEventArgs e)
        {
            cliente = null;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    cb_lista_placa.DataSource = null;

                    if (txt_numero.Text.Length > 0)
                    {
                        cliente = admcli.listar_cliente_xnumeroplaca(new clsPlaca()
                        {
                            Numero = txt_numero.Text
                        });

                        if (cliente != null)
                        {
                            txtNroDocRec.Text = cliente.Documento;
                            txtNombreLegalRec.Text = cliente.Nombreyapellido;
                            txtDirRec.Text = cliente.Direccion;

                            if (cliente.Documento.Length == 8)
                            {

                                cboTipoDocRec.SelectedIndex = 1;
                            }

                            if (cliente.Documento.Length == 11)
                            {

                                cboTipoDocRec.SelectedIndex = 3;
                            }

                            if (_documento != null)
                            {
                                _documento.Receptor.NroDocumento = txtNroDocRec.Text;
                                _documento.Receptor.NombreLegal = txtNombreLegalRec.Text;
                                _documento.Receptor.Direccion = txtDirRec.Text;
                            }
                        }
                        else
                        {

                            MessageBox.Show("Cliente no encontrado por Número de Placa... F1 para registrar", "Advertencia");
                        }

                    }
                    else
                    {

                        MessageBox.Show("Por favor complete la información...", "Advertencia");
                    }

                }
            }
            catch (Exception) { }
        }

        private void cb_lista_placa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_lista_placa.Items.Count > 0)
            {

                txt_numero.Text = cb_lista_placa.Text;
            }
        }

        private void btn_actulizar_capcha_Click(object sender, EventArgs e)
        {
            #region CARGAR RUC
            try
            {
                CargarImagenSunat();
                LeerCaptchaSunat();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                MessageBox.Show("No se pudo conectar a SUNAT. Sírvase ingresar manualmente los datos...");
            }
            tipoDocumentoContribuyenteBindingSource.ResetBindings(false);
            #endregion

        }

        private void kryptonLabel25_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
