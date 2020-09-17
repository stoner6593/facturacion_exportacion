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
    public partial class FrmMenuPrincipal : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                if (usuario != null)
                {
                    permiso_xtipousuario();
                }
            }
            catch (Exception) { }
        }

        /*********************Mis Metodos**************************/
        public void permiso_xtipousuario() {

            switch (usuario.Tipousuario.Idtipousuario) {

                case 1: break;
                case 2:break;
            }
        }

        private void btn_emitir_comprobante_Click(object sender, EventArgs e)
        {

        }

        private void btn_caja_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_caja_movimiento_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FrmCajaMovimiento"] != null)
            {
                Application.OpenForms["FrmCajaMovimiento"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmCajaMovimiento frm_cajamov = new FrmCajaMovimiento();
                frm_cajamov.usuario = usuario;
                frm_cajamov.Estado = 1;
                frm_cajamov.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_abrir_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmApertura"] != null)
            {
                Application.OpenForms["FrmApertura"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmApertura form_apertura = new FrmApertura();
                form_apertura.usuario = usuario;
                form_apertura.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_emitir_comprobante_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["Form1"] != null)
            {
                Application.OpenForms["Form1"].Activate();
            }
            else
            {
                this.Visible = false;
                Form1 form1 = new Form1();
                form1.usuario = usuario;
                form1.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_cajas_abiertas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmVerAperturaCaja"] != null)
            {
                Application.OpenForms["FrmVerAperturaCaja"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmVerAperturaCaja frm_vercaja = new FrmVerAperturaCaja();
                frm_vercaja.usuario = usuario;
                frm_vercaja.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_cajas_cerradas_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmVerCierreCaja"] != null)
            {
                Application.OpenForms["FrmVerCierreCaja"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmVerCierreCaja frm_vercaja = new FrmVerCierreCaja();
                frm_vercaja.usuario = usuario;
                frm_vercaja.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_listar_comprobante_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FrmListaComprobante"] != null)
            {
                Application.OpenForms["FrmListaComprobante"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmListaComprobante frm_listacomprobante = new FrmListaComprobante();
                frm_listacomprobante.usuario = usuario;
                frm_listacomprobante.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_item_repositorio_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["FrmRepositorio"] != null)
            {
                Application.OpenForms["FrmRepositorio"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmRepositorio frm_repositorio = new FrmRepositorio();
                frm_repositorio.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_cliente_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms["FrmCajaMovimiento"] != null)
            {
                Application.OpenForms["FrmCajaMovimiento"].Activate();
            }
            else
            {
                this.Visible = false;
                FrmCliente frm_cliente = new FrmCliente();
                frm_cliente.ShowDialog();
                this.Visible = true;
            }
        }

        private void btn_usuario_Click(object sender, EventArgs e)
        {
            if (usuario != null)
            {
                if (usuario.Tipousuario.Idtipousuario == 1)
                {
                    if (Application.OpenForms["FrmUsuario"] != null)
                    {
                        Application.OpenForms["FrmUsuario"].Activate();
                    }
                    else
                    {
                        this.Visible = false;
                        FrmUsuario frm_usuario = new FrmUsuario();
                        frm_usuario.ShowDialog();
                        this.Visible = true;
                    }
                }
            }
        }
    }
}
