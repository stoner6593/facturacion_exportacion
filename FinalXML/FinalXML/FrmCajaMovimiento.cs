using FinalXML.Administradores;
using FinalXML.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalXML
{
    public partial class FrmCajaMovimiento : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        private clsAdmCaja admcaja = new clsAdmCaja();
        private clsCaja caja = null;
        private DataTable cajamovimientos = null;
        private DataSet data = null;
        public int _Cajaid { get; set; }
        public int Estado { get; set; }
        public FrmCajaMovimiento()
        {
            InitializeComponent();
        }

        private void FrmCajaMovimiento_Load(object sender, EventArgs e)
        {
            int idcaja = -1;

            try
            {            
                dg_resultado.AutoGenerateColumns = false;

                if (usuario != null)
                {                   

                    if (Estado == 2)
                    {
                        btn_cerrar_caja.Enabled = false;
                        caja = new clsCaja() { Cajaid = _Cajaid, Estado = Estado,Usuario=usuario };
                        cargar_caja_movimiento();
                        total_caja();
                    }
                    else
                    {
                        idcaja = admcaja.buscar_caja_abierta(usuario);  
                                             
                        if (idcaja > 0)
                        {

                            caja = new clsCaja() { Cajaid = idcaja, Estado = Estado, Usuario = usuario };
                            cargar_caja_movimiento();
                            total_caja();
                        }
                    }
                }
                else {

                    this.Close();
                }
            }
            catch (Exception) { }
        }
        private void btn_cerrar_caja_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_resultado.Rows.Count > 0)
                {
                    //caja = new clsCaja() { Cajaid = _Cajaid, Estado = Estado, Usuario = usuario };

                    if (caja != null)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea cerra caja?...", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            if (admcaja.cerrar_caja(caja) > 0)
                            {
                                MessageBox.Show("Caja cerrada correctamente...", "Información");
                                btn_cerrar_caja.Enabled = false;

                                data = admcaja.reporte_caja_movimiento(caja);
                            }
                            else
                            {
                                MessageBox.Show("Problemas para cerrar caja...", "Advertencia");
                            }
                        }
                    }
                }
            }
            catch (Exception) { }

        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_resultado.Rows.Count > 0)
                {
                    dg_resultado.MultiSelect = true;
                    dg_resultado.SelectAll();
                    dg_resultado.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    DataObject dataObj = dg_resultado.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    dg_resultado.MultiSelect = false;

                    MessageBox.Show("Puede copiarlo a cualquier editor de texto...", "Información");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_comprobante_KeyPress(object sender, KeyPressEventArgs e)
        {
        
        }

        /***************************Mis Metodos******************************/

        public void cargar_caja_movimiento()
        {
            try
            {

                dg_resultado.DataSource = null;
                cajamovimientos = admcaja.listar_caja_movimiento(caja);

                if (cajamovimientos != null)
                {

                    if (cajamovimientos.Rows.Count > 0)
                    {

                        dg_resultado.DataSource = cajamovimientos;
                    }

                }
            }
            catch (Exception) { }
        }

        public void total_caja()
        {
            try
            {
                caja = admcaja.total_caja(caja);
           
                if (caja != null)
                {
                    caja.Usuario=usuario;

                    txt_apertura.Text = caja.Montoapertura.ToString();
                    txt_t_efectivo.Text = caja.Totalefectivo.ToString();
                    txt_t_deposito.Text = caja.Totaldeposito.ToString();
                    txt_t_transferencia.Text = caja.Totaltransferencia.ToString();
                    txt_t_tarjeta.Text = caja.Totaltarjeta.ToString();
                    txt_cierre.Text = caja.Montocierre.ToString();
                    txt_total_nota.Text = caja.Totalnotacredito.ToString();
                    txt_saldo.Text = caja.Totaldisponible.ToString();

                }
            }
            catch (Exception) { }
        }

        public void listar_movimiento_caja_xcomprobante()
        {
            int idcaja = -1;
            try
            {
                dg_resultado.DataSource = null;
                caja.Estado = Estado;
                caja.Usuario=usuario;
                cajamovimientos = admcaja.listar_movimiento_caja_xcomprobante(
                                                                                caja,                                                                               
                                                                                txt_comprobante.Text   
                                                                                                                                                    
                                                                             );

                if (cajamovimientos != null)
                {
                    if (cajamovimientos.Rows.Count > 1)
                    {
                        dg_resultado.DataSource = cajamovimientos;
                    }
                    else
                    {

                        if (Estado == 2)
                        {
                            btn_cerrar_caja.Enabled = false;
                            caja = new clsCaja() { Cajaid = _Cajaid, Estado = Estado, Usuario = usuario };
                            cargar_caja_movimiento();
                            total_caja();
                        }
                        else
                        {

                            idcaja = admcaja.buscar_caja_abierta(usuario);

                            if (idcaja > 0)
                            {

                                caja = new clsCaja() { Cajaid = idcaja, Estado = Estado, Usuario = usuario };
                                cargar_caja_movimiento();
                                total_caja();
                            }
                        }

                    }

                }
            }
            catch (Exception) { }
        }

        private void txt_comprobante_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_comprobante.CharacterCasing = CharacterCasing.Upper;

                if (txt_comprobante.Text.Length > 0)
                {

                    if (caja != null)
                    {
                        listar_movimiento_caja_xcomprobante();
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
