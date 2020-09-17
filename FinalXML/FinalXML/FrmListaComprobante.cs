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
using Excel = Microsoft.Office.Interop.Excel;

namespace FinalXML
{
    public partial class FrmListaComprobante : PlantillaBase
    {
        public clsUsuario usuario { get; set; }
        private clsAdmComprobante admcompro = new clsAdmComprobante();
        private DataTable comprobantes = null;
        private DataTable reporte = null;
        private Excel.Application excel;
        private Object obt;
        private Excel.Workbook librotrabajo;

        public FrmListaComprobante()
        {
            InitializeComponent();
        }

        private void FrmListaComprobante_Load(object sender, EventArgs e)
        {
            dg_venta.AutoGenerateColumns = false;
            dt_fechainicio.Value = DateTime.Now;
            dt_fecha_fin.Value = DateTime.Now;
            cb_estado.SelectedIndex = 0;
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            try
            {
                listar_comprobante_xfecha();
            }
            catch (Exception) { }
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_venta.Rows.Count > 0)
                {
                    dg_venta.MultiSelect = true;
                    dg_venta.SelectAll();
                    dg_venta.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
                    DataObject dataObj = dg_venta.GetClipboardContent();
                    if (dataObj != null)
                        Clipboard.SetDataObject(dataObj);

                    dg_venta.MultiSelect = false;

                    MessageBox.Show("Puede copiarlo a cualquier editor de texto...", "Información");

                    
                }

                
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            if (txt_numero.Text.Length > 0)
            {

                listar_comprobante_xfecha_xnumero();
            }
        }

        private void btn_anular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Desea anular comprobante?...", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    anular_comprobante();
                }
            }
            catch (Exception) { }
        }

        private void cb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            dg_venta.DataSource = null;
            comprobantes = null;
            dt_fechainicio.Value = DateTime.Now;
            dt_fecha_fin.Value = DateTime.Now;
        }

        /******************Mis Metodos********************/

        public void listar_comprobante_xfecha() {

            try
            {
                dg_venta.DataSource = null;
                comprobantes = admcompro.listar_comprobante_xfecha(
                        dt_fechainicio.Value,
                        dt_fecha_fin.Value,
                        (cb_estado.SelectedIndex==0?1:0)
                    );

                if (comprobantes != null) {

                    if (comprobantes.Rows.Count > 0) {

                        dg_venta.DataSource = comprobantes;
                        dg_venta.Refresh();
                        total_venta();
                    }
                }
                else
                {
                    MessageBox.Show("No hay comprobantes para mostrar");
                }
            }
            catch (Exception) { }
        }

        public void listar_comprobante_xfecha_xnumero() {

            try
            {
                dg_venta.DataSource = null;
                comprobantes = admcompro.listar_comprobante_xfecha_xnumero(
                        dt_fechainicio.Value,
                        dt_fecha_fin.Value,
                        (cb_estado.SelectedIndex == 0 ? 1 : 0),
                        txt_numero.Text
                    );

                if (comprobantes != null)
                {

                    if (comprobantes.Rows.Count > 0)
                    {

                        dg_venta.DataSource = comprobantes;
                        dg_venta.Refresh();
                        total_venta();
                    }
                }
            }
            catch (Exception) { }
        }

        public void total_venta()
        {
            try
            {
                if (dg_venta.Rows.Count > 0)
                {
                    lb_total_soles.Text = (dg_venta.Rows.Cast<DataGridViewRow>().Select(x => decimal.Parse(x.Cells["total"].Value.ToString())).Sum()).ToString();    
                }
                else
                {
                    lb_total_soles.Text = "0.00";               
                }
            }
            catch (Exception) { }
        }

        public void anular_comprobante() {

            int filas_afectadas = -1;

            try
            {
                if (dg_venta.Rows.Count > 0) {

                    if (dg_venta.CurrentCell != null) {

                        if (dg_venta.CurrentCell.RowIndex != -1) {

                            if (usuario != null) {

                                if (usuario.Tipousuario.Idtipousuario == 1)
                                {
                                    filas_afectadas = admcompro.anular_comprobante(
                                            new clsComprobante() {
                                                Idcomprobante=int.Parse(dg_venta.Rows[dg_venta.CurrentCell.RowIndex].Cells[idcomprobante.Index].Value.ToString())
                                            }
                                        );

                                    if (filas_afectadas >= 1)
                                    {
                                        MessageBox.Show("Comprobante anulado correctamente...", "Información");
                                        btn_buscar.PerformClick();
                                    }
                                    else {

                                        switch (filas_afectadas)
                                        {
                                            case -1:
                                                MessageBox.Show("Comprobante no existe en repositorio...", "Advertencia");
                                                break;
                                            case 0:
                                                MessageBox.Show("Comprobante enviado a sunat...", "Advertencia");
                                                break;                                           
                                            case 5:
                                                MessageBox.Show("Comprobante anulado anteriormente...", "Advertencia");
                                                break;

                                        }

                                        btn_buscar.PerformClick();
                                    }
                                }
                                else {

                                    MessageBox.Show("Tipo de Usuario Invalido...","Advertencia");
                                }
                            }

                        }

                    }

                }
            }
            catch (Exception) { }
        }

        private void dg_venta_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index =Convert.ToInt32(dg_venta.CurrentRow.Cells[idcomprobante.Name].Value);

            Form2 detallecomprobante = new Form2(index);
            detallecomprobante.ShowDialog();


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                excel = new Excel.Application();
                obt = Type.Missing;
                librotrabajo = excel.Workbooks.Add(obt);
                Excel.Worksheet hoja1 = new Excel.Worksheet();
                hoja1 = librotrabajo.Sheets.Item[1];
                hoja1.Name = "Reporte Ventas";
                hoja1.Activate();
                //hoja1.Cells[1,1] = "hola";
                excel.Visible = true;

                reporte = new DataTable();
                reporte = admcompro.listar_reporte(dt_fechainicio.Value, dt_fecha_fin.Value, (cb_estado.SelectedIndex == 0 ? 1 : 0));

                int prev = 0;
                int fila = 1;
                foreach (DataRow d in reporte.Rows)
                {

                    int idcomprobante = (int)d["idcomprobante"];

                    //int filas_add = 0;

                    if (idcomprobante != prev)
                    {
                        fila++;
                        hoja1.Cells[fila, 1] = "Cabecera Comprobante";
                        fila++;
                        //insertamos las cabeceras
                        for (int i = 0; i < 7; i++)
                        {
                            hoja1.Cells[fila, i + 1] = reporte.Columns[i + 1].ColumnName; //titulos cabecera
                            hoja1.Cells[fila + 1, i + 1] = d[i + 1]; //datos de la cabecera
                        }
                        fila = fila + 2; //damos un espacio de 2 filas

                        hoja1.Cells[fila, 1] = "Detalle Comprobante";
                        fila++;

                        //ahora agregamos los titulos del detalle
                        for (int i = 0; i < 7; i++)
                        {
                            hoja1.Cells[fila, i + 1] = reporte.Columns[i + 9].ColumnName;
                        }

                        fila++; //avanzamos 1 fila para insertar el detalle

                        //insertamos el detalle
                        for (int i = 0; i < 7; i++)
                        {
                            hoja1.Cells[fila, i + 1] = d[i + 9];
                        }

                        fila++;

                    }
                    else
                    {

                        for (int i = 0; i < 7; i++)
                        {
                            hoja1.Cells[fila, i + 1] = d[i + 9];
                        }
                        fila++;

                    }
                    prev = idcomprobante;
                    

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Hubo un error..." + ex.Message.ToString());
            }

        }
    }
}
