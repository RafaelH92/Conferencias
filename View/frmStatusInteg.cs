/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 28/05/2020          *
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
	public partial class frmStatusInteg : Form
	{
		frmMenu frmMenu;
		public frmStatusInteg(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

		}	
		


		void Consultar()
		{
			try
			{
				{

					if (StatusInteg().Count() == 0) // Verifica se o metodo possui registro
					{

						lbStatus.Visible = true;
						lbStatus.Text = "NÃO EXISTE NENHUM REGISTRO EM PROCESSAMENTO!";
						lbStatus.ForeColor = System.Drawing.Color.Green;
						lbDeveloped.Visible = true;
						//lbNome.Visible = true;
						lbRaf.Visible = true;
						lLemail.Visible = true;

					}
					else
					{

						dgvConsulta.Columns.Clear();

						dgvConsulta.DataSource = StatusInteg();

						//Laço que altera a cor do grid e da fonte

						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.IndianRed;
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.ForeColor = Color.White;
	
						}

						dgvConsulta.ClearSelection();

						lbStatus.Visible = true;
						lbStatus.Text = "ATENÇÃO, EXISTEM REGISTROS EM PROCESSAMENTO, VERIFIQUE!";
						lbStatus.ForeColor = System.Drawing.Color.Red;
						lbDeveloped.Visible = true;

						lbDeveloped.Visible = true;
						//lbNome.Visible = true;
						lbRaf.Visible = true;
						lLemail.Visible = true;

					}

				}

			}
			catch (Exception ex)
			{

				MessageBox.Show("OCORREU UM ERRO! " + ex.Message);
			
			}

			
		}


		public List<StatusInteg> StatusInteg() // Método que retorna o status da integração
		{

			string qyStatus = "SELECT B.COL004N   BOLETIM, DECODE( B.COL002C, 'MI_MANLUBR', 'INDUSTRIA', 'AGRICOLA')   ORIGEM_INTEGRACAO, B.COL028N   EQUIPAMENTO, B.COL007D   MOVIMENTO, B.COL008N   OS_INDUSTRIA, DECODE(  B.COL010C, 'S', 'SAÍDA', 'ESTORNO')  TP_MOVIMENTO, B.COL013C   CODIGO_MATERIAL, M.COL007C   MATERIAL, B.COL014N   QUANTIDADE, B.COL015C   UNIDADE, B.COL024C   MENSAGEM_DE_ERRO FROM  PIMS_INTEG.INT_PIMS_032M B, PIMS_INTEG.INT_PIMS_003C M WHERE B.COL019C = '1' AND  ((B.COL013C = M.COL001C) OR (TO_NUMBER(B.COL013C) = M.COL002N)OR (B.COL006C = M.COL001C)) AND B.COL003C = DECODE('*','*', B.COL003C, '*') ORDER BY 1 ASC";


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ora81_tcp"))
			{
				var statusInteg = conn.Query<StatusInteg>(qyStatus).ToList();

				return statusInteg;
			}

		}


		private void btnExecutar_Click(object sender, EventArgs e)
		{
			Consultar();
		}

		private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			dgvConsulta.ClearSelection();
		}


	}

}
