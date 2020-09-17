using System;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;
using WinApp.API;
using WinApp.Comun.Dto.Intercambio;
using WinApp.Comun.Dto.Modelos;
using WinApp.Firmado;
using WinApp.Properties;
using WinApp.Servicio;
using WinApp.Servicio.Soap;
using WinApp.Comun;
using System.Collections.Generic;

namespace WinApp
{
    public partial class FrmFormatos : PlantillaBase
    {
        #region Variables Privadas
        private readonly DocumentoElectronico _documento;
        #endregion

        #region Propiedades
        public string RutaArchivo { get; set; }
        public string IdDocumento { get; set; }
        
        #endregion

        #region Constructores
        public FrmFormatos()
        {
            InitializeComponent();
            _documento = new DocumentoElectronico();
        }

        public FrmFormatos(DocumentoElectronico documento)
        {
            InitializeComponent();
            _documento = new DocumentoElectronico();
        }
        #endregion

        #region Metodos de llendo de datos

        private void DatosBoleta()
        {
            var dtsEmisor = new Contribuyente()
            {
                NroDocumento = "20556442259",
                TipoDocumento = "6",
                Direccion = "CAL.GERMAN SCHREIBER NRO. 276 LIMA - LIMA - SAN ISIDRO",
                Departamento = "PIURA",
                Provincia = "PIURA",
                Distrito = "PIURA",
                NombreLegal = "LUNA VERDE SOCIEDAD ANONIMA CERRADA",
                NombreComercial = "",
                Ubigeo = "150131",
                CodDomicilioFiscal = "0000" //Código de cuatro dígitos asignado por SUNAT

            };

            var dtsReceptor = new Contribuyente()
            {
                NroDocumento = "47961796",
                TipoDocumento = "1",
                NombreLegal = "ERWIN STALIN TORRES LEON",
                NombreComercial = "",
                Direccion = "PIURA - PIURA"
            };
            _documento.CalculoIgv = 0.18m;
            var dtsItems = new DetalleDocumento
            {
                Id = 1,
                Cantidad = 1,
                UnidadMedida = "NIU",
                CodigoItem = "COD001",
                Descripcion = "PRODUCTO PRUEBA",
                PrecioUnitario =1.50m,
                PrecioReferencial =20m,
                TipoPrecio = "01",
                TipoImpuesto = "10",
                OtroImpuesto  = 0,
                Descuento = 0,
                Suma = 1.50m * 1m, //_detalle.PrecioUnitario * _detalle.Cantidad
                Impuesto = (1.50m * 1m) * _documento.CalculoIgv, //_detalle.Suma * _documento.CalculoIgv
                ImpuestoSelectivo = 0, //_detalle.Suma * _documento.CalculoIsc;
                TotalVenta = (1.5m * 1m) - 0 //_detalle.Suma - _detalle.Descuento
            };

            _documento.IdDocumento = "B005-00000006";
            _documento.TipoDocumento = "03";
            _documento.Emisor = dtsEmisor;
            _documento.Receptor = dtsReceptor;
            _documento.FechaEmision = DateTime.Today.ToShortDateString();
            _documento.IssueTime = String.Format("{0:HH:mm:ss}", DateTime.Now);
            _documento.Moneda = "PEN";
            _documento.TipoOperacion = "0101";
            //Agregamos Detalle
            _documento.Items.Add(dtsItems);
            CalcularTotales();
        }
       
