﻿namespace FinalXML
{
    partial class FrmDetalleDocumento
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoPrecioLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel totalVentaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel otroImpuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel impuestoSelectivoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoImpuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel impuestoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel unidadMedidaLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel cantidadLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel precioReferencialLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel precioUnitarioLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel descripcionLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel codigoItemLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel idLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel lblProducto;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleDocumento));
            this.tipoPrecioComboBox = new System.Windows.Forms.ComboBox();
            this.detalleDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipoPrecioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnCalcIsc = new System.Windows.Forms.Button();
            this.btnCalcIgv = new System.Windows.Forms.Button();
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.toolOk = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.totalVentaTextBox = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.otroImpuestoTextBox = new System.Windows.Forms.TextBox();
            this.impuestoSelectivoTextBox = new System.Windows.Forms.TextBox();
            this.tipoImpuestoComboBox = new System.Windows.Forms.ComboBox();
            this.tipoImpuestoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.impuestoTextBox = new System.Windows.Forms.TextBox();
            this.unidadMedidaComboBox = new System.Windows.Forms.ComboBox();
            this.cantidadTextBox = new System.Windows.Forms.TextBox();
            this.precioReferencialTextBox = new System.Windows.Forms.TextBox();
            this.precioUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.descripcionTextBox = new System.Windows.Forms.TextBox();
            this.codigoItemTextBox = new System.Windows.Forms.TextBox();
            this.idNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.txt_servicio = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.cmbPro = new System.Windows.Forms.ComboBox();
            tipoPrecioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            totalVentaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            otroImpuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            impuestoSelectivoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoImpuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            impuestoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            unidadMedidaLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            cantidadLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            precioReferencialLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            precioUnitarioLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            descripcionLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            codigoItemLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            idLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            lblProducto = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).BeginInit();
            this.barraBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tipoPrecioLabel
            // 
            tipoPrecioLabel.Location = new System.Drawing.Point(42, 315);
            tipoPrecioLabel.Name = "tipoPrecioLabel";
            tipoPrecioLabel.Size = new System.Drawing.Size(74, 20);
            tipoPrecioLabel.TabIndex = 56;
            tipoPrecioLabel.Values.Text = "Tipo Precio:";
            // 
            // totalVentaLabel
            // 
            totalVentaLabel.Location = new System.Drawing.Point(41, 503);
            totalVentaLabel.Name = "totalVentaLabel";
            totalVentaLabel.Size = new System.Drawing.Size(75, 20);
            totalVentaLabel.TabIndex = 54;
            totalVentaLabel.Values.Text = "Total Venta:";
            // 
            // otroImpuestoLabel
            // 
            otroImpuestoLabel.Location = new System.Drawing.Point(24, 477);
            otroImpuestoLabel.Name = "otroImpuestoLabel";
            otroImpuestoLabel.Size = new System.Drawing.Size(93, 20);
            otroImpuestoLabel.TabIndex = 53;
            otroImpuestoLabel.Values.Text = "Otro Impuesto:";
            // 
            // impuestoSelectivoLabel
            // 
            impuestoSelectivoLabel.Location = new System.Drawing.Point(0, 446);
            impuestoSelectivoLabel.Name = "impuestoSelectivoLabel";
            impuestoSelectivoLabel.Size = new System.Drawing.Size(116, 20);
            impuestoSelectivoLabel.TabIndex = 52;
            impuestoSelectivoLabel.Values.Text = "Impuesto Selectivo:";
            // 
            // tipoImpuestoLabel
            // 
            tipoImpuestoLabel.Location = new System.Drawing.Point(24, 425);
            tipoImpuestoLabel.Name = "tipoImpuestoLabel";
            tipoImpuestoLabel.Size = new System.Drawing.Size(92, 20);
            tipoImpuestoLabel.TabIndex = 51;
            tipoImpuestoLabel.Values.Text = "Tipo Impuesto:";
            // 
            // impuestoLabel
            // 
            impuestoLabel.Location = new System.Drawing.Point(51, 399);
            impuestoLabel.Name = "impuestoLabel";
            impuestoLabel.Size = new System.Drawing.Size(65, 20);
            impuestoLabel.TabIndex = 50;
            impuestoLabel.Values.Text = "Impuesto:";
            // 
            // unidadMedidaLabel
            // 
            unidadMedidaLabel.Location = new System.Drawing.Point(19, 373);
            unidadMedidaLabel.Name = "unidadMedidaLabel";
            unidadMedidaLabel.Size = new System.Drawing.Size(97, 20);
            unidadMedidaLabel.TabIndex = 46;
            unidadMedidaLabel.Values.Text = "Unidad Medida:";
            // 
            // cantidadLabel
            // 
            cantidadLabel.Location = new System.Drawing.Point(54, 344);
            cantidadLabel.Name = "cantidadLabel";
            cantidadLabel.Size = new System.Drawing.Size(62, 20);
            cantidadLabel.TabIndex = 44;
            cantidadLabel.Values.Text = "Cantidad:";
            // 
            // precioReferencialLabel
            // 
            precioReferencialLabel.Location = new System.Drawing.Point(6, 290);
            precioReferencialLabel.Name = "precioReferencialLabel";
            precioReferencialLabel.Size = new System.Drawing.Size(110, 20);
            precioReferencialLabel.TabIndex = 40;
            precioReferencialLabel.Values.Text = "Precio Referencial:";
            // 
            // precioUnitarioLabel
            // 
            precioUnitarioLabel.Location = new System.Drawing.Point(22, 262);
            precioUnitarioLabel.Name = "precioUnitarioLabel";
            precioUnitarioLabel.Size = new System.Drawing.Size(94, 20);
            precioUnitarioLabel.TabIndex = 37;
            precioUnitarioLabel.Values.Text = "Precio Unitario:";
            // 
            // descripcionLabel
            // 
            descripcionLabel.Location = new System.Drawing.Point(39, 123);
            descripcionLabel.Name = "descripcionLabel";
            descripcionLabel.Size = new System.Drawing.Size(77, 20);
            descripcionLabel.TabIndex = 34;
            descripcionLabel.Values.Text = "Descripcion:";
            // 
            // codigoItemLabel
            // 
            codigoItemLabel.Location = new System.Drawing.Point(247, 93);
            codigoItemLabel.Name = "codigoItemLabel";
            codigoItemLabel.Size = new System.Drawing.Size(81, 20);
            codigoItemLabel.TabIndex = 32;
            codigoItemLabel.Values.Text = "Código Item:";
            // 
            // idLabel
            // 
            idLabel.Location = new System.Drawing.Point(88, 91);
            idLabel.Name = "idLabel";
            idLabel.Size = new System.Drawing.Size(24, 20);
            idLabel.TabIndex = 29;
            idLabel.Values.Text = "Id:";
            // 
            // lblProducto
            // 
            lblProducto.Location = new System.Drawing.Point(50, 32);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new System.Drawing.Size(63, 20);
            lblProducto.TabIndex = 58;
            lblProducto.Values.Text = "Producto:";
            // 
            // tipoPrecioComboBox
            // 
            this.tipoPrecioComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoPrecio", true));
            this.tipoPrecioComboBox.DataSource = this.tipoPrecioBindingSource;
            this.tipoPrecioComboBox.DisplayMember = "Descripcion";
            this.tipoPrecioComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoPrecioComboBox.FormattingEnabled = true;
            this.tipoPrecioComboBox.Location = new System.Drawing.Point(118, 315);
            this.tipoPrecioComboBox.Name = "tipoPrecioComboBox";
            this.tipoPrecioComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoPrecioComboBox.TabIndex = 6;
            this.tipoPrecioComboBox.ValueMember = "Codigo";
            // 
            // detalleDocumentoBindingSource
            // 
            this.detalleDocumentoBindingSource.DataSource = typeof(WinApp.Comun.Dto.Modelos.DetalleDocumento);
            // 
            // tipoPrecioBindingSource
            // 
            this.tipoPrecioBindingSource.DataSource = typeof(WinApp.Entidades.TipoPrecio);
            // 
            // btnCalcIsc
            // 
            this.btnCalcIsc.Location = new System.Drawing.Point(224, 443);
            this.btnCalcIsc.Name = "btnCalcIsc";
            this.btnCalcIsc.Size = new System.Drawing.Size(125, 23);
            this.btnCalcIsc.TabIndex = 13;
            this.btnCalcIsc.Text = "Ca&lcular ISC";
            this.btnCalcIsc.UseVisualStyleBackColor = true;
            this.btnCalcIsc.Click += new System.EventHandler(this.btnCalcIsc_Click);
            // 
            // btnCalcIgv
            // 
            this.btnCalcIgv.Location = new System.Drawing.Point(221, 394);
            this.btnCalcIgv.Name = "btnCalcIgv";
            this.btnCalcIgv.Size = new System.Drawing.Size(125, 23);
            this.btnCalcIgv.TabIndex = 10;
            this.btnCalcIgv.Text = "C&alcular IGV";
            this.btnCalcIgv.UseVisualStyleBackColor = true;
            this.btnCalcIgv.Click += new System.EventHandler(this.btnCalcIgv_Click);
            // 
            // barraBotones
            // 
            this.barraBotones.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOk,
            this.toolCancel});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(575, 25);
            this.barraBotones.TabIndex = 55;
            this.barraBotones.Text = "toolStrip1";
            // 
            // toolOk
            // 
            this.toolOk.Image = global::FinalXML.Properties.Resources.ok;
            this.toolOk.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolOk.Name = "toolOk";
            this.toolOk.Size = new System.Drawing.Size(68, 22);
            this.toolOk.Text = "&Aceptar";
            this.toolOk.Click += new System.EventHandler(this.toolOk_Click);
            // 
            // toolCancel
            // 
            this.toolCancel.Image = global::FinalXML.Properties.Resources.cancel;
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(73, 22);
            this.toolCancel.Text = "&Cancelar";
            this.toolCancel.Click += new System.EventHandler(this.toolCancel_Click);
            // 
            // totalVentaTextBox
            // 
            this.totalVentaTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.totalVentaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "TotalVenta", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.totalVentaTextBox.Location = new System.Drawing.Point(118, 503);
            this.totalVentaTextBox.Name = "totalVentaTextBox";
            this.totalVentaTextBox.ReadOnly = true;
            this.totalVentaTextBox.Size = new System.Drawing.Size(100, 22);
            this.totalVentaTextBox.TabIndex = 15;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.DataSource = this.detalleDocumentoBindingSource;
            // 
            // otroImpuestoTextBox
            // 
            this.otroImpuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "OtroImpuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.otroImpuestoTextBox.Location = new System.Drawing.Point(118, 477);
            this.otroImpuestoTextBox.Name = "otroImpuestoTextBox";
            this.otroImpuestoTextBox.Size = new System.Drawing.Size(100, 22);
            this.otroImpuestoTextBox.TabIndex = 14;
            // 
            // impuestoSelectivoTextBox
            // 
            this.impuestoSelectivoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "ImpuestoSelectivo", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoSelectivoTextBox.Location = new System.Drawing.Point(118, 446);
            this.impuestoSelectivoTextBox.Name = "impuestoSelectivoTextBox";
            this.impuestoSelectivoTextBox.Size = new System.Drawing.Size(100, 22);
            this.impuestoSelectivoTextBox.TabIndex = 12;
            // 
            // tipoImpuestoComboBox
            // 
            this.tipoImpuestoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.detalleDocumentoBindingSource, "TipoImpuesto", true));
            this.tipoImpuestoComboBox.DataSource = this.tipoImpuestoBindingSource;
            this.tipoImpuestoComboBox.DisplayMember = "Descripcion";
            this.tipoImpuestoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoImpuestoComboBox.FormattingEnabled = true;
            this.tipoImpuestoComboBox.Location = new System.Drawing.Point(118, 422);
            this.tipoImpuestoComboBox.Name = "tipoImpuestoComboBox";
            this.tipoImpuestoComboBox.Size = new System.Drawing.Size(240, 21);
            this.tipoImpuestoComboBox.TabIndex = 11;
            this.tipoImpuestoComboBox.ValueMember = "Codigo";
            this.tipoImpuestoComboBox.SelectedIndexChanged += new System.EventHandler(this.tipoImpuestoComboBox_SelectedIndexChanged);
            // 
            // tipoImpuestoBindingSource
            // 
            this.tipoImpuestoBindingSource.DataSource = typeof(WinApp.Entidades.TipoImpuesto);
            // 
            // impuestoTextBox
            // 
            this.impuestoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Impuesto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.impuestoTextBox.Location = new System.Drawing.Point(118, 396);
            this.impuestoTextBox.Name = "impuestoTextBox";
            this.impuestoTextBox.Size = new System.Drawing.Size(100, 22);
            this.impuestoTextBox.TabIndex = 9;
            // 
            // unidadMedidaComboBox
            // 
            this.unidadMedidaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "UnidadMedida", true));
            this.unidadMedidaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.unidadMedidaComboBox.FormattingEnabled = true;
            this.unidadMedidaComboBox.Items.AddRange(new object[] {
            "TNE",
            "NIU",
            "KG",
            "LBR",
            "ONZ",
            "LTR",
            "GLL",
            "SET",
            "ZZ"});
            this.unidadMedidaComboBox.Location = new System.Drawing.Point(118, 369);
            this.unidadMedidaComboBox.Name = "unidadMedidaComboBox";
            this.unidadMedidaComboBox.Size = new System.Drawing.Size(100, 21);
            this.unidadMedidaComboBox.TabIndex = 8;
            // 
            // cantidadTextBox
            // 
            this.cantidadTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Cantidad", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.cantidadTextBox.Location = new System.Drawing.Point(118, 344);
            this.cantidadTextBox.Name = "cantidadTextBox";
            this.cantidadTextBox.Size = new System.Drawing.Size(100, 22);
            this.cantidadTextBox.TabIndex = 7;
            this.cantidadTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cantidadTextBox_KeyDown);
            this.cantidadTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadTextBox_KeyPress);
            // 
            // precioReferencialTextBox
            // 
            this.precioReferencialTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioReferencial", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioReferencialTextBox.Location = new System.Drawing.Point(118, 289);
            this.precioReferencialTextBox.Name = "precioReferencialTextBox";
            this.precioReferencialTextBox.Size = new System.Drawing.Size(100, 22);
            this.precioReferencialTextBox.TabIndex = 5;
            // 
            // precioUnitarioTextBox
            // 
            this.precioUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "PrecioUnitario", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.precioUnitarioTextBox.Location = new System.Drawing.Point(118, 262);
            this.precioUnitarioTextBox.Name = "precioUnitarioTextBox";
            this.precioUnitarioTextBox.Size = new System.Drawing.Size(100, 22);
            this.precioUnitarioTextBox.TabIndex = 4;
            // 
            // descripcionTextBox
            // 
            this.descripcionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "Descripcion", true));
            this.descripcionTextBox.Location = new System.Drawing.Point(118, 123);
            this.descripcionTextBox.MaxLength = 250;
            this.descripcionTextBox.Multiline = true;
            this.descripcionTextBox.Name = "descripcionTextBox";
            this.descripcionTextBox.Size = new System.Drawing.Size(445, 136);
            this.descripcionTextBox.TabIndex = 3;
            this.descripcionTextBox.TextChanged += new System.EventHandler(this.descripcionTextBox_TextChanged);
            this.descripcionTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.descripcionTextBox_KeyPress);
            // 
            // codigoItemTextBox
            // 
            this.codigoItemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.detalleDocumentoBindingSource, "CodigoItem", true));
            this.codigoItemTextBox.Location = new System.Drawing.Point(330, 93);
            this.codigoItemTextBox.Name = "codigoItemTextBox";
            this.codigoItemTextBox.Size = new System.Drawing.Size(151, 22);
            this.codigoItemTextBox.TabIndex = 2;
            // 
            // idNumericUpDown
            // 
            this.idNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.detalleDocumentoBindingSource, "Id", true));
            this.idNumericUpDown.Location = new System.Drawing.Point(118, 91);
            this.idNumericUpDown.Name = "idNumericUpDown";
            this.idNumericUpDown.Size = new System.Drawing.Size(100, 22);
            this.idNumericUpDown.TabIndex = 1;
            this.idNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.txt_servicio);
            this.kryptonPanel1.Controls.Add(this.cmbPro);
            this.kryptonPanel1.Controls.Add(lblProducto);
            this.kryptonPanel1.Controls.Add(idLabel);
            this.kryptonPanel1.Controls.Add(this.idNumericUpDown);
            this.kryptonPanel1.Controls.Add(tipoPrecioLabel);
            this.kryptonPanel1.Controls.Add(this.totalVentaTextBox);
            this.kryptonPanel1.Controls.Add(this.tipoPrecioComboBox);
            this.kryptonPanel1.Controls.Add(totalVentaLabel);
            this.kryptonPanel1.Controls.Add(this.btnCalcIsc);
            this.kryptonPanel1.Controls.Add(this.descripcionTextBox);
            this.kryptonPanel1.Controls.Add(this.btnCalcIgv);
            this.kryptonPanel1.Controls.Add(otroImpuestoLabel);
            this.kryptonPanel1.Controls.Add(this.otroImpuestoTextBox);
            this.kryptonPanel1.Controls.Add(impuestoSelectivoLabel);
            this.kryptonPanel1.Controls.Add(this.impuestoSelectivoTextBox);
            this.kryptonPanel1.Controls.Add(tipoImpuestoLabel);
            this.kryptonPanel1.Controls.Add(this.tipoImpuestoComboBox);
            this.kryptonPanel1.Controls.Add(impuestoLabel);
            this.kryptonPanel1.Controls.Add(this.impuestoTextBox);
            this.kryptonPanel1.Controls.Add(unidadMedidaLabel);
            this.kryptonPanel1.Controls.Add(this.unidadMedidaComboBox);
            this.kryptonPanel1.Controls.Add(cantidadLabel);
            this.kryptonPanel1.Controls.Add(this.cantidadTextBox);
            this.kryptonPanel1.Controls.Add(precioReferencialLabel);
            this.kryptonPanel1.Controls.Add(this.precioReferencialTextBox);
            this.kryptonPanel1.Controls.Add(precioUnitarioLabel);
            this.kryptonPanel1.Controls.Add(this.precioUnitarioTextBox);
            this.kryptonPanel1.Controls.Add(this.codigoItemTextBox);
            this.kryptonPanel1.Controls.Add(descripcionLabel);
            this.kryptonPanel1.Controls.Add(codigoItemLabel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(575, 578);
            this.kryptonPanel1.TabIndex = 57;
            this.kryptonPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.kryptonPanel1_Paint);
            // 
            // txt_servicio
            // 
            // 
            // 
            // 
            this.txt_servicio.Border.Class = "TextBoxBorder";
            this.txt_servicio.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_servicio.Location = new System.Drawing.Point(119, 58);
            this.txt_servicio.Name = "txt_servicio";
            this.txt_servicio.PreventEnterBeep = true;
            this.txt_servicio.Size = new System.Drawing.Size(444, 22);
            this.txt_servicio.TabIndex = 59;
            this.txt_servicio.TextChanged += new System.EventHandler(this.txt_servicio_TextChanged);
            this.txt_servicio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_servicio_KeyUp);
            // 
            // cmbPro
            // 
            this.cmbPro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPro.FormattingEnabled = true;
            this.cmbPro.Location = new System.Drawing.Point(119, 31);
            this.cmbPro.Name = "cmbPro";
            this.cmbPro.Size = new System.Drawing.Size(444, 21);
            this.cmbPro.TabIndex = 16;
            this.cmbPro.SelectedIndexChanged += new System.EventHandler(this.cmbPro_SelectedIndexChanged);
            this.cmbPro.SelectionChangeCommitted += new System.EventHandler(this.cmbPro_SelectionChangeCommitted);
            // 
            // FrmDetalleDocumento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 578);
            this.Controls.Add(this.barraBotones);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetalleDocumento";
            this.ShowInTaskbar = false;
            this.Text = "FrmDetalleDocumento";
            this.Load += new System.EventHandler(this.FrmDetalleDocumento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.detalleDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoPrecioBindingSource)).EndInit();
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoImpuestoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tipoPrecioComboBox;
        private System.Windows.Forms.BindingSource detalleDocumentoBindingSource;
        private System.Windows.Forms.BindingSource tipoPrecioBindingSource;
        private System.Windows.Forms.Button btnCalcIsc;
        private System.Windows.Forms.Button btnCalcIgv;
        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.ToolStripButton toolOk;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.TextBox totalVentaTextBox;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox otroImpuestoTextBox;
        private System.Windows.Forms.TextBox impuestoSelectivoTextBox;
        private System.Windows.Forms.ComboBox tipoImpuestoComboBox;
        private System.Windows.Forms.BindingSource tipoImpuestoBindingSource;
        private System.Windows.Forms.TextBox impuestoTextBox;
        private System.Windows.Forms.ComboBox unidadMedidaComboBox;
        private System.Windows.Forms.TextBox cantidadTextBox;
        private System.Windows.Forms.TextBox precioReferencialTextBox;
        private System.Windows.Forms.TextBox precioUnitarioTextBox;
        private System.Windows.Forms.TextBox descripcionTextBox;
        private System.Windows.Forms.TextBox codigoItemTextBox;
        private System.Windows.Forms.NumericUpDown idNumericUpDown;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.ComboBox cmbPro;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_servicio;
    }
}