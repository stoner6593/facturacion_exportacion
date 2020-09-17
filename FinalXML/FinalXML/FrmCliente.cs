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
    public partial class FrmCliente : PlantillaBase
    {
        private List<clsTipoDocumentoIdentidad> lista_tipodoc = null;
        private clsAdmTipoDocumentoIdentidad admtipodocidentidad = new clsAdmTipoDocumentoIdentidad();
        private DataTable clientes = null;
        private clsCliente cliente = null;
        private clsAdmCliente admcli = new clsAdmCliente();
        public FrmDocumento frm_documento { get; set; }
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            cb_estado.SelectedIndex = 0;
            dg_cliente.AutoGenerateColumns = false;
            listar_tipodoc_identidad();
        }

        private void txt_razon_social_TextChanged(object sender, EventArgs e)
        {
            txt_razon_social.CharacterCasing = CharacterCasing.Upper;
           
        }

        private void txt_documento_TextChanged(object sender, EventArgs e)
        {
            txt_documento.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_direccion_TextChanged(object sender, EventArgs e)
        {
            txt_direccion.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_codigo.Text.Length == 0)
                {

                    if (txt_razon_social.Text.Length > 0
                        && txt_documento.Text.Length > 0
                        && txt_direccion.Text.Length > 0)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea registrar cliente?...", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            registrar_cliente();
                            buscar_clientexnombreyapellido();
                        }

                    }
                    else
                    {

                        MessageBox.Show("Por favor complete la información solicitada...", "Advertencia");
                    }
                }
                else
                {

                    if (txt_razon_social.Text.Length > 0
                       && txt_documento.Text.Length > 0
                       && txt_direccion.Text.Length > 0)
                    {
                        DialogResult respuesta = MessageBox.Show("¿Desea actualizar cliente?...", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            actualizar_cliente();
                            buscar_clientexnombreyapellido();
                        }

                    }
                    else
                    {

                        MessageBox.Show("Por favor complete la información solicitada...", "Advertencia");
                    }
                }
            }
            catch (Exception) { }
        }

        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            limpiar_todo();
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            listar_cliente();
        }

        private void dg_cliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_cliente.Rows.Count > 0)
                {
                    if (e.RowIndex != -1)
                    {
                        txt_codigo.Text = dg_cliente.Rows[e.RowIndex].Cells[idcliente.Index].Value.ToString();
                        cb_estado.SelectedIndex = (dg_cliente.Rows[e.RowIndex].Cells[estado.Index].Value.ToString() == "ACTIVO") ? 0 : 1;
                        txt_razon_social.Text = dg_cliente.Rows[e.RowIndex].Cells[nombreyapellido.Index].Value.ToString();
                        cb_tipodoc.SelectedValue = (from x in lista_tipodoc
                                                    where x.Descripcion == dg_cliente.Rows[e.RowIndex].Cells[descripcion.Index].Value.ToString()
                                                    select x.Idtipodocumentoidentidad).ToList()[0];
                        txt_documento.Text = dg_cliente.Rows[e.RowIndex].Cells[documento.Index].Value.ToString();
                        txt_direccion.Text = dg_cliente.Rows[e.RowIndex].Cells[direccion.Index].Value.ToString();
                    }
                }
            }
            catch (Exception) { }
        }

        /*********************Mis Metodos********************************/
        public void listar_tipodoc_identidad()
        {

            try
            {
                lista_tipodoc = admtipodocidentidad.listar_tipo_documento_identidad();

                if (lista_tipodoc != null)
                {

                    if (lista_tipodoc.Count > 0)
                    {

                        cb_tipodoc.DataSource = lista_tipodoc;
                        cb_tipodoc.DisplayMember = "Descripcion";
                        cb_tipodoc.ValueMember = "Idtipodocumentoidentidad";
                        cb_tipodoc.SelectedIndex = 0;
                    }

                }
            }
            catch (Exception) { }
        }

        public void registrar_cliente()
        {

            try
            {
                if (lista_tipodoc == null)
                {
                    MessageBox.Show("No se ha poido cargar los tipos de documento...", "Advertencia");
                    return;
                }

                cliente = new clsCliente()
                {
                    Nombreyapellido = txt_razon_social.Text,
                    Tipodocumentoidentidad = lista_tipodoc[cb_tipodoc.SelectedIndex],
                    Documento = txt_documento.Text,
                    Direccion = txt_direccion.Text,
                    Estado = (cb_estado.SelectedItem.ToString() == "ACTIVO") ? 1 : 0
                };

                if (admcli.registrar_cliente(cliente) > 0)
                {
                    MessageBox.Show("Registro correcto...", "Información");
                }
                else
                {
                    MessageBox.Show("Problemas para registrar cliente...", "Advertencia");
                }
            }
            catch (Exception) { }
        }

        public void actualizar_cliente()
        {
            try
            {
                if (lista_tipodoc == null)
                {
                    MessageBox.Show("No se ha poido cargar los tipos de documento...", "Advertencia");
                    return;
                }

                cliente = new clsCliente()
                {
                    Idcliente = int.Parse(txt_codigo.Text),
                    Nombreyapellido = txt_razon_social.Text,
                    Tipodocumentoidentidad = lista_tipodoc[cb_tipodoc.SelectedIndex],
                    Documento = txt_documento.Text,
                    Direccion = txt_direccion.Text,
                    Estado = (cb_estado.SelectedItem.ToString() == "ACTIVO") ? 1 : 0
                };

                if (admcli.actualizar_cliente(cliente) > 0)
                {
                    MessageBox.Show("Actualización correcta...", "Información");
                }
                else
                {
                    MessageBox.Show("Problemas para actulizar cliente...", "Advertencia");
                }
            }
            catch (Exception) { }

        }

        public void buscar_clientexnombreyapellido()
        {
            try
            {
                dg_cliente.DataSource = null;
                clientes = admcli.buscar_clientexnombreyapellido(new clsCliente()
                {
                    Nombreyapellido = txt_razon_social.Text
                });
                if (clientes != null)
                {
                    if (clientes.Rows.Count > 0)
                    {

                        dg_cliente.DataSource = clientes;
                        dg_cliente.Refresh();
                    }
                }
            }
            catch (Exception) { }
        }

        public void limpiar_todo()
        {

            try
            {
                txt_codigo.Text = string.Empty;
                cb_estado.SelectedIndex = 0;
                txt_razon_social.Text = string.Empty;
                cb_tipodoc.SelectedIndex = 0;
                txt_documento.Text = string.Empty;
                txt_direccion.Text = string.Empty;
                dg_cliente.DataSource = null;
            }
            catch (Exception) { }
        }

        public void listar_cliente()
        {

            try
            {
                dg_cliente.DataSource = null;
                clientes = admcli.listar_cliente();
                if (clientes != null)
                {

                    if (clientes.Rows.Count > 0)
                    {

                        dg_cliente.DataSource = clientes;
                        dg_cliente.Refresh();
                    }
                }
            }
            catch (Exception) { }
        }

        private void dg_cliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dg_cliente.Rows.Count > 0) {

                if (e.RowIndex != -1) {

                    if (frm_documento != null) {

                        frm_documento.cliente = new clsCliente()
                        {
                            Idcliente =int.Parse(dg_cliente.Rows[e.RowIndex].Cells[idcliente.Index].Value.ToString()),
                            Nombreyapellido= dg_cliente.Rows[e.RowIndex].Cells[nombreyapellido.Index].Value.ToString(),
                            Documento= dg_cliente.Rows[e.RowIndex].Cells[documento.Index].Value.ToString(),
                            Direccion= dg_cliente.Rows[e.RowIndex].Cells[direccion.Index].Value.ToString()
                        };

                        this.Close();

                    }

                }
            }
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_placa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_cliente.Rows.Count > 0)
                {                    
                    if (txt_codigo.Text.Length > 0)
                    {
                        if (Application.OpenForms["FrmPlaca"] != null)
                        {
                            Application.OpenForms["FrmPlaca"].Activate();
                        }
                        else
                        {
                            this.Visible = false;
                            FrmPlaca frm_placa = new FrmPlaca();
                            frm_placa.cliente = new clsCliente() { Idcliente=int.Parse(txt_codigo.Text)};
                            frm_placa.ShowDialog();
                            this.Visible = true;
                        }

                    }
                }
            }
            catch (Exception) { }
        }

        private void txt_razon_social_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txt_razon_social.Text.Length > 0)
                {

                    buscar_clientexnombreyapellido();
                }
            }
            catch (Exception) { }
        }
    }
}
