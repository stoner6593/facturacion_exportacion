namespace FinalXML
{
    partial class FrmListaComprobante
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaComprobante));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.txt_numero = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.btn_salir = new DevComponents.DotNetBar.ButtonX();
            this.lb_total_soles = new DevComponents.DotNetBar.LabelX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_buscar = new DevComponents.DotNetBar.ButtonX();
            this.dt_fecha_fin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dt_fechainicio = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cb_estado = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dg_venta = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.idcomprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idrepositorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaemision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documento_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_copiar = new DevComponents.DotNetBar.ButtonX();
            this.btn_anular = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_fin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fechainicio)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_venta)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.txt_numero);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.btn_salir);
            this.panelEx1.Controls.Add(this.lb_total_soles);
            this.panelEx1.Controls.Add(this.groupPanel2);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.Controls.Add(this.btn_copiar);
            this.panelEx1.Controls.Add(this.btn_anular);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(883, 508);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Image = global::FinalXML.Properties.Resources.reportes;
            this.buttonX1.Location = new System.Drawing.Point(562, 388);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(93, 38);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 298;
            this.buttonX1.Text = "Reporte";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // txt_numero
            // 
            this.txt_numero.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.txt_numero.Border.Class = "TextBoxBorder";
            this.txt_numero.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_numero.Location = new System.Drawing.Point(147, 396);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.PreventEnterBeep = true;
            this.txt_numero.Size = new System.Drawing.Size(128, 22);
            this.txt_numero.TabIndex = 297;
            this.txt_numero.TextChanged += new System.EventHandler(this.txt_numero_TextChanged);
            // 
            // labelX4
            // 
            this.labelX4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(30, 395);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(110, 23);
            this.labelX4.TabIndex = 296;
            this.labelX4.Text = "Buscar Comprobante :";
            // 
            // btn_salir
            // 
            this.btn_salir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_salir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_salir.Image = global::FinalXML.Properties.Resources.cancelar;
            this.btn_salir.Location = new System.Drawing.Point(466, 388);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(85, 38);
            this.btn_salir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_salir.TabIndex = 295;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // lb_total_soles
            // 
            this.lb_total_soles.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.lb_total_soles.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lb_total_soles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_total_soles.Location = new System.Drawing.Point(744, 394);
            this.lb_total_soles.Name = "lb_total_soles";
            this.lb_total_soles.Size = new System.Drawing.Size(107, 23);
            this.lb_total_soles.TabIndex = 287;
            this.lb_total_soles.Text = "0.00";
            this.lb_total_soles.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupPanel2
            // 
            this.groupPanel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.btn_buscar);
            this.groupPanel2.Controls.Add(this.dt_fecha_fin);
            this.groupPanel2.Controls.Add(this.labelX1);
            this.groupPanel2.Controls.Add(this.dt_fechainicio);
            this.groupPanel2.Controls.Add(this.labelX2);
            this.groupPanel2.Controls.Add(this.cb_estado);
            this.groupPanel2.Controls.Add(this.labelX8);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(41, 436);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(789, 56);
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
            // 
            // btn_buscar
            // 
            this.btn_buscar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_buscar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_buscar.Image = global::FinalXML.Properties.Resources.buscar;
            this.btn_buscar.Location = new System.Drawing.Point(661, 5);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(91, 41);
            this.btn_buscar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_buscar.TabIndex = 280;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // dt_fecha_fin
            // 
            // 
            // 
            // 
            this.dt_fecha_fin.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt_fecha_fin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fecha_fin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt_fecha_fin.ButtonDropDown.Visible = true;
            this.dt_fecha_fin.IsPopupCalendarOpen = false;
            this.dt_fecha_fin.Location = new System.Drawing.Point(496, 14);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dt_fecha_fin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fecha_fin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt_fecha_fin.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt_fecha_fin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fecha_fin.MonthCalendar.DisplayMonth = new System.DateTime(2018, 5, 1, 0, 0, 0, 0);
            this.dt_fecha_fin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dt_fecha_fin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt_fecha_fin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fecha_fin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt_fecha_fin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fecha_fin.MonthCalendar.TodayButtonVisible = true;
            this.dt_fecha_fin.Name = "dt_fecha_fin";
            this.dt_fecha_fin.Size = new System.Drawing.Size(140, 22);
            this.dt_fecha_fin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt_fecha_fin.TabIndex = 21;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(432, 14);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(58, 23);
            this.labelX1.TabIndex = 20;
            this.labelX1.Text = "Fecha Fin :";
            // 
            // dt_fechainicio
            // 
            // 
            // 
            // 
            this.dt_fechainicio.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dt_fechainicio.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fechainicio.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dt_fechainicio.ButtonDropDown.Visible = true;
            this.dt_fechainicio.IsPopupCalendarOpen = false;
            this.dt_fechainicio.Location = new System.Drawing.Point(282, 14);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dt_fechainicio.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fechainicio.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dt_fechainicio.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dt_fechainicio.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fechainicio.MonthCalendar.DisplayMonth = new System.DateTime(2018, 5, 1, 0, 0, 0, 0);
            this.dt_fechainicio.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dt_fechainicio.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dt_fechainicio.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dt_fechainicio.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dt_fechainicio.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dt_fechainicio.MonthCalendar.TodayButtonVisible = true;
            this.dt_fechainicio.Name = "dt_fechainicio";
            this.dt_fechainicio.Size = new System.Drawing.Size(140, 22);
            this.dt_fechainicio.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dt_fechainicio.TabIndex = 19;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(223, 14);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(49, 23);
            this.labelX2.TabIndex = 18;
            this.labelX2.Text = "Fecha Ini :";
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
            this.cb_estado.Location = new System.Drawing.Point(79, 14);
            this.cb_estado.Name = "cb_estado";
            this.cb_estado.Size = new System.Drawing.Size(134, 22);
            this.cb_estado.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_estado.TabIndex = 17;
            this.cb_estado.SelectedIndexChanged += new System.EventHandler(this.cb_estado_SelectedIndexChanged);
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "REGISTRADO";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "ANULADO";
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(8, 13);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(65, 23);
            this.labelX8.TabIndex = 16;
            this.labelX8.Text = "Estado :";
            this.labelX8.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(684, 395);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(53, 23);
            this.labelX3.TabIndex = 286;
            this.labelX3.Text = "Total  :";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dg_venta);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(859, 370);
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
            this.groupPanel1.Text = "Ventas";
            // 
            // dg_venta
            // 
            this.dg_venta.AllowUserToAddRows = false;
            this.dg_venta.AllowUserToDeleteRows = false;
            this.dg_venta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_venta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_venta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_venta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_venta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_venta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idcomprobante,
            this.idrepositorio,
            this.fechaemision,
            this.cliente,
            this.documento_cliente,
            this.numero,
            this.total,
            this.estado,
            this.idusuario,
            this.nombre});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_venta.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_venta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_venta.EnableHeadersVisualStyles = false;
            this.dg_venta.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_venta.Location = new System.Drawing.Point(0, 0);
            this.dg_venta.MultiSelect = false;
            this.dg_venta.Name = "dg_venta";
            this.dg_venta.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_venta.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_venta.RowHeadersVisible = false;
            this.dg_venta.RowTemplate.Height = 30;
            this.dg_venta.Size = new System.Drawing.Size(853, 347);
            this.dg_venta.TabIndex = 0;
            this.dg_venta.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_venta_CellDoubleClick);
            // 
            // idcomprobante
            // 
            this.idcomprobante.DataPropertyName = "idcomprobante";
            this.idcomprobante.HeaderText = "COD";
            this.idcomprobante.Name = "idcomprobante";
            this.idcomprobante.ReadOnly = true;
            this.idcomprobante.Width = 56;
            // 
            // idrepositorio
            // 
            this.idrepositorio.DataPropertyName = "idrepositorio";
            this.idrepositorio.HeaderText = "COD REPOSITORIO";
            this.idrepositorio.Name = "idrepositorio";
            this.idrepositorio.ReadOnly = true;
            this.idrepositorio.Visible = false;
            this.idrepositorio.Width = 128;
            // 
            // fechaemision
            // 
            this.fechaemision.DataPropertyName = "fechaemision";
            this.fechaemision.HeaderText = "FECHA EMISION";
            this.fechaemision.Name = "fechaemision";
            this.fechaemision.ReadOnly = true;
            this.fechaemision.Width = 105;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "CLIENTE";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 72;
            // 
            // documento_cliente
            // 
            this.documento_cliente.DataPropertyName = "documento_cliente";
            this.documento_cliente.HeaderText = "DOCUMENTO";
            this.documento_cliente.Name = "documento_cliente";
            this.documento_cliente.ReadOnly = true;
            this.documento_cliente.Width = 101;
            // 
            // numero
            // 
            this.numero.DataPropertyName = "numero";
            this.numero.HeaderText = "COMPROBANTE";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            this.numero.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.numero.Width = 113;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 61;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "ESTADO";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 72;
            // 
            // idusuario
            // 
            this.idusuario.DataPropertyName = "idusuario";
            this.idusuario.HeaderText = "COD USUARIO";
            this.idusuario.Name = "idusuario";
            this.idusuario.ReadOnly = true;
            this.idusuario.Visible = false;
            this.idusuario.Width = 98;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "USUARIO";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 80;
            // 
            // btn_copiar
            // 
            this.btn_copiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_copiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_copiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_copiar.Image = global::FinalXML.Properties.Resources.copiar_g;
            this.btn_copiar.Location = new System.Drawing.Point(377, 388);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(80, 38);
            this.btn_copiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_copiar.TabIndex = 282;
            this.btn_copiar.Text = "Copiar";
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click);
            // 
            // btn_anular
            // 
            this.btn_anular.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_anular.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_anular.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_anular.Image = global::FinalXML.Properties.Resources.anular;
            this.btn_anular.Location = new System.Drawing.Point(285, 388);
            this.btn_anular.Name = "btn_anular";
            this.btn_anular.Size = new System.Drawing.Size(83, 38);
            this.btn_anular.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_anular.TabIndex = 281;
            this.btn_anular.Text = "Anular";
            this.btn_anular.Click += new System.EventHandler(this.btn_anular_Click);
            // 
            // FrmListaComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 508);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaComprobante";
            this.Text = "Lista de Comprobantes";
            this.Load += new System.EventHandler(this.FrmListaComprobante_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dt_fecha_fin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_fechainicio)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_venta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.ButtonX btn_buscar;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dt_fecha_fin;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dt_fechainicio;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_estado;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_salir;
        private DevComponents.DotNetBar.LabelX lb_total_soles;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_copiar;
        private DevComponents.DotNetBar.ButtonX btn_anular;
        private DevComponents.DotNetBar.Controls.DataGridViewX dg_venta;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_numero;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.DataGridViewTextBoxColumn idcomprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idrepositorio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaemision;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn documento_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}