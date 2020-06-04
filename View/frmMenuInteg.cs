/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 25/05/2020          *
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
using CONFERENCIAS.Entidades;
using Dapper;
using System.Data.OracleClient;
using CONFERENCIAS.View;

namespace CONFERENCIAS.View
{
    public partial class frmMenuInteg : Form
    {
        frmMenu frmMenu;
        public frmMenuInteg(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }

        private void btnComb_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmConAbast frm = new frmConAbast(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "INTEGRAÇÃO COMBUSTÍVEIS";
            frmMenu.lbTitulo.Visible = true;

        }

        private void btnLub_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmConLub frm = new frmConLub(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "INTEGRAÇÃO PRODUTOS";
            frmMenu.lbTitulo.Visible = true;

        }

        private void btnIStatusIntegracao_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmStatusInteg frm = new frmStatusInteg (frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "STATUS DA INTEGRAÇÃO";
            frmMenu.lbTitulo.Visible = true;
        }
    }
}
