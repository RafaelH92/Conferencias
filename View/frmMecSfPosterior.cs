/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 25/06/2020          *
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
	public partial class frmMecSfPosterior : Form
	{
		frmMenu frmMenu;
		public frmMecSfPosterior(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

			cbSafra.DataSource = Safras(); // Alimenta o combobox com a consulta das safras, no momento da instanciação do form.
			cbSafra.ValueMember = "SAFRA"; // Seleciona o valor da lista que será exibido no combobox.

		}	
		


		void Consultar()
		{
			try
			{
				if (txtInicio.Text == "__/__/____" || txtFim.Text == "__/__/____")
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

					dgvConsulta.DataSource = MecSfPosterior();

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


		public List<MecSfPosterior> MecSfPosterior() // Método que retorna a conferência dos erros 
		{

			string qyMac = "SELECT PIMSCS.APT_MEC_HE.DT_OPERACAO DATA,        PIMSCS.APT_MEC_HE.NO_BOLETIM  BOLETIM,        PIMSCS.APT_MEC_DE.CD_SAFRA    SAFRA,        PIMSCS.APT_MEC_HE.CD_FUNC     COD_FUNC,        PIMSCS.FUNCIONARS.DE_FUNC     FUNCIONARIO,        PIMSCS.APT_MEC_HE.CD_EQUIPTO  COD_EQUIPAMENTO,               PIMSCS.APT_MEC_DE.CD_CCUSTO   COD_CCUSTO,        PIMSCS.APT_MEC_DE.CD_OPERACAO COD_OPERACAO,        PIMSCS.APT_MEC_DE.CD_UPNIVEL1 COD_PARCERIA,        PIMSCS.UPNIVEL1.DA_UPNIVEL1   PARCERIA,        PIMSCS.APT_MEC_DE.CD_UPNIVEL3 TALHAO,        PIMSCS.APT_MEC_HE.CD_USR_DML  USUARIO    FROM PIMSCS.APT_MEC_DE,        PIMSCS.APT_MEC_HE,        PIMSCS.CCUSTOS,        PIMSCS.OPERACOES,        PIMSCS.UPNIVEL1,        PIMSCS.FUNCIONARS   WHERE PIMSCS.APT_MEC_HE.DT_OPERACAO >= :DataIni    AND PIMSCS.APT_MEC_HE.DT_OPERACAO <= :DataFim    AND PIMSCS.APT_MEC_DE.CD_CCUSTO IN (190105, 190106)    AND PIMSCS.APT_MEC_DE.CD_SAFRA <> :Safra    AND PIMSCS.APT_MEC_HE.CD_FUNC = PIMSCS.FUNCIONARS.CD_FUNC    AND PIMSCS.APT_MEC_HE.FG_TP_APTO = PIMSCS.APT_MEC_DE.FG_TP_APTO    AND PIMSCS.APT_MEC_HE.NO_BOLETIM = PIMSCS.APT_MEC_DE.NO_BOLETIM    AND PIMSCS.APT_MEC_DE.CD_UPNIVEL1 = PIMSCS.UPNIVEL1.CD_UPNIVEL1    AND PIMSCS.APT_MEC_DE.CD_OPERACAO = PIMSCS.OPERACOES.CD_OPERACAO    AND PIMSCS.APT_MEC_DE.CD_CCUSTO = PIMSCS.CCUSTOS.CD_CCUSTO   ORDER BY PIMSCS.APT_MEC_HE.DT_OPERACAO,           PIMSCS.APT_MEC_HE.NO_BOLETIM,           PIMSCS.APT_MEC_DE.CD_UPNIVEL1";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroMec = conn.Query<MecSfPosterior>(qyMac, param).ToList();

				return erroMec;
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

		public List<Safra> Safras() // Método que retorna a conferência das safras 
		{

			string qySafras = "SELECT CD_SAFRA SAFRA FROM PIMSCS.SAFRAS S ORDER BY S.CD_SAFRA DESC";


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var safras = conn.Query<Safra>(qySafras).ToList();

				return safras;
			}
		}
	}


}
