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
	public partial class frmMecEquipXImp : Form
	{
		frmMenu frmMenu;
		public frmMecEquipXImp(frmMenu form)
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

					dgvConsulta.DataSource = MecEquipXImp();

					//dgvConsulta.Columns.Add("descontinuidade", "DESCONTINUIDADE");
					//dgvConsulta.Columns["diferença"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
					//dgvConsulta.Columns.Add("status", "STATUS");
					//dgvConsulta.Columns["status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


					//Laço que faz a diferença da km inicial e km final, e adiciona na Grid

					for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
					{
						//dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.DarkGreen;
						//dgvConsulta.Rows[contador - 1].DefaultCellStyle.ForeColor = Color.Silver;
						dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
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


		public List<MecEquipXImp> MecEquipXImp() // Método que retorna a conferência dos erros 
		{

			string qyMec = "SELECT  A.DT_OPERACAO DATA,  A.NO_BOLETIM BOLETIM,  B.CD_SAFRA SAFRA,  A.CD_FUNC COD_FUNC,  C.DE_FUNC FUNCIONARIO,  H.CD_EQUIPTO COD_EQUIPAMENTO,  D.DE_MODELO EQUIPAMENTO,  B.CD_EQ_IMPL1  IMPLEMENTO,  B.CD_CCUSTO COD_CCUSTO,  B.CD_OPERACAO COD_OPERACAO,  B.CD_UPNIVEL1 COD_PARCERIA,  B.CD_UPNIVEL3 TALHAO,  B.CD_USR_DML USUARIO    FROM PIMSCS.APT_MEC_HE A,        PIMSCS.APT_MEC_DE B,        PIMSCS.FUNCIONARS C,        PIMSCS.MODELOS    D,        PIMSCS.CCUSTOS    E,        PIMSCS.OPERACOES  F,        PIMSCS.UPNIVEL1   G,        PIMSCS.EQUIPTOS   H   WHERE   A.NO_BOLETIM = B.NO_BOLETIM  AND A.CD_FUNC = C.CD_FUNC  AND A.CD_EQUIPTO = H.CD_EQUIPTO  AND H.CD_MODELO = D.CD_MODELO  AND B.CD_CCUSTO = E.CD_CCUSTO  AND B.CD_OPERACAO = F.CD_OPERACAO  AND B.CD_UPNIVEL1 = G.CD_UPNIVEL1  AND B.CD_EQ_IMPL1 NOT IN  (SELECT A.CD_EQUIPTO     FROM PIMSCS.EQUIPTOS A    INNER JOIN PIMSCS.MODELOS Y       ON A.CD_MODELO = Y.CD_MODELO    WHERE Y.CD_GRUPO_OP IN (10, 93, 7, 95, 18))  AND B.CD_EQ_IMPL1 <> 0  AND A.DT_OPERACAO BETWEEN :DataIni AND :DataFim   ORDER BY A.DT_OPERACAO,                       A.NO_BOLETIM,                   H.CD_EQUIPTO,           B.CD_EQ_IMPL1,           B.CD_CCUSTO,           B.CD_OPERACAO,           B.CD_UPNIVEL1,           B.CD_UPNIVEL3";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroMec = conn.Query<MecEquipXImp>(qyMec, param).ToList();

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
