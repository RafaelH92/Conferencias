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
    }
}
