namespace CONFERENCIAS.View
{
    partial class frmMenuTransporte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenuTransporte));
            this.btnRateio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConsecutivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRateio
            // 
            this.btnRateio.BackColor = System.Drawing.Color.Black;
            this.btnRateio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRateio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnRateio.FlatAppearance.BorderSize = 0;
            this.btnRateio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRateio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnRateio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRateio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRateio.ForeColor = System.Drawing.Color.White;
            this.btnRateio.Image = ((System.Drawing.Image)(resources.GetObject("btnRateio.Image")));
            this.btnRateio.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnRateio.Location = new System.Drawing.Point(42, 415);
            this.btnRateio.Name = "btnRateio";
            this.btnRateio.Size = new System.Drawing.Size(255, 55);
            this.btnRateio.TabIndex = 4;
            this.btnRateio.Text = "&Rateio Canavieiros";
            this.btnRateio.UseVisualStyleBackColor = false;
            this.btnRateio.Click += new System.EventHandler(this.btnRateio_Click);
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
            // btnConsecutivo
            // 
            this.btnConsecutivo.BackColor = System.Drawing.Color.Black;
            this.btnConsecutivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConsecutivo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnConsecutivo.FlatAppearance.BorderSize = 0;
            this.btnConsecutivo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsecutivo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnConsecutivo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsecutivo.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsecutivo.ForeColor = System.Drawing.Color.White;
            this.btnConsecutivo.Image = ((System.Drawing.Image)(resources.GetObject("btnConsecutivo.Image")));
            this.btnConsecutivo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnConsecutivo.Location = new System.Drawing.Point(303, 414);
            this.btnConsecutivo.Name = "btnConsecutivo";
            this.btnConsecutivo.Size = new System.Drawing.Size(255, 55);
            this.btnConsecutivo.TabIndex = 7;
            this.btnConsecutivo.Text = "&Cargas com Consecutivos Iguais";
            this.btnConsecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsecutivo.UseVisualStyleBackColor = false;
            this.btnConsecutivo.Click += new System.EventHandler(this.btnConsecutivo_Click);
            // 
            // frmMenuTransporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(864, 481);
            this.ControlBox = false;
            this.Controls.Add(this.btnConsecutivo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRateio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMenuTransporte";
            this.Text = "frmMenuTransporte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRateio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConsecutivo;
    }
}