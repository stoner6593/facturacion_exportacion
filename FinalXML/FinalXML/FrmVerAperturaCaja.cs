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
    public partial class FrmVerAperturaCaja : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        private clsAdmCaja admca = new clsAdmCaja();
        private clsCaja caja = null;
        private DataTable cajas = null;
        public FrmVerAperturaCaja()
        {
            InitializeComponent();
        }

        private void FrmVerAperturaCaja_Load(object sender, EventArgs e)
        {
            dg_resultado.AutoGenerateColumns = false;
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            try
            {
                cargar_caja();
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

        /**********************Mis Metodos***********************/

        public void cargar_caja()
        {
            try
            {
                dg_resultado.DataSource = null;
                cajas = admca.listar_caja_apertura();

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

        private void btn_anular_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_resultado.Rows.Count > 0)
                {
                    if (dg_resultado.CurrentCell != null)
                    {
                        if (dg_resultado.CurrentCell.RowIndex != -1)
                        {

                            DialogResult respuesta = MessageBox.Show("¿Desea anular caja?...", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (respuesta == DialogResult.Yes)
                            {
                                caja = new clsCaja()
                                {
                                    Cajaid = int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[numero.Index].Value.ToString()),
                                    Usuario = new clsUsuario() {

                                       Idusuario= int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[idusuario.Index].Value.ToString()),
                                    }
                                };

                                if (admca.anular_caja(caja) > 0)
                                {
                                    MessageBox.Show("Caja anulada correctamente...", "Información");
                                    cargar_caja();
                                }
                                else
                                {
                                    MessageBox.Show("Caja no se puede anular tiene movimientos...", "Advertencia");

                                }

                            }
                        }
                    }
                }
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
                                Cajaid = int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[numero.Index].Value.ToString())
                            };

                            if (Application.OpenForms["FrmCajaMovimiento"] != null)
                            {
                                Application.OpenForms["FrmCajaMovimiento"].Activate();
                            }
                            else
                            {
                                FrmCajaMovimiento frm_cajamovimiento = new FrmCajaMovimiento();
                                frm_cajamovimiento.usuario = new clsUsuario() { Idusuario = int.Parse(dg_resultado.Rows[dg_resultado.CurrentCell.RowIndex].Cells[idusuario.Index].Value.ToString()) };
                                frm_cajamovimiento._Cajaid = caja.Cajaid;
                                frm_cajamovimiento.Estado = 1;
                                frm_cajamovimiento.ShowDialog();

                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
  }
    

