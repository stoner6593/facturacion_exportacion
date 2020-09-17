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
using System.Data.Entity;
using FinalXML.Informes;
using DevComponents.DotNetBar;
using FinalXML.Administradores;
using FinalXML.Interfaces;
using FinalXML.Entidades;
using FinalXML.Librerias;
using FinalXML.controlador;
using WinApp.API;
using WinApp.Comun.Dto.Intercambio;
using WinApp.Comun.Dto.Modelos;
using WinApp.Datos;
using WinApp.Entidades;
using WinApp.Firmado;

using WinApp.Servicio;
using WinApp.Servicio.Soap;


namespace FinalXML
{
    public partial class Form1 : PlantillaBase
    {
        private int imprimir = -1;
        private clsCaja caja = null;
        private clsAdmCaja admcaja = new clsAdmCaja();
        public clsUsuario usuario { get; set; }
        clsValidarSGE valida = new clsValidarSGE();
        DataTable tabla = new DataTable();
        //public static clsParametros Configuracion = new clsParametros();
        clsTipoCambioSunat clstipoc = new clsTipoCambioSunat();
        DateTime dia;

        public Double comp;
        public Double vent;
        clsTipoCambio oTipoCambio = new clsTipoCambio();
        public Boolean EstadoTC_BD = false;
        clsAdmTipoCambio admTipoCambio = new clsAdmTipoCambio();
        public Double tc_hoy = 0;
        public Int32 tcvalida;
        public static clsParametros Configuracion = new clsParametros();
        public Boolean EstadoTC = false;

        Herramientas herramientas = new Herramientas();
        public String ticket;
        private FrmDocumento _frmDocumento;
        public DocumentoElectronico _documento;
        public DocumentoRetencion _retencion;
        clsAdmNumeracion AdmNumeracion = new clsAdmNumeracion();
        clsNumeracion Numeracion = new clsNumeracion();

        private CclsConfiguracionEnvio cconfig = new CclsConfiguracionEnvio();
        private clsConfiguracionEnvio config = null;

        private clsArchivo archivo = null;
        private clsRepositorio repositorio = null;
        private clsAdmRepositorio admrepo = new clsAdmRepositorio();
        private clsAdmDetalleComprobante detcomprobante = new clsAdmDetalleComprobante();

        private clsEmpresa empresa = null;
        private string firmadig = "";
        private string resumenfirmadig = "";


