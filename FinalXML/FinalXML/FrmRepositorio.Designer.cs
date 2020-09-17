namespace FinalXML
{
    partial class FrmRepositorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRepositorio));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.ctxtmenu_verdoc = new DevComponents.DotNetBar.ContextMenuBar();
            this.btn_ver = new DevComponents.DotNetBar.ButtonItem();
            this.btn_verxml = new DevComponents.DotNetBar.ButtonItem();
            this.btn_verpdf = new DevComponents.DotNetBar.ButtonItem();
            this.dg_repositorio = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_copiar = new DevComponents.DotNetBar.ButtonX();
            this.btn_buscar = new DevComponents.DotNetBar.ButtonX();
            this.cancelar = new DevComponents.DotNetBar.ButtonX();
            this.btn_enviar = new DevComponents.DotNetBar.ButtonX();
            this.btn_limpiar = new DevComponents.DotNetBar.ButtonX();
            this.cb_estado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.dtp_fecha = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cb_serie = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cb_tipodoc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.repositorioid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocomprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadosunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mensajesunat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombredocxml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutaxml = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombredocpdf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rutapdf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaactualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcorigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariopc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcorigenactualiza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuariopcactualiza = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctxtmenu_verdoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_repositorio)).BeginInit();
            this.groupPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(900, 513);
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
            this.groupPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.ctxtmenu_verdoc);
            this.groupPanel2.Controls.Add(this.groupPanel3);
            this.groupPanel2.Controls.Add(this.cb_estado);
            this.groupPanel2.Controls.Add(this.labelX4);
            this.groupPanel2.Controls.Add(this.dtp_fecha);
            this.groupPanel2.Controls.Add(this.labelX3);
            this.groupPanel2.Controls.Add(this.cb_serie);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.cb_tipodoc);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(13, 379);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(875, 122);
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
            this.groupPanel2.Text = "Filtros";
            // 
            // ctxtmenu_verdoc
            // 
            this.ctxtmenu_verdoc.AntiAlias = true;
            this.ctxtmenu_verdoc.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ctxtmenu_verdoc.IsMaximized = false;
            this.ctxtmenu_verdoc.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_ver});
            this.ctxtmenu_verdoc.Location = new System.Drawing.Point(693, 56);
            this.ctxtmenu_verdoc.Name = "ctxtmenu_verdoc";
            this.ctxtmenu_verdoc.Size = new System.Drawing.Size(133, 25);
            this.ctxtmenu_verdoc.Stretch = true;
            this.ctxtmenu_verdoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ctxtmenu_verdoc.TabIndex = 1;
            this.ctxtmenu_verdoc.TabStop = false;
            this.ctxtmenu_verdoc.Text = "contextMenuBar1";
            // 
            // btn_ver
            // 
            this.btn_ver.AutoExpandOnClick = true;
            this.btn_ver.Name = "btn_ver";
            this.btn_ver.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_verxml,
            this.btn_verpdf});
            this.btn_ver.Text = "ver";
            // 
            // btn_verxml
            // 
            this.btn_verxml.Name = "btn_verxml";
            this.btn_verxml.Text = "Ver Xml";
            this.btn_verxml.Click += new System.EventHandler(this.btn_verxml_Click);
            // 
            // btn_verpdf
            // 
            this.btn_verpdf.Name = "btn_verpdf";
            this.btn_verpdf.Text = "Ver Pdf";
            this.btn_verpdf.Click += new System.EventHandler(this.btn_verpdf_Click);
            // 
            // dg_repositorio
            // 
            this.dg_repositorio.AllowUserToAddRows = false;
            this.dg_repositorio.AllowUserToDeleteRows = false;
            this.dg_repositorio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_repositorio.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_repositorio.BackgroundColor = System.Drawing.Color.White;
            this.dg_repositorio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_repositorio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.repositorioid,
            this.tipocomprobante,
            this.serie,
            this.correlativo,
            this.comprobante,
            this.cliente,
            this.fechaemision,
            this.monto,
            this.estadosunat,
            this.mensajesunat,
            this.nombredocxml,
            this.rutaxml,
            this.nombredocpdf,
            this.rutapdf,
            this.fecharegistro,
            this.fechaactualizacion,
            this.pcorigen,
            this.usuariopc,
            this.pcorigenactualiza,
            this.usuariopcactualiza});
            this.ctxtmenu_verdoc.SetContextMenuEx(this.dg_repositorio, this.btn_ver);
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_repositorio.DefaultCellStyle = dataGridViewCellStyle1;
            this.dg_repositorio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_repositorio.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_repositorio.Location = new System.Drawing.Point(0, 0);
            this.dg_repositorio.Name = "dg_repositorio";
            this.dg_repositorio.ReadOnly = true;
            this.dg_repositorio.RowHeadersVisible = false;
            this.dg_repositorio.Size = new System.Drawing.Size(869, 337);
            this.dg_repositorio.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.btn_copiar);
            this.groupPanel3.Controls.Add(this.btn_buscar);
            this.groupPanel3.Controls.Add(this.cancelar);
            this.groupPanel3.Controls.Add(this.btn_enviar);
            this.groupPanel3.Controls.Add(this.btn_limpiar);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(147, 47);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(509, 45);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel3.TabIndex = 12;
            // 
            // btn_copiar
            // 
            this.btn_copiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_copiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_copiar.Image = global::FinalXML.Properties.Resources.iconcopy1;
            this.btn_copiar.Location = new System.Drawing.Point(204, 8);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(75, 23);
            this.btn_copiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_copiar.TabIndex = 12;
            this.btn_copiar.Text = "Copiar";
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click);
            // 
            // btn_buscar
            // 
            this.btn_buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_buscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_buscar.Image = global::FinalXML.Properties.Resources.examine_24;
            this.btn_buscar.Location = new System.Drawing.Point(16, 8);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_buscar.TabIndex = 8;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // cancelar
            // 
            this.cancelar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.cancelar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.cancelar.Image = global::FinalXML.Properties.Resources.delete1;
            this.cancelar.Location = new System.Drawing.Point(400, 8);
            this.cancelar.Name = "cancelar";
            this.cancelar.Size = new System.Drawing.Size(75, 23);
            this.cancelar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cancelar.TabIndex = 11;
            this.cancelar.Text = "Cancelar";
            this.cancelar.Click += new System.EventHandler(this.cancelar_Click);
            // 
            // btn_enviar
            // 
            this.btn_enviar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_enviar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_enviar.Image = global::FinalXML.Properties.Resources.ok;
            this.btn_enviar.Location = new System.Drawing.Point(109, 8);
            this.btn_enviar.Name = "btn_enviar";
            this.btn_enviar.Size = new System.Drawing.Size(75, 23);
            this.btn_enviar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_enviar.TabIndex = 9;
            this.btn_enviar.Text = "Enviar";
            this.btn_enviar.Click += new System.EventHandler(this.btn_enviar_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_limpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_limpiar.Image = global::FinalXML.Properties.Resources.UI_11_24;
            this.btn_limpiar.Location = new System.Drawing.Point(306, 8);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(75, 23);
            this.btn_limpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_limpiar.TabIndex = 10;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // cb_estado
            // 
            this.cb_estado.DisplayMember = "Text";
            this.cb_estado.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_estado.FormattingEnabled = true;
            this.cb_estado.ItemHeight = 16;
            this.cb_estado.Location = new System.Drawing.Point(693, 4);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(105, 22);
            this.cb_estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_estado.TabIndex = 7;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(643, 2);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(44, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Estado :";
            // 
            // dtp_fecha
            // 
            // 
            // 
            // 
            this.dtp_fecha.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtp_fecha.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_fecha.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtp_fecha.ButtonDropDown.Visible = true;
            this.dtp_fecha.IsPopupCalendarOpen = false;
            this.dtp_fecha.Location = new System.Drawing.Point(510, 3);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtp_fecha.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_fecha.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtp_fecha.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtp_fecha.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_fecha.MonthCalendar.DisplayMonth = new System.DateTime(2018, 4, 1, 0, 0, 0, 0);
            // 
            // 
            // 
            this.dtp_fecha.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtp_fecha.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtp_fecha.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtp_fecha.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtp_fecha.MonthCalendar.TodayButtonVisible = true;
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(110, 22);
            this.dtp_fecha.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtp_fecha.TabIndex = 5;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(460, 2);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(44, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Fecha :";
            // 
            // cb_serie
            // 
            this.cb_serie.DisplayMember = "Text";
            this.cb_serie.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_serie.FormattingEnabled = true;
            this.cb_serie.ItemHeight = 16;
            this.cb_serie.Location = new System.Drawing.Point(355, 3);
            this.cb_serie.Name = "cb_serie";
            this.cb_serie.Size = new System.Drawing.Size(75, 22);
            this.cb_serie.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_serie.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(305, 2);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(44, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Serie :";
            // 
            // cb_tipodoc
            // 
            this.cb_tipodoc.DisplayMember = "Text";
            this.cb_tipodoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tipodoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipodoc.FormattingEnabled = true;
            this.cb_tipodoc.ItemHeight = 16;
            this.cb_tipodoc.Location = new System.Drawing.Point(121, 3);
            this.cb_tipodoc.Name = "cb_tipodoc";
            this.cb_tipodoc.Size = new System.Drawing.Size(162, 22);
            this.cb_tipodoc.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tipodoc.TabIndex = 1;
            this.cb_tipodoc.SelectedIndexChanged += new System.EventHandler(this.cb_tipodoc_SelectedIndexChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(55, 2);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(60, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Tipo Doc :";
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dg_repositorio);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(875, 360);
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
            this.groupPanel1.Text = "Listado de Documentos";
            // 
            // repositorioid
            // 
            this.repositorioid.DataPropertyName = "repositorioid";
            this.repositorioid.HeaderText = "COD";
            this.repositorioid.Name = "repositorioid";
            this.repositorioid.ReadOnly = true;
            this.repositorioid.Width = 56;
            // 
            // tipocomprobante
            // 
            this.tipocomprobante.DataPropertyName = "tipocomprobante";
            this.tipocomprobante.HeaderText = "TIPO DOC";
            this.tipocomprobante.Name = "tipocomprobante";
            this.tipocomprobante.ReadOnly = true;
            this.tipocomprobante.Visible = false;
            this.tipocomprobante.Width = 82;
            // 
            // serie
            // 
            this.serie.DataPropertyName = "serie";
            this.serie.HeaderText = "SERIE";
            this.serie.Name = "serie";
            this.serie.ReadOnly = true;
            this.serie.Width = 60;
            // 
            // correlativo
            // 
            this.correlativo.DataPropertyName = "correlativo";
            this.correlativo.HeaderText = "CORRELATIVO";
            this.correlativo.Name = "correlativo";
            this.correlativo.ReadOnly = true;
            this.correlativo.Width = 103;
            // 
            // comprobante
            // 
            this.comprobante.DataPropertyName = "comprobante";
            this.comprobante.HeaderText = "COMPROBANTE";
            this.comprobante.Name = "comprobante";
            this.comprobante.ReadOnly = true;
            this.comprobante.Width = 113;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "CLIENTE";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 72;
            // 
            // fechaemision
            // 
            this.fechaemision.DataPropertyName = "fechaemision";
            this.fechaemision.HeaderText = "FECHA";
            this.fechaemision.Name = "fechaemision";
            this.fechaemision.ReadOnly = true;
            this.fechaemision.Width = 66;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            this.monto.HeaderText = "MONTO";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 72;
            // 
            // estadosunat
            // 
            this.estadosunat.DataPropertyName = "estadosunat";
            this.estadosunat.HeaderText = "ESTADO";
            this.estadosunat.Name = "estadosunat";
            this.estadosunat.ReadOnly = true;
            this.estadosunat.Width = 72;
            // 
            // mensajesunat
            // 
            this.mensajesunat.DataPropertyName = "mensajesunat";
            this.mensajesunat.HeaderText = "MENSAJE";
            this.mensajesunat.Name = "mensajesunat";
            this.mensajesunat.ReadOnly = true;
            this.mensajesunat.Width = 80;
            // 
            // nombredocxml
            // 
            this.nombredocxml.DataPropertyName = "nombredocxml";
            this.nombredocxml.HeaderText = "NOMBRRE XML";
            this.nombredocxml.Name = "nombredocxml";
            this.nombredocxml.ReadOnly = true;
            this.nombredocxml.Width = 101;
            // 
            // rutaxml
            // 
            this.rutaxml.DataPropertyName = "rutaxml";
            this.rutaxml.HeaderText = "RUTA XML";
            this.rutaxml.Name = "rutaxml";
            this.rutaxml.ReadOnly = true;
            this.rutaxml.Visible = false;
            this.rutaxml.Width = 76;
            // 
            // nombredocpdf
            // 
            this.nombredocpdf.DataPropertyName = "nombredocpdf";
            this.nombredocpdf.HeaderText = "NOMBRE PDF";
            this.nombredocpdf.Name = "nombredocpdf";
            this.nombredocpdf.ReadOnly = true;
            this.nombredocpdf.Width = 94;
            // 
            // rutapdf
            // 
            this.rutapdf.DataPropertyName = "rutapdf";
            this.rutapdf.HeaderText = "RUTA PDF";
            this.rutapdf.Name = "rutapdf";
            this.rutapdf.ReadOnly = true;
            this.rutapdf.Visible = false;
            this.rutapdf.Width = 75;
            // 
            // fecharegistro
            // 
            this.fecharegistro.DataPropertyName = "fecharegistro";
            this.fecharegistro.HeaderText = "FECHAR";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Visible = false;
            this.fecharegistro.Width = 73;
            // 
            // fechaactualizacion
            // 
            this.fechaactualizacion.DataPropertyName = "fechaactualizacion";
            this.fechaactualizacion.HeaderText = "FECHAA";
            this.fechaactualizacion.Name = "fechaactualizacion";
            this.fechaactualizacion.ReadOnly = true;
            this.fechaactualizacion.Visible = false;
            this.fechaactualizacion.Width = 73;
            // 
            // pcorigen
            // 
            this.pcorigen.DataPropertyName = "pcorigen";
            this.pcorigen.HeaderText = "PCORIGEN";
            this.pcorigen.Name = "pcorigen";
            this.pcorigen.ReadOnly = true;
            this.pcorigen.Visible = false;
            this.pcorigen.Width = 86;
            // 
            // usuariopc
            // 
            this.usuariopc.DataPropertyName = "usuariopc";
            this.usuariopc.HeaderText = "USUARIOPC";
            this.usuariopc.Name = "usuariopc";
            this.usuariopc.ReadOnly = true;
            this.usuariopc.Visible = false;
            this.usuariopc.Width = 93;
            // 
            // pcorigenactualiza
            // 
            this.pcorigenactualiza.DataPropertyName = "pcorigenactualiza";
            this.pcorigenactualiza.HeaderText = "PCORIGENACTUALIZA";
            this.pcorigenactualiza.Name = "pcorigenactualiza";
            this.pcorigenactualiza.ReadOnly = true;
            this.pcorigenactualiza.Visible = false;
            this.pcorigenactualiza.Width = 141;
            // 
            // usuariopcactualiza
            // 
            this.usuariopcactualiza.DataPropertyName = "usuariopcactualiza";
            this.usuariopcactualiza.HeaderText = "USUARIOPCACTUALIZA";
            this.usuariopcactualiza.Name = "usuariopcactualiza";
            this.usuariopcactualiza.ReadOnly = true;
            this.usuariopcactualiza.Visible = false;
            this.usuariopcactualiza.Width = 148;
            // 
            // FrmRepositorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 513);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRepositorio";
            this.Text = "Repositorio";
            this.Load += new System.EventHandler(this.FrmRepositorio_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ctxtmenu_verdoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_repositorio)).EndInit();
            this.groupPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtp_fecha)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dg_repositorio;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.ButtonX btn_buscar;
        private DevComponents.DotNetBar.ButtonX cancelar;
        private DevComponents.DotNetBar.ButtonX btn_enviar;
        private DevComponents.DotNetBar.ButtonX btn_limpiar;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_estado;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtp_fecha;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_serie;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_tipodoc;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ContextMenuBar ctxtmenu_verdoc;
        private DevComponents.DotNetBar.ButtonItem btn_ver;
        private DevComponents.DotNetBar.ButtonItem btn_verxml;
        private DevComponents.DotNetBar.ButtonItem btn_verpdf;
        private DevComponents.DotNetBar.ButtonX btn_copiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn repositorioid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocomprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn serie;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadosunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn mensajesunat;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombredocxml;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutaxml;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombredocpdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn rutapdf;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaactualizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcorigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariopc;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcorigenactualiza;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariopcactualiza;
    }
}