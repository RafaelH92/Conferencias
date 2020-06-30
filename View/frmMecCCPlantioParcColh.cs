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
	public partial class frmMecCCPlantioParcColh : Form
	{
		frmMenu frmMenu;
		public frmMecCCPlantioParcColh(frmMenu form)
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

					dgvConsulta.DataSource = MecCCPlantioParcColh();

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


		public List<MecCCPlantioParcColh> MecCCPlantioParcColh() // Método que retorna a conferência dos erros 
		{

			string qyManu = "SELECT DISTINCT PIMSCS.APT_MEC_HE.DT_OPERACAO DATA,                 APT_MEC_DE.NO_BOLETIM         BOLETIM,                 C.CD_SAFRA                    SAFRA,                 PIMSCS.APT_MEC_HE.CD_FUNC     COD_FUNC,                 PIMSCS.FUNCIONARS.DE_FUNC     FUNCIONARIO,                 PIMSCS.APT_MEC_HE.CD_EQUIPTO  COD_EQUIPAMENTO,                 APT_MEC_DE.CD_CCUSTO          COD_CCUSTO,                 PIMSCS.APT_MEC_DE.CD_OPERACAO COD_OPERACAO,                 C.CD_UPNIVEL1                 COD_PARCERIA,                 A.DA_UPNIVEL1                 PARCERIA,                 C.CD_UPNIVEL3                 TALHAO,                 SAFRUPNIV3.FG_OCORREN         OCORRENCIA,                 PIMSCS.APT_MEC_HE.CD_USR_DML  USUARIO    FROM PIMSCS.UPNIVEL1   A,        PIMSCS.UPNIVEL2,        PIMSCS.UPNIVEL3   C,        PIMSCS.SAFRUPNIV3,        PIMSCS.APT_MEC_DE,        PIMSCS.APT_MEC_HE,        PIMSCS.FUNCIONARS   WHERE A.CD_UPNIVEL1 = UPNIVEL2.CD_UPNIVEL1    AND UPNIVEL2.CD_UPNIVEL1 = C.CD_UPNIVEL1    AND UPNIVEL2.CD_UPNIVEL2 = C.CD_UPNIVEL2    AND C.CD_SAFRA = SAFRUPNIV3.CD_SAFRA    AND C.CD_UPNIVEL1 = SAFRUPNIV3.CD_UPNIVEL1    AND PIMSCS.APT_MEC_HE.CD_FUNC = PIMSCS.FUNCIONARS.CD_FUNC    AND C.CD_UPNIVEL2 = SAFRUPNIV3.CD_UPNIVEL2    AND C.CD_UPNIVEL3 = SAFRUPNIV3.CD_UPNIVEL3    AND PIMSCS.APT_MEC_HE.INSTANCIA = PIMSCS.APT_MEC_DE.INSTANCIA    AND PIMSCS.APT_MEC_HE.FG_TP_APTO = PIMSCS.APT_MEC_DE.FG_TP_APTO    AND PIMSCS.APT_MEC_HE.NO_BOLETIM = PIMSCS.APT_MEC_DE.NO_BOLETIM    AND PIMSCS.SAFRUPNIV3.CD_SAFRA = PIMSCS.APT_MEC_DE.CD_SAFRA    AND PIMSCS.SAFRUPNIV3.CD_UPNIVEL1 = PIMSCS.APT_MEC_DE.CD_UPNIVEL1    AND PIMSCS.SAFRUPNIV3.CD_UPNIVEL2 = PIMSCS.APT_MEC_DE.CD_UPNIVEL2    AND PIMSCS.SAFRUPNIV3.CD_UPNIVEL3 = PIMSCS.APT_MEC_DE.CD_UPNIVEL3    AND PIMSCS.SAFRUPNIV3.CD_REDUZ1 = PIMSCS.APT_MEC_DE.CD_REDUZ1    AND PIMSCS.SAFRUPNIV3.CD_REDUZ2 = PIMSCS.APT_MEC_DE.CD_REDUZ2          AND SAFRUPNIV3.FG_OCORREN IN ('Q')    AND PIMSCS.SAFRUPNIV3.DT_OCORREN >= :DataVeri    AND APT_MEC_DE.CD_CCUSTO IN        (190101, 190102, 190103, 190121, 190122, 190123)    AND APT_MEC_HE.DT_OPERACAO >= :DataIni    AND APT_MEC_HE.DT_OPERACAO <= :DataFim   ORDER BY PIMSCS.C.CD_UPNIVEL1,           C.CD_UPNIVEL3,           PIMSCS.APT_MEC_HE.DT_OPERACAO,           APT_MEC_DE.NO_BOLETIM";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":DataVeri",txtVerif.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroManu = conn.Query<MecCCPlantioParcColh>(qyManu, param).ToList();

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

			frmMecanizadas frm = new frmMecanizadas(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frmMenu.lbTitulo.Text = "ERROS DE APONTAMENTOS MECANIZADOS";

			frm.Show();
		}
	}

}
