namespace FinalXML
{
    partial class FrmMenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            this.btn_item_abrir = new DevComponents.DotNetBar.ButtonItem();
            this.btn_caja_movimiento = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_lista_caja = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_cajas_abiertas = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_cajas_cerradas = new DevComponents.DotNetBar.ButtonItem();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.context_menu_comprobante = new DevComponents.DotNetBar.ContextMenuBar();
            this.btn_item_comprobante = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_emitir_comprobante = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_listar_comprobante = new DevComponents.DotNetBar.ButtonItem();
            this.btn_item_repositorio = new DevComponents.DotNetBar.ButtonItem();
            this.btn_emitir_comprobante = new DevComponents.DotNetBar.ButtonX();
            this.contextbar_caja = new DevComponents.DotNetBar.ContextMenuBar();
            this.btn_item_apertura = new DevComponents.DotNetBar.ButtonItem();
            this.btn_caja = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_usuario = new DevComponents.DotNetBar.ButtonX();
            this.btn_cliente = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.context_menu_comprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contextbar_caja)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_item_abrir
            // 
            this.btn_item_abrir.Name = "btn_item_abrir";
            this.btn_item_abrir.Text = "Apertura";
            this.btn_item_abrir.Click += new System.EventHandler(this.btn_item_abrir_Click);
            // 
            // btn_caja_movimiento
            // 
            this.btn_caja_movimiento.Name = "btn_caja_movimiento";
            this.btn_caja_movimiento.Text = "Caja Movimientos";
            this.btn_caja_movimiento.Click += new System.EventHandler(this.btn_caja_movimiento_Click);
            // 
            // btn_item_lista_caja
            // 
            this.btn_item_lista_caja.Name = "btn_item_lista_caja";
            this.btn_item_lista_caja.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_cajas_abiertas,
            this.btn_item_cajas_cerradas});
            this.btn_item_lista_caja.Text = "Lista de Cajas";
            // 
            // btn_item_cajas_abiertas
            // 
            this.btn_item_cajas_abiertas.Name = "btn_item_cajas_abiertas";
            this.btn_item_cajas_abiertas.Text = "Cajas Abiertas";
            this.btn_item_cajas_abiertas.Click += new System.EventHandler(this.btn_item_cajas_abiertas_Click);
            // 
            // btn_item_cajas_cerradas
            // 
            this.btn_item_cajas_cerradas.Name = "btn_item_cajas_cerradas";
            this.btn_item_cajas_cerradas.Text = "Cajas Cerradas";
            this.btn_item_cajas_cerradas.Click += new System.EventHandler(this.btn_item_cajas_cerradas_Click);
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.context_menu_comprobante);
            this.panelEx1.Controls.Add(this.contextbar_caja);
            this.panelEx1.Controls.Add(this.groupPanel1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(239, 354);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // context_menu_comprobante
            // 
            this.context_menu_comprobante.AntiAlias = true;
            this.context_menu_comprobante.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.context_menu_comprobante.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.context_menu_comprobante.IsMaximized = false;
            this.context_menu_comprobante.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_comprobante});
            this.context_menu_comprobante.Location = new System.Drawing.Point(747, 292);
            this.context_menu_comprobante.Name = "context_menu_comprobante";
            this.context_menu_comprobante.Size = new System.Drawing.Size(112, 25);
            this.context_menu_comprobante.Stretch = true;
            this.context_menu_comprobante.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.context_menu_comprobante.TabIndex = 2;
            this.context_menu_comprobante.TabStop = false;
            this.context_menu_comprobante.Text = "contextMenuBar1";
            // 
            // btn_item_comprobante
            // 
            this.btn_item_comprobante.AutoExpandOnClick = true;
            this.btn_item_comprobante.Name = "btn_item_comprobante";
            this.btn_item_comprobante.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_emitir_comprobante,
            this.btn_item_listar_comprobante,
            this.btn_item_repositorio});
            this.btn_item_comprobante.Text = "Comprobante";
            // 
            // btn_item_emitir_comprobante
            // 
            this.btn_item_emitir_comprobante.Name = "btn_item_emitir_comprobante";
            this.btn_item_emitir_comprobante.Text = "Emitir";
            this.btn_item_emitir_comprobante.Click += new System.EventHandler(this.btn_item_emitir_comprobante_Click);
            // 
            // btn_item_listar_comprobante
            // 
            this.btn_item_listar_comprobante.Name = "btn_item_listar_comprobante";
            this.btn_item_listar_comprobante.Text = "Listar Comprobantes";
            this.btn_item_listar_comprobante.Click += new System.EventHandler(this.btn_item_listar_comprobante_Click);
            // 
            // btn_item_repositorio
            // 
            this.btn_item_repositorio.Name = "btn_item_repositorio";
            this.btn_item_repositorio.Text = "Repositorio";
            this.btn_item_repositorio.Click += new System.EventHandler(this.btn_item_repositorio_Click);
            // 
            // btn_emitir_comprobante
            // 
            this.btn_emitir_comprobante.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_emitir_comprobante.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.context_menu_comprobante.SetContextMenuEx(this.btn_emitir_comprobante, this.btn_item_comprobante);
            this.btn_emitir_comprobante.Image = global::FinalXML.Properties.Resources.venta;
            this.btn_emitir_comprobante.Location = new System.Drawing.Point(13, 80);
            this.btn_emitir_comprobante.Name = "btn_emitir_comprobante";
            this.btn_emitir_comprobante.Size = new System.Drawing.Size(195, 79);
            this.btn_emitir_comprobante.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_emitir_comprobante.TabIndex = 1;
            this.btn_emitir_comprobante.Text = "Comprobante";
            this.btn_emitir_comprobante.Click += new System.EventHandler(this.btn_emitir_comprobante_Click);
            // 
            // contextbar_caja
            // 
            this.contextbar_caja.AntiAlias = true;
            this.contextbar_caja.DockSide = DevComponents.DotNetBar.eDockSide.Document;
            this.contextbar_caja.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.contextbar_caja.IsMaximized = false;
            this.contextbar_caja.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_apertura});
            this.contextbar_caja.Location = new System.Drawing.Point(747, 240);
            this.contextbar_caja.Name = "contextbar_caja";
            this.contextbar_caja.Size = new System.Drawing.Size(75, 25);
            this.contextbar_caja.Stretch = true;
            this.contextbar_caja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.contextbar_caja.TabIndex = 1;
            this.contextbar_caja.TabStop = false;
            this.contextbar_caja.Text = "contextMenuBar1";
            // 
            // btn_item_apertura
            // 
            this.btn_item_apertura.AutoExpandOnClick = true;
            this.btn_item_apertura.Name = "btn_item_apertura";
            this.btn_item_apertura.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btn_item_abrir,
            this.btn_caja_movimiento,
            this.btn_item_lista_caja});
            this.btn_item_apertura.Text = "Apertura";
            // 
            // btn_caja
            // 
            this.btn_caja.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_caja.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.contextbar_caja.SetContextMenuEx(this.btn_caja, this.btn_item_apertura);
            this.btn_caja.Image = global::FinalXML.Properties.Resources.caja;
            this.btn_caja.Location = new System.Drawing.Point(13, 6);
            this.btn_caja.Name = "btn_caja";
            this.btn_caja.Size = new System.Drawing.Size(195, 68);
            this.btn_caja.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_caja.TabIndex = 0;
            this.btn_caja.Text = "Caja";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btn_usuario);
            this.groupPanel1.Controls.Add(this.btn_cliente);
            this.groupPanel1.Controls.Add(this.btn_emitir_comprobante);
            this.groupPanel1.Controls.Add(this.btn_caja);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(4, 3);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(230, 349);
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
            // 
            // btn_usuario
            // 
            this.btn_usuario.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_usuario.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_usuario.Image = global::FinalXML.Properties.Resources.usuario;
            this.btn_usuario.Location = new System.Drawing.Point(13, 251);
            this.btn_usuario.Name = "btn_usuario";
            this.btn_usuario.Size = new System.Drawing.Size(195, 80);
            this.btn_usuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_usuario.TabIndex = 3;
            this.btn_usuario.Text = "Usuario";
            this.btn_usuario.Click += new System.EventHandler(this.btn_usuario_Click);
            // 
            // btn_cliente
            // 
            this.btn_cliente.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cliente.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cliente.Image = global::FinalXML.Properties.Resources.cliente;
            this.btn_cliente.Location = new System.Drawing.Point(13, 165);
            this.btn_cliente.Name = "btn_cliente";
            this.btn_cliente.Size = new System.Drawing.Size(195, 75);
            this.btn_cliente.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cliente.TabIndex = 2;
            this.btn_cliente.Text = "Cliente";
            this.btn_cliente.Click += new System.EventHandler(this.btn_cliente_Click);
            // 
            // FrmMenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 354);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMenuPrincipal";
            this.Text = "Panel";
            this.Load += new System.EventHandler(this.FrmMenuPrincipal_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.context_menu_comprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contextbar_caja)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ContextMenuBar contextbar_caja;
        private DevComponents.DotNetBar.ButtonItem btn_item_apertura;
        private DevComponents.DotNetBar.ButtonX btn_caja;
        private DevComponents.DotNetBar.ButtonItem btn_item_abrir;
        private DevComponents.DotNetBar.ButtonItem btn_caja_movimiento;
        private DevComponents.DotNetBar.ButtonItem btn_item_lista_caja;
        private DevComponents.DotNetBar.ButtonX btn_emitir_comprobante;
        private DevComponents.DotNetBar.ButtonItem btn_item_cajas_abiertas;
        private DevComponents.DotNetBar.ButtonItem btn_item_cajas_cerradas;
        private DevComponents.DotNetBar.ContextMenuBar context_menu_comprobante;
        private DevComponents.DotNetBar.ButtonItem btn_item_comprobante;
        private DevComponents.DotNetBar.ButtonItem btn_item_emitir_comprobante;
        private DevComponents.DotNetBar.ButtonItem btn_item_listar_comprobante;
        private DevComponents.DotNetBar.ButtonItem btn_item_repositorio;
        private DevComponents.DotNetBar.ButtonX btn_cliente;
        private DevComponents.DotNetBar.ButtonX btn_usuario;
    }
}