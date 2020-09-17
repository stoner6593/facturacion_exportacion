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
    public partial class FrmUsuario : PlantillaBase
    {
        private clsAdmTipoUsuario admtipousu = new clsAdmTipoUsuario();
        private List<clsTipoUsuario> lista_tippusuario = null;
        private clsAdmUsuario admusu = new clsAdmUsuario();
        private DataTable usuarios = null;
        public FrmUsuario()
        {
            InitializeComponent();
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            dg_usuario.AutoGenerateColumns = false;
            listar_tipo_usuario();
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lista_tippusuario == null)
                {

                    return;
                }

                if (txt_cod.Text.Length == 0)
                {
                    if (txt_nombre.Text.Length > 0 && txt_cuenta.Text.Length > 0 && txt_clave.Text.Length > 0)
                    {

                        registrar_usuario();
                        listar_usuario();
                    }
                }
                else
                {


                    if (txt_nombre.Text.Length > 0 && txt_cuenta.Text.Length > 0 && txt_clave.Text.Length > 0)
                    {

                        actualizar_usuario();
                        listar_usuario();
                    }
                }
            }
            catch (Exception) { }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            txt_cod.Text = string.Empty;
            txt_nombre.Text = string.Empty;
            txt_cuenta.Text = string.Empty;
            txt_clave.Text = string.Empty;
            dg_usuario.DataSource = null;
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            try
            {
                listar_usuario();
            }
            catch (Exception) { }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_usuario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_usuario.Rows.Count > 0)
                {
                    if (e.RowIndex != -1)
                    {

                        txt_cod.Text = dg_usuario.Rows[e.RowIndex].Cells[idusuario.Index].Value.ToString();
                        cb_tipousuario.Text = dg_usuario.Rows[e.RowIndex].Cells[descripcion.Index].Value.ToString();
                        txt_nombre.Text = dg_usuario.Rows[e.RowIndex].Cells[nombre.Index].Value.ToString();
                        txt_cuenta.Text = dg_usuario.Rows[e.RowIndex].Cells[cuenta.Index].Value.ToString();
                        txt_clave.Text = dg_usuario.Rows[e.RowIndex].Cells[clave.Index].Value.ToString();

                    }
                }
            }
            catch (Exception) { }
        }

        /******************MIS METODOS***************/
        public void listar_tipo_usuario() {

            try
            {
                lista_tippusuario = admtipousu.listar_tipo_usuario();
                if (lista_tippusuario != null) {
                    if (lista_tippusuario.Count >0) {

                        cb_tipousuario.DataSource = lista_tippusuario;
                        cb_tipousuario.DisplayMember = "Descripcion";
                        cb_tipousuario.ValueMember = "Idtipousuario";
                    }
                }
            }
            catch (Exception) { }

        }

        public void registrar_usuario() {

            int id = -1;
            try
            {
                id = admusu.registrar_usuario(new clsUsuario()
                {
                    Tipousuario=lista_tippusuario[cb_tipousuario.SelectedIndex],
                    Nombre = txt_nombre.Text,
                    Cuenta=txt_cuenta.Text,
                    Clave=txt_clave.Text

                });

                if (id > 0) {

                    MessageBox.Show("Registro correcto...", "Información");

                }
            }
            catch (Exception) { }
        }

        public void actualizar_usuario()
        {

            int filas_afectadas = -1;
            try
            {
                filas_afectadas = admusu.actualizar_usuario(new clsUsuario()
                {

                    Idusuario=int.Parse(txt_cod.Text),
                    Tipousuario = lista_tippusuario[cb_tipousuario.SelectedIndex],
                    Nombre = txt_nombre.Text,
                    Cuenta = txt_cuenta.Text,
                    Clave = txt_clave.Text

                });

                if (filas_afectadas > 0)
                {

                    MessageBox.Show("Actualización correcta...", "Información");

                }
            }
            catch (Exception) { }
        }

        public void listar_usuario() {

            try
            {
                dg_usuario.DataSource = null;
                usuarios = admusu.listar_usuario();
                if (usuarios != null) {

                    if (usuarios.Rows.Count > 0) {

                        dg_usuario.DataSource = usuarios;
                        dg_usuario.Refresh();
                    }
                }
            }
            catch (Exception) { }
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            txt_nombre.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_cuenta_TextChanged(object sender, EventArgs e)
        {
            txt_cuenta.CharacterCasing = CharacterCasing.Upper;
        }
    }
}
