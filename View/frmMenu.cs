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
                MessageBox.Show("ATENÇÃO! USUÁRIO GAY DETECTADO!");
                lbNome.ForeColor = Color.HotPink;
                lbNome.Font = new Font(lbNome.Font, FontStyle.Bold);
                lbNome.Text = userName;
            }
        }

        void btnAbastec_Click(object sender, EventArgs e)
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

        private void btnLub_Click(object sender, EventArgs e)
        {
            //pnlBody.Controls.Clear();
            //pnlAtivo.Top = btnLub.Top;

            //frmConLub frm = new frmConLub(this);
            //frm.TopLevel = false;
            //pnlBody.Controls.Add(frm);

            //frm.Show();
        }

        private void btnIStatusIntegracao_Click(object sender, EventArgs e)
        {
            pnlBody.Controls.Clear();
            pnlAtivo.Top = btnInconsistencia.Top;

            frmInconsistencia frm = new frmInconsistencia(this);
            frm.TopLevel = false;
            pnlBody.Controls.Add(frm);

            frm.Show();

            lbTitulo.Text = "VERIFICAÇÃO DE INCONSISTÊNCIAS";
            lbTitulo.Visible = true;
        }

        private void btnLogoff_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

    }
}
