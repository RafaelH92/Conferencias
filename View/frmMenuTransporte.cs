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
    public partial class frmMenuTransporte : Form
    {
        frmMenu frmMenu;
        public frmMenuTransporte(frmMenu form)
        {
            this.frmMenu = form;
            InitializeComponent();
        }


        private void btnMecanizada_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmMecanizadas frm = new frmMecanizadas(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "ERROS DE APONTAMENTOS MECANIZADOS";
            frmMenu.lbTitulo.Visible = true;
        }

        private void btnRateio_Click(object sender, EventArgs e)
        {
            frmMenu.pnlBody.Controls.Clear();

            frmRateio frm = new frmRateio(frmMenu);
            frm.TopLevel = false;
            frmMenu.pnlBody.Controls.Add(frm);

            frm.Show();

            frmMenu.lbTitulo.Text = "RATEIO DOS CAMINHÕES CANAVIEIROS";
            frmMenu.lbTitulo.Visible = true;
        }
    }
}
