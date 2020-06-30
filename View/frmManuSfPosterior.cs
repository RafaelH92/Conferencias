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
	public partial class frmManuSfPosterior : Form
	{
		frmMenu frmMenu;
		public frmManuSfPosterior(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

			cbSafra.DataSource = safras(); // Alimenta o combobox com a consulta das safras, no momento da instanciação do form.
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

					dgvConsulta.DataSource = manuSfPosterior();

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


		public List<ManuSfPosterior> manuSfPosterior() // Método que retorna a conferência dos erros 
		{

			string qyManu = "SELECT A.NO_BOLETIM              BOLETIM,        A.DT_OPERACAO             DATA,        A.CD_FUNC                 COD_FUNC,        PIMSCS.FUNCIONARS.DE_FUNC FUNCIONARIO,        A.CD_SAFRA                SAFRA,        A.CD_CCUSTO               CCUSTO,        A.CD_UPNIVEL1             COD_PARCERIA,        UPNIVEL1.DA_UPNIVEL1      PARCERIA,        A.CD_UPNIVEL3             AS TALHAO,        A.CD_OPERACAO             COD_OPERACAO,        B.DE_OPERACAO             OPERACAO    FROM PIMSCS.APT_MANU   A,        PIMSCS.OPERACOES  B,        PIMSCS.CCUSTOS,        PIMSCS.UPNIVEL1,        PIMSCS.FUNCIONARS   WHERE A.CD_OPERACAO = B.CD_OPERACAO    AND A.CD_FUNC = PIMSCS.FUNCIONARS.CD_FUNC    AND CCUSTOS.CD_CCUSTO = A.CD_CCUSTO    AND A.CD_UPNIVEL1 = UPNIVEL1.CD_UPNIVEL1    AND A.DT_OPERACAO >= :DataIni    AND A.DT_OPERACAO <= :DataFim    AND A.CD_CCUSTO IN (190105, 190106)    AND A.CD_SAFRA <> :Safra  ORDER BY A.DT_OPERACAO, A.NO_BOLETIM, A.CD_CCUSTO, A.CD_UPNIVEL1";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroManu = conn.Query<ManuSfPosterior>(qyManu, param).ToList();

				return erroManu;
			}
		}

		public List<Safra> safras() // Método que retorna a conferência das safras 
		{

			string qySafras = "SELECT CD_SAFRA SAFRA FROM PIMSCS.SAFRAS S ORDER BY S.CD_SAFRA DESC";

	
			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var safras = conn.Query<Safra>(qySafras).ToList();
				
				return safras;
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
