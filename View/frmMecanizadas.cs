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
    public partial class frmMecanizadas : Form
    {
        frmMenu frmMenu;
        public frmMecanizadas(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }

        private void btnImplemento_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecOpImplemento frm = new frmMecOpImplemento(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "APONTAMENTOS SEM IMPLEMENTO APONTADO";
            frm.Show();
        }

        private void btnFunc110100_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecFunc110100 frm = new frmMecFunc110100(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "FUNCIONÁRIOS PERTENCENTES AO CC 110100";
            frm.Show();
        }

        private void btnCCUnidades_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecCCEntreposto frm = new frmMecCCEntreposto(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CENTRO DE CUSTO DE UNIDADES";
            frm.Show();
        }

        private void btnTlZero_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecTZero frm = new frmMecTZero(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "TALHÃO IGUAL A ZERO";
            frm.Show();
        }

        private void btnELADiversas_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecELADiversas frm = new frmMecELADiversas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CC DE LAGOA, ESTRADAS E ATERROS COM PARCERIA DIVERSAS";
            frm.Show();
        }

        private void btnCCParcDiv_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecCCCanaParDiv frm = new frmMecCCCanaParDiv(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CENTRO DE CUSTO DA CANA COM PARCERIA DIVERSAS";
            frm.Show();
        }

        private void btnCCAdm_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecCCAdmDifParDiv frm = new frmMecCCAdmDifParDiv(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO ADMINISTRATIVO COM PARCERIA DIFERENTE DE DIVERSAS";
            frm.Show();
        }

        private void btnSafra_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecSfPosterior frm = new frmMecSfPosterior(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "SAFRA DIFERENTE DA ATUAL";
            frm.Show();
        }

        private void btnCCColhNov_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecCCanaParcNovas frm = new frmMecCCanaParcNovas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO COLHEITA/MANEJO COM PARCERIAS NOVAS";
            frm.Show();
        }

        private void btnCCPlanColh_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecCCPlantioParcColh frm = new frmMecCCPlantioParcColh(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "CCUSTO PLANTIO COM PARCERIAS JÁ COLHIDAS";
            frm.Show();
        }

        private void btnEqXIm_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecEquipXImp frm = new frmMecEquipXImp(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "EQUIPAMENTO APONTADO COMO IMPLEMENTO";
            frm.Show();
        }

        private void btnImXEq_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecImpXEquip frm = new frmMecImpXEquip(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "IMPLEMENTO APONTADO COMO EQUIPAMENTO";
            frm.Show();
        }

        private void btnHora_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecHoraOp frm = new frmMecHoraOp(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frmMenu.lbTitulo.Visible = true;
            frmMenu.lbTitulo.Text = "OPERADOR COM MAIS DE 24 HORAS TRABALHADAS";
            frm.Show();
        }
    }
}
