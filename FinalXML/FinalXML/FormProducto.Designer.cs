namespace FinalXML
{
    partial class FormProducto
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
            ComponentFactory.Krypton.Toolkit.KryptonLabel nroDocumentoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel tipoDocumentoLabel;
            ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProducto));
            this.kryptonPanel1 = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.btnCancelar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAceptar = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            nroDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            tipoDocumentoLabel = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nroDocumentoLabel
            // 
            nroDocumentoLabel.Location = new System.Drawing.Point(9, 44);
            nroDocumentoLabel.Name = "nroDocumentoLabel";
            nroDocumentoLabel.Size = new System.Drawing.Size(77, 20);
            nroDocumentoLabel.TabIndex = 12;
            nroDocumentoLabel.Values.Text = "Descripción:";
            // 
            // tipoDocumentoLabel
            // 
            tipoDocumentoLabel.Location = new System.Drawing.Point(9, 17);
            tipoDocumentoLabel.Name = "tipoDocumentoLabel";
            tipoDocumentoLabel.Size = new System.Drawing.Size(70, 20);
            tipoDocumentoLabel.TabIndex = 11;
            tipoDocumentoLabel.Values.Text = "Referencia:";
            // 
            // kryptonLabel1
            // 
            kryptonLabel1.Location = new System.Drawing.Point(9, 110);
            kryptonLabel1.Name = "kryptonLabel1";
            kryptonLabel1.Size = new System.Drawing.Size(47, 20);
            kryptonLabel1.TabIndex = 15;
            kryptonLabel1.Values.Text = "Precio:";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.btnCancelar);
            this.kryptonPanel1.Controls.Add(this.btnAceptar);
            this.kryptonPanel1.Controls.Add(this.txtReferencia);
            this.kryptonPanel1.Controls.Add(kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.txtPrecio);
            this.kryptonPanel1.Controls.Add(nroDocumentoLabel);
            this.kryptonPanel1.Controls.Add(tipoDocumentoLabel);
            this.kryptonPanel1.Controls.Add(this.txtDescripcion);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(417, 198);
            this.kryptonPanel1.TabIndex = 16;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(222, 148);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 25);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Values.Image = global::FinalXML.Properties.Resources.cancel;
            this.btnCancelar.Values.Text = "&Cancelar";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(94, 148);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 25);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Values.Image = global::FinalXML.Properties.Resources.ok;
            this.btnAceptar.Values.Text = "&Aceptar";
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(94, 17);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(152, 22);
            this.txtReferencia.TabIndex = 1;
            this.txtReferencia.TextChanged += new System.EventHandler(this.txtReferencia_TextChanged);
            this.txtReferencia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReferencia_KeyPress);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(94, 109);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(152, 22);
            this.txtPrecio.TabIndex = 3;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(94, 43);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(309, 60);
            this.txtDescripcion.TabIndex = 2;
            this.txtDescripcion.TextChanged += new System.EventHandler(this.txtDescripcion_TextChanged);
            this.txtDescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescripcion_KeyPress);
            // 
            // FormProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 198);
            this.Controls.Add(this.kryptonPanel1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProducto";
            this.ShowInTaskbar = false;
            this.Text = "FormProducto";
            this.Load += new System.EventHandler(this.FormProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComponentFactory.Krypton.Toolkit.KryptonPanel kryptonPanel1;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtDescripcion;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancelar;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAceptar;
    }
}