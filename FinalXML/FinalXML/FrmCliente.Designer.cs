namespace FinalXML
{
    partial class FrmCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCliente));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dg_cliente = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.idcliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipodocumentoidentidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreyapellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codsunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_cargar = new DevComponents.DotNetBar.ButtonX();
            this.btn_limpiar = new DevComponents.DotNetBar.ButtonX();
            this.btn_placa = new DevComponents.DotNetBar.ButtonX();
            this.btn_cancelar = new DevComponents.DotNetBar.ButtonX();
            this.btn_guardar = new DevComponents.DotNetBar.ButtonX();
            this.cb_estado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txt_direccion = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txt_documento = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_razon_social = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cb_tipodoc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_codigo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_cliente)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(820, 493);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dg_cliente);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(12, 220);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(796, 261);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Lista de Clientes";
            // 
            // dg_cliente
            // 
            this.dg_cliente.AllowUserToAddRows = false;
            this.dg_cliente.AllowUserToDeleteRows = false;
            this.dg_cliente.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_cliente.BackgroundColor = System.Drawing.Color.White;
            this.dg_cliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_cliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcliente,
            this.idtipodocumentoidentidad,
            this.nombreyapellido,
            this.documento,
            this.direccion,
            this.descripcion,
            this.codsunat,
            this.estado});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_cliente.DefaultCellStyle = dataGridViewCellStyle1;
            this.dg_cliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_cliente.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_cliente.Location = new System.Drawing.Point(0, 0);
            this.dg_cliente.Name = "dg_cliente";
            this.dg_cliente.ReadOnly = true;
            this.dg_cliente.RowHeadersVisible = false;
            this.dg_cliente.RowTemplate.Height = 30;
            this.dg_cliente.Size = new System.Drawing.Size(790, 238);
            this.dg_cliente.TabIndex = 0;
            this.dg_cliente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_cliente_CellClick);
            this.dg_cliente.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_cliente_CellDoubleClick);
            // 
            // idcliente
            // 
            this.idcliente.DataPropertyName = "idcliente";
            this.idcliente.HeaderText = "COD";
            this.idcliente.Name = "idcliente";
            this.idcliente.ReadOnly = true;
            // 
            // idtipodocumentoidentidad
            // 
            this.idtipodocumentoidentidad.DataPropertyName = "idtipodocumentoidentidad";
            this.idtipodocumentoidentidad.HeaderText = "COD TIPO DOC";
            this.idtipodocumentoidentidad.Name = "idtipodocumentoidentidad";
            this.idtipodocumentoidentidad.ReadOnly = true;
            this.idtipodocumentoidentidad.Visible = false;
            this.idtipodocumentoidentidad.Width = 109;
            // 
            // nombreyapellido
            // 
            this.nombreyapellido.DataPropertyName = "nombreyapellido";
            this.nombreyapellido.HeaderText = "RAZON SOCIAL";
            this.nombreyapellido.Name = "nombreyapellido";
            this.nombreyapellido.ReadOnly = true;
            // 
            // documento
            // 
            this.documento.DataPropertyName = "documento";
            this.documento.HeaderText = "DOCUMENTO";
            this.documento.Name = "documento";
            this.documento.ReadOnly = true;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "DIRECCION";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "DESCRIPCION";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Visible = false;
            this.descripcion.Width = 102;
            // 
            // codsunat
            // 
            this.codsunat.DataPropertyName = "codsunat";
            this.codsunat.HeaderText = "COD SUNAT";
            this.codsunat.Name = "codsunat";
            this.codsunat.ReadOnly = true;
            this.codsunat.Visible = false;
            this.codsunat.Width = 85;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "ESTADO";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btn_cargar);
            this.groupPanel1.Controls.Add(this.btn_limpiar);
            this.groupPanel1.Controls.Add(this.btn_placa);
            this.groupPanel1.Controls.Add(this.btn_cancelar);
            this.groupPanel1.Controls.Add(this.btn_guardar);
            this.groupPanel1.Controls.Add(this.cb_estado);
            this.groupPanel1.Controls.Add(this.labelX6);
            this.groupPanel1.Controls.Add(this.txt_direccion);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txt_documento);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.txt_razon_social);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.cb_tipodoc);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txt_codigo);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(107, 4);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(596, 210);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 0;
            this.groupPanel1.Text = "Datos";
            // 
            // btn_cargar
            // 
            this.btn_cargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cargar.Image = global::FinalXML.Properties.Resources.cargar;
            this.btn_cargar.Location = new System.Drawing.Point(271, 144);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(93, 36);
            this.btn_cargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cargar.TabIndex = 13;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_limpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_limpiar.Image = global::FinalXML.Properties.Resources.limpiar;
            this.btn_limpiar.Location = new System.Drawing.Point(371, 144);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(97, 36);
            this.btn_limpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_limpiar.TabIndex = 14;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_placa
            // 
            this.btn_placa.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_placa.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_placa.Image = global::FinalXML.Properties.Resources.placa1;
            this.btn_placa.Location = new System.Drawing.Point(164, 144);
            this.btn_placa.Name = "btn_placa";
            this.btn_placa.Size = new System.Drawing.Size(97, 36);
            this.btn_placa.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_placa.TabIndex = 15;
            this.btn_placa.Text = "Placa";
            this.btn_placa.Click += new System.EventHandler(this.btn_placa_Click);
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cancelar.Image = global::FinalXML.Properties.Resources.cancelar;
            this.btn_cancelar.Location = new System.Drawing.Point(474, 145);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(93, 35);
            this.btn_cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cancelar.TabIndex = 13;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_guardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_guardar.Image = global::FinalXML.Properties.Resources.guardar;
            this.btn_guardar.Location = new System.Drawing.Point(59, 145);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(95, 35);
            this.btn_guardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_guardar.TabIndex = 12;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // cb_estado
            // 
            this.cb_estado.DisplayMember = "Text";
            this.cb_estado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.ItemHeight = 16;
            this.cb_estado.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cb_estado.Location = new System.Drawing.Point(195, 117);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(169, 22);
            this.cb_estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_estado.TabIndex = 11;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "ACTIVO";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "NO ACTIVO";
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(125, 116);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(52, 23);
            this.labelX6.TabIndex = 10;
            this.labelX6.Text = "Estado :";
            // 
            // txt_direccion
            // 
            // 
            // 
            // 
            this.txt_direccion.Border.Class = "TextBoxBorder";
            this.txt_direccion.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_direccion.Location = new System.Drawing.Point(195, 88);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.PreventEnterBeep = true;
            this.txt_direccion.Size = new System.Drawing.Size(297, 22);
            this.txt_direccion.TabIndex = 9;
            this.txt_direccion.TextChanged += new System.EventHandler(this.txt_direccion_TextChanged);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(116, 90);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(69, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Dirección :";
            // 
            // txt_documento
            // 
            // 
            // 
            // 
            this.txt_documento.Border.Class = "TextBoxBorder";
            this.txt_documento.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_documento.Location = new System.Drawing.Point(195, 60);
            this.txt_documento.Name = "txt_documento";
            this.txt_documento.PreventEnterBeep = true;
            this.txt_documento.Size = new System.Drawing.Size(136, 22);
            this.txt_documento.TabIndex = 7;
            this.txt_documento.TextChanged += new System.EventHandler(this.txt_documento_TextChanged);
            this.txt_documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_documento_KeyPress);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(116, 61);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(69, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Documento :";
            // 
            // txt_razon_social
            // 
            // 
            // 
            // 
            this.txt_razon_social.Border.Class = "TextBoxBorder";
            this.txt_razon_social.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_razon_social.Location = new System.Drawing.Point(195, 32);
            this.txt_razon_social.Name = "txt_razon_social";
            this.txt_razon_social.PreventEnterBeep = true;
            this.txt_razon_social.Size = new System.Drawing.Size(297, 22);
            this.txt_razon_social.TabIndex = 5;
            this.txt_razon_social.TextChanged += new System.EventHandler(this.txt_razon_social_TextChanged);
            this.txt_razon_social.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_razon_social_KeyPress);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(116, 32);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(69, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Razon Social :";
            // 
            // cb_tipodoc
            // 
            this.cb_tipodoc.DisplayMember = "Text";
            this.cb_tipodoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tipodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipodoc.FormattingEnabled = true;
            this.cb_tipodoc.ItemHeight = 16;
            this.cb_tipodoc.Location = new System.Drawing.Point(319, 3);
            this.cb_tipodoc.Name = "cb_tipodoc";
            this.cb_tipodoc.Size = new System.Drawing.Size(173, 22);
            this.cb_tipodoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tipodoc.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(257, 3);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(56, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tipo Doc. :";
            // 
            // txt_codigo
            // 
            this.txt_codigo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_codigo.Border.Class = "TextBoxBorder";
            this.txt_codigo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_codigo.Location = new System.Drawing.Point(195, 3);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.PreventEnterBeep = true;
            this.txt_codigo.ReadOnly = true;
            this.txt_codigo.Size = new System.Drawing.Size(48, 22);
            this.txt_codigo.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(134, 3);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(27, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Cod :";
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 493);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_cliente)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_cargar;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dg_cliente;
        private DevComponents.DotNetBar.ButtonX btn_cancelar;
        private DevComponents.DotNetBar.ButtonX btn_guardar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_estado;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_direccion;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_documento;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_razon_social;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_tipodoc;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_codigo;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX btn_limpiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipodocumentoidentidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreyapellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn codsunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private DevComponents.DotNetBar.ButtonX btn_placa;
    }
}