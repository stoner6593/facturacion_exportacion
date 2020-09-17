using FinalXML.Administradores;
using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinApp.API;
using WinApp.Comun.Dto.Intercambio;
using WinApp.Comun.Dto.Modelos;
using WinApp.Firmado;
using WinApp.Servicio;
using WinApp.Servicio.Soap;
using WinApp.Comun;


namespace FinalXML
{
    public partial class FrmRepositorio : PlantillaBase
    {
        private List<clsNumeracion> lista_numeracion = null;
        private clsAdmNumeracion admnum = new clsAdmNumeracion();
        private clsAdmRepositorio admrepo = new clsAdmRepositorio();
        private DataTable tabla = null;
        private clsNumeracion numeracion = null;
        private clsRepositorio repositorio = null;
        private clsArchivo archivo = null;
        private Herramientas herramienta = new Herramientas();
        private clsAdmEmpresa admempresa = new clsAdmEmpresa();
        public clsEmpresa empresa { get; set; }

        public FrmRepositorio()
        {
            InitializeComponent();
        }

        private void FrmRepositorio_Load(object sender, EventArgs e)
        {

            dg_repositorio.AutoGenerateColumns = false;
            cb_estado.Items.Add("No Enviado");
            cb_estado.Items.Add("Enviado");
            cb_estado.SelectedIndex = 0;
            dtp_fecha.Value = DateTime.Now;
            if (empresa == null)
            {
                empresa = admempresa.listar_empresa();
            }
            listar_tipo_doc();
        }

        private void cb_tipodoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_serie.Items.Clear();

