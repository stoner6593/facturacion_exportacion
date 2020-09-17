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
    public partial class FrmApertura : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        private clsAdmCaja admca = new clsAdmCaja();
        private clsCaja caja = null;
        public FrmApertura()
        {
            InitializeComponent();
        }

        private void FrmApertura_Load(object sender, EventArgs e)
        {

        }

        private void txt_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }


            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (!char.IsControl(e.KeyChar))
            {

                TextBox textBox = (TextBox)sender;

                if (textBox.Text.IndexOf('.') > -1 &&
                         textBox.Text.Substring(textBox.Text.IndexOf('.')).Length >= 4)
                {
                    e.Handled = true;
                }

            }
        }

        private void txt_monto_KeyDown(object sender, KeyEventArgs e)
        {
            int id = -1;

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txt_monto.Text.Length > 0)
                    {
                        if (decimal.Parse(txt_monto.Text) >= 0)
                        {
                            id = admca.buscar_caja_abierta(usuario);

                            if (id == -1)
                            {
                                caja = new clsCaja()
                                {
                                    Montoapertura = decimal.Round(decimal.Parse(txt_monto.Text), 2),
                                    Usuario = usuario,
                                    Estado = 1
                                };

                                if (admca.registrar_caja(caja) > 0)
                                {
                                    MessageBox.Show("Apertura de caja correcta...", "Información");
                                    this.Close();
                                }
                                else
                                {

                                    MessageBox.Show("Problemas para la apertura de caja...", "Error");
                                }
                            }
                            else
                            {

                                MessageBox.Show("Ya tiene caja aperturada...", "Advertencia");
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_monto_KeyDown(sender,new KeyEventArgs(Keys.Enter));
            }
            catch (Exception) { }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
