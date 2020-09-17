namespace FinalXML
{
    partial class FrmUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUsuario));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.dg_usuario = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.idusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idtipousuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cuenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clave = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.btn_salir = new DevComponents.DotNetBar.ButtonX();
            this.btn_limpiar = new DevComponents.DotNetBar.ButtonX();
            this.btn_cargar = new DevComponents.DotNetBar.ButtonX();
            this.btn_guardar = new DevComponents.DotNetBar.ButtonX();
            this.txt_clave = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.txt_cuenta = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txt_nombre = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cb_tipousuario = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txt_cod = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_usuario)).BeginInit();
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
            this.panelEx1.Size = new System.Drawing.Size(703, 444);
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
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.dg_usuario);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(12, 188);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(679, 244);
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
            this.groupPanel2.Text = "Lista Usuarios";
            // 
            // dg_usuario
            // 
            this.dg_usuario.AllowUserToAddRows = false;
            this.dg_usuario.AllowUserToDeleteRows = false;
            this.dg_usuario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dg_usuario.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dg_usuario.BackgroundColor = System.Drawing.Color.White;
            this.dg_usuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_usuario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idusuario,
            this.idtipousuario,
            this.descripcion,
            this.nombre,
            this.cuenta,
            this.clave});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_usuario.DefaultCellStyle = dataGridViewCellStyle1;
            this.dg_usuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dg_usuario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dg_usuario.Location = new System.Drawing.Point(0, 0);
            this.dg_usuario.Name = "dg_usuario";
            this.dg_usuario.ReadOnly = true;
            this.dg_usuario.RowHeadersVisible = false;
            this.dg_usuario.Size = new System.Drawing.Size(673, 221);
            this.dg_usuario.TabIndex = 0;
            this.dg_usuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dg_usuario_CellClick);
            // 
            // idusuario
            // 
            this.idusuario.DataPropertyName = "idusuario";
            this.idusuario.HeaderText = "COD";
            this.idusuario.Name = "idusuario";
            this.idusuario.ReadOnly = true;
            this.idusuario.Width = 56;
            // 
            // idtipousuario
            // 
            this.idtipousuario.DataPropertyName = "idtipousuario";
            this.idtipousuario.HeaderText = "COD TIPO";
            this.idtipousuario.Name = "idtipousuario";
            this.idtipousuario.ReadOnly = true;
            this.idtipousuario.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcion";
            this.descripcion.HeaderText = "TIPO USUARIO";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 97;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "NOMBRE";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 79;
            // 
            // cuenta
            // 
            this.cuenta.DataPropertyName = "cuenta";
            this.cuenta.HeaderText = "CUENTA";
            this.cuenta.Name = "cuenta";
            this.cuenta.ReadOnly = true;
            this.cuenta.Width = 72;
            // 
            // clave
            // 
            this.clave.DataPropertyName = "clave";
            this.clave.HeaderText = "CLAVE";
            this.clave.Name = "clave";
            this.clave.ReadOnly = true;
            this.clave.Width = 63;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.btn_salir);
            this.groupPanel1.Controls.Add(this.btn_limpiar);
            this.groupPanel1.Controls.Add(this.btn_cargar);
            this.groupPanel1.Controls.Add(this.btn_guardar);
            this.groupPanel1.Controls.Add(this.txt_clave);
            this.groupPanel1.Controls.Add(this.labelX5);
            this.groupPanel1.Controls.Add(this.txt_cuenta);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.txt_nombre);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.Controls.Add(this.cb_tipousuario);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.txt_cod);
            this.groupPanel1.Controls.Add(this.labelX1);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(128, 12);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(480, 170);
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
            this.groupPanel1.Text = "Usuario";
            // 
            // btn_salir
            // 
            this.btn_salir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_salir.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_salir.Image = global::FinalXML.Properties.Resources.cancelar;
            this.btn_salir.Location = new System.Drawing.Point(337, 102);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(79, 35);
            this.btn_salir.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_salir.TabIndex = 13;
            this.btn_salir.Text = "Salir";
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);
            // 
            // btn_limpiar
            // 
            this.btn_limpiar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_limpiar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_limpiar.Image = global::FinalXML.Properties.Resources.limpiar;
            this.btn_limpiar.Location = new System.Drawing.Point(242, 102);
            this.btn_limpiar.Name = "btn_limpiar";
            this.btn_limpiar.Size = new System.Drawing.Size(89, 35);
            this.btn_limpiar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_limpiar.TabIndex = 12;
            this.btn_limpiar.Text = "Limpiar";
            this.btn_limpiar.Click += new System.EventHandler(this.btn_limpiar_Click);
            // 
            // btn_cargar
            // 
            this.btn_cargar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_cargar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_cargar.Image = global::FinalXML.Properties.Resources.cargar;
            this.btn_cargar.Location = new System.Drawing.Point(145, 102);
            this.btn_cargar.Name = "btn_cargar";
            this.btn_cargar.Size = new System.Drawing.Size(91, 35);
            this.btn_cargar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_cargar.TabIndex = 11;
            this.btn_cargar.Text = "Cargar";
            this.btn_cargar.Click += new System.EventHandler(this.btn_cargar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btn_guardar.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btn_guardar.Image = global::FinalXML.Properties.Resources.guardar;
            this.btn_guardar.Location = new System.Drawing.Point(43, 102);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(94, 35);
            this.btn_guardar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btn_guardar.TabIndex = 10;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // txt_clave
            // 
            // 
            // 
            // 
            this.txt_clave.Border.Class = "TextBoxBorder";
            this.txt_clave.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_clave.Location = new System.Drawing.Point(275, 71);
            this.txt_clave.Name = "txt_clave";
            this.txt_clave.PreventEnterBeep = true;
            this.txt_clave.Size = new System.Drawing.Size(121, 22);
            this.txt_clave.TabIndex = 9;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(231, 71);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(42, 23);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "Clave :";
            // 
            // txt_cuenta
            // 
            // 
            // 
            // 
            this.txt_cuenta.Border.Class = "TextBoxBorder";
            this.txt_cuenta.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cuenta.Location = new System.Drawing.Point(113, 71);
            this.txt_cuenta.Name = "txt_cuenta";
            this.txt_cuenta.PreventEnterBeep = true;
            this.txt_cuenta.Size = new System.Drawing.Size(113, 22);
            this.txt_cuenta.TabIndex = 7;
            this.txt_cuenta.TextChanged += new System.EventHandler(this.txt_cuenta_TextChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(49, 73);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(49, 23);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Cuenta :";
            // 
            // txt_nombre
            // 
            // 
            // 
            // 
            this.txt_nombre.Border.Class = "TextBoxBorder";
            this.txt_nombre.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_nombre.Location = new System.Drawing.Point(113, 43);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.PreventEnterBeep = true;
            this.txt_nombre.Size = new System.Drawing.Size(283, 22);
            this.txt_nombre.TabIndex = 5;
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(49, 44);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(58, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Nombre :";
            // 
            // cb_tipousuario
            // 
            this.cb_tipousuario.DisplayMember = "Text";
            this.cb_tipousuario.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cb_tipousuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipousuario.FormattingEnabled = true;
            this.cb_tipousuario.ItemHeight = 16;
            this.cb_tipousuario.Location = new System.Drawing.Point(272, 16);
            this.cb_tipousuario.Name = "cb_tipousuario";
            this.cb_tipousuario.Size = new System.Drawing.Size(121, 22);
            this.cb_tipousuario.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cb_tipousuario.TabIndex = 3;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(188, 15);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(81, 23);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "Tipo Usuario :";
            // 
            // txt_cod
            // 
            this.txt_cod.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txt_cod.Border.Class = "TextBoxBorder";
            this.txt_cod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txt_cod.Location = new System.Drawing.Point(113, 15);
            this.txt_cod.Name = "txt_cod";
            this.txt_cod.PreventEnterBeep = true;
            this.txt_cod.ReadOnly = true;
            this.txt_cod.Size = new System.Drawing.Size(54, 22);
            this.txt_cod.TabIndex = 1;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(68, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(39, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "Cod :";
            // 
            // FrmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 444);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUsuario";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.FrmUsuario_Load);
            this.panelEx1.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_usuario)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dg_usuario;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.ButtonX btn_salir;
        private DevComponents.DotNetBar.ButtonX btn_limpiar;
        private DevComponents.DotNetBar.ButtonX btn_cargar;
        private DevComponents.DotNetBar.ButtonX btn_guardar;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_clave;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cuenta;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_nombre;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cb_tipousuario;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txt_cod;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idusuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn idtipousuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn clave;
    }
}