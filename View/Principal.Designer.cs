namespace CONFERENCIAS
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFim = new System.Windows.Forms.MaskedTextBox();
            this.txtInicio = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.rbDiesel500 = new System.Windows.Forms.RadioButton();
            this.rbDiesel10 = new System.Windows.Forms.RadioButton();
            this.rbEtanol = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbDeveloped = new System.Windows.Forms.Label();
            this.lbRaf = new System.Windows.Forms.Label();
            this.lLemail = new System.Windows.Forms.LinkLabel();
            this.lbNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFim);
            this.groupBox1.Controls.Add(this.txtInicio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(101, 97);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(513, 87);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Período:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Inicio\r\n";
            // 
            // txtFim
            // 
            this.txtFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFim.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.Location = new System.Drawing.Point(296, 48);
            this.txtFim.Mask = "00/00/0000";
            this.txtFim.Name = "txtFim";
            this.txtFim.Size = new System.Drawing.Size(127, 23);
            this.txtFim.TabIndex = 2;
            this.txtFim.ValidatingType = typeof(System.DateTime);
            // 
            // txtInicio
            // 
            this.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.Location = new System.Drawing.Point(73, 48);
            this.txtInicio.Mask = "00/00/0000";
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(127, 23);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.ValidatingType = typeof(System.DateTime);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Inicio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnExecutar
            // 
            this.btnExecutar.FlatAppearance.BorderSize = 0;
            this.btnExecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecutar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(117)))), ((int)(((byte)(177)))));
            this.btnExecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnExecutar.Image")));
            this.btnExecutar.Location = new System.Drawing.Point(620, 107);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(182, 77);
            this.btnExecutar.TabIndex = 6;
            this.btnExecutar.Text = "Consultar";
            this.btnExecutar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecutar.UseVisualStyleBackColor = true;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            this.dgvConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.BackgroundColor = System.Drawing.Color.White;
            this.dgvConsulta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(117)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(117)))), ((int)(((byte)(177)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvConsulta.EnableHeadersVisualStyles = false;
            this.dgvConsulta.GridColor = System.Drawing.Color.Silver;
            this.dgvConsulta.Location = new System.Drawing.Point(101, 236);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.ReadOnly = true;
            this.dgvConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvConsulta.RowHeadersVisible = false;
            this.dgvConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsulta.Size = new System.Drawing.Size(701, 487);
            this.dgvConsulta.TabIndex = 4;
            this.dgvConsulta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsulta_CellContentClick);
            // 
            // rbDiesel500
            // 
            this.rbDiesel500.AutoSize = true;
            this.rbDiesel500.Checked = true;
            this.rbDiesel500.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiesel500.Location = new System.Drawing.Point(73, 13);
            this.rbDiesel500.Name = "rbDiesel500";
            this.rbDiesel500.Size = new System.Drawing.Size(104, 21);
            this.rbDiesel500.TabIndex = 8;
            this.rbDiesel500.TabStop = true;
            this.rbDiesel500.Text = "DIESEL B S500";
            this.rbDiesel500.UseVisualStyleBackColor = true;
            // 
            // rbDiesel10
            // 
            this.rbDiesel10.AutoSize = true;
            this.rbDiesel10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiesel10.Location = new System.Drawing.Point(301, 13);
            this.rbDiesel10.Name = "rbDiesel10";
            this.rbDiesel10.Size = new System.Drawing.Size(97, 21);
            this.rbDiesel10.TabIndex = 9;
            this.rbDiesel10.TabStop = true;
            this.rbDiesel10.Text = "DIESEL B S10";
            this.rbDiesel10.UseVisualStyleBackColor = true;
            // 
            // rbEtanol
            // 
            this.rbEtanol.AutoSize = true;
            this.rbEtanol.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEtanol.Location = new System.Drawing.Point(556, 13);
            this.rbEtanol.Name = "rbEtanol";
            this.rbEtanol.Size = new System.Drawing.Size(71, 21);
            this.rbEtanol.TabIndex = 10;
            this.rbEtanol.TabStop = true;
            this.rbEtanol.Text = "ETANOL";
            this.rbEtanol.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbDiesel500);
            this.groupBox2.Controls.Add(this.rbEtanol);
            this.groupBox2.Controls.Add(this.rbDiesel10);
            this.groupBox2.Location = new System.Drawing.Point(101, 190);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(701, 40);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Combustível:";
            // 
            // lbDeveloped
            // 
            this.lbDeveloped.AutoSize = true;
            this.lbDeveloped.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeveloped.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbDeveloped.Location = new System.Drawing.Point(385, 737);
            this.lbDeveloped.Name = "lbDeveloped";
            this.lbDeveloped.Size = new System.Drawing.Size(90, 16);
            this.lbDeveloped.TabIndex = 12;
            this.lbDeveloped.Text = "Developed by:";
            this.lbDeveloped.Visible = false;
            // 
            // lbRaf
            // 
            this.lbRaf.AutoSize = true;
            this.lbRaf.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRaf.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbRaf.Location = new System.Drawing.Point(471, 737);
            this.lbRaf.Name = "lbRaf";
            this.lbRaf.Size = new System.Drawing.Size(90, 15);
            this.lbRaf.TabIndex = 13;
            this.lbRaf.Text = "Rafael H. Souza";
            this.lbRaf.Visible = false;
            // 
            // lLemail
            // 
            this.lLemail.AutoSize = true;
            this.lLemail.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lLemail.LinkColor = System.Drawing.Color.DimGray;
            this.lLemail.Location = new System.Drawing.Point(416, 754);
            this.lLemail.Name = "lLemail";
            this.lLemail.Size = new System.Drawing.Size(108, 13);
            this.lLemail.TabIndex = 14;
            this.lLemail.TabStop = true;
            this.lLemail.Text = "rafaelsrt8@gmail.com";
            this.lLemail.Visible = false;
            // 
            // lbNome
            // 
            this.lbNome.AutoSize = true;
            this.lbNome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNome.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lbNome.Location = new System.Drawing.Point(358, 60);
            this.lbNome.Name = "lbNome";
            this.lbNome.Size = new System.Drawing.Size(54, 18);
            this.lbNome.TabIndex = 15;
            this.lbNome.Text = "label6";
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNome.Location = new System.Drawing.Point(460, 63);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(127, 23);
            this.txtNome.TabIndex = 5;
            this.txtNome.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtNome.ValidatingType = typeof(System.DateTime);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(917, 784);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lbNome);
            this.Controls.Add(this.lLemail);
            this.Controls.Add(this.lbRaf);
            this.Controls.Add(this.lbDeveloped);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.btnExecutar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "frmPrincipal";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Conferências Combustíveis";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtFim;
        private System.Windows.Forms.MaskedTextBox txtInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.RadioButton rbDiesel500;
        private System.Windows.Forms.RadioButton rbDiesel10;
        private System.Windows.Forms.RadioButton rbEtanol;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbDeveloped;
        private System.Windows.Forms.Label lbRaf;
        private System.Windows.Forms.LinkLabel lLemail;
        private System.Windows.Forms.Label lbNome;
        private System.Windows.Forms.MaskedTextBox txtNome;
    }
}

