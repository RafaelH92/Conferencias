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
    public partial class frmManuais : Form
    {
        frmMenu frmMenu;
        public frmManuais(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }

        private void btnManuDupl_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuDuplicado frm = new frmManuDuplicado(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APONTAMENTOS DUPLICADOS";
            frm.Show();
        }

        private void btnFuncSede_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuFuncSede frm = new frmManuFuncSede(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "FUNCIONÁRIOS DA SEDE";
            frm.Show();
        }

        private void btnSafra_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuSfPosterior frm = new frmManuSfPosterior(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "SAFRA DIFERENTE DA ATUAL";
            frm.Show();
        }

        private void btnCCParcDiv_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuParDiversas frm = new frmManuParDiversas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO DA CANA E PARCERIAS DIVERSAS";
            frm.Show();
        }

        private void btnCCAdm_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuCCAdmParDiv frm = new frmManuCCAdmParDiv(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO ADMINISTRATIVOS E PARCERIAS DIVERSAS";
            frm.Show();
        }

        private void btnCCColhNov_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuCCanaParcNovas frm = new frmManuCCanaParcNovas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO COLHEITA/MANEJO COM PARCERIAS NOVAS";
            frm.Show();
        }

        private void btnCCPlanColh_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuCCPlantioParcColh frm = new frmManuCCPlantioParcColh(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO PLANTIO COM PARCERIAS JÁ COLHIDAS";
            frm.Show();
        }

        private void btnVeriManu_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmManuVeriBoletim frm = new frmManuVeriBoletim(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "VERIFICAÇÃO DA SEQUÊNCIA DOS BOLETINS";
            frm.Show();
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
    }
}
