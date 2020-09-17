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
    public partial class FrmIngreso : PlantillaBase
    {
        private clsAdmUsuario admusuario = new clsAdmUsuario();
        private clsUsuario usuario = null;
        public FrmIngreso()
        {
            InitializeComponent();
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {

        }

        private void FrmIngreso_Shown(object sender, EventArgs e)
        {
            txt_usuario.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ingresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_usuario.Text.Length > 0 && txt_clave.Text.Length > 0)
                {

                    validar_usuario();
                }
                else
                {

                    if (txt_clave.Text.Length == 0 && txt_usuario.Text.Length == 0)
                    {
                        MessageBox.Show("Falta ingresar datos...");
                    }
                    else
                    {
                        if (txt_usuario.Text.Length == 0)
                        {
                            MessageBox.Show("Falta ingresar usuario...");
                        }

                        if (txt_clave.Text.Length == 0)
                        {
                            MessageBox.Show("Falta ingresar clave...");
                        }
                    }



                }
            }
            catch (Exception a ) { MessageBox.Show(a.Message); }
        }

        private void txt_clave_KeyPress(object sender, KeyPressEventArgs e)
        {
       
        }
        /*********************Mis Metodos********************/

        public void validar_usuario() {

            try
            {
                usuario = admusuario.validar_usuario(new clsUsuario()
                {
                    Cuenta = txt_usuario.Text,
                    Clave = txt_clave.Text
                });

                if (usuario != null) {

                    if (Application.OpenForms["FrmMenuPrincipal"] != null)
                    {
                        Application.OpenForms["FrmMenuPrincipal"].Activate();
                    }
                    else
                    {
                        this.Visible = false;
                        FrmMenuPrincipal frm_menuprincipal = new FrmMenuPrincipal();
                        frm_menuprincipal.usuario = usuario;
                        frm_menuprincipal.ShowDialog();                        
                        this.Close();
                    }
                }
                else
                {

                    txt_usuario.Text = string.Empty;
                    txt_clave.Text = string.Empty;
                    txt_usuario.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void txt_clave_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {                   
                     btn_ingresar.PerformClick();
                }
            }
            catch (Exception) { }
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {
            txt_usuario.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
