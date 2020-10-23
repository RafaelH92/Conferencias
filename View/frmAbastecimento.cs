/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 06/06/2020          *
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
    public partial class frmAbastecimento : Form
    {
        frmMenu frmMenu;
        public frmAbastecimento(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }



        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();
            frmMenuErros frm = new frmMenuErros(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Visible = false;
        }

        private void btnAbastDupl_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmAbastDuplicado frm = new frmAbastDuplicado(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APONTAMENTOS DUPLICADOS";
            frm.Show();
        }

        private void btnAbastCC_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmAbastCC frm = new frmAbastCC(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APONTAMENTOS POR CENTRO DE CUSTO";
            frm.Show();
        }

        private void btnAbastLt_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmAbastLt frm = new frmAbastLt(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APONTAMENTOS COM QUANTIDADE MENOR QUE 1 LITRO";
            frm.Show();
        }

        private void btnAbasTan_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmAbastTan frm = new frmAbastTan(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APTOS COM QUANTIDADE MAIOR QUE CAPACIDADE DO TANQUE";
            frm.Show();
        }
    }
}
