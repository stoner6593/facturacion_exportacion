using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalXML.Administradores;
using FinalXML.Entidades;
using WinApp.Comun.Dto.Modelos;
using WinApp.Datos;
namespace FinalXML
{
    public partial class FrmDetalleDocumento : PlantillaBase
    {
        private readonly DetalleDocumento _detalle;
        private readonly DocumentoElectronico _documento;
        private clsDetalleComprobante _detcomprobante;
        private AutoCompleteStringCollection namesCollection;
        private DataTable dt = null;
        public FrmDetalleDocumento()
        {
            InitializeComponent();
        }
        public FrmDetalleDocumento(DetalleDocumento detalle, DocumentoElectronico documento)
        {
            InitializeComponent();
            _detalle = detalle;
            _documento = documento;

            detalleDocumentoBindingSource.DataSource = detalle;
            detalleDocumentoBindingSource.ResetBindings(false);

            Load += (s, e) =>
            {
                using (var ctx = new OpenInvoicePeruDb())
                {
                    tipoImpuestoBindingSource.DataSource = ctx.TipoImpuestos.ToList();
                    tipoImpuestoBindingSource.ResetBindings(false);

                    tipoPrecioBindingSource.DataSource = ctx.TipoPrecios.ToList();
                    tipoPrecioBindingSource.ResetBindings(false);
                }
            };
            decimal sumar = 0;
            sumar = documento.Items.Count() + 1;
            idNumericUpDown.Value = (sumar);
        }
        private void FrmDetalleDocumento_Load(object sender, EventArgs e)
        {

         
            decimal sumar = 0;
           // idNumericUpDown.Value = 1;
            sumar = _documento.Items.Count() + 1;
            idNumericUpDown.Value = (sumar);

            cargarProductos();

        }