        private void DatosFactura()
        {
            var dtsEmisor = new Contribuyente()
            {
                NroDocumento = "20556442259",
                TipoDocumento = "6",
                Direccion = "CAL.GERMAN SCHREIBER NRO. 276 LIMA - LIMA - SAN ISIDRO",
                Departamento = "PIURA",
                Provincia = "PIURA",
                Distrito = "PIURA",
                NombreLegal = "LUNA VERDE SOCIEDAD ANONIMA CERRADA",
                NombreComercial = "",
                Ubigeo = "150131",
                CodDomicilioFiscal = "0000" //Código de cuatro dígitos asignado por SUNAT

            };

            var dtsReceptor = new Contribuyente()
            {
                NroDocumento = "10479617967",
                TipoDocumento = "6",
                NombreLegal = "TORRES LEON ERWIN STALIN",
                NombreComercial = "",
                Direccion = "PIURA - PIURA - PIURA"
            };

            
            _documento.Items.Clear();

            _documento.TipoOperacion = "0101"; //0101 - Venta interna - 1001 Venta interna sujeta a detracción

            for (var i = 1; i < 2 ; i++)
            {
                _documento.CalculoIgv = 0.18m;
                var dtsItems = new DetalleDocumento
                {
                    Id = i,
                    Cantidad = 1m,
                    UnidadMedida = "NIU",
                    CodigoItem = "COD001" + i,
                    //ItemClassificationCode = "82141601",// Este código será obligatorio para el 1-1-2019 - catálogo N° 15 del Anexo N° 8 - OBLIGATOIO PARA EXPORTACIONES DESDE NOVIEMBRE
                    Descripcion = "PRODUCTO PRUEBA",
                    PrecioUnitario = 84.7457627119m, //Consignar 0.00 siempre y cuando la factura sea gratuita - TipoImpuesto=21
                    PrecioReferencial = 100m,
                    TipoPrecio = "01", //Se usa 02 cuando el tipo de impuesto es gratuito - Valor referencial unitario en operaciones no onerosas
                    TipoImpuesto = "10",
                    OtroImpuesto = 0,
                    Descuento = 0,
                    Suma = 84.7457627119m * 1m, //_detalle.PrecioUnitario * _detalle.Cantidad
                    Impuesto = (84.7457627119m * 1m) * _documento.CalculoIgv, //_detalle.Suma * _documento.CalculoIgv
                    ImpuestoSelectivo = 0, //_detalle.Suma * _documento.CalculoIsc;
                    TotalVenta = (84.7457627119m * 1m) - 0, //_detalle.Suma - _detalle.Descuento
                   //CodDetraccion="022", //catalogo54
                    //PorcentajeDetraccion ="20",
                    //MontoDetraccion=0.00m
                    
                };
               

                //Agregamos Detalle
                _documento.Items.Add(dtsItems);
            }

            _documento.Cargos =2.00m; //Usar solo si la factura tendrá cargos adicionas - flete
            _documento.IdDocumento = "F005-00000006";
            _documento.TipoDocumento = "01";
            _documento.Emisor = dtsEmisor;
            _documento.Receptor = dtsReceptor;
            _documento.FechaEmision = DateTime.Today.ToShortDateString();
            _documento.IssueTime = String.Format("{0:HH:mm:ss}", DateTime.Now) ;
            _documento.Moneda = "PEN";            
            _documento.Glosa = "Aquí algun información para SUNAT";
            _documento.Imcoterm = _documento.TipoOperacion == "0200" ? "FOB" : ""; //Si TipoOperacion es exportacion se agrega tipo de IMCOTERMS
            _documento.OrderReference = "";
            if (_documento.TipoOperacion == "0200") {
                var dato=_documento.Items.Where(x=> x.ItemClassificationCode==null).Any();
                if (dato)
                {
                    MessageBox.Show("El tipo de operación es EXPORTACION, por favor agregar un código de producto según SUNAT");
                    return;
                }
            }

            
            _documento.DescuentoGlobal = 0.85m; //Descuento aplica de acuerdo al porcentaje

            /*DETRACCION*/
            _documento.MediosPago.PaymentMeansCode = "001";//Medio de pago según catálago 59
            _documento.MediosPago.ID = "123456789";//Numero de cuenta de banco
         
            CalcularTotales();
        }

