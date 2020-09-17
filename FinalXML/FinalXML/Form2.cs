using FinalXML.Administradores;
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
    public partial class Form2 : PlantillaBase
    {
        private int index;
        private DataTable detalle;
        private clsAdmDetalleComprobante admdetalle= new clsAdmDetalleComprobante();
        public Form2(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            dt_detalle.AutoGenerateColumns = false;

            try
            {
                detalle = admdetalle.listarxcomprobante(index);
                dt_detalle.DataSource = null;

                if (detalle != null)
                {

                    if (detalle.Rows.Count > 0)
                    {

                        dt_detalle.DataSource = detalle;
                        dt_detalle.Refresh();
                        total_venta();
                    }
                }
                else
                {
                    MessageBox.Show("No hay comprobantes para mostrar");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error " + ex);
            }


        }

        private void total_venta()
        {
            try
            {
                if (dt_detalle.Rows.Count > 0)
                {
                    lbl_total.Text = (dt_detalle.Rows.Cast<DataGridViewRow>().Select(x => decimal.Parse(x.Cells["total"].Value.ToString())).Sum()).ToString();
                }
                else
                {
                    lbl_total.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error..." + ex.Message.ToString());
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
