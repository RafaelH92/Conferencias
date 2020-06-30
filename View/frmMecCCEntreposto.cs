﻿/*************************************
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
	public partial class frmMecCCEntreposto : Form
	{
		frmMenu frmMenu;
		public frmMecCCEntreposto(frmMenu form)
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

					dgvConsulta.DataSource = MecCCEntreposto();

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


		public List<MecCCEntreposto> MecCCEntreposto() // Método que retorna a conferência dos erros 
		{

			string qyMec = " SELECT A.DT_OPERACAO DATA,        A.NO_BOLETIM BOLETIM,        A.CD_EQUIPTO COD_EQUIPAMENTO,        D.DE_MODELO MODELO,        A.CD_FUNC COD_FUNC,        B.DE_FUNC FUNCIONARIO,        C.DE_CARGO CARGO,        L.CD_CCUSTO COD_CCUSTO,        U.DE_CCUSTO CCUSTO,        A.CD_USR_DML USUARIO    FROM PIMSCS.APT_MEC_HE A,        PIMSCS.APT_MEC_DE L,        PIMSCS.CCUSTOS    U,        PIMSCS.FUNCIONARS B,        PIMSCS.CARGOS     C,        PIMSCS.MODELOS    D,        PIMSCS.EQUIPTOS   E   WHERE A.CD_FUNC = B.CD_FUNC    AND A.NO_BOLETIM = L.NO_BOLETIM    AND L.CD_CCUSTO = U.CD_CCUSTO    AND B.CD_CARGO = C.CD_CARGO    AND A.CD_EQUIPTO = E.CD_EQUIPTO    AND D.CD_MODELO = E.CD_MODELO    AND L.CD_CCUSTO IN        (550100, 550400, 550500, 550700, 551200, 551000, 550900, 550800,551300)    AND A.DT_OPERACAO >= :DataIni    AND A.DT_OPERACAO <= :DataFim   ORDER BY A.DT_OPERACAO, A.NO_BOLETIM, B.CD_CCUSTO";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroMec = conn.Query<MecCCEntreposto>(qyMec, param).ToList();

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
	}

}
