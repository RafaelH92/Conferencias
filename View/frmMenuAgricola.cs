/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 26/08/2020          *
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
    public partial class frmMenuAgricola : Form
    {
        frmMenu frmMenu;
        public frmMenuAgricola(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }

        private void btnPerdas_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmPerdas frm = new frmPerdas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "PERDAS MECANIZADAS";
            frmMenu.lbTitulo.Visible = true;
        }

        private void btnBroca_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmBrocas frm = new frmBrocas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "BROCA";
            frmMenu.lbTitulo.Visible = true;
        }
    }
}