        public Form1()
        {
            InitializeComponent();

            Load += (s, e) =>
            {

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    using (var ctx = new OpenInvoicePeruDb())
                    {
                        direccionSunatBindingSource.DataSource = ctx.DireccionesSunat.ToList();
                        direccionSunatBindingSource.ResetBindings(false);
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
            };
            var recursos = herramientas.GetResourcesPath();
            txtRutaCertificado.Text = recursos + "\\Certificadopfx.pfx";

        }

        private void CargaDatos1()
        {
            txtNroRuc.Text = "20600121066";
            txtUsuarioSol.Text = "EDSO2018";
            txtClaveSol.Text = "edso2018";
            txtPassCertificado.Text = "tVm7Wt7gdwHeXnVM";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string ValorSeleccionado()
        {
            // var direccionSunat = direccionSunatBindingSource.Current as DireccionSunat;
            return ""; //direccionSunat == null ? string.Empty : direccionSunat.Descripcion;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int idcaja = -1;

            if (usuario != null)
            {
                idcaja = admcaja.buscar_caja_abierta(usuario);

                if (idcaja > 0)
                {
                    listar_configuracionenvio();
                    CargaDatos1();
                    CargarTipoCambio();

                }
                else
                {

                    MessageBox.Show("Por favor aperture caja...");
                    this.Close();
                }

            }
            else
            {
                return;
            }
        }


        public void CargarTipoCambio()
        {
            try
            {

                Configuracion.Autoguardado = true;
                dia = DateTime.Today.Date;

                EstadoTC_BD = admTipoCambio.VerificaTCFecha(dia);

                if (EstadoTC_BD)
                {
                    tcvalida = 1;
                    oTipoCambio = admTipoCambio.CargaTipoCambio(dia, 2);
                    tc_hoy = oTipoCambio.Venta;
                    liTipodeCambio.Text = "Fecha TC:  " + oTipoCambio.Fecha.ToShortDateString() + "  Compra: " + oTipoCambio.Compra.ToString() + " - Venta: " + oTipoCambio.Venta.ToString();
                }
                else
                {
                    if (valida.AccesoInternet())
                    {
                        MetodoTipoCambio();
                        //if ("" != "Tipo de Cambio" && Configuracion.Autoguardado == true)
                        if (liTipodeCambio.Text != "Tipo de Cambio" && Configuracion.Autoguardado == true)
                        {
                            tcvalida = 1;
                            oTipoCambio = admTipoCambio.CargaTipoCambio(dia, 2);
                            tc_hoy = oTipoCambio.Venta;
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void MetodoTipoCambio()
        {
            try
            {
                Boolean auto = Configuracion.Autoguardado;

                tabla = clstipoc.ConsultaTCSunat(dia);
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    //var sdiabuscado = TipoCam.Select("Día = '" + Fechabuscada.Date.Day.ToString() + "'");
                    String cadenabusqueda = "[Día] like '*" + dia.Date.Day.ToString() + "*'";
                    DataRow[] foundRows = tabla.Select(cadenabusqueda);
                    //if (sdiabuscado.Length != 0)
                    if (foundRows.Length != 0)
                    {
                        foreach (DataRow r in tabla.Rows)
                        {
                            if (Convert.ToInt32(r[0]) == dia.Date.Day)
                            {
                                liTipodeCambio.Text = "Fecha TC:  " + dia.ToShortDateString() + " Compra: " + r[1].ToString() + " Venta: " + r[2].ToString();
                                //Thread.Sleep(1000);
                                comp = Convert.ToDouble(r[1].ToString().Replace(",", "."));
                                vent = Convert.ToDouble(r[2].ToString().Replace(",", "."));
                            }
                        }
                        if (auto)
                        {
                            //if ("" != "Tipo de Cambio")
                            if (liTipodeCambio.Text != "Tipo de Cambio")
                            {
                                oTipoCambio.ICodMoneda = 2;
                                oTipoCambio.Compra = comp;
                                oTipoCambio.Venta = vent;
                                oTipoCambio.Fecha = dia;
                                oTipoCambio.CodUser = 1;
                                oTipoCambio.Automatico_manual = 1; // regitro del tipo de cambio via web es decir automatica
                                if (admTipoCambio.insert(oTipoCambio))
                                {
                                    //MetodoTipoCambio();
                                    EstadoTC = true;
                                    dia = DateTime.Now;
                                    ValidaTipoCambio();
                                }
                            }
                        }
                    }
                    else
                    {
                        dia = dia.AddDays(-1);
                        MetodoTipoCambio();
                    }
                }
                else
                {
                    dia = dia.AddDays(-1);
                    MetodoTipoCambio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas de Conexión : " + ex.Message, "Error en Hilo Tipo Cambio", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        public void ValidaTipoCambio()
        {
            try
            {
                EstadoTC_BD = admTipoCambio.VerificaTCFecha(dia);
                if (EstadoTC_BD)
                {
                    tcvalida = 1;
                    oTipoCambio = admTipoCambio.CargaTipoCambio(dia, 2);
                    tc_hoy = oTipoCambio.Venta;
                    kryptonPanel1.Text = "Fecha TC:  " + oTipoCambio.Fecha.ToShortDateString() + "  Compra: " + oTipoCambio.Compra.ToString() + " - Venta: " + oTipoCambio.Venta.ToString();
                }
                else
                {
                    if (valida.AccesoInternet())
                    {
                        MetodoTipoCambio();
                        if (kryptonPanel1.Text != "Tipo de Cambio" && Configuracion.Autoguardado == true)
                        //if ("" != "Tipo de Cambio" && Configuracion.Autoguardado == true)
                        {
                            tcvalida = 1;
                            oTipoCambio = admTipoCambio.CargaTipoCambio(dia, 2);
                            tc_hoy = oTipoCambio.Venta;
                        }
                        else
                        {
                            MessageBox.Show("Ingresa Tipo de Cambio de Hoy");
                            if (Application.OpenForms["frmTipoCambio"] != null)
                            {
                                Application.OpenForms["frmTipoCambio"].Activate();
                            }
                            else
                            {
                                frmTipoCambio form = new frmTipoCambio();
                                form.btnNuevo_Click(null, null);
                                form.ShowDialog();
                                ValidaTipoCambio();
                            }
                        }
                    }
                    else
                    {
                        //dia = dia.AddDays(-1);

                        MessageBox.Show("Ingresa Tipo de Cambio de Hoy");
                        if (Application.OpenForms["frmTipoCambio"] != null)
                        {
                            Application.OpenForms["frmTipoCambio"].Activate();
                        }
                        else
                        {
                            frmTipoCambio form = new frmTipoCambio();
                            //form.MdiParent = this;
                            form.btnNuevo_Click(new object(), new EventArgs());
                            form.ShowDialog();
                        }

                        ValidaTipoCambio();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnBrowseCert_Click_2(object sender, EventArgs e)
        {

            try
            {
                if (txtRutaCertificado.Text == "")
                {
                    using (var ofd = new OpenFileDialog())
                    {
                        ofd.Title = Resources.seleccioneCertificado;
                        ofd.Filter = Resources.formatosCertificado;
                        ofd.FilterIndex = 1;
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            txtRutaCertificado.Text = ofd.FileName;
                        }
                    }
                }
                else
                {

                    // MessageBox.Show("La ruta del certificado ya existe..!");
                    // return;
                    if (MessageBox.Show("Estas seguro de querer cargar el certificado..?", "Buscar Certificado", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (var ofd = new OpenFileDialog())
                        {
                            ofd.Title = Resources.seleccioneCertificado;
                            ofd.Filter = Resources.formatosCertificado;
                            ofd.FilterIndex = 1;
                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                txtRutaCertificado.Text = ofd.FileName;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_frmDocumento == null)
                {
                    if (string.IsNullOrEmpty(txtNroRuc.Text))
                        _frmDocumento = new FrmDocumento();
                    else
                    {
                        var documento = new DocumentoElectronico
                        {
                            Emisor = { NroDocumento = txtNroRuc.Text, NombreLegal = "LUNA VERDE SOCIEDAD ANONIMA CERRADA", NombreComercial="",
                            Ubigeo="150131",Direccion="CAL.GERMAN SCHREIBER NRO. 276 LIMA - LIMA - SAN ISIDRO",
                            Departamento="LIMA",Provincia="LIMA",Distrito="SAN ISIDRO",CodDomicilioFiscal = "0000"

                            },
                            FechaEmision = DateTime.Today.ToShortDateString()
                        };
                        _frmDocumento = new FrmDocumento(documento);
                    }
                }
                var rpta = _frmDocumento.ShowDialog(this);

                if (rpta != DialogResult.OK) return;

                txtSource.Text = _frmDocumento.RutaArchivo;
                txtSerieCorrelativo.Text = _frmDocumento.IdDocumento;
                _documento = _frmDocumento._documento2;


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

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ofd = new OpenFileDialog())
                {
                    ofd.Title = Resources.seleccionXml;
                    ofd.Filter = Resources.formatosXml;
                    ofd.FilterIndex = 1;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        txtSource.Text = ofd.FileName;
                        txtSerieCorrelativo.Text = (Path.GetFileName(ofd.FileName)).Substring(15, 13);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            try
            {
                //if (imprimir == -1)
                //{

                //    return;
                //}
                string codigoTipoDoc = "";
                switch (cboTipoDoc.SelectedIndex)
                {
                    case 0:
                        codigoTipoDoc = "01";
                        break;
                    case 1:
                        codigoTipoDoc = "03";
                        break;
                    case 2:
                        codigoTipoDoc = "07";
                        break;
                    case 3:
                        codigoTipoDoc = "08";
                        break;

                    case 4:
                        codigoTipoDoc = "20";
                        break;
                    case 5:
                        codigoTipoDoc = "40";
                        break;
                }
                if (codigoTipoDoc == "")
                {
                    MessageBox.Show("Seleccione Tipo de Documento");
                    return;
                }


                if (codigoTipoDoc == "01")
                {

                    if (_documento.Receptor.TipoDocumento == "6" || _documento.Receptor.TipoDocumento=="0")
                    {

                         FrmFactura2 form = new FrmFactura2("Informes\\TFactura.rdlc", _documento);
                         form._documento = _documento;
                         form.ShowDialog();


                        /*FrmTFactura fac = new FrmTFactura("Informes\\TFactura.rdlc", _documento, usuario);
                        fac._documento = _documento;
                        fac.ShowDialog();
                        imprimir = -1;*/

                    }



                }
                else
                {
                    if (codigoTipoDoc == "03")
                    {
                       FrmBoletas form = new FrmBoletas("Informes\\DTBoletas.rdlc", _documento);
                        form._documento = _documento;
                        form.ShowDialog();


                       /* FrmTTicket ticket = new FrmTTicket("Informes\\TTicket.rdlc", _documento, usuario);
                        ticket._documento = _documento;
                        ticket.ShowDialog();
                        imprimir = -1;*/

                        /*Erwin erwin = new Erwin("Informes\\Prueba.rdlc", _documento);
                        erwin._documento = _documento;
                        erwin.ShowDialog();*/
                    }
                    else
                    {

                        if (codigoTipoDoc == "07")//NC
                        {

                            FrmNC form = new FrmNC("Informes\\DTNC.rdlc", _documento, usuario);
                            form._documento = _documento;
                            form.ShowDialog();
                            imprimir = -1;
                        }
                        else
                        {
                            if (codigoTipoDoc == "08")//ND
                            {

                                FrmND form = new FrmND("Informes\\DTND.rdlc", _documento, usuario);
                                form._documento = _documento;
                                form.ShowDialog();
                                imprimir = -1;
                            }
                            else
                            {
                                if (codigoTipoDoc == "20") //Retención
                                {
                                    FrmRetencion form = new FrmRetencion("Informes\\DTRetencion.rdlc", _documento);
                                    form._documento = _documento;
                                    form.ShowDialog();
                                }
                                else if (codigoTipoDoc == "40")
                                {

                                    FrmPercepcion form = new FrmPercepcion("Informes\\DTPercepcion.rdlc", _documento);
                                    form._documento = _documento;
                                    form.ShowDialog();
                                }
                            }
                        }
                    }

                }

            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private async void kryptonButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                string codigoTipoDoc;
                string ruta_pdf = "";
                string nombre_pdf = "";              
                imprimir = 1;

                switch (cboTipoDoc.SelectedIndex)
                {
                    case 0:
                        codigoTipoDoc = "01";
                        break;
                    case 1:
                        codigoTipoDoc = "03";
                        break;
                    case 2:
                        codigoTipoDoc = "07";
                        break;
                    case 3:
                        codigoTipoDoc = "08";
                        break;
                    case 4:
                        codigoTipoDoc = "20";
                        break;
                    case 5:
                        codigoTipoDoc = "40";
                        break;
                    case 6:
                        codigoTipoDoc = "RC";
                        break;
                    case 7:
                        codigoTipoDoc = "RA";
                        break;
                    default:
                        codigoTipoDoc = "01";
                        break;
                }
                if (cboTipoDoc.SelectedIndex == -1)
                {

                    

                    if (txtSerieCorrelativo.Text == "")
                    {

                        MessageBox.Show("No hay documentos para envío....");
                        throw new InvalidOperationException("No hay documentos para envío....");


                    }
                    else{
                        MessageBox.Show("Seleccione Tipo de documento");
                        throw new InvalidOperationException("Seleccione Tipo de documento");
                    }

                }


                if (_documento.TipoDocumento == null)
                {

                    _documento.TipoDocumento = codigoTipoDoc;
                }
                else
                {

                    if (_documento.TipoDocumento != codigoTipoDoc)
                    {

                        MessageBox.Show("Seleccione Tipo de documento correcto");
                        throw new InvalidOperationException("Seleccione Tipo de documento");
                    }
                }

                if (_documento.Receptor == null)
                {

                    if (_documento.Receptor.NroDocumento.Length == 0)
                    {
                        MessageBox.Show("Datos del cliente no ingresados");
                        throw new InvalidOperationException("Datos del cliente no ingresados");
                    }

                }


                if (string.IsNullOrEmpty(txtSerieCorrelativo.Text))
                    throw new InvalidOperationException("La Serie y el Correlativo no pueden estar vacíos");


                if (config != null)
                {

                    if (config.Estadoenvio == 1)
                    {
                        var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(txtSource.Text));

                        var firmadoRequest = new FirmadoRequest
                        {
                            TramaXmlSinFirma = tramaXmlSinFirma,
                            CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                            PasswordCertificado = txtPassCertificado.Text,
                            UnSoloNodoExtension = rbRetenciones.Checked || rbResumen.Checked

                        };


                    

                        ICertificador certificador = new Certificador();
                        var respuestaFirmado = await new Firmar(certificador).Post(firmadoRequest);

                        if (!respuestaFirmado.Exito)
                            throw new ApplicationException(respuestaFirmado.MensajeError);

                        resumenfirmadig = respuestaFirmado.ResumenFirma;
                        firmadig = respuestaFirmado.ValorFirma;


                        var enviarDocumentoRequest = new EnviarDocumentoRequest
                        {
                            Ruc = txtNroRuc.Text,
                            UsuarioSol = txtUsuarioSol.Text,
                            ClaveSol = txtClaveSol.Text,
                            EndPointUrl = ValorSeleccionado(),
                            //https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService //RETENCION
                            IdDocumento = txtSerieCorrelativo.Text,
                            TipoDocumento = codigoTipoDoc,
                            TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                        };



                        // RespuestaComun respuestaEnvio;
                        //var respuestaEnvio = new EnviarDocumentoResponse();

                        ISerializador serializador = new Serializador();
                        IServicioSunatDocumentos servicioSunatDocumentos = new ServicioSunatDocumentos();

                        RespuestaComunConArchivo respuestaEnvio;


                        var apiMetodo = rbResumen.Checked ? "EnviarResumen" : "EnviarDocumento";

                        if (!rbResumen.Checked)
                        {

                            respuestaEnvio = await new EnviarDocumento(serializador, servicioSunatDocumentos).Post(enviarDocumentoRequest);                          
                        
                            var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                            txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{rpta.MensajeRespuesta} siendo las {DateTime.Now}";
                            try
                            {
                                if (rpta.MensajeRespuesta.IndexOf("Error") != -1)
                                {
                                    MessageBox.Show("Ocurrió un error al enviar documento \n intente nuevamente.");
                                    return;
                                }


                                //ACTUALIZA CORRELATIVO SI EL DOCUMENTO FUE ACEPTADO
                                if (_documento.Items != null && _documento.Receptor.NroDocumento != "")
                                {
                                    clsNumeracion busnum = new clsNumeracion();
                                    busnum = AdmNumeracion.BuscaNumeracion(_documento.TipoDocumento);
                                    Numeracion.TipoDocumento = Convert.ToString(_documento.TipoDocumento);
                                    //Numeracion.Numeracion = busnum.Numeracion + 1;
                                    if (!AdmNumeracion.ActualizaNumeracion(busnum))
                                    {
                                        MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                                    }
                                }


                                //if (_documento.TipoDocumento == "20")
                                if (codigoTipoDoc == "20")
                                {
                                    if (_documento.Items != null && _documento.DocumentoRetencion.IdDocumento != "")
                                    {
                                        clsNumeracion busnum = new clsNumeracion();
                                        busnum = AdmNumeracion.BuscaNumeracion(codigoTipoDoc);
                                        Numeracion.TipoDocumento = Convert.ToString(codigoTipoDoc);
                                        //Numeracion.Numeracion = busnum.Numeracion + 1;
                                        if (!AdmNumeracion.ActualizaNumeracion(busnum))
                                        {
                                            MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                                        }
                                    }
                                }

                                if (codigoTipoDoc == "40")
                                {
                                    if (_documento.DocumentoPercepcion.IdDocumento != "")
                                    {
                                        clsNumeracion busnum = new clsNumeracion();
                                        busnum = AdmNumeracion.BuscaNumeracion(codigoTipoDoc);
                                        Numeracion.TipoDocumento = Convert.ToString(codigoTipoDoc);
                                        //Numeracion.Numeracion = busnum.Numeracion + 1;
                                        if (!AdmNumeracion.ActualizaNumeracion(busnum))
                                        {
                                            MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                                        }
                                    }
                                }

                                if (rpta != null)
                                {
                                    if (rpta.Exito)
                                    {

                                        File.WriteAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml",
                                            Convert.FromBase64String(respuestaFirmado.TramaXmlFirmado));

                                        if (!string.IsNullOrEmpty(rpta.TramaZipCdr))
                                        {
                                            File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip",
                                                Convert.FromBase64String(rpta.TramaZipCdr));
                                        }

                                        _documento.FirmaDigital = respuestaFirmado.ValorFirma;
                                        _documento.ResumenFirma = respuestaFirmado.ResumenFirma;

                                        kryptonButton2.PerformClick();
                                        repositorio = new clsRepositorio();

                                        if (!string.IsNullOrEmpty(rpta.TramaZipCdr))
                                        {
                                            archivo = new clsArchivo()
                                            {

                                                Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml"),
                                                Zip = File.ReadAllBytes($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip")

                                            };
                                        }
                                        else
                                        {

                                            archivo = new clsArchivo()
                                            {

                                                Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml")

                                            };
                                        }

                                        nombre_pdf = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";

                                        switch (codigoTipoDoc)
                                        {

                                            case "01":

                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"FACTURAS_PDF\"
                                                    + _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                            case "03":
                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"BOLETAS_PDF\" +
                                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                            case "07":

                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"NOTA_CREDITO_PDF\" +
                                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;


                                            case "08":
                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"NOTA_DEBITO_PDF\" + _documento.Emisor.NroDocumento + " - " + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                   + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                        }


                                        repositorio.Archivo = archivo;
                                        repositorio.Tipodocumento = codigoTipoDoc;
                                        repositorio.Serie = _documento.IdDocumento.Substring(0, _documento.IdDocumento.IndexOf("-"));
                                        repositorio.Correlativo = (_documento.IdDocumento.Substring((_documento.IdDocumento.IndexOf("-") + 1), (_documento.IdDocumento.Length - (_documento.IdDocumento.IndexOf("-") + 1))));
                                        repositorio.Comprobante = _documento.IdDocumento;
                                        repositorio.Fechaemision = DateTime.Parse(_documento.FechaEmision);
                                        repositorio.Monto = _documento.TotalVenta;
                                        repositorio.Cliente = new clsCliente() { Nombreyapellido = _documento.Receptor.NombreLegal, Documento=_documento.Receptor.NroDocumento };

                                        if (rpta.CodigoRespuesta != null)
                                        {
                                            repositorio.Estadosunat = Convert.ToInt32(rpta.CodigoRespuesta);
                                        }
                                        else
                                        {

                                            repositorio.Estadosunat = -1;
                                        }

                                        repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                        repositorio.Nombredocxml = _documento.IdDocumento + ".xml";
                                        repositorio.Rutaxml = txtSource.Text;
                                        repositorio.Nombredocpdf = nombre_pdf;
                                        repositorio.Rutapdf = ruta_pdf;
                                        repositorio.Pcorigen = SystemInformation.UserDomainName;
                                        repositorio.Usuariopc = usuario.Idusuario.ToString();

                                        repositorio = admrepo.listar_repositorio_xtscfm(repositorio);

                                        if (repositorio.Repositorioid == 0)
                                        {
                                            int idrepo = admrepo.registrar_repositorio(repositorio);

                                            if (idrepo > 0)
                                            {
                                                bool bandera = false;
                                                foreach (var item in _documento.Items)
                                                {
                                                   bandera= detcomprobante.insertdetalle(idrepo, item);
                                                }

                                                if (bandera == false)
                                                {
                                                    MessageBox.Show("Error al insertar detalle", "Error");
                                                }

                                                MessageBox.Show("Documento se envió a repositorio...", "Información");
                                            }
                                            else
                                            {

                                                MessageBox.Show("Problemas para registro de documento en repositorio...", "Advertencia");
                                            }

                                        }
                                        else
                                        {

                                            if (admrepo.actualizar_repositorio(repositorio) > 0)
                                            {
                                                MessageBox.Show("Se actualizó el estado del documento en el repositorio...", "Información");
                                            }
                                            else
                                            {

                                                MessageBox.Show("Problemas para actualizar información...", "Información");
                                            }

                                        }

                                    }
                                    else
                                    {
                                        kryptonButton2.PerformClick();

                                        archivo = new clsArchivo()
                                        {

                                            Xml = File.ReadAllBytes(txtSource.Text)

                                        };

                                        repositorio = new clsRepositorio();
                                        nombre_pdf = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";

                                        switch (codigoTipoDoc)
                                        {

                                            case "01":

                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"FACTURAS_PDF\"
                                                    + _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                            case "03":
                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"BOLETAS_PDF\" +
                                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                            case "07":

                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"NOTA_CREDITO_PDF\" +
                                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                    + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;


                                            case "08":
                                                ruta_pdf = Application.StartupPath.ToString() + @"\" + @"NOTA_DEBITO_PDF\" + _documento.Emisor.NroDocumento + " - " + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                                   + ".pdf";
                                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                                break;

                                        }

                                        repositorio.Archivo = archivo;
                                        repositorio.Tipodocumento = codigoTipoDoc;
                                        repositorio.Serie = _documento.IdDocumento.Substring(0, _documento.IdDocumento.IndexOf("-"));
                                        repositorio.Correlativo = (_documento.IdDocumento.Substring((_documento.IdDocumento.IndexOf("-") + 1), (_documento.IdDocumento.Length - (_documento.IdDocumento.IndexOf("-") + 1))));
                                        repositorio.Comprobante = _documento.IdDocumento;
                                        repositorio.Fechaemision = DateTime.Parse(_documento.FechaEmision);
                                        repositorio.Monto = _documento.TotalVenta;
                                        repositorio.Cliente = new clsCliente() { Nombreyapellido = _documento.Receptor.NombreLegal };

                                        if (rpta.CodigoRespuesta != null)
                                        {
                                            repositorio.Estadosunat = Convert.ToInt32(rpta.CodigoRespuesta);
                                        }
                                        else
                                        {
                                            if (rpta.MensajeRespuesta.IndexOf("1033") > 0)
                                            {
                                                repositorio.Estadosunat = 0;
                                            }
                                            else
                                            {
                                                repositorio.Estadosunat = -1;
                                            }

                                        }

                                        repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                        repositorio.Nombredocxml = _documento.IdDocumento + ".xml";
                                        repositorio.Rutaxml = txtSource.Text;
                                        repositorio.Nombredocpdf = nombre_pdf;
                                        repositorio.Rutapdf = ruta_pdf;
                                        repositorio.Pcorigen = SystemInformation.UserDomainName;
                                        repositorio.Usuariopc = usuario.Idusuario.ToString();

                                        repositorio = admrepo.listar_repositorio_xtscfm(repositorio);

                                        if (repositorio.Repositorioid == 0)
                                        {
                                            int idrepo = admrepo.registrar_repositorio(repositorio);
                                            if ( idrepo> 0)
                                            {
                                                
                                                bool bandera = false;
                                                foreach (var item in _documento.Items)
                                                {
                                                    bandera = detcomprobante.insertdetalle(idrepo, item);
                                                }

                                                if (bandera == false)
                                                {
                                                    MessageBox.Show("Error al insertar detalle", "Error");
                                                }

                                                MessageBox.Show("Documento se envió a repositorio...", "Información");
                                            }
                                            else
                                            {

                                                MessageBox.Show("Problemas para registro de documento en repositorio...", "Advertencia");
                                            }

                                        }
                                        else
                                        {

                                            MessageBox.Show("Documento registrado en repositorio realice el envio desde alli...", "Información");
                                        }
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (apiMetodo == "EnviarResumen")
                            {
                                respuestaEnvio = await new EnviarResumen(serializador, servicioSunatDocumentos).Post(enviarDocumentoRequest);

                                var rpta = (EnviarResumenResponse)respuestaEnvio;

                                txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{rpta.NroTicket}";
                                if (rpta.Exito)
                                {
                                    if (codigoTipoDoc == "RA")
                                    {
                                        clsNumeracion busnum = new clsNumeracion();
                                        busnum = AdmNumeracion.BuscaNumeracion(codigoTipoDoc);
                                        Numeracion.TipoDocumento = Convert.ToString(codigoTipoDoc);
                                        //Numeracion.Numeracion = busnum.Numeracion + 1;
                                        if (!AdmNumeracion.ActualizaNumeracion(busnum))
                                        {
                                            MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                                        }
                                    }
                                }
                            }
                        }

                       // if (!respuestaEnvio.Exito)
                        //    throw new ApplicationException(respuestaEnvio.MensajeError);

                    }
                    else
                    {


                        var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(txtSource.Text));

                        var firmadoRequest = new FirmadoRequest
                        {
                            TramaXmlSinFirma = tramaXmlSinFirma,
                            CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(txtRutaCertificado.Text)),
                            PasswordCertificado = txtPassCertificado.Text,
                            UnSoloNodoExtension = rbRetenciones.Checked || rbResumen.Checked

                        };


                       

                        ICertificador certificador = new Certificador();
                        var respuestaFirmado = await new Firmar(certificador).Post(firmadoRequest);

                        if (!respuestaFirmado.Exito)
                            throw new ApplicationException(respuestaFirmado.MensajeError);




                   
                        if (!respuestaFirmado.Exito)
                            throw new ApplicationException(respuestaFirmado.MensajeError);

                        _documento.FirmaDigital = respuestaFirmado.ValorFirma;
                        _documento.ResumenFirma = respuestaFirmado.ResumenFirma;

                        kryptonButton2.PerformClick();

                        archivo = new clsArchivo()
                        {

                            Xml = File.ReadAllBytes(txtSource.Text)

                        };

                        repositorio = new clsRepositorio();
                        nombre_pdf = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                    + ".pdf";

                        switch (codigoTipoDoc)
                        {

                            case "01":

                                ruta_pdf = Application.StartupPath.ToString() + @"\FACTURAS_PDF\"
                                    + _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                    + ".pdf";
                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                break;

                            case "03":
                                ruta_pdf = Application.StartupPath.ToString() + @"\BOLETAS_PDF\" +
                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                + ".pdf";
                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                break;

                            case "07":

                                ruta_pdf = Application.StartupPath.ToString() + @"\NOTA_CREDITO_PDF\" +
                                    _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                    + ".pdf";
                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                break;


                            case "08":
                                ruta_pdf = Application.StartupPath.ToString() + @"\NOTA_DEBITO_PDF\" + _documento.Emisor.NroDocumento + " - " + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento
                                   + ".pdf";
                                archivo.Pdf = File.ReadAllBytes(ruta_pdf);
                                break;

                        }
                        repositorio.Archivo = archivo;
                        repositorio.Tipodocumento = codigoTipoDoc;
                        repositorio.Serie = _documento.IdDocumento.Substring(0, _documento.IdDocumento.IndexOf("-"));
                        repositorio.Correlativo = (_documento.IdDocumento.Substring((_documento.IdDocumento.IndexOf("-") + 1), (_documento.IdDocumento.Length - (_documento.IdDocumento.IndexOf("-") + 1))));
                        repositorio.Comprobante = _documento.IdDocumento;
                        repositorio.Fechaemision = DateTime.Parse(_documento.FechaEmision);
                        repositorio.Monto = _documento.TotalVenta;
                        repositorio.Cliente = new clsCliente() { Nombreyapellido = _documento.Receptor.NombreLegal,Documento=_documento.Receptor.NroDocumento };
                        repositorio.Estadosunat = -1;

                        repositorio.Mensajesunat = "Documento no enviado";
                        repositorio.Nombredocxml = _documento.IdDocumento + ".xml";
                        repositorio.Rutaxml = txtSource.Text;
                        repositorio.Nombredocpdf = nombre_pdf;
                        repositorio.Rutapdf = ruta_pdf;
                        repositorio.Pcorigen = SystemInformation.UserDomainName;
                        repositorio.Usuariopc = usuario.Idusuario.ToString();

                        repositorio = admrepo.listar_repositorio_xtscfm(repositorio);

                        if (repositorio.Repositorioid == 0)
                        {
                            int idrepo = admrepo.registrar_repositorio(repositorio);
                            if ( idrepo> 0)
                            {
                                bool bandera = false;
                                foreach (var item in _documento.Items)
                                {
                                    bandera = detcomprobante.insertdetalle(idrepo, item);
                                }

                                if (bandera == false)
                                {
                                    MessageBox.Show("Error al insertar detalle", "Error");
                                }


                                clsNumeracion busnum = new clsNumeracion();
                                busnum = AdmNumeracion.BuscaNumeracion(_documento.TipoDocumento);
                                Numeracion.TipoDocumento = Convert.ToString(_documento.TipoDocumento);
                                //Numeracion.Numeracion = busnum.Numeracion + 1;
                                if (!AdmNumeracion.ActualizaNumeracion(busnum))
                                {
                                    MessageBox.Show("Ocurrió un Error al Actualizar la Numeración");
                                }

                                MessageBox.Show("Documento se envió a repositorio...", "Información");
                            }
                            else
                            {

                                MessageBox.Show("Problemas para registro de documento en repositorio...", "Advertencia");
                            }

                        }
                        else
                        {

                            MessageBox.Show("Documento registrado en repositorio realice el envio desde alli...", "Información");
                        }

                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                txtResult.Text = "No hay documentos para envío.....";
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void btnGetStatus_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                using (var frm = new FrmTicket())
                {
                    if (frm.ShowDialog() != DialogResult.OK) return;
                    if (string.IsNullOrEmpty(frm.txtNroTicket.Text)) return;

                    var consultaTicketRequest = new ConsultaTicketRequest
                    {
                        Ruc = txtNroRuc.Text,
                        UsuarioSol = txtUsuarioSol.Text,
                        ClaveSol = txtClaveSol.Text,
                        EndPointUrl = ValorSeleccionado(),
                        IdDocumento = txtSerieCorrelativo.Text,
                        NroTicket = frm.txtNroTicket.Text
                    };

                    ISerializador serializador = new Serializador();
                    IServicioSunatDocumentos servicioSunatDocumentos = new ServicioSunatDocumentos();
                    EnviarDocumentoResponse respuestaEnvio = await new ConsultarTicket(servicioSunatDocumentos, serializador).Post(consultaTicketRequest);

                    if (!respuestaEnvio.Exito || !string.IsNullOrEmpty(respuestaEnvio.MensajeError))
                        throw new InvalidOperationException(respuestaEnvio.MensajeError);

                    File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{respuestaEnvio.NombreArchivo}.zip",
                        Convert.FromBase64String(respuestaEnvio.TramaZipCdr));

                    txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{respuestaEnvio.MensajeRespuesta}";

                   
                }
            }
            catch (Exception ex)
            {
                txtResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void kryptonWrapLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btnTC_Click(object sender, EventArgs e)
        {
            frmTipoCambio frm = new frmTipoCambio();
            frm.ShowDialog(this);
        }

        private void switch_envio_ValueChanged(object sender, EventArgs e)
        {
            actualizar_configuracionenvio();
        }


        /******************************************MIS METODOS**********************************/
        public void listar_configuracionenvio()
        {

            int id = -1;
            config = cconfig.listar_configuracionenvio();

            if (config == null)
            {

                config = new clsConfiguracionEnvio()
                {
                    Estadoenvio = 0,
                    Pcorigen = SystemInformation.UserDomainName,
                    Usuariopc = SystemInformation.UserName
                };

                id = cconfig.registrar_configuracionenvio(config);

                if (id > 0)
                {

                    config.Configuracionid = id;
                    switch_envio.Value = false;
                }
                else
                {

                    MessageBox.Show("Problemas para registrar configuración...", "Advertencia");
                }
            }
            else
            {

                if (config.Estadoenvio == 0)
                {
                    switch_envio.Value = false;
                }
                else
                {

                    switch_envio.Value = true;

                }
            }
        }

        public void actualizar_configuracionenvio()
        {

            if (config != null)
            {
                if (switch_envio.Value)
                {
                    config.Estadoenvio = 1;
                    config.Pcorigen = SystemInformation.UserDomainName;
                    config.Usuariopc = usuario.Idusuario.ToString();
                }
                else
                {
                    config.Estadoenvio = 0;
                    config.Pcorigen = SystemInformation.UserDomainName;
                    config.Usuariopc = usuario.Idusuario.ToString();
                }

                if (cconfig.actualizar_configuracionenvio(config) < 0)
                {
                    MessageBox.Show("Problemas para cambiar configuración..");
                }

            }
        }

        private void btn_repositorio_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmRepositorio"] != null)
            {
                Application.OpenForms["FrmRepositorio"].Activate();
            }
            else
            {
                empresa = new clsEmpresa();
                empresa.Ruc = txtNroRuc.Text;
                empresa.Usuariosol = txtUsuarioSol.Text;
                empresa.Clavesol = txtClaveSol.Text;
                empresa.Rutacertificado = txtRutaCertificado.Text;
                empresa.Clavecertificado = txtPassCertificado.Text;
                empresa.Urlenvio = ValorSeleccionado();
                FrmRepositorio frm_repo = new FrmRepositorio();
                frm_repo.empresa = empresa;
                frm_repo.ShowDialog();
            }
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
        }
    }
}