        private void DatosNCredito()
        {

            var dtsEmisor = new Contribuyente()
            {
                NroDocumento = "20561278441",
                TipoDocumento = "6",
                Direccion = "AV. TACNA NRO. 516 LAMBAYEQUE - FERREÑAFE - FERREÑAFE",
                Departamento = "LAMBAYEQUE",
                Provincia = "FERREÑAFE",
                Distrito = "FERREÑAFE",
                NombreLegal = "INVERSIONES NANDO´S CHICKEN SAC",
                NombreComercial = "",
                Ubigeo = "140201",
                CodDomicilioFiscal = "0000" //Código de cuatro dígitos asignado por SUNAT
            };

            var dtsReceptor = new Contribuyente()
            {
                NroDocumento = "-",
                TipoDocumento = "0",
                NombreLegal = "TORRES LEON ERWIN STALIN",
                NombreComercial = "",
                Direccion = "PIURA - PIURA - PIURA"
            };

            _documento.Items.Clear();
            for (var i = 1; i < 3; i++)
            {
                _documento.CalculoIgv = 0.00m;
                var dtsItems = new DetalleDocumento
                {
                    Id = i,
                    Cantidad =1m,
                    UnidadMedida = "NIU",
                    CodigoItem = "COD001" + i,
                    //ItemClassificationCode = "82141601",// Este código será obligatorio para el 1-1-2019 - catálogo N° 15 del Anexo N° 8 - OBLIGATOIO PARA EXPORTACIONES DESDE NOVIEMBRE
                    Descripcion = "PRODUCTO PRUEBA",
                    PrecioUnitario = 42.3728m, //Consignar 0.00 siempre y cuando la factura sea gratuita - TipoImpuesto=21
                    PrecioReferencial = 50m,
                    TipoPrecio = "01", //Se usa 02 cuando el tipo de impuesto es gratuito - Valor referencial unitario en operaciones no onerosas
                    TipoImpuesto = "40",
                    OtroImpuesto = 0,
                    Descuento = 0,
                    Suma = 42.3728m * 1m, //_detalle.PrecioUnitario * _detalle.Cantidad
                    Impuesto = (42.3728m * 1m) * _documento.CalculoIgv, //_detalle.Suma * _documento.CalculoIgv
                    ImpuestoSelectivo = 0, //_detalle.Suma * _documento.CalculoIsc;
                    TotalVenta = (42.3728m * 1m) - 0 //_detalle.Suma - _detalle.Descuento
                };
                //Agregamos Detalle
                _documento.Items.Add(dtsItems);
            }

            _documento.Cargos = 2.00m;
            _documento.IdDocumento = "FC05-00000005";
            _documento.TipoDocumento = "07";
            _documento.Emisor = dtsEmisor;
            _documento.Receptor = dtsReceptor;
            _documento.FechaEmision = DateTime.Today.ToShortDateString();
            _documento.Moneda = "PEN";
            _documento.TipoOperacion = "0200";
            //_documento.Imcoterm = "FCA"; //Esto se usa para la factura de exportacion - ver listado de IMCOTERM

    
            CalcularTotales();

            //Nota de Credito
            _documento.Relacionados.Clear();
           var dtsDocumentoRelacionado = new DocumentoRelacionado
            {
                NroDocumento = "F005-00000005",
                TipoDocumento = "01"
            };
            _documento.Relacionados.Add(dtsDocumentoRelacionado);
            _documento.Discrepancias.Clear();
            var dtsDiscrepancia = new Discrepancia
            {
                NroReferencia = "F005-00000005",
                Tipo = "09",
                Descripcion = "Nota de Credito del usuario admin"
            };
            _documento.Discrepancias.Add(dtsDiscrepancia);
        }

