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
	public partial class frmInconsistencia : Form
	{
		frmMenu frmMenu;
		public frmInconsistencia(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

		}	
		


		void Consultar()
		{
			try
			{
				if (txtInicio.Text == "__/__/____" || txtFim.Text == "__/__/____")
				{
					MessageBox.Show("PREENCHA CORRETAMENTE OS CAMPOS!");
				}
				else if (txtFrota.Text == string.Empty)
				{
					MessageBox.Show("INFORME O EQUIPAMENTO!");
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

					dgvConsulta.DataSource = inconsistncias();

					dgvConsulta.Columns.Add("descontinuidade", "DESCONTINUIDADE");
					//dgvConsulta.Columns["diferença"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
					dgvConsulta.Columns.Add("status", "STATUS");
					//dgvConsulta.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


					//Laço que faz a diferença da km inicial e km final, e adiciona na Grid

					for (int contador = 1; contador < dgvConsulta.Rows.Count; contador++)
					{
						Int32 diferenca = Convert.ToInt32(dgvConsulta.Rows[contador - 1].Cells[7].Value) - Convert.ToInt32(dgvConsulta.Rows[contador].Cells[6].Value);

						string valor = Convert.ToString(diferenca);
						valor = valor.Insert(valor.Length - 1, ",");

						if (valor == ",0")
						{
							valor = null;
							dgvConsulta.Rows[contador - 1].Cells[9].Value = "OK!";
							//dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.DarkGreen;
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
						}
						else if (valor != ",0")
						{
							dgvConsulta.Rows[contador - 1].Cells[9].Value = "VERIFIQUE!";
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.IndianRed;
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.ForeColor = Color.White;
						}

						dgvConsulta.Rows[contador - 1].Cells[8].Value = valor;

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


		public List<Inconsistncia> inconsistncias() // Método que retorna a conferência dos abastecimentos 
		{

			string qyIncon = "SELECT A.NO_BOLETIM AS BOLETIM, A.DT_OPERACAO AS DATA, A.CD_FUNC AS COD_FUNC, F.DE_FUNC AS FUNCIONARIO, A.CD_EQUIPTO AS COD_EQUIPAMENTO, M.DE_MODELO AS MODELO, B.QT_HK_INICIO AS INICIO, B.QT_HK_FINAL AS FIM FROM PIMSCS.APT_MEC_HE A, PIMSCS.APT_MEC_DE B, PIMSCS.FUNCIONARS F, PIMSCS.MODELOS    M, PIMSCS.EQUIPTOS   E WHERE A.NO_BOLETIM = B.NO_BOLETIM AND A.CD_FUNC = F.CD_FUNC AND E.CD_MODELO = M.CD_MODELO AND E.CD_EQUIPTO = A.CD_EQUIPTO AND A.CD_EQUIPTO = :Frota AND B.FG_TP_APTO = 'M' AND A.DT_OPERACAO >= :DataIni AND A.DT_OPERACAO <= :DataFim ORDER BY A.DT_OPERACAO, B.QT_HK_INICIO";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Frota", txtFrota.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var incon = conn.Query<Inconsistncia>(qyIncon, param).ToList();

				return incon;
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
			
		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			frmMenu.pnlBody.Controls.Clear();
			frmMenuInteg frm = new frmMenuInteg(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frm.Show();
		}


	}

}
