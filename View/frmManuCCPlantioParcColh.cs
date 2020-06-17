/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 04/06/2020          *
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


namespace CONFERENCIAS
{
	public partial class frmManuCCPlantioParcColh : Form
	{
		frmMenu frmMenu;
		public frmManuCCPlantioParcColh(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

		}	
		


		void Consultar()
		{
			try
			{
				if (txtInicio.Text == "__/__/____" || txtFim.Text == "__/__/____" || txtVerif.Text == "__/__/____")
				{
					MessageBox.Show("PREENCHA CORRETAMENTE OS CAMPOS!");
				}
				else if (VerificaDataMenor() == true)
				{
					MessageBox.Show("DATA INICIAL NÃO PODE SER MAIOR QUE A DATA FINAL!");
				}
				else
				{
				
					//-------------------------------------------------------------------

					// Metódo utilizando Dapper

					dgvConsulta.Columns.Clear();

					dgvConsulta.DataSource = manuCCPlantioParcColh();

					//dgvConsulta.Columns.Add("descontinuidade", "DESCONTINUIDADE");
					//dgvConsulta.Columns["diferença"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
					//dgvConsulta.Columns.Add("status", "STATUS");
					//dgvConsulta.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


					//Laço que faz a diferença da km inicial e km final, e adiciona na Grid

					for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador+=2)
					{
						dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.DarkGreen;
						dgvConsulta.Rows[contador - 1].DefaultCellStyle.ForeColor = Color.Silver;

					}

					dgvConsulta.ClearSelection();

					lbDeveloped.Visible = true;
					//lbNome.Visible = true;
					lbRaf.Visible = true;
					lLemail.Visible = true;

				}

			}
			catch (Exception ex)
			{

				MessageBox.Show("OCORREU UM ERRO! " + ex.Message);
			
			}

			
		}


		public List<ManuCCPlantioParcColh> manuCCPlantioParcColh() // Método que retorna a conferência dos erros 
		{

			string qyManu = "SELECT DISTINCT PIMSCS.APT_MANU.NO_BOLETIM  BOLETIM,                 PIMSCS.APT_MANU.DT_OPERACAO DATA,                 PIMSCS.APT_MANU.CD_FUNC     COD_FUNC,                 G.DE_FUNC                   FUNCIONARIO,                 PIMSCS.APT_MANU.CD_CCUSTO   COD_CCUSTO,                 C.DE_CCUSTO                 CCUSTOS,                 PIMSCS.APT_MANU.CD_UPNIVEL1 COD_PARCERIA,                 PIMSCS.UPNIVEL1.DA_UPNIVEL1 PARCERIA,                 PIMSCS.APT_MANU.CD_UPNIVEL3 TALHAO,                 PIMSCS.APT_MANU.CD_OPERACAO COD_OPERACAO,                 D.DE_OPERACAO               OPERACAO    FROM PIMSCS.APT_MANU,        PIMSCS.SAFRUPNIV3,        PIMSCS.FUNCIONARS G,        PIMSCS.UPNIVEL3,        PIMSCS.UPNIVEL1,        PIMSCS.CCUSTOS    C,        PIMSCS.OPERACOES  D   WHERE PIMSCS.APT_MANU.CD_UPNIVEL1 = PIMSCS.SAFRUPNIV3.CD_UPNIVEL1    AND PIMSCS.APT_MANU.CD_UPNIVEL2 = PIMSCS.SAFRUPNIV3.CD_UPNIVEL2    AND PIMSCS.APT_MANU.CD_UPNIVEL3 = PIMSCS.SAFRUPNIV3.CD_UPNIVEL3    AND PIMSCS.APT_MANU.CD_SAFRA = PIMSCS.SAFRUPNIV3.CD_SAFRA    AND PIMSCS.APT_MANU.CD_FUNC = G.CD_FUNC    AND PIMSCS.APT_MANU.CD_UPNIVEL1 = PIMSCS.UPNIVEL1.CD_UPNIVEL1    AND PIMSCS.APT_MANU.CD_CCUSTO = C.CD_CCUSTO    AND PIMSCS.APT_MANU.CD_OPERACAO = D.CD_OPERACAO    AND PIMSCS.SAFRUPNIV3.FG_OCORREN IN ('Q')    AND PIMSCS.APT_MANU.DT_OPERACAO >= :DataIni    AND PIMSCS.APT_MANU.DT_OPERACAO <= :DataFim    AND PIMSCS.SAFRUPNIV3.DT_OCORREN >= :DataVeri    AND PIMSCS.APT_MANU.CD_CCUSTO IN        (190101, 190102, 190103, 190121, 190122, 190123)  ORDER BY PIMSCS.APT_MANU.DT_OPERACAO, PIMSCS.APT_MANU.NO_BOLETIM, PIMSCS.APT_MANU.CD_UPNIVEL1, PIMSCS.APT_MANU.CD_UPNIVEL3 ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":DataVeri",txtVerif.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroManu = conn.Query<ManuCCPlantioParcColh>(qyManu, param).ToList();

				return erroManu;
			}
		}


		public bool VerificaDataMenor() // Verifica se a data inicial é menor que a data inicial
		{
			DateTime dataIni = DateTime.ParseExact(txtInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
			DateTime dataFim = DateTime.ParseExact(txtFim.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));

			if (dataIni > dataFim)
			{
				return true;
			}
			else return false;
		}


		private void btnExecutar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//dgvConsulta.ClearSelection();
		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			frmMenu.pnlBody.Controls.Clear();

			frmManuais frm = new frmManuais(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frmMenu.lbTitulo.Text = "ERROS DE APONTAMENTOS MANUAIS"; 

			frm.Show();
		}
	}

}
