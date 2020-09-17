namespace FinalXML
{
    partial class FrmCajaMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCajaMovimiento));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txt_total_nota = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.txt_saldo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.txt_t_tarjeta = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_t_transferencia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_t_deposito = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_t_efectivo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txt_cierre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txt_apertura = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btn_salir = new DevComponents.DotNetBar.ButtonX();
            this.btn_copiar = new DevComponents.DotNetBar.ButtonX();
            this.txt_comprobante = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.btn_cerrar_caja = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dg_resultado = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.cajaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cobroid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipocobro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEx1.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_resultado)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.groupPanel3);
            this.panelEx1.Controls.Add(this.btn_salir);
            this.panelEx1.Controls.Add(this.btn_copiar);
            this.panelEx1.Controls.Add(this.txt_comprobante);
            this.panelEx1.Controls.Add(this.labelX9);
            this.panelEx1.Controls.Add(this.btn_cerrar_caja);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(869, 509);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 4;
            // 
            // groupPanel3
            // 
            this.groupPanel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel3.Controls.Add(this.txt_total_nota);
            this.groupPanel3.Controls.Add(this.labelX8);
            this.groupPanel3.Controls.Add(this.txt_saldo);
            this.groupPanel3.Controls.Add(this.labelX7);
            this.groupPanel3.Controls.Add(this.txt_t_tarjeta);
            this.groupPanel3.Controls.Add(this.txt_t_transferencia);
            this.groupPanel3.Controls.Add(this.txt_t_deposito);
            this.groupPanel3.Controls.Add(this.txt_t_efectivo);
            this.groupPanel3.Controls.Add(this.txt_cierre);
            this.groupPanel3.Controls.Add(this.labelX6);
            this.groupPanel3.Controls.Add(this.txt_apertura);
            this.groupPanel3.Controls.Add(this.labelX5);
            this.groupPanel3.Controls.Add(this.labelX1);
            this.groupPanel3.Controls.Add(this.labelX4);
            this.groupPanel3.Controls.Add(this.labelX2);
            this.groupPanel3.Controls.Add(this.labelX3);
            this.groupPanel3.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel3.Location = new System.Drawing.Point(65, 426);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(716, 72);
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
            this.groupPanel3.TabIndex = 3;
            // 
            // txt_total_nota
            // 
            this.txt_total_nota.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_total_nota.Border.Class = "TextBoxBorder";
            this.txt_total_nota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_total_nota.Location = new System.Drawing.Point(619, 35);
            this.txt_total_nota.Name = "txt_total_nota";
            this.txt_total_nota.PreventEnterBeep = true;
            this.txt_total_nota.ReadOnly = true;
            this.txt_total_nota.Size = new System.Drawing.Size(83, 22);
            this.txt_total_nota.TabIndex = 20;
            this.txt_total_nota.Text = "0.00";
            this.txt_total_nota.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(560, 35);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(53, 20);
            this.labelX8.TabIndex = 19;
            this.labelX8.Text = "T.Nota :";
            // 
            // txt_saldo
            // 
            this.txt_saldo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_saldo.Border.Class = "TextBoxBorder";
            this.txt_saldo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_saldo.Location = new System.Drawing.Point(619, 9);
            this.txt_saldo.Name = "txt_saldo";
            this.txt_saldo.PreventEnterBeep = true;
            this.txt_saldo.ReadOnly = true;
            this.txt_saldo.Size = new System.Drawing.Size(83, 22);
            this.txt_saldo.TabIndex = 18;
            this.txt_saldo.Text = "0.00";
            this.txt_saldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(560, 9);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(53, 20);
            this.labelX7.TabIndex = 17;
            this.labelX7.Text = "Saldo :";
            // 
            // txt_t_tarjeta
            // 
            this.txt_t_tarjeta.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_t_tarjeta.Border.Class = "TextBoxBorder";
            this.txt_t_tarjeta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_t_tarjeta.Location = new System.Drawing.Point(275, 35);
            this.txt_t_tarjeta.Name = "txt_t_tarjeta";
            this.txt_t_tarjeta.PreventEnterBeep = true;
            this.txt_t_tarjeta.ReadOnly = true;
            this.txt_t_tarjeta.Size = new System.Drawing.Size(85, 22);
            this.txt_t_tarjeta.TabIndex = 16;
            this.txt_t_tarjeta.Text = "0.00";
            this.txt_t_tarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_t_transferencia
            // 
            this.txt_t_transferencia.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_t_transferencia.Border.Class = "TextBoxBorder";
            this.txt_t_transferencia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_t_transferencia.Location = new System.Drawing.Point(275, 8);
            this.txt_t_transferencia.Name = "txt_t_transferencia";
            this.txt_t_transferencia.PreventEnterBeep = true;
            this.txt_t_transferencia.Size = new System.Drawing.Size(85, 22);
            this.txt_t_transferencia.TabIndex = 15;
            this.txt_t_transferencia.Text = "0.00";
            this.txt_t_transferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_t_deposito
            // 
            this.txt_t_deposito.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_t_deposito.Border.Class = "TextBoxBorder";
            this.txt_t_deposito.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_t_deposito.Location = new System.Drawing.Point(81, 38);
            this.txt_t_deposito.Name = "txt_t_deposito";
            this.txt_t_deposito.PreventEnterBeep = true;
            this.txt_t_deposito.ReadOnly = true;
            this.txt_t_deposito.Size = new System.Drawing.Size(83, 22);
            this.txt_t_deposito.TabIndex = 14;
            this.txt_t_deposito.Text = "0.00";
            this.txt_t_deposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_t_efectivo
            // 
            this.txt_t_efectivo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_t_efectivo.Border.Class = "TextBoxBorder";
            this.txt_t_efectivo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_t_efectivo.Location = new System.Drawing.Point(81, 9);
            this.txt_t_efectivo.Name = "txt_t_efectivo";
            this.txt_t_efectivo.PreventEnterBeep = true;
            this.txt_t_efectivo.ReadOnly = true;
            this.txt_t_efectivo.Size = new System.Drawing.Size(83, 22);
            this.txt_t_efectivo.TabIndex = 13;
            this.txt_t_efectivo.Text = "0.00";
            this.txt_t_efectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_cierre
            // 
            this.txt_cierre.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cierre.Border.Class = "TextBoxBorder";
            this.txt_cierre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cierre.Location = new System.Drawing.Point(461, 35);
            this.txt_cierre.Name = "txt_cierre";
            this.txt_cierre.PreventEnterBeep = true;
            this.txt_cierre.ReadOnly = true;
            this.txt_cierre.Size = new System.Drawing.Size(83, 22);
            this.txt_cierre.TabIndex = 12;
            this.txt_cierre.Text = "0.00";
            this.txt_cierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(390, 32);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(53, 23);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "Cierre :";
            // 
            // txt_apertura
            // 
            this.txt_apertura.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_apertura.Border.Class = "TextBoxBorder";
            this.txt_apertura.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_apertura.Location = new System.Drawing.Point(461, 10);
            this.txt_apertura.Name = "txt_apertura";
            this.txt_apertura.PreventEnterBeep = true;
            this.txt_apertura.ReadOnly = true;
            this.txt_apertura.Size = new System.Drawing.Size(83, 22);
            this.txt_apertura.TabIndex = 10;
            this.txt_apertura.Text = "0.00";
            this.txt_apertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(390, 8);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(53, 23);
            this.labelX5.TabIndex = 9;
            this.labelX5.Text = "Apertura :";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(11, 7);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(64, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "T Efectivo :";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(186, 35);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(68, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "T Tarjeta :";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(6, 32);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(69, 23);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "T Depósito :";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(176, 8);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(92, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "T Transferencia :";
            // 
            // btn_salir
            // 
            this.btn_salir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_salir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_salir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_salir.Image = global::FinalXML.Properties.Resources.cancelar2;
            this.btn_salir.Location = new System.Drawing.Point(598, 376);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(105, 42);
            this.btn_salir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_salir.TabIndex = 295;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_copiar
            // 
            this.btn_copiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_copiar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_copiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_copiar.Image = global::FinalXML.Properties.Resources.copiar_g;
            this.btn_copiar.Location = new System.Drawing.Point(487, 377);
            this.btn_copiar.Name = "btn_copiar";
            this.btn_copiar.Size = new System.Drawing.Size(105, 41);
            this.btn_copiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_copiar.TabIndex = 283;
            this.btn_copiar.Text = "Copiar";
            this.btn_copiar.Click += new System.EventHandler(this.btn_copiar_Click);
            // 
            // txt_comprobante
            // 
            this.txt_comprobante.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.txt_comprobante.Border.Class = "TextBoxBorder";
            this.txt_comprobante.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_comprobante.Location = new System.Drawing.Point(247, 386);
            this.txt_comprobante.Name = "txt_comprobante";
            this.txt_comprobante.PreventEnterBeep = true;
            this.txt_comprobante.Size = new System.Drawing.Size(97, 22);
            this.txt_comprobante.TabIndex = 5;
            this.txt_comprobante.TextChanged += new System.EventHandler(this.txt_comprobante_TextChanged);
            this.txt_comprobante.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_comprobante_KeyPress);
            // 
            // labelX9
            // 
            this.labelX9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(119, 385);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(122, 23);
            this.labelX9.TabIndex = 4;
            this.labelX9.Text = "Buscar Comprobante :";
            // 
            // btn_cerrar_caja
            // 
            this.btn_cerrar_caja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cerrar_caja.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_cerrar_caja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cerrar_caja.Image = global::FinalXML.Properties.Resources.cerrarcaja;
            this.btn_cerrar_caja.Location = new System.Drawing.Point(369, 377);
            this.btn_cerrar_caja.Name = "btn_cerrar_caja";
            this.btn_cerrar_caja.Size = new System.Drawing.Size(112, 41);
            this.btn_cerrar_caja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cerrar_caja.TabIndex = 0;
            this.btn_cerrar_caja.Text = "Cerrar Caja";
            this.btn_cerrar_caja.Click += new System.EventHandler(this.btn_cerrar_caja_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.dg_resultado);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(847, 370);
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
            this.groupPanel1.TabIndex = 2;
            this.groupPanel1.Text = "Movimientos";
            // 
            // dg_resultado
            // 
            this.dg_resultado.AllowUserToAddRows = false;
            this.dg_resultado.AllowUserToDeleteRows = false;
            this.dg_resultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_resultado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_resultado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_resultado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_resultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_resultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cajaid,
            this.cobroid,
            this.concepto,
            this.monto,
            this.descripcion,
            this.cliente,
            this.fecha,
            this.comprobante,
            this.total,
            this.tipocobro,
            this.noperacion,
            this.observacion});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_resultado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dg_resultado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_resultado.EnableHeadersVisualStyles = false;
            this.dg_resultado.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_resultado.Location = new System.Drawing.Point(0, 0);
            this.dg_resultado.Name = "dg_resultado";
            this.dg_resultado.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_resultado.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dg_resultado.RowHeadersVisible = false;
            this.dg_resultado.RowTemplate.Height = 30;
            this.dg_resultado.RowTemplate.ReadOnly = true;
            this.dg_resultado.Size = new System.Drawing.Size(841, 347);
            this.dg_resultado.TabIndex = 0;
            // 
            // cajaid
            // 
            this.cajaid.DataPropertyName = "cajaid";
            this.cajaid.HeaderText = "N° CAJA";
            this.cajaid.Name = "cajaid";
            this.cajaid.ReadOnly = true;
            this.cajaid.Visible = false;
            this.cajaid.Width = 54;
            // 
            // cobroid
            // 
            this.cobroid.DataPropertyName = "cobroid";
            this.cobroid.HeaderText = "COD COBRO";
            this.cobroid.Name = "cobroid";
            this.cobroid.ReadOnly = true;
            this.cobroid.Visible = false;
            this.cobroid.Width = 79;
            // 
            // concepto
            // 
            this.concepto.DataPropertyName = "concepto";
            this.concepto.HeaderText = "CONCEPTO";
            this.concepto.Name = "concepto";
            this.concepto.ReadOnly = true;
            this.concepto.Width = 88;
            // 
            // monto
            // 
            this.monto.DataPropertyName = "monto";
            this.monto.HeaderText = "MONTO";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            this.monto.Width = 72;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "MOVIMIENTO";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 101;
            // 
            // cliente
            // 
            this.cliente.DataPropertyName = "cliente";
            this.cliente.HeaderText = "CLIENTE";
            this.cliente.Name = "cliente";
            this.cliente.ReadOnly = true;
            this.cliente.Width = 72;
            // 
            // fecha
            // 
            this.fecha.DataPropertyName = "fechacobro";
            this.fecha.HeaderText = "FECHA";
            this.fecha.Name = "fecha";
            this.fecha.ReadOnly = true;
            this.fecha.Width = 66;
            // 
            // comprobante
            // 
            this.comprobante.DataPropertyName = "comprobante";
            this.comprobante.HeaderText = "COMPROBANTE";
            this.comprobante.Name = "comprobante";
            this.comprobante.ReadOnly = true;
            this.comprobante.Width = 113;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "TOTAL";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 61;
            // 
            // tipocobro
            // 
            this.tipocobro.DataPropertyName = "tipocobro";
            this.tipocobro.HeaderText = "PAGO CON";
            this.tipocobro.Name = "tipocobro";
            this.tipocobro.ReadOnly = true;
            this.tipocobro.Width = 81;
            // 
            // noperacion
            // 
            this.noperacion.DataPropertyName = "noperacion";
            this.noperacion.HeaderText = "N° OPERACIÓN";
            this.noperacion.Name = "noperacion";
            this.noperacion.ReadOnly = true;
            // 
            // observacion
            // 
            this.observacion.DataPropertyName = "observacion";
            this.observacion.HeaderText = "OBSERVACIÓN";
            this.observacion.Name = "observacion";
            this.observacion.ReadOnly = true;
            this.observacion.Width = 107;
            // 
            // FrmCajaMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 509);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCajaMovimiento";
            this.Text = "Caja Movimientos";
            this.Load += new System.EventHandler(this.FrmCajaMovimiento_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_resultado)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btn_salir;
        private DevComponents.DotNetBar.ButtonX btn_copiar;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_comprobante;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_total_nota;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_saldo;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_t_tarjeta;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_t_transferencia;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_t_deposito;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_t_efectivo;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cierre;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_apertura;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btn_cerrar_caja;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dg_resultado;
        private System.Windows.Forms.DataGridViewTextBoxColumn cajaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn cobroid;
        private System.Windows.Forms.DataGridViewTextBoxColumn concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn comprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipocobro;
        private System.Windows.Forms.DataGridViewTextBoxColumn noperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacion;
    }
}