        private void DatosNDebito()
        {
            var dtsEmisor = new Contribuyente()
            {
                NroDocumento = "20525411401",
                TipoDocumento = "6",
                Direccion = "MZA. 228 LOTE. 06 ZONA INDUSTRIAL  PIURA - PIURA - PIURA",
                Departamento = "PIURA",
                Provincia = "PIURA",
                Distrito = "PIURA",
                NombreLegal = "PIURAMAQ S.R.L.",
                NombreComercial = "",
                Ubigeo = "200101"

            };

            var dtsReceptor = new Contribuyente()
            {
                NroDocumento = "10472308616",
                TipoDocumento = "6",
                NombreLegal = "MEJIA MOSCOL JUAN JOSE",
                NombreComercial = "",
                Direccion = "JR. TUMBES NRO. 100 CENTRO PIURA (A 1 CUADRA DE AV. LIBERTAD CON BOLOGNESI)"
            };

            var dtsItems = new DetalleDocumento
            {
                Id = 1,
                Cantidad = 2000,
                UnidadMedida = "NIU",
                CodigoItem = "COD001",
                ItemClassificationCode = "82141601",
                Descripcion = "PRODUCTO PRUEBA",
                PrecioUnitario = 21.92m,
                PrecioReferencial = 25.86m,
                TipoPrecio = "01",
                TipoImpuesto = "10",
                OtroImpuesto = 0,
                Descuento = 0,
                Suma = 2000 * 21.92m, //_detalle.PrecioUnitario * _detalle.Cantidad
                Impuesto = (2000 * 21.92m) * _documento.CalculoIgv, //_detalle.Suma * _documento.CalculoIgv
                ImpuestoSelectivo = 0, //_detalle.Suma * _documento.CalculoIsc;
                TotalVenta = (2000 * 21.92m) - 0 //_detalle.Suma - _detalle.Descuento
            };

            _documento.IdDocumento = "FND1-00000001";
            _documento.TipoDocumento = "08";
            _documento.Emisor = dtsEmisor;
            _documento.Receptor = dtsReceptor;
            _documento.FechaEmision = DateTime.Today.ToShortDateString();
            _documento.Moneda = "PEN";
            _documento.TipoOperacion = "0101";
            //Agregamos Detalle
            _documento.Items.Add(dtsItems);
            CalcularTotales();

            //Nota de Credito
            var dtsDocumentoRelacionado = new DocumentoRelacionado
            {
                NroDocumento = "F001-00000001",
                TipoDocumento = "01"
            };
            _documento.Relacionados.Add(dtsDocumentoRelacionado);

            var dtsDiscrepancia = new Discrepancia
            {
                NroReferencia = "F001-00000001",
                Tipo = "01",
                Descripcion = "Nota de Debito del usuario admin"
            };
            _documento.Discrepancias.Add(dtsDiscrepancia);
        }
        #endregion

        #region Metodos Privados

        private void CalcularTotales()
        {
      
            // Realizamos los cálculos respectivos.
            

            _documento.Gravadas = _documento.DescuentoGlobal > 0  && _documento.Items.Where(y => y.TipoImpuesto.StartsWith("1")).Any() ? ( _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.Suma) - _documento.DescuentoGlobal ) : _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("1"))
                .Sum(d => d.Suma);

