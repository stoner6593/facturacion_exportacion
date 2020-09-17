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

namespace FinalXML
{
    public partial class FormProducto : PlantillaBase
    {

        public clsProducto oProducto=null;

        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                clsAdmProducto admProducto= new clsAdmProducto();
                
                oProducto= new clsProducto();

                oProducto.Referencia = txtReferencia.Text;
                oProducto.Descripcion = txtDescripcion.Text;
                oProducto.Precio = Convert.ToDecimal(txtPrecio.Text);


                oProducto=admProducto.Insertar(oProducto);


                this.Close();


                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            SOLONumeros(sender, e);
        }

        public void SOLONumeros(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsNumber(e.KeyChar) && e.KeyChar != (Char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            txtReferencia.CharacterCasing = CharacterCasing.Upper;
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            txtDescripcion.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
