namespace CONFERENCIAS.View
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.pnlBody = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lbVer = new System.Windows.Forms.Label();
            this.btnInconsistencia = new System.Windows.Forms.Button();
            this.pnlAtivo = new System.Windows.Forms.Panel();
            this.btnErros = new System.Windows.Forms.Button();
            this.btnInteg = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogoff = new System.Windows.Forms.Button();
            this.lbNome = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.btnAgricola = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBody
            // 
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.Color.Black;
            this.pnlBody.Location = new System.Drawing.Point(282, 63);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(727, 779);
            this.pnlBody.TabIndex = 7;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSidebar.BackColor = System.Drawing.Color.Black;
            this.pnlSidebar.Controls.Add(this.btnAgricola);
            this.pnlSidebar.Controls.Add(this.lbVer);
            this.pnlSidebar.Controls.Add(this.btnInconsistencia);
            this.pnlSidebar.Controls.Add(this.pnlAtivo);
            this.pnlSidebar.Controls.Add(this.btnErros);
            this.pnlSidebar.Controls.Add(this.btnInteg);
            this.pnlSidebar.Location = new System.Drawing.Point(12, 24);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(270, 821);
            this.pnlSidebar.TabIndex = 6;
            // 
            // lbVer
            // 
            this.lbVer.AutoSize = true;
            this.lbVer.Font = new System.Drawing.Font("Century Gothic", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVer.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbVer.Location = new System.Drawing.Point(104, 802);
            this.lbVer.Name = "lbVer";
            this.lbVer.Size = new System.Drawing.Size(38, 12);
            this.lbVer.TabIndex = 13;
            this.lbVer.Text = "Ver: 6.3";
            // 
            // btnInconsistencia
            // 
            this.btnInconsistencia.BackColor = System.Drawing.Color.Black;
            this.btnInconsistencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInconsistencia.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnInconsistencia.FlatAppearance.BorderSize = 0;
            this.btnInconsistencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInconsistencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInconsistencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInconsistencia.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInconsistencia.ForeColor = System.Drawing.Color.White;
            this.btnInconsistencia.Image = ((System.Drawing.Image)(resources.GetObject("btnInconsistencia.Image")));
            this.btnInconsistencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInconsistencia.Location = new System.Drawing.Point(11, 496);
            this.btnInconsistencia.Name = "btnInconsistencia";
            this.btnInconsistencia.Size = new System.Drawing.Size(255, 55);
            this.btnInconsistencia.TabIndex = 2;
            this.btnInconsistencia.Text = "&Inconsistências";
            this.btnInconsistencia.UseVisualStyleBackColor = false;
            this.btnInconsistencia.Click += new System.EventHandler(this.btnInconsistencia_Click);
            // 
            // pnlAtivo
            // 
            this.pnlAtivo.BackColor = System.Drawing.Color.Green;
            this.pnlAtivo.Location = new System.Drawing.Point(0, 201);
            this.pnlAtivo.Name = "pnlAtivo";
            this.pnlAtivo.Size = new System.Drawing.Size(10, 55);
            this.pnlAtivo.TabIndex = 0;
            // 
            // btnErros
            // 
            this.btnErros.BackColor = System.Drawing.Color.Black;
            this.btnErros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnErros.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnErros.FlatAppearance.BorderSize = 0;
            this.btnErros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnErros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnErros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErros.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErros.ForeColor = System.Drawing.Color.White;
            this.btnErros.Image = ((System.Drawing.Image)(resources.GetObject("btnErros.Image")));
            this.btnErros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnErros.Location = new System.Drawing.Point(11, 302);
            this.btnErros.Name = "btnErros";
            this.btnErros.Size = new System.Drawing.Size(255, 55);
            this.btnErros.TabIndex = 0;
            this.btnErros.Text = "&Erros Apontamentos";
            this.btnErros.UseVisualStyleBackColor = false;
            this.btnErros.Click += new System.EventHandler(this.btnErros_Click);
            // 
            // btnInteg
            // 
            this.btnInteg.BackColor = System.Drawing.Color.Black;
            this.btnInteg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInteg.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnInteg.FlatAppearance.BorderSize = 0;
            this.btnInteg.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInteg.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInteg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInteg.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInteg.ForeColor = System.Drawing.Color.White;
            this.btnInteg.Image = ((System.Drawing.Image)(resources.GetObject("btnInteg.Image")));
            this.btnInteg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInteg.Location = new System.Drawing.Point(9, 201);
            this.btnInteg.Name = "btnInteg";
            this.btnInteg.Size = new System.Drawing.Size(261, 55);
            this.btnInteg.TabIndex = 0;
            this.btnInteg.Text = "&Integração - PIMS/ADM";
            this.btnInteg.UseVisualStyleBackColor = false;
            this.btnInteg.Click += new System.EventHandler(this.btnInteg_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.btnLogoff);
            this.panel1.Controls.Add(this.lbNome);
            this.panel1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(11, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 45);
            this.panel1.TabIndex = 1;
            // 
            // btnLogoff
            // 
            this.btnLogoff.BackColor = System.Drawing.Color.Black;
            this.btnLogoff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogoff.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnLogoff.FlatAppearance.BorderSize = 0;
            this.btnLogoff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogoff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogoff.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogoff.ForeColor = System.Drawing.Color.White;
            this.btnLogoff.Image = ((System.Drawing.Image)(resources.GetObject("btnLogoff.Image")));
            this.btnLogoff.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoff.Location = new System.Drawing.Point(8, 3);
            this.btnLogoff.Name = "btnLogoff";
            this.btnLogoff.Size = new System.Drawing.Size(50, 39);
            this.btnLogoff.TabIndex = 3;
            this.btnLogoff.UseVisualStyleBackColor = false;
            this.btnLogoff.Click += new System.EventHandler(this.btnLogoff_Click);
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.ForeColor = System.Drawing.Color.LightGray;
            this.lbNome.Location = new System.Drawing.Point(64, 11);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(69, 23);
            this.lbNome.TabIndex = 0;
            this.lbNome.Text = "label2";
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.Black;
            this.pnlHeader.Controls.Add(this.lbTitulo);
            this.pnlHeader.Location = new System.Drawing.Point(282, 24);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(727, 45);
            this.pnlHeader.TabIndex = 8;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTitulo.AutoSize = true;
            this.lbTitulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.ForeColor = System.Drawing.Color.LightGray;
            this.lbTitulo.Location = new System.Drawing.Point(392, 11);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(58, 19);
            this.lbTitulo.TabIndex = 4;
            this.lbTitulo.Text = "label2";
            this.lbTitulo.Visible = false;
            // 
            // btnAgricola
            // 
            this.btnAgricola.BackColor = System.Drawing.Color.Black;
            this.btnAgricola.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgricola.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnAgricola.FlatAppearance.BorderSize = 0;
            this.btnAgricola.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgricola.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnAgricola.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgricola.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgricola.ForeColor = System.Drawing.Color.White;
            this.btnAgricola.Image = ((System.Drawing.Image)(resources.GetObject("btnAgricola.Image")));
            this.btnAgricola.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgricola.Location = new System.Drawing.Point(9, 404);
            this.btnAgricola.Name = "btnAgricola";
            this.btnAgricola.Size = new System.Drawing.Size(255, 55);
            this.btnAgricola.TabIndex = 14;
            this.btnAgricola.Text = "&Agrícola";
            this.btnAgricola.UseVisualStyleBackColor = false;
            this.btnAgricola.Click += new System.EventHandler(this.btnAgricola_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 844);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlSidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMenu";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Tag = "";
            this.Text = "Menu de Conferências";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnInconsistencia;
        private System.Windows.Forms.Panel pnlAtivo;
        private System.Windows.Forms.Button btnErros;
        private System.Windows.Forms.Button btnInteg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.Button btnLogoff;
        public System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.Label lbVer;
        private System.Windows.Forms.Button btnAgricola;
    }
}