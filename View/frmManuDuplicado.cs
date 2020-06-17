﻿/*************************************
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
	public partial class frmManuDuplicado : Form
	{
		frmMenu frmMenu;
		public frmManuDuplicado(frmMenu form)
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
				else if (VerificaDataMenor() == true)
				{
					MessageBox.Show("DATA INICIAL NÃO PODE SER MAIOR QUE A DATA FINAL!");
				}
				else
				{
				
					//-------------------------------------------------------------------

					// Metódo utilizando Dapper

					dgvConsulta.Columns.Clear();

					dgvConsulta.DataSource = ManuDuplicados();

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


		public List<ManuDuplicados> ManuDuplicados() // Método que retorna a conferência dos erros 
		{

			string qyManu = "SELECT DISTINCT A.DT_OPERACAO DATA, A.NO_BOLETIM BOLETIM,   A.CD_FUNC COD_FUNC, 				B.DE_FUNC FUNCIONARIO,                 A.CD_CCUSTO CCUSTO,                 A.CD_OPERACAO OPERACAO,                 A.CD_UPNIVEL1 PARCERIA,                 A.CD_UPNIVEL3 TALHAO,                 A.HR_INICIAL INICIO,                 A.HR_FINAL FIM,                 COUNT(A.CD_FUNC) LINHAS_DUPLICADAS   FROM PIMSCS.APT_MANU A, PIMSCS.FUNCIONARS B  WHERE A.DT_OPERACAO >= :DataIni    AND A.DT_OPERACAO <= :DataFim    AND A.CD_FUNC <> 2000152    AND A.CD_FUNC = B.CD_FUNC   GROUP BY A.DT_OPERACAO,           A.NO_BOLETIM,           A.CD_FUNC, 		  B.DE_FUNC,           A.CD_CCUSTO,           A.CD_OPERACAO,           A.CD_UPNIVEL1,           A.CD_UPNIVEL3,           A.HR_INICIAL,           A.HR_FINAL HAVING COUNT(A.CD_FUNC) > 1  ORDER BY A.DT_OPERACAO, A.NO_BOLETIM, A.CD_FUNC, B.DE_FUNC";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroManu = conn.Query<ManuDuplicados>(qyManu, param).ToList();

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
