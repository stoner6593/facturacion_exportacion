using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using WinApp.Comun.Dto.Modelos;
namespace FinalXML.Informes
{
    public partial class FrmPercepcion : Form
    {
        public DocumentoElectronico _documento;
        private string rptact;
        private object lst;
        public object empresa;
        public object general;
        public object receptor;
        public object otros;
        public object item;
        public object percepcion;

        public DocumentoElectronico _idcodumento;
        public FrmPercepcion(string nombrereporte, DocumentoElectronico lista)
        {
            try
            {
                InitializeComponent();
                List<Contribuyente> Emisor = new List<Contribuyente>();
                ClsDatosReportes cabecera = new ClsDatosReportes();
                List<ClsDatosReportes> valores = new List<ClsDatosReportes>();
                List<Contribuyente> Receptor = new List<Contribuyente>();
                List<DocumentoPercepcion> Percepcion = new List<DocumentoPercepcion>();


                if (lista.DocumentoPercepcion.Moneda == "PEN")
                {
                    cabecera.MonedaLetra = "SOLES";
                    cabecera.Moneda = "S/";
                }
                else
                {
                    if (lista.DocumentoPercepcion.Moneda == "USD")
                    {
                        cabecera.MonedaLetra = "DOLARES AMERICANOS";
                        cabecera.Moneda = "$";
                    }
                    else
                    {
                        if (lista.DocumentoPercepcion.Moneda == "EUR")
                        {
                            cabecera.MonedaLetra = "EUROS";
                            cabecera.Moneda = "€";
                        }
                    }
                }
                cabecera.IdDocumento = lista.DocumentoPercepcion.IdDocumento;
                cabecera.FechaEmision = lista.DocumentoPercepcion.FechaEmision;
                cabecera.MontoEnLetras = lista.MontoEnLetras;
                valores.Add(cabecera);
                Emisor.Add(lista.DocumentoPercepcion.Emisor);
                Receptor.Add(lista.DocumentoPercepcion.Receptor);
                Percepcion.Add(lista.DocumentoPercepcion);



                this.rptact = nombrereporte;
                this.empresa = Emisor;
                this.general = valores;
                this.receptor = Receptor;
                this.otros = valores;
                this.item = lista.DocumentoPercepcion.DocumentosRelacionados;
                percepcion = Percepcion;
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }

        private void FrmPercepcion_Load(object sender, EventArgs e)
        {
            try
            {

                Herramientas herramientas = new Herramientas();
                var recursos = herramientas.GetResourcesPath2();

                /*FIRMA PDF*/
                var nomdocumento = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.DocumentoPercepcion.IdDocumento;

                String datosAdicionales_CDB = "";
                String CodigoCertificado = "";
                String firmadig = "";
                string[] Serie = _documento.IdDocumento.Split('-');

                datosAdicionales_CDB = _documento.Emisor.NroDocumento + "|" + _documento.TipoDocumento + "|" + Serie[0] + "|" + Serie[1] + "|" + _documento.TotalIgv + "|" + _documento.DocumentoPercepcion.ImporteTotalPercibido + "|"
                                         + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "|" + _documento.DocumentoPercepcion.Receptor.TipoDocumento + "|" + _documento.DocumentoPercepcion.Receptor.NroDocumento + "|" + _documento.ResumenFirma;
                CodigoCertificado = datosAdicionales_CDB; //+ "|" + _documento.FirmaDigital;
                BarcodePDF417 codigobarras = new BarcodePDF417();
                codigobarras.Options = BarcodePDF417.PDF417_USE_ASPECT_RATIO;
                codigobarras.ErrorLevel = 5;
                codigobarras.YHeight = 6f;
                codigobarras.SetText(CodigoCertificado);
                System.Drawing.Bitmap bm = new System.Drawing.Bitmap(codigobarras.CreateDrawingImage(System.Drawing.Color.Black, System.Drawing.Color.White));
                //bm.Save(@"C:\DOCUMENTOS ELECTRONICOS\CERTIFIK\QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                bm.Save(@"QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                List<ReportParameter> parametro = new List<ReportParameter>();
                parametro.Add(new ReportParameter("pLogo", @"file:///" + recursos + "/" + nomdocumento + ".jpeg"));
                this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.EnableExternalImages = true;

                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.DTPercepcion.rdlc";
                reportViewer1.LocalReport.SetParameters(parametro);

                ReportDataSource datos = new ReportDataSource();
                datos.Name = "DetalleDocumento";
                datos.Value = lst;
                ReportDataSource datos2 = new ReportDataSource();
                datos2.Name = "Empresa";
                datos2.Value = empresa;
                ReportDataSource datos3 = new ReportDataSource();
                datos3.Name = "General";
                datos3.Value = general;
                ReportDataSource datos4 = new ReportDataSource();
                datos4.Name = "Receptor";
                datos4.Value = receptor;
                ReportDataSource datos5 = new ReportDataSource();
                datos5.Name = "Otros";
                datos5.Value = otros;
                ReportDataSource datos6 = new ReportDataSource();
                datos6.Name = "Items";
                datos6.Value = item;
                ReportDataSource datos7 = new ReportDataSource();
                datos7.Name = "Percepcion";
                datos7.Value = percepcion;

                /*FIN FIRMA*/
                this.reportViewer1.RefreshReport();
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datos);
                this.reportViewer1.LocalReport.DataSources.Add(datos2);
                this.reportViewer1.LocalReport.DataSources.Add(datos3);
                this.reportViewer1.LocalReport.DataSources.Add(datos4);
                this.reportViewer1.LocalReport.DataSources.Add(datos5);
                this.reportViewer1.LocalReport.DataSources.Add(datos6);
                this.reportViewer1.LocalReport.DataSources.Add(datos7);


                this.reportViewer1.RefreshReport();


                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string filenameExtension;
                //ToString("yyyy-MM-dd")
                byte[] bytes = reportViewer1.LocalReport.Render(
                    "PDF", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

                using (FileStream fs = new FileStream(@"PERCEPCION_PDF\\" + nomdocumento + ".pdf", FileMode.Create))
                {
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
        }
    
    }
}
