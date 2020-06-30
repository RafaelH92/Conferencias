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
	public partial class frmMecOpImplemento : Form
	{
		frmMenu frmMenu;
		public frmMecOpImplemento(frmMenu form)
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

					dgvConsulta.DataSource = macOpImplemento();

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


		public List<MecOpImplemento> macOpImplemento() // Método que retorna a conferência dos erros 
		{

			string qyMac = "SELECT B.DT_OPERACAO AS DATA,   A.NO_BOLETIM AS BOLETIM,   A.CD_SAFRA AS SAFRA,   B.CD_EQUIPTO AS COD_EQUIPAMENTO,   E.DE_MODELO AS MODELO,   A.CD_EQ_IMPL1 AS IMPLEMENTO,   A.CD_CCUSTO AS COD_CCUSTO,   C.DE_CCUSTO AS CCUSTO,   A.CD_OPERACAO AS COD_OPERACAO,   D.DE_OPERACAO AS OPERACAO,   A.CD_UPNIVEL1 AS COD_PARCERIA,   A.CD_UPNIVEL3 AS TALHAO,   A.CD_USR_DML AS USUARIO  FROM PIMSCS.APT_MEC_DE A,   PIMSCS.APT_MEC_HE B,   PIMSCS.CCUSTOS C,   PIMSCS.OPERACOES D,   PIMSCS.MODELOS E,   PIMSCS.EQUIPTOS F  WHERE A.NO_BOLETIM = B.NO_BOLETIM  AND B.DT_OPERACAO BETWEEN :DataIni  AND :DataFim  AND A.CD_OPERACAO = D.CD_OPERACAO  AND A.CD_CCUSTO = C.CD_CCUSTO  AND F.CD_EQUIPTO = B.CD_EQUIPTO  AND F.CD_MODELO = E.CD_MODELO  AND A.CD_OPERACAO IN(57,   64,   65,   66,   72,   76,   92,   100,   102,   104,   108,   110,   111,   112,   114,   116,   118,   122,   124,   126,   115,   151,   169,   177,   188,   191,   123,   235)  AND A.CD_EQ_IMPL1 = 0  AND B.CD_EQUIPTO < 9000  AND A.CD_SAFRA >= :Safra  AND B.CD_EQUIPTO NOT IN (6116,6238)   ORDER BY B.DT_OPERACAO, B.NO_BOLETIM , B.DT_OPERACAO    ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var erroMec = conn.Query<MecOpImplemento>(qyMac, param).ToList();

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