            _documento.Exoneradas = _documento.DescuentoGlobal > 0 && _documento.Items.Where(y => y.TipoImpuesto.Contains("20")).Any() ? (_documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma) - _documento.DescuentoGlobal ) : _documento.Items
                .Where(d => d.TipoImpuesto.Contains("20"))
                .Sum(d => d.Suma);

            _documento.Inafectas = _documento.DescuentoGlobal > 0 && _documento.Items.Where(y => y.TipoImpuesto.StartsWith("3") || y.TipoImpuesto.Contains("40")).Any() ? ( _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma) - _documento.DescuentoGlobal ) : _documento.Items
                .Where(d => d.TipoImpuesto.StartsWith("3") || d.TipoImpuesto.Contains("40"))
                .Sum(d => d.Suma);

            _documento.Gratuitas =  _documento.Items
                .Where(d => d.TipoImpuesto.Contains("21"))
                .Sum(d => d.Suma);

            _documento.LineCountNumeric = Convert.ToString(_documento.Items.Count());

            _documento.TotalIgv = _documento.DescuentoGlobal > 0 ? ((_documento.Gravadas) * (_documento.CalculoIgv==0 ? 0.18m : 0.18m))  : _documento.Items.Sum(d => d.Impuesto);
            _documento.TotalIsc = _documento.Items.Sum(d => d.ImpuestoSelectivo);
            _documento.TotalOtrosTributos = _documento.Items.Sum(d => d.OtroImpuesto);

            // Cuando existe ISC se debe recalcular el IGV.
            if (_documento.TotalIsc > 0)
            {
                _documento.TotalIgv = (_documento.Gravadas + _documento.TotalIsc) * _documento.CalculoIgv;
                // Se recalcula nuevamente el Total de Venta.
            }
            

            _documento.TotalVenta = _documento.Gravadas + _documento.Exoneradas + _documento.Inafectas +
                                    _documento.TotalIgv + _documento.TotalIsc + _documento.TotalOtrosTributos + _documento.Cargos;

            _documento.MontoEnLetras = Conversion.Enletras(_documento.TotalVenta); //Monto en letras agregado

        }

        private void Hablar()
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;
            var synth = new SpeechSynthesizer();

            synth.SetOutputToDefaultAudioDevice();
            synth.SpeakAsync(txtResult.Text);
        }
        #endregion

        #region Generadores
        private async void BtnFactura_Click(object sender, System.EventArgs e)
        {
            DatosFactura();

            ISerializador serializador = new Serializador();
            DocumentoResponse response = new DocumentoResponse
            {
                Exito = false
            };
            response = await new GenerarFactura(serializador).Post(_documento);

            if (!response.Exito)
                throw new ApplicationException(response.MensajeError);

            RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{_documento.IdDocumento}.xml");

            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
        }

        private async void BtnBoleta_Click(object sender, EventArgs e)
        {
            DatosBoleta();

            ISerializador serializador = new Serializador();
            DocumentoResponse response = new DocumentoResponse
            {
                Exito = false
            };
            response = await new GenerarFactura(serializador).Post(_documento);

            if (!response.Exito)
                throw new ApplicationException(response.MensajeError);

            RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{_documento.IdDocumento}.xml");

            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
        }

        private async void BtnNotaCredito_Click(object sender, EventArgs e)
        {
            DatosNCredito();
            ISerializador serializador = new Serializador();
            DocumentoResponse response = new DocumentoResponse
            {
                Exito = false
            };
            response = await new GenerarNotaCredito(serializador).Post(_documento);

            if (!response.Exito)
                throw new ApplicationException(response.MensajeError);

            RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{_documento.IdDocumento}.xml");

            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
        }

        private async void BtnNotaDebito_Click(object sender, EventArgs e)
        {
            DatosNDebito();
            ISerializador serializador = new Serializador();
            DocumentoResponse response = new DocumentoResponse
            {
                Exito = false
            };
            response = await new GenerarNotaDedito(serializador).Post(_documento);

            if (!response.Exito)
                throw new ApplicationException(response.MensajeError);

            RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                $"{_documento.IdDocumento}.xml");

            File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(response.TramaXmlSinFirma));
        }
        #endregion

        private async void BtnFirmar_Click(object sender, EventArgs e)
        {
            try
            {
                //_documento.IdDocumento = "F001-00000001"; //Probar

                if (string.IsNullOrEmpty(_documento.IdDocumento))
                throw new InvalidOperationException("La Serie y el Correlativo no pueden estar vacíos");

                var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(RutaArchivo)); //Original
                //var tramaXmlSinFirma = Convert.ToBase64String(File.ReadAllBytes(@"D:\Valle\XML_SF\F001-00000001.xml"));
                
                var firmadoRequest = new FirmadoRequest
                {
                    TramaXmlSinFirma = tramaXmlSinFirma,
                    CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(@"E:\Certificado_Luna_Verde.pfx")), //@"E:\Valle\certificado\CertificadoPFX.pfx"
                    PasswordCertificado = "pXnC3uUsdf7852Rz",
                    UnSoloNodoExtension = false //rbRetenciones.Checked || rbResumen.Checked
                };

                ICertificador certificador = new Certificador();
                var respuestaFirmado = await new Firmar(certificador).Post(firmadoRequest);
                _documento.ResumenFirma = respuestaFirmado.ResumenFirma; //Firma para ser usada en el PDF si es necesario
                _documento.FirmaDigital = respuestaFirmado.ValorFirma; // No olvidar agregar las referencias iTextSharp para generar los PDF y las firmas

                if (!respuestaFirmado.Exito)
                    throw new ApplicationException(respuestaFirmado.MensajeError);


                RutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    $"{_documento.Emisor.NroDocumento+"-"+_documento.IdDocumento}.xml");

                File.WriteAllBytes(RutaArchivo, Convert.FromBase64String(respuestaFirmado.TramaXmlFirmado));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void EnvDocumento_Click(object sender, EventArgs e)
        {
            try
            {
                var fileCF = Convert.ToBase64String(File.ReadAllBytes(RutaArchivo));

                var enviarDocumentoRequest = new EnviarDocumentoRequest
                {
                    Ruc = "20556442259",
                    UsuarioSol = "BIZLINKS", //LC_CONTR
                    ClaveSol = "TESTBIZLINKS", //Gq0aXgrrWG7osEa9
                    EndPointUrl = "https://osetesting.bizlinks.com.pe/ol-ti-itcpe/billService",
                    IdDocumento = _documento.IdDocumento,
                    TipoDocumento = _documento.TipoDocumento,
                    TramaXmlFirmado = fileCF
                };

                ISerializador serializador = new Serializador();
                IServicioSunatDocumentos servicioSunatDocumentos = new ServicioSunatDocumentos();

                RespuestaComunConArchivo respuestaEnvio;
                respuestaEnvio = await new EnviarDocumento(serializador, servicioSunatDocumentos).Post(enviarDocumentoRequest);

                var rpta = (EnviarDocumentoResponse)respuestaEnvio;
                txtResult.Text = $@"{Resources.procesoCorrecto}{Environment.NewLine}{rpta.MensajeRespuesta} siendo {DateTime.Now}";
                try
                {
                    if (rpta.Exito && !string.IsNullOrEmpty(rpta.TramaZipCdr))
                    {
                        File.WriteAllBytes($"{Program.CarpetaXml}\\{_documento.IdDocumento}.xml",
                            Convert.FromBase64String(fileCF));

                        File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{respuestaEnvio.NombreArchivo}.zip",
                            Convert.FromBase64String(rpta.TramaZipCdr));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (!respuestaEnvio.Exito)
                    throw new ApplicationException(respuestaEnvio.MensajeError);
                Hablar();
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

        private void kryptonButton9_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton11_Click(object sender, EventArgs e)
        {

        }

        private async void kryptonButton1_Click(object sender, EventArgs e)
        {
            ISerializador serializador = new Serializador();
            IServicioSunatConsultas servicioSunatDocumentos = new ServicioSunatConsultas();
            RespuestaSincrono respuestaEnvio = new RespuestaSincrono();

            var response = new EnviarDocumentoResponse();

            var request = new DatosDocumento
            {
                TipoComprobante =  "01",
                Serie = "F005",
                Numero = 3,
                RucEmisor = "20561278441"
            };

            servicioSunatDocumentos.Inicializar(new ParametrosConexion
            {
                Ruc = "20561278441",
                UserName = "NANDOS18",
                Password = "NANDOS18",
                EndPointUrl = "https://e-factura.sunat.gob.pe/ol-it-wsconscpegem/billConsultService"
            });

            respuestaEnvio = servicioSunatDocumentos.ConsultarConstanciaDeRecepcion(request);

            if (respuestaEnvio.Exito)
            {
                response = await serializador.GenerarDocumentoRespuesta(respuestaEnvio.ConstanciaDeRecepcion);

                if (response.Exito)
                {

                    MessageBox.Show(response.MensajeRespuesta);

                    File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{request.RucEmisor}-{request.TipoComprobante}-{request.Serie}-{request.Numero}.zip",
                          Convert.FromBase64String(respuestaEnvio.ConstanciaDeRecepcion));
                }
                else {
                    MessageBox.Show(response.MensajeError);
                }

               
            }
            else {
                MessageBox.Show(respuestaEnvio.MensajeError);
            }

            
        }

        private void kryptonButton10_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
