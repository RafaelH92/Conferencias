﻿namespace CONFERENCIAS
{
    partial class frmConAbast
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConAbast));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnExecutar = new System.Windows.Forms.Button();
            this.dgvConsulta = new System.Windows.Forms.DataGridView();
            this.rbDiesel500 = new System.Windows.Forms.RadioButton();
            this.rbDiesel10 = new System.Windows.Forms.RadioButton();
            this.rbEtanol = new System.Windows.Forms.RadioButton();
            this.lbDeveloped = new System.Windows.Forms.Label();
            this.lbRaf = new System.Windows.Forms.Label();
            this.lLemail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.MaskedTextBox();
            this.txtFim = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Gb1 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).BeginInit();
            this.Gb1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExecutar
            // 
            this.btnExecutar.BackColor = System.Drawing.Color.Black;
            this.btnExecutar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExecutar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SeaGreen;
            this.btnExecutar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnExecutar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecutar.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecutar.ForeColor = System.Drawing.Color.White;
            this.btnExecutar.Image = ((System.Drawing.Image)(resources.GetObject("btnExecutar.Image")));
            this.btnExecutar.Location = new System.Drawing.Point(538, 38);
            this.btnExecutar.Name = "btnExecutar";
            this.btnExecutar.Size = new System.Drawing.Size(234, 96);
            this.btnExecutar.TabIndex = 6;
            this.btnExecutar.Text = "&Consultar!";
            this.btnExecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecutar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecutar.UseVisualStyleBackColor = false;
            this.btnExecutar.Click += new System.EventHandler(this.btnExecutar_Click);
            // 
            // dgvConsulta
            // 
            this.dgvConsulta.AllowUserToAddRows = false;
            this.dgvConsulta.AllowUserToDeleteRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgvConsulta.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvConsulta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvConsulta.BackgroundColor = System.Drawing.Color.Black;
            this.dgvConsulta.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.SeaGreen;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvConsulta.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvConsulta.EnableHeadersVisualStyles = false;
            this.dgvConsulta.GridColor = System.Drawing.Color.Black;
            this.dgvConsulta.Location = new System.Drawing.Point(104, 165);
            this.dgvConsulta.Name = "dgvConsulta";
            this.dgvConsulta.ReadOnly = true;
            this.dgvConsulta.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.Firebrick;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvConsulta.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvConsulta.RowHeadersVisible = false;
            this.dgvConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConsulta.Size = new System.Drawing.Size(1022, 574);
            this.dgvConsulta.TabIndex = 4;
            this.dgvConsulta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConsulta_CellContentClick);
            // 
            // rbDiesel500
            // 
            this.rbDiesel500.AutoSize = true;
            this.rbDiesel500.Checked = true;
            this.rbDiesel500.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiesel500.ForeColor = System.Drawing.Color.Silver;
            this.rbDiesel500.Location = new System.Drawing.Point(17, 19);
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
            this.rbDiesel10.BackColor = System.Drawing.Color.Black;
            this.rbDiesel10.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDiesel10.ForeColor = System.Drawing.Color.Silver;
            this.rbDiesel10.Location = new System.Drawing.Point(17, 46);
            this.rbDiesel10.Name = "rbDiesel10";
            this.rbDiesel10.Size = new System.Drawing.Size(97, 21);
            this.rbDiesel10.TabIndex = 9;
            this.rbDiesel10.TabStop = true;
            this.rbDiesel10.Text = "DIESEL B S10";
            this.rbDiesel10.UseVisualStyleBackColor = false;
            // 
            // rbEtanol
            // 
            this.rbEtanol.AutoSize = true;
            this.rbEtanol.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbEtanol.ForeColor = System.Drawing.Color.Silver;
            this.rbEtanol.Location = new System.Drawing.Point(17, 73);
            this.rbEtanol.Name = "rbEtanol";
            this.rbEtanol.Size = new System.Drawing.Size(71, 21);
            this.rbEtanol.TabIndex = 10;
            this.rbEtanol.TabStop = true;
            this.rbEtanol.Text = "ETANOL";
            this.rbEtanol.UseVisualStyleBackColor = true;
            // 
            // lbDeveloped
            // 
            this.lbDeveloped.AutoSize = true;
            this.lbDeveloped.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeveloped.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbDeveloped.Location = new System.Drawing.Point(457, 755);
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
            this.lbRaf.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbRaf.Location = new System.Drawing.Point(543, 755);
            this.lbRaf.Name = "lbRaf";
            this.lbRaf.Size = new System.Drawing.Size(90, 15);
            this.lbRaf.TabIndex = 13;
            this.lbRaf.Text = "Rafael H. Souza";
            this.lbRaf.Visible = false;
            // 
            // lLemail
            // 
            this.lLemail.AutoSize = true;
            this.lLemail.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLemail.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lLemail.LinkColor = System.Drawing.Color.DimGray;
            this.lLemail.Location = new System.Drawing.Point(484, 771);
            this.lLemail.Name = "lLemail";
            this.lLemail.Size = new System.Drawing.Size(119, 15);
            this.lLemail.TabIndex = 14;
            this.lLemail.TabStop = true;
            this.lLemail.Text = "rafaelsrt8@gmail.com";
            this.lLemail.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data Inicial:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInicio
            // 
            this.txtInicio.BackColor = System.Drawing.Color.Black;
            this.txtInicio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInicio.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInicio.ForeColor = System.Drawing.Color.White;
            this.txtInicio.Location = new System.Drawing.Point(102, 31);
            this.txtInicio.Mask = "00/00/0000";
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(127, 23);
            this.txtInicio.TabIndex = 1;
            this.txtInicio.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtInicio.ValidatingType = typeof(System.DateTime);
            // 
            // txtFim
            // 
            this.txtFim.BackColor = System.Drawing.Color.Black;
            this.txtFim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFim.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFim.ForeColor = System.Drawing.Color.White;
            this.txtFim.Location = new System.Drawing.Point(102, 57);
            this.txtFim.Mask = "00/00/0000";
            this.txtFim.Name = "txtFim";
            this.txtFim.Size = new System.Drawing.Size(127, 23);
            this.txtFim.TabIndex = 2;
            this.txtFim.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            this.txtFim.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Data Final:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Gb1
            // 
            this.Gb1.BackColor = System.Drawing.Color.Black;
            this.Gb1.Controls.Add(this.txtFim);
            this.Gb1.Controls.Add(this.txtInicio);
            this.Gb1.Controls.Add(this.label1);
            this.Gb1.Controls.Add(this.label4);
            this.Gb1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Gb1.ForeColor = System.Drawing.Color.White;
            this.Gb1.Location = new System.Drawing.Point(104, 34);
            this.Gb1.Margin = new System.Windows.Forms.Padding(2);
            this.Gb1.Name = "Gb1";
            this.Gb1.Padding = new System.Windows.Forms.Padding(2);
            this.Gb1.Size = new System.Drawing.Size(273, 100);
            this.Gb1.TabIndex = 18;
            this.Gb1.TabStop = false;
            this.Gb1.Text = "Periodo:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbEtanol);
            this.groupBox1.Controls.Add(this.rbDiesel10);
            this.groupBox1.Controls.Add(this.rbDiesel500);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(382, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 100);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Combustível:";
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.Color.Black;
            this.btnVoltar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.btnVoltar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnVoltar.Image = ((System.Drawing.Image)(resources.GetObject("btnVoltar.Image")));
            this.btnVoltar.Location = new System.Drawing.Point(2, 2);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(71, 37);
            this.btnVoltar.TabIndex = 20;
            this.btnVoltar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // frmConAbast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1079, 802);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Gb1);
            this.Controls.Add(this.lLemail);
            this.Controls.Add(this.lbRaf);
            this.Controls.Add(this.lbDeveloped);
            this.Controls.Add(this.dgvConsulta);
            this.Controls.Add(this.btnExecutar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmConAbast";
            this.Text = "Conferências Combustíveis";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsulta)).EndInit();
            this.Gb1.ResumeLayout(false);
            this.Gb1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExecutar;
        private System.Windows.Forms.DataGridView dgvConsulta;
        private System.Windows.Forms.RadioButton rbDiesel500;
        private System.Windows.Forms.RadioButton rbDiesel10;
        private System.Windows.Forms.RadioButton rbEtanol;
        private System.Windows.Forms.Label lbDeveloped;
        private System.Windows.Forms.Label lbRaf;
        private System.Windows.Forms.LinkLabel lLemail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtInicio;
        private System.Windows.Forms.MaskedTextBox txtFim;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox Gb1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnVoltar;
    }
}