        public void cargarProductos()
        {
            DataTable dt = null;
            try
            {

                clsAdmProducto admProducto = new clsAdmProducto();
                cmbPro.DataSource = admProducto.Listar();
                cmbPro.ValueMember = "codProducto";
                cmbPro.DisplayMember = "Descripcion";
                //cmbPro.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void toolCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void toolOk_Click(object sender, EventArgs e)
        {
            btnCalcIgv.PerformClick();
            tipoPrecioComboBox.Focus();
            _detalle.UnidadMedida = unidadMedidaComboBox.Text;
            _detalle.Descripcion = descripcionTextBox.Text;

            // Evaluamos el tipo de Impuesto.
            if (!_detalle.TipoImpuesto.StartsWith("1"))
            {
                _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
                _detalle.TotalVenta = _detalle.Suma;
               
            }
            else
            {
                if (_detalle.OtroImpuesto > 0)
                    _detalle.TotalVenta = _detalle.TotalVenta + _detalle.OtroImpuesto;
            }

           
            if (_documento.CalculoIgv > 0)
            {

                _detalle.PrecioReferencial = _detalle.PrecioUnitario;
                _detalle.PrecioUnitario = _detalle.PrecioReferencial / 1.18m;
            }
            else {
                _detalle.PrecioReferencial = _detalle.PrecioUnitario;
                _detalle.PrecioUnitario = _detalle.PrecioReferencial;
            }

            if (_detalle.TipoImpuesto.Equals("40")) {

                _detalle.ItemClassificationCode = _detalle.CodigoItem;
            }

            DialogResult = DialogResult.Cancel;
        }

        private void btnCalcIgv_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            // _detalle.Impuesto = _detalle.Suma * _documento.CalculoIgv;


            if (_documento.CalculoIgv > 0)
            {
                //_detalle.SubTotalVenta = _detalle.Suma;
                //_detalle.Impuesto = _detalle.Suma * _documento.CalculoIgv;
                //Válido cuando el precio incluye IGV
                 _detalle.SubTotalVenta = Math.Round((_detalle.Suma / Convert.ToDecimal(1.18)), 2);
                 _detalle.Impuesto = Math.Round(_detalle.Suma - _detalle.SubTotalVenta, 2);
            }
            else
            {
                //_documento.SubTotalVenta = _detalle.Suma;
                _detalle.SubTotalVenta = _detalle.Suma;
                _detalle.Impuesto = 0;
            }


            //_detalle.TotalVenta = _detalle.Suma;
            _detalle.TotalVenta = _detalle.Suma;

            detalleDocumentoBindingSource.ResetBindings(false);
        }

        private void btnCalcIsc_Click(object sender, EventArgs e)
        {
            _detalle.Suma = _detalle.PrecioUnitario * _detalle.Cantidad;
            _detalle.ImpuestoSelectivo = _detalle.Suma * _documento.CalculoIsc;

            detalleDocumentoBindingSource.ResetBindings(false);
        }



        private void cantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
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


        private void cmbPro_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
            /*try
            {
               
               if (cmbPro.Items.Count > 0 && cmbPro.SelectedValue.ToString() != "System.Data.DataRowView")
               {

                    clsAdmProducto admProducto = new clsAdmProducto();
                    clsProducto oProducto = null;

                    oProducto = admProducto.Buscar(Convert.ToInt32(cmbPro.SelectedValue.ToString()));

                    if (oProducto != null)
                    {
                       codigoItemTextBox.Text = oProducto.IdProducto.ToString();
                       descripcionTextBox.Text = oProducto.Descripcion.ToString();
                       precioUnitarioTextBox.Text = oProducto.Precio.ToString();

                       _detalle.CodigoItem = oProducto.IdProducto.ToString();
                       _detalle.Id = Convert.ToInt32(idNumericUpDown.Value);
                       _detalle.PrecioUnitario = oProducto.Precio;
                       _detalle.Descripcion = descripcionTextBox.Text;
                        cantidadTextBox.Text = "1";
                       cantidadTextBox.Focus();
                    }

                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void descripcionTextBox_TextChanged(object sender, EventArgs e)
        {
            //descripcionTextBox.CharacterCasing = CharacterCasing.Upper;
        }

        private void descripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txt_servicio_TextChanged(object sender, EventArgs e)
        {
            txt_servicio.CharacterCasing = CharacterCasing.Upper;
        }

        private void txt_servicio_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_servicio.Text.Length > 0) {

                cargarProductos_xnombre();
            }
        }

        public void cargarProductos_xnombre()
        {
            
            clsAdmProducto admProducto = new clsAdmProducto();
            try
            {
                namesCollection = new AutoCompleteStringCollection();
                dt = admProducto.Listar_xnombre(new clsProducto() { Descripcion=txt_servicio.Text});

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        namesCollection.Add(row["Descripcion"].ToString());
                    }

                    txt_servicio.AutoCompleteMode = AutoCompleteMode.Append;
                    txt_servicio.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt_servicio.AutoCompleteCustomSource = namesCollection;
                    cmbPro.Text = txt_servicio.Text;
                    //btnCalcIgv.PerformClick();
                }

            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPro_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (cmbPro.SelectedIndex != -1)
                {
                    if (cmbPro.Items.Count > 0 && cmbPro.SelectedValue.ToString() != "System.Data.DataRowView")
                    {

                        clsAdmProducto admProducto = new clsAdmProducto();
                        clsProducto oProducto = null;

                        oProducto = admProducto.Buscar(Convert.ToInt32(cmbPro.SelectedValue.ToString()));

                        if (oProducto != null)
                        {
                            codigoItemTextBox.Text = oProducto.IdProducto.ToString();
                            descripcionTextBox.Text = oProducto.Descripcion.ToString();
                            precioUnitarioTextBox.Text = oProducto.Precio.ToString();

                            _detalle.CodigoItem = oProducto.IdProducto.ToString();
                            _detalle.Id = Convert.ToInt32(idNumericUpDown.Value);
                            _detalle.PrecioUnitario = oProducto.Precio;
                            _detalle.Descripcion = descripcionTextBox.Text;
                            cantidadTextBox.Text = "1.00";                           
                            cantidadTextBox.Focus();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cantidadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _detalle.Cantidad = Convert.ToDecimal(cantidadTextBox.Text);
                btnCalcIgv_Click(null, null);
            }
        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tipoImpuestoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
