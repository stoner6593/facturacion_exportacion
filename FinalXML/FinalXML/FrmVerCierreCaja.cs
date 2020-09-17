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
    public partial class FrmVerCierreCaja : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        private clsAdmCaja admca = new clsAdmCaja();
        private clsCaja caja = null;
        private DataTable cajas = null;
        public FrmVerCierreCaja()
        {
            InitializeComponent();
        }

        private void FrmVerCierreCaja_Load(object sender, EventArgs e)
        {           
            dg_resultado.AutoGenerateColumns = false;   
            dt_fecha_ini.Value = DateTime.Now;
            dt_fecha_fin.Value = DateTime.Now;
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            try
            {
                cargar_caja();
            }
            catch (Exception) { }
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_resultado.Rows.Count > 0)
                {
                    if (dg_resultado.CurrentCell != null)
                    {
                        if (dg_resultado.CurrentCell.RowIndex != -1)
                        {

                            caja = new clsCaja()
                            {
                                Cajaid = int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[numero.Index].Value.ToString()),
                                Usuario = new clsUsuario()
                                {

                                    Idusuario = int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[idusuario.Index].Value.ToString()),
                                }
                            };

                            if (Application.OpenForms["FrmCajaMovimiento"] != null)
                            {
                                Application.OpenForms["FrmCajaMovimiento"].Activate();
                            }
                            else
                            {
                                FrmCajaMovimiento frm_cajamovimiento = new FrmCajaMovimiento();
                                frm_cajamovimiento.usuario = usuario;
                                frm_cajamovimiento._Cajaid = caja.Cajaid;
                                frm_cajamovimiento.Estado = 2;
                                frm_cajamovimiento.ShowDialog();

                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        /**********************Mis Metodos***********************/

        public void cargar_caja()
        {
            try
            {
                dg_resultado.DataSource = null;
                cajas = admca.listar_caja_cerrada(dt_fecha_ini.Value, dt_fecha_fin.Value);

                if (cajas != null)
                {
                    if (cajas.Rows.Count > 0)
                    {

                        dg_resultado.DataSource = cajas;
                    }

                }
            }
            catch (Exception) { }

        }

        
    }
}
