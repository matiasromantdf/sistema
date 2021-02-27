namespace SGI
{
    partial class form_eliminarArticulo
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
            this.txt_codEliminar = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_codEliminar
            // 
            this.txt_codEliminar.Location = new System.Drawing.Point(63, 50);
            this.txt_codEliminar.Name = "txt_codEliminar";
            this.txt_codEliminar.Size = new System.Drawing.Size(267, 20);
            this.txt_codEliminar.TabIndex = 0;
            this.txt_codEliminar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_codEliminar_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // form_eliminarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(571, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_codEliminar);
            this.Name = "form_eliminarArticulo";
            this.Text = "eliminarArticulo";
            this.Load += new System.EventHandler(this.form_eliminarArticulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_eliminarArticulo_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_codEliminar;
        private System.Windows.Forms.Button button1;
    }
}