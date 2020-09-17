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
    public partial class FrmPlaca : PlantillaBase
    {
        public clsCliente cliente { get; set; }
        private DataTable placas = null;
        private clsAdmPlaca admpla = new clsAdmPlaca();
        public FrmPlaca()
        {
            InitializeComponent();
        }

        private void FrmPlaca_Load(object sender, EventArgs e)
        {
            dg_placa.AutoGenerateColumns = false;
            if (cliente == null) {

                MessageBox.Show("Error de cliente...","Advertencia");
                return;
            }

            listar_placa_xidcliente();
        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            txt_numero.CharacterCasing = CharacterCasing.Upper;
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dg_placa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dg_placa.Rows.Count > 0)
                {

                    if (e.RowIndex != -1)
                    {

                        txt_cod.Text = dg_placa.Rows[e.RowIndex].Cells[idplaca.Index].Value.ToString();
                        txt_numero.Text = dg_placa.Rows[e.RowIndex].Cells[numero.Index].Value.ToString();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (txt_cod.Text.Length == 0)
            {
                if (txt_numero.Text.Length > 0)
                {
                    registrar_placa();
                    listar_placa_xidcliente();
                }
                else
                {

                    MessageBox.Show("Por favor complete la información solicitada...", "Advertencia");
                }
            }
            else
            {

                if (txt_numero.Text.Length > 0)
                {
                    actualizar_placa();
                    listar_placa_xidcliente();
                }
                else
                {
                    MessageBox.Show("Por favor complete la información solicitada...", "Advertencia");
                }

            }
        }

        /******************Mis Metodos**************/
        public void listar_placa_xidcliente() {

            try
            {
                dg_placa.DataSource = null;
                placas = admpla.listar_placa_xidcliente(cliente);
                if (placas != null) {

                    if (placas.Rows.Count > 0) {

                        dg_placa.DataSource = placas;
                        dg_placa.Refresh();

                    }
                }
            }
            catch (Exception) { }

        }


        public void registrar_placa() {

            int id = -1;

            try
            {
                id = admpla.registrar_placa(new clsPlaca()
                {
                    Cliente=cliente,
                    Numero=txt_numero.Text
                });

                if (id > 0)
                {
                    MessageBox.Show("Registro correcto...","Información");                    
                }
                else {

                    MessageBox.Show("Problemas para registrar placa...", "Advertencia");                   
                }
                    
            }
            catch (Exception) { }
        }

        public void actualizar_placa()
        {

            int fila_afectadas = -1;

            try
            {
                fila_afectadas = admpla.actualizar_placa(new clsPlaca()
                {
                    Idplaca=int.Parse(txt_cod.Text),
                    Cliente = cliente,
                    Numero = txt_numero.Text
                });

                if (fila_afectadas > 0)
                {
                    MessageBox.Show("Actualización correcta...", "Información");
                }
                else
                {

                    MessageBox.Show("Problemas para actualizar placa...", "Advertencia");
                }

            }
            catch (Exception) { }
        }        
    }
}