            if (cb_tipodoc.Items.Count > 0)
            {

                if (lista_numeracion != null)
                {

                    if (lista_numeracion.Count > 0)
                    {

                        cb_serie.Items.Add(lista_numeracion[cb_tipodoc.SelectedIndex].Serie);
                        cb_serie.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            if (cb_tipodoc.Items.Count > 0 && cb_serie.Items.Count > 0 && cb_estado.Items.Count > 0)
            {

                listar_repositorio();

            }
        }

        private void cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void btn_enviar_Click(object sender, EventArgs e)
        {
            if (dg_repositorio.RowCount > 0)
            {
                if (empresa != null)
                {
                    if (cb_estado.SelectedIndex == 0)
                    {
                        enviar_documentos();
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay documentos para envío...", "Información");
            }
        }
        /**************Mis Metodos*****************/

        public void listar_tipo_doc()
        {

            lista_numeracion = admnum.listar_Numeracion();

            if (lista_numeracion != null)
            {

                if (lista_numeracion.Count > 0)
                {

                    foreach (clsNumeracion num in lista_numeracion)
                    {

                        cb_tipodoc.Items.Add(num.NombreDocumento);

                    }

                    cb_tipodoc.SelectedIndex = 0;
                }
            }

        }

        public void listar_repositorio()
        {

            int estado = -1;
            numeracion = null;
            dg_repositorio.DataSource = null;
            estado = cb_estado.SelectedIndex == 0 ? -1 : 0;

            if (lista_numeracion != null)
            {

                if (lista_numeracion.Count > 0)
                {

                    numeracion = lista_numeracion[cb_tipodoc.SelectedIndex];
                    numeracion.Fecha = dtp_fecha.Value;
                    numeracion.Estado = estado;

                    tabla = admrepo.listar_repositorio_xtsfe(numeracion);

                    if (tabla != null)
                    {
                        if (tabla.Rows.Count > 0)
                        {

                            dg_repositorio.DataSource = tabla;
                        }
                        else
                        {

                            MessageBox.Show("No se encontraron Documentos para la fecha...", "Información");

                        }

                    }
                    else
                    {

                        MessageBox.Show("No se encontraron Documentos para la fecha...", "Información");

                    }

                }

            }
        }

        public void limpiar()
        {

            dg_repositorio.DataSource = null;
            tabla = null;
            numeracion = null;
            cb_tipodoc.SelectedIndex = 0;
            dtp_fecha.Value = DateTime.Now;
            cb_estado.SelectedIndex = 0;
        }


        public async void enviar_documentos()
        {
            try
            {



                byte[] archivo_xml = null;
                byte[] archivo_cdr = null;
                int enviados = 0;
                byte[] archivo_pdf = null;


                foreach (DataGridViewRow row in dg_repositorio.Rows)
                {
                    //if (!archivo_existe(row.Cells[rutaxml.Index].Value.ToString()))
                    //{
                    descargar_xml(row.Index, 0);
                    descargar_pdf(row.Index, 0);
                    //}
                    var tramaXmlSinFirma = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutaxml.Index].Value.ToString())) ?
                                                 Convert.ToBase64String(File.ReadAllBytes(row.Cells[rutaxml.Index].Value.ToString())) :
                                                 Convert.ToBase64String(File.ReadAllBytes(herramienta.GetResourcesPath5() + "\\" + dg_repositorio.Rows[row.Index].Cells[nombredocxml.Index].Value.ToString()));
                    var firmadoRequest = new FirmadoRequest
                    {
                        TramaXmlSinFirma = tramaXmlSinFirma,
                        CertificadoDigital = Convert.ToBase64String(File.ReadAllBytes(herramienta.GetResourcesPath() + "\\" + empresa.Rutacertificado)),
                        PasswordCertificado = empresa.Clavecertificado,
                        UnSoloNodoExtension = false
                    };

                    ICertificador certificador = new Certificador();
                    var respuestaFirmado = await new Firmar(certificador).Post(firmadoRequest);


                    if (!respuestaFirmado.Exito)
                        MessageBox.Show(respuestaFirmado.MensajeError);



                    var enviarDocumentoRequest = new EnviarDocumentoRequest
                    {
                        Ruc = empresa.Ruc,
                        UsuarioSol = empresa.Usuariosol,
                        ClaveSol = empresa.Clavesol,
                        EndPointUrl = empresa.Urlenvio,
                        //https://www.sunat.gob.pe/ol-ti-itcpgem-sqa/billService //RETENCION
                        IdDocumento = row.Cells[comprobante.Index].Value.ToString(),
                        TipoDocumento = row.Cells[tipocomprobante.Index].Value.ToString(),
                        TramaXmlFirmado = respuestaFirmado.TramaXmlFirmado
                    };


                    /*===================================*/

                    ISerializador serializador = new Serializador();
                    IServicioSunatDocumentos servicioSunatDocumentos = new ServicioSunatDocumentos();

                    RespuestaComunConArchivo respuestaEnvio;
                    respuestaEnvio = await new EnviarDocumento(serializador, servicioSunatDocumentos).Post(enviarDocumentoRequest);

                    var rpta = (EnviarDocumentoResponse)respuestaEnvio;


                    if (!respuestaEnvio.Exito)
                        MessageBox.Show(respuestaEnvio.MensajeError);

                    /*==============================*/


                    if (rpta != null)
                    {
                        repositorio = new clsRepositorio();
                        repositorio.Repositorioid = Convert.ToInt32(row.Cells[repositorioid.Index].Value.ToString());

                        archivo_xml = Convert.FromBase64String(respuestaFirmado.TramaXmlFirmado);
                        File.WriteAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml", archivo_xml);

                        if (rpta.Exito)
                        {
                            if (rpta.MensajeRespuesta != null)
                            {
                                if (rpta.MensajeRespuesta.IndexOf("1033") > 0)
                                {
                                    repositorio.Estadosunat = 0;
                                    repositorio.Mensajesunat = rpta.MensajeRespuesta;

                                }
                                else
                                {
                                    if (rpta.MensajeRespuesta.IndexOf("ha sido aceptada") > 0)
                                    {
                                        repositorio.Estadosunat = 0;
                                        repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                    }
                                    else
                                    {
                                        repositorio.Estadosunat = -1;
                                        repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                    }
                                }
                            }
                            else
                            {
                                repositorio.Estadosunat = -1;
                                repositorio.Mensajesunat = "No Enviado";
                            }


                            if (!string.IsNullOrEmpty(rpta.TramaZipCdr))
                            {
                                archivo_cdr = Convert.FromBase64String(rpta.TramaZipCdr);
                                File.WriteAllBytes($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip", archivo_cdr);
                            }

                            if (File.Exists($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml") &&
                                                           File.Exists($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip"))
                            {
                                switch (row.Cells[tipocomprobante.Index].Value.ToString())
                                {

                                    case "03":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath6() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "01":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath3() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "07":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath7() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "08":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath8() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;

                                }

                                if (!string.IsNullOrEmpty(rpta.TramaZipCdr))
                                {
                                    archivo = new clsArchivo()
                                    {
                                        Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml"),
                                        Zip = File.ReadAllBytes($"{Program.CarpetaCdr}\\R-{rpta.NombreArchivo}.zip"),
                                        Pdf = archivo_pdf
                                    };

                                    repositorio.Archivo = archivo;
                                    repositorio.Pcorigen = SystemInformation.UserDomainName;
                                    repositorio.Usuariopc = SystemInformation.UserName;
                                    if (admrepo.actualizar_repositorio(repositorio) < 0)
                                    {
                                        MessageBox.Show("Problemas para actualizar información el proceso de detuvo...", "Información");
                                        break;
                                    }

                                }
                                else
                                {

                                    archivo = new clsArchivo()
                                    {
                                        Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml"),
                                        Pdf = archivo_pdf
                                    };

                                    repositorio.Archivo = archivo;
                                    repositorio.Pcorigen = SystemInformation.UserDomainName;
                                    repositorio.Usuariopc = SystemInformation.UserName;
                                    if (admrepo.actualizar_repositorio(repositorio) < 0)
                                    {
                                        MessageBox.Show("Problemas para actualizar información el proceso de detuvo...", "Información");
                                        break;
                                    }
                                }

                            }
                            else
                            {
                                switch (row.Cells[tipocomprobante.Index].Value.ToString())
                                {

                                    case "03":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath6() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "01":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath3() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "07":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath7() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;
                                    case "08":
                                        archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                        File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                        File.ReadAllBytes(herramienta.GetResourcesPath8() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                        break;

                                }

                                archivo = new clsArchivo()
                                {

                                    Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml"),
                                    Pdf = archivo_pdf

                                };

                                repositorio.Archivo = archivo;
                                repositorio.Pcorigen = SystemInformation.UserDomainName;
                                repositorio.Usuariopc = SystemInformation.UserName;
                                if (admrepo.actualizar_repositorio(repositorio) < 0)
                                {
                                    MessageBox.Show("Problemas para actualizar información el proceso de detuvo...", "Información");
                                    break;
                                }
                            }
                        }
                        else
                        {
                            switch (row.Cells[tipocomprobante.Index].Value.ToString())
                            {

                                case "03":
                                    archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                    File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                    File.ReadAllBytes(herramienta.GetResourcesPath6() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                    break;
                                case "01":
                                    archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                    File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                    File.ReadAllBytes(herramienta.GetResourcesPath3() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                    break;
                                case "07":
                                    archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                    File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                    File.ReadAllBytes(herramienta.GetResourcesPath7() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                    break;
                                case "08":
                                    archivo_pdf = (File.Exists(dg_repositorio.Rows[row.Index].Cells[rutapdf.Index].Value.ToString())) ?
                                    File.ReadAllBytes(row.Cells[rutapdf.Index].Value.ToString()) :
                                    File.ReadAllBytes(herramienta.GetResourcesPath8() + "\\" + row.Cells[nombredocpdf.Index].Value.ToString());
                                    break;

                            }

                            archivo = new clsArchivo()
                            {
                                Xml = File.ReadAllBytes($"{Program.CarpetaXml}\\{rpta.NombreArchivo}.xml"),
                                Pdf = archivo_pdf
                            };

                            if (rpta.MensajeRespuesta != null)
                            {
                                if (rpta.MensajeRespuesta.IndexOf("1033") > 0)
                                {
                                    repositorio.Estadosunat = 0;
                                    repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                }
                                else
                                {
                                    enviados++;
                                    repositorio.Estadosunat = -1;
                                    repositorio.Mensajesunat = rpta.MensajeRespuesta;
                                }
                            }
                            else
                            {
                                repositorio.Estadosunat = -1;
                                repositorio.Mensajesunat = "No Enviado";
                                enviados++;
                            }

                            repositorio.Archivo = archivo;
                            repositorio.Pcorigen = SystemInformation.UserDomainName;
                            repositorio.Usuariopc = SystemInformation.UserName;

                            if (admrepo.actualizar_repositorio(repositorio) < 0)
                            {
                                MessageBox.Show("Problemas para actualizar información el proceso de detuvo...", "Información");
                                break;
                            }
                        }
                    }
                    else
                    {

                        enviados++;
                    }

                }

                if (enviados > 0)
                {

                    MessageBox.Show("No todos los documentos se enviaron...", "Información");
                    btn_buscar.PerformClick();
                }
                else
                {

                    MessageBox.Show("Todos los documentos se enviaron...", "Información");
                    btn_buscar.PerformClick();

                }
            }
            catch (Exception a ) { MessageBox.Show(a.Message); }

        }


        private void btn_verxml_Click(object sender, EventArgs e)
        {
            if (dg_repositorio.RowCount > 0)
            {

                if (dg_repositorio.CurrentCell != null)
                {

                    if (dg_repositorio.CurrentCell.RowIndex != -1)
                    {

                        descargar_xml(dg_repositorio.CurrentCell.RowIndex, 1);
                    }

                }
            }
        }

        private void btn_verpdf_Click(object sender, EventArgs e)
        {
            if (dg_repositorio.RowCount > 0)
            {

                if (dg_repositorio.CurrentCell != null)
                {

                    if (dg_repositorio.CurrentCell.RowIndex != -1)
                    {

                        descargar_pdf(dg_repositorio.CurrentCell.RowIndex, 1);
                    }

                }
            }
        }

        public bool archivo_existe(string archivo)
        {

            return (File.Exists(archivo) ? true : false);

        }

        public void descargar_xml(int index, int opcion)
        {

            //opcion 1 apertura, 0 solo descarga

            try
            {
                repositorio = new clsRepositorio()
                {

                    Repositorioid = Convert.ToInt32(dg_repositorio.Rows[index].Cells[0].Value.ToString())
                };

                repositorio = admrepo.listar_archivo_xrepositorio(repositorio);

                if (repositorio != null)
                {
                    if (repositorio.Archivo != null)
                    {

                        if (File.Exists(dg_repositorio.Rows[index].Cells[rutaxml.Index].Value.ToString()))
                        {

                            File.WriteAllBytes(dg_repositorio.Rows[index].Cells[rutaxml.Index].Value.ToString(), repositorio.Archivo.Xml);
                        }
                        else
                        {

                            File.WriteAllBytes(herramienta.GetResourcesPath5() + "\\" + dg_repositorio.Rows[index].Cells[nombredocxml.Index].Value.ToString(), repositorio.Archivo.Xml);

                        }

                        if (opcion == 1)
                        {

                            if (File.Exists(dg_repositorio.Rows[index].Cells[rutaxml.Index].Value.ToString()))
                            {
                                Process.Start(dg_repositorio.Rows[index].Cells[rutaxml.Index].Value.ToString());
                            }
                            else
                            {

                                Process.Start(herramienta.GetResourcesPath5() + "\\" + dg_repositorio.Rows[index].Cells[nombredocxml.Index].Value.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception) { }

        }

        public void descargar_pdf(int index, int opcion)
        {

            //opcion 1 apertura, 0 solo descarga

            try
            {
                if (!archivo_existe(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString()))
                {

                    repositorio = new clsRepositorio()
                    {
                        Repositorioid = Convert.ToInt32(dg_repositorio.Rows[index].Cells[repositorioid.Index].Value.ToString())
                    };

                    repositorio = admrepo.listar_archivo_xrepositorio(repositorio);

                    if (repositorio != null)
                    {
                        if (repositorio.Archivo != null)
                        {
                            if (File.Exists(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString()))
                            {

                                File.WriteAllBytes(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString(), repositorio.Archivo.Pdf);
                            }
                            else
                            {
                                switch (dg_repositorio.Rows[index].Cells[tipocomprobante.Index].Value.ToString())
                                {

                                    case "03":
                                        File.WriteAllBytes(herramienta.GetResourcesPath6() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString(), repositorio.Archivo.Pdf);
                                        break;
                                    case "01":
                                        File.WriteAllBytes(herramienta.GetResourcesPath3() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString(), repositorio.Archivo.Pdf);
                                        break;
                                    case "07":
                                        File.WriteAllBytes(herramienta.GetResourcesPath7() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString(), repositorio.Archivo.Pdf);
                                        break;
                                    case "08":
                                        File.WriteAllBytes(herramienta.GetResourcesPath8() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString(), repositorio.Archivo.Pdf);
                                        break;

                                }


                            }

                            //File.WriteAllBytes(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString(), repositorio.Archivo.Pdf);

                            if (opcion == 1)
                            {
                                if (File.Exists(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString()))
                                {
                                    Process.Start(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString());
                                }
                                else
                                {
                                    switch (dg_repositorio.Rows[index].Cells[tipocomprobante.Index].Value.ToString())
                                    {

                                        case "03":
                                            Process.Start(herramienta.GetResourcesPath6() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString());
                                            break;
                                        case "01":
                                            Process.Start(herramienta.GetResourcesPath3() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString());
                                            break;
                                        case "07":
                                            Process.Start(herramienta.GetResourcesPath7() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString());
                                            break;
                                        case "08":
                                            Process.Start(herramienta.GetResourcesPath8() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString());
                                            break;

                                    }
                                    //Process.Start(herramienta.GetResourcesPath5() + "\\" + dg_repositorio.Rows[index].Cells[nombredocpdf.Index].Value.ToString());
                                }

                                //Process.Start(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString());
                            }
                        }
                    }
                }
                else
                {
                    if (opcion == 1)
                    {
                        Process.Start(dg_repositorio.Rows[index].Cells[rutapdf.Index].Value.ToString());
                    }
                }

            }
            catch (Exception) { }

        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_repositorio.Rows.Count > 0)
                {
                    dg_repositorio.MultiSelect = true;
                    dg_repositorio.SelectAll();
                    dg_repositorio.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    DataObject dataObj = dg_repositorio.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    dg_repositorio.MultiSelect = false;

                    MessageBox.Show("Puede copiarlo a cualquier editor de texto...", "Información");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }
    }
}
