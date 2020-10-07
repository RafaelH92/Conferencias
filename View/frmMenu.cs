/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 28/05/2020          *
 *************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CONFERENCIAS.View;

namespace CONFERENCIAS.View
{
    public partial class frmMenu : MetroForm
    {
        public frmMenu()
        {
            InitializeComponent();

            //DateTime horaAtual = 

            DateTime dtVencLicenca = DateTime.Parse("28/05/2021");

            DateTime dataatual = DateTime.Today;

            if(dtVencLicenca < dataatual)
            {               
                Environment.Exit(0);
            }

            string userName = System.Environment.UserName;  // Atribui o usuário corrente a variável

            lbNome.Text = userName;

            if (userName == "ferrarini")
            {
                
                lbNome.ForeColor = Color.HotPink;
                lbNome.Font = new Font(lbNome.Font, FontStyle.Bold);
                lbNome.Text = userName;
            }
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnErros_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnErros.Top;

            frmMenuErros frm = new frmMenuErros(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            lbTitulo.Visible = false;
            frm.Show();
        }

        private void btnInteg_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnInteg.Top;

            frmMenuInteg frm = new frmMenuInteg(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            frm.Show();

            //lbTitulo.Text = "SELECIONE UM TIPO DE CONFERENCIA ABAIXO:";
            //lbTitulo.Visible = true;
            lbTitulo.Visible = false;
        }

        private void btnAgricola_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnAgricola.Top;

            frmMenuAgricola frm = new frmMenuAgricola(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            lbTitulo.Visible = false;
            frm.Show();
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnSobre.Top;

            frmSobre frm = new frmSobre(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            lbTitulo.Visible = false;
            frm.Show();
        }

        private void btnFechamento_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnFechamento.Top;

            frmFechamento frm = new frmFechamento(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            lbTitulo.Visible = false;
            frm.Show();
            lbTitulo.Text = "          FECHAMENTO";
            lbTitulo.Visible = true;
            frm.Consultar();
        }

        private void btnTransporte_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnTransporte.Top;

            frmMenuTransporte frm = new frmMenuTransporte(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            lbTitulo.Visible = false;
            frm.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false; //Desabilita o botão de Maximizar do form
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; //Força a aplicação a abrir em "tela cheia" (Maximizado)
        }
    }
    
}
