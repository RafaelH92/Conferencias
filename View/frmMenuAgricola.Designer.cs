namespace CONFERENCIAS.View
{
    partial class frmMenuAgricola
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuAgricola));
            this.btnBroca = new System.Windows.Forms.Button();
            this.btnPerdas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBroca
            // 
            this.btnBroca.BackColor = System.Drawing.Color.Black;
            this.btnBroca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBroca.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnBroca.FlatAppearance.BorderSize = 0;
            this.btnBroca.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBroca.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnBroca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBroca.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBroca.ForeColor = System.Drawing.Color.White;
            this.btnBroca.Image = ((System.Drawing.Image)(resources.GetObject("btnBroca.Image")));
            this.btnBroca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBroca.Location = new System.Drawing.Point(374, 367);
            this.btnBroca.Name = "btnBroca";
            this.btnBroca.Size = new System.Drawing.Size(338, 55);
            this.btnBroca.TabIndex = 3;
            this.btnBroca.Text = "&Broca";
            this.btnBroca.UseVisualStyleBackColor = false;
            this.btnBroca.Click += new System.EventHandler(this.btnBroca_Click);
            // 
            // btnPerdas
            // 
            this.btnPerdas.BackColor = System.Drawing.Color.Black;
            this.btnPerdas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPerdas.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnPerdas.FlatAppearance.BorderSize = 0;
            this.btnPerdas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPerdas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPerdas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerdas.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerdas.ForeColor = System.Drawing.Color.White;
            this.btnPerdas.Image = ((System.Drawing.Image)(resources.GetObject("btnPerdas.Image")));
            this.btnPerdas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPerdas.Location = new System.Drawing.Point(39, 367);
            this.btnPerdas.Name = "btnPerdas";
            this.btnPerdas.Size = new System.Drawing.Size(311, 55);
            this.btnPerdas.TabIndex = 4;
            this.btnPerdas.Text = "&Perdas Mecanizadas";
            this.btnPerdas.UseVisualStyleBackColor = false;
            this.btnPerdas.Click += new System.EventHandler(this.btnPerdas_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(52, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Selecione um tipo de conferência abaixo:";
            // 
            // frmMenuAgricola
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(864, 481);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBroca);
            this.Controls.Add(this.btnPerdas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuAgricola";
            this.Text = "frmMenuAgricola";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBroca;
        private System.Windows.Forms.Button btnPerdas;
        private System.Windows.Forms.Label label1;
    }
}