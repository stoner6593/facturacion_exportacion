﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.xml;
using WinApp.Comun.Dto.Modelos;
using QRCoder;


namespace FinalXML.Informes
{
    public partial class FrmBoletas : Form
    {
        public DocumentoElectronico _documento;
        private string rptact;
        private object lst;
        public object empresa;
        public object general;
        public object receptor;
        public object otros;
        public Byte[] LogoEmp { get; set; }
        public DocumentoElectronico _idcodumento;

        public FrmBoletas(string nombrereporte, DocumentoElectronico lista)
        {
            InitializeComponent();
            List<Contribuyente> Emisor = new List<Contribuyente>();
            ClsDatosReportes cabecera = new ClsDatosReportes();
            List<ClsDatosReportes> valores = new List<ClsDatosReportes>();
            List<Contribuyente> Receptor = new List<Contribuyente>();
            if (lista.Moneda == "PEN")
            {
                cabecera.MonedaLetra = "SOLES";
                cabecera.Moneda = "S/";
            }
            else
            {
                if (lista.Moneda == "USD")
                {
                    cabecera.MonedaLetra = "DOLARES AMERICANOS";
                    cabecera.Moneda = "$";
                }
            }
            cabecera.IdDocumento = lista.IdDocumento;
            cabecera.FechaEmision = lista.FechaEmision;
            cabecera.Gravadas = lista.Gravadas;
            cabecera.Inafectas = lista.Inafectas;
            cabecera.Gratuitas = lista.Gratuitas;
            cabecera.Exoneradas = lista.Exoneradas;
            cabecera.TotalIgv = lista.TotalIgv;
            cabecera.TotalVenta = lista.TotalVenta;
            cabecera.SubTotalVentas = lista.SubTotalVenta;
            cabecera.MontoEnLetras = lista.MontoEnLetras;

            cabecera.NumeroCajas = lista.Cajas;
            cabecera.Total2 = lista.Total2;
            cabecera.Glosa = lista.Glosa;
           
            valores.Add(cabecera);
            Emisor.Add(lista.Emisor);
            Receptor.Add(lista.Receptor);

            this.rptact = nombrereporte;
            this.lst = lista.Items;
            this.empresa = Emisor;
            this.general = valores;
            this.receptor = Receptor;
            this.otros = valores;
        }

        private void FrmBoletas_Load(object sender, EventArgs e)
        {
            Herramientas herramientas = new Herramientas();
            var recursos = herramientas.GetResourcesPath2();

            /*FIRMA PDF*/
            var nomdocumento = _documento.Emisor.NroDocumento + "-" + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "-" + _documento.IdDocumento;

            String datosAdicionales_CDB = "";
            String CodigoCertificado = "";
            string[] Serie = _documento.IdDocumento.Split('-');

            datosAdicionales_CDB = _documento.Emisor.NroDocumento + "|" + _documento.TipoDocumento + "|" + Serie[0] + "|" + Serie[1] + "|" + _documento.TotalIgv + "|" + _documento.TotalVenta + "|"
                                 + DateTime.Parse(_documento.FechaEmision).ToString("yyyy-MM-dd") + "|" + _documento.Receptor.TipoDocumento + "|" + _documento.Receptor.NroDocumento + "|" + _documento.ResumenFirma;
            CodigoCertificado = datosAdicionales_CDB + "|" + _documento.FirmaDigital + "|";

          

            QRCodeGenerator codigobarras = new QRCodeGenerator();
            QRCodeData qrcode = codigobarras.CreateQrCode(CodigoCertificado, QRCodeGenerator.ECCLevel.Q);
            QRCode qrco = new QRCode(qrcode);
            System.Drawing.Bitmap bm = qrco.GetGraphic(20);
           
            //bm.Save(@"C:\DOCUMENTOS ELECTRONICOS\CERTIFIK\QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            bm.Save(@"QR\" + nomdocumento + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

            /*FIN FIRMA*/

            List<ReportParameter> parametro = new List<ReportParameter>();
            //parametro.Add(new ReportParameter("pLogo", @"file:///C:/PIURAMAQ.png"));
            parametro.Add(new ReportParameter("pLogo", @"file:///" + recursos + "/" + nomdocumento + ".jpeg"));
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.EnableExternalImages = true;

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.LocalReport.ReportEmbeddedResource = "FinalXML.Informes.DTBoletas.rdlc";
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

            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(datos);
            this.reportViewer1.LocalReport.DataSources.Add(datos2);
            this.reportViewer1.LocalReport.DataSources.Add(datos3);
            this.reportViewer1.LocalReport.DataSources.Add(datos4);
            this.reportViewer1.LocalReport.DataSources.Add(datos5);
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

            using (FileStream fs = new FileStream(@"BOLETAS_PDF\\" + nomdocumento + ".pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
            //this.Close();

        }
    }
}