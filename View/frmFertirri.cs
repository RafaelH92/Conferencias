/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 26/08/2020          *
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
	public partial class frmFertirri : Form
	{
		frmMenu frmMenu;
		public frmFertirri(frmMenu form)
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

					// Metódo utilizando DataTable

					/*ConPims Conspims = new ConPims(); // Instancia conexão do PIMS
					ConADM ConsADM = new ConADM();    // Instancia conexão do ADM

					string strInicio = txtInicio.Text;
					string strFim = txtFim.Text;

					//Consulta dos prestadores que não são integrados
					string sqlparam = "SELECT REPLACE(COL005C,';',',') FROM PIMS_INTEG.INT_PIMS_001P WHERE COL002C = 'CONSUMIVEIS' AND COL003C = 'NAO_INTEGRA_PRESTADOR'";
					DataTable dtparam = new DataTable();

					//Atribui o resultado do select acima para a variável "param"

					dtparam = Conspims.getDataTable(sqlparam);
					string param = dtparam.Rows[0][0].ToString();


					if (rbDiesel500.Checked)
					{
						// Atribui as variáveis os comandos SQL

						string abastpims = "SELECT D.DT_OPERACAO MOVIMENTO, CASE WHEN D.CD_MATERIAL = 312500018 THEN 'DIESEL B S500 - PIMS' WHEN D.CD_MATERIAL = 312500025 THEN 'ETANOL - PIMS' WHEN D.CD_MATERIAL = 312500060 THEN 'DIESEL B S10 - PIMS' END COMBUSTIVEL, SUM(D.QT_ABASTEC) QUANTIDADE FROM PIMSCS.APT_ABAST_DE D, PIMSCS.APT_ABAST_HE H, PIMSCS.EQUIPTOS E, PIMSCS.MODELOS M WHERE D.NO_BOLETIM = H.NO_BOLETIM AND D.CD_EQUIPTO = E.CD_EQUIPTO AND E.CD_MODELO = M.CD_MODELO AND D.DT_OPERACAO >= '" + strInicio + "' AND D.DT_OPERACAO <= '" + strFim + "' AND H.CD_PONTO IN (2, 3, 11, 12) AND E.CD_TRANSP NOT IN (" + param + ") AND D.CD_MATERIAL = 312500018 GROUP BY D.DT_OPERACAO, D.CD_MATERIAL ORDER BY D.DT_OPERACAO, D.CD_MATERIAL";
						string abastADM = "SELECT TRUNC(A.DDATAMOVIM) MOVIMENTO, CASE WHEN C.CCODIPRODU = 312500018 THEN 'DIESEL B S500 - ADM' WHEN C.CCODIPRODU = 312500025 THEN 'ETANOL - ADM' WHEN C.CCODIPRODU = 170300018 THEN 'DIESEL2 - ADM' WHEN C.CCODIPRODU = 170600010 THEN 'DIESEL BS10 - ADM' WHEN C.CCODIPRODU = 312500060 THEN 'DIESEL BS10 - ADM' END COMBUSTIVEL, SUM(B.NQTDEITMOV) QUANTIDADE FROM PADRAO2T.ADMMOVIM A, PADRAO2T.ADMITMOV B, PADRAO2T.ADMPRODU C, PADRAO2T.ADMOPERA D WHERE A.NCODIGOEMPRE = 2 AND(A.NNUMEALMOX = 35) AND TRUNC(A.DDATAMOVIM) >= '" + strInicio + "' AND TRUNC(A.DDATAMOVIM) <= '" + strFim + "' AND A.NNUMEOPERA IN( 106,1896,3472,4379) AND A.NCODIGOEMPRE = B.NCODIGOEMPRE AND A.NCODIMOVIM = B.NCODIMOVIM AND B.NNUMEPRODU = C.NNUMEPRODU AND C.CCODIPRODU = 312500018 AND A.NNUMEOPERA = D.NNUMEOPERA AND D.CTIPOOPERA = 'S' AND A.CDESCMOVIM IN('CONSUMO GERAL DA FROTA', 'CONSUMO DA FROTA TERCEIRIZADA', 'DESTILARIA / CONSUMO | PIMS MI 32M')AND C.CCODIPRODU = 312500018 GROUP BY  A.DDATAMOVIM, C.CCODIPRODU ORDER BY A.DDATAMOVIM";

						//Instancia as DataTable's

						DataTable dtpims = new DataTable();
						dtpims = Conspims.getDataTable(abastpims);

						DataTable dtADM = new DataTable();
						dtADM = ConsADM.getDataTable(abastADM);

						//Adiciona duas colunas na DataTable 

						dtADM.Columns.Add("DIFERENÇA");
						dtADM.Columns.Add("STATUS");

						dtpims.Merge(dtADM); // Comando Merge, mescla as duas DataTables

						dtpims.DefaultView.Sort = "MOVIMENTO ASC"; // Ordena a DataTable por Data

						dgvConsulta.DataSource = dtpims;
					}
					else if (rbDiesel10.Checked)
					{
						// Atribui as variáveis os comandos SQL

						string abastpims = "SELECT D.DT_OPERACAO MOVIMENTO, CASE WHEN D.CD_MATERIAL = 312500018 THEN 'DIESEL B S500 - PIMS' WHEN D.CD_MATERIAL = 312500025 THEN 'ETANOL - PIMS' WHEN D.CD_MATERIAL = 312500060 THEN 'DIESEL B S10 - PIMS' END COMBUSTIVEL, SUM(D.QT_ABASTEC) QUANTIDADE FROM PIMSCS.APT_ABAST_DE D, PIMSCS.APT_ABAST_HE H, PIMSCS.EQUIPTOS E, PIMSCS.MODELOS M WHERE D.NO_BOLETIM = H.NO_BOLETIM AND D.CD_EQUIPTO = E.CD_EQUIPTO AND E.CD_MODELO = M.CD_MODELO AND D.DT_OPERACAO >= '" + strInicio + "' AND D.DT_OPERACAO <= '" + strFim + "' AND H.CD_PONTO IN (2, 3, 11, 12) AND E.CD_TRANSP NOT IN (" + param + ") AND D.CD_MATERIAL = 312500060 GROUP BY D.DT_OPERACAO, D.CD_MATERIAL ORDER BY D.DT_OPERACAO, D.CD_MATERIAL";
						string abastADM = "SELECT TRUNC(A.DDATAMOVIM) MOVIMENTO, CASE WHEN C.CCODIPRODU = 312500018 THEN 'DIESEL B S500 - ADM' WHEN C.CCODIPRODU = 312500025 THEN 'ETANOL - ADM' WHEN C.CCODIPRODU = 170300018 THEN 'DIESEL2 - ADM' WHEN C.CCODIPRODU = 170600010 THEN 'DIESEL BS10 - ADM' WHEN C.CCODIPRODU = 312500060 THEN 'DIESEL BS10 - ADM' END COMBUSTIVEL, SUM(B.NQTDEITMOV) QUANTIDADE FROM PADRAO2T.ADMMOVIM A, PADRAO2T.ADMITMOV B, PADRAO2T.ADMPRODU C, PADRAO2T.ADMOPERA D WHERE A.NCODIGOEMPRE = 2 AND(A.NNUMEALMOX = 35) AND TRUNC(A.DDATAMOVIM) >= '" + strInicio + "' AND TRUNC(A.DDATAMOVIM) <= '" + strFim + "' AND A.NNUMEOPERA IN( 106,1896,3472,4379) AND A.NCODIGOEMPRE = B.NCODIGOEMPRE AND A.NCODIMOVIM = B.NCODIMOVIM AND B.NNUMEPRODU = C.NNUMEPRODU AND C.CCODIPRODU = 312500060 AND A.NNUMEOPERA = D.NNUMEOPERA AND D.CTIPOOPERA = 'S' AND A.CDESCMOVIM IN('CONSUMO GERAL DA FROTA', 'CONSUMO DA FROTA TERCEIRIZADA', 'DESTILARIA / CONSUMO | PIMS MI 32M')AND C.CCODIPRODU = 312500060 GROUP BY  A.DDATAMOVIM, C.CCODIPRODU ORDER BY A.DDATAMOVIM";

						//Instancia as DataTable's

						DataTable dtpims = new DataTable();
						dtpims = Conspims.getDataTable(abastpims);

						DataTable dtADM = new DataTable();
						dtADM = ConsADM.getDataTable(abastADM);

						//Adiciona duas colunas na DataTable 

						dtADM.Columns.Add("DIFERENÇA");
						dtADM.Columns.Add("STATUS");

						dtpims.Merge(dtADM);// Comando Merge, mescla as duas DataTables

						dtpims.DefaultView.Sort = "MOVIMENTO ASC";// Ordena a DataTable por Data

						dgvConsulta.DataSource = dtpims;
					}
					else if (rbEtanol.Checked)
					{
						// Atribui as variáveis os comandos SQL

						string abastpims = "SELECT D.DT_OPERACAO MOVIMENTO, CASE WHEN D.CD_MATERIAL = 312500018 THEN 'DIESEL B S500 - PIMS' WHEN D.CD_MATERIAL = 312500025 THEN 'ETANOL - PIMS' WHEN D.CD_MATERIAL = 312500060 THEN 'DIESEL B S10 - PIMS' END COMBUSTIVEL, SUM(D.QT_ABASTEC) QUANTIDADE FROM PIMSCS.APT_ABAST_DE D, PIMSCS.APT_ABAST_HE H, PIMSCS.EQUIPTOS E, PIMSCS.MODELOS M WHERE D.NO_BOLETIM = H.NO_BOLETIM AND D.CD_EQUIPTO = E.CD_EQUIPTO AND E.CD_MODELO = M.CD_MODELO AND D.DT_OPERACAO >= '" + strInicio + "' AND D.DT_OPERACAO <= '" + strFim + "' AND H.CD_PONTO IN (2, 3, 11, 12) AND E.CD_TRANSP NOT IN (" + param + ") AND D.CD_MATERIAL = 312500025 GROUP BY D.DT_OPERACAO, D.CD_MATERIAL ORDER BY D.DT_OPERACAO, D.CD_MATERIAL";
						string abastADM = "SELECT TRUNC(A.DDATAMOVIM) MOVIMENTO, CASE WHEN C.CCODIPRODU = 312500018 THEN 'DIESEL B S500 - ADM' WHEN C.CCODIPRODU = 312500025 THEN 'ETANOL - ADM' WHEN C.CCODIPRODU = 170300018 THEN 'DIESEL2 - ADM' WHEN C.CCODIPRODU = 170600010 THEN 'DIESEL BS10 - ADM' WHEN C.CCODIPRODU = 312500060 THEN 'DIESEL BS10 - ADM' END COMBUSTIVEL, SUM(B.NQTDEITMOV) QUANTIDADE FROM PADRAO2T.ADMMOVIM A, PADRAO2T.ADMITMOV B, PADRAO2T.ADMPRODU C, PADRAO2T.ADMOPERA D WHERE A.NCODIGOEMPRE = 2 AND(A.NNUMEALMOX = 35) AND TRUNC(A.DDATAMOVIM) >= '" + strInicio + "' AND TRUNC(A.DDATAMOVIM) <= '" + strFim + "' AND A.NNUMEOPERA IN( 106,1896,3472,4379) AND A.NCODIGOEMPRE = B.NCODIGOEMPRE AND A.NCODIMOVIM = B.NCODIMOVIM AND B.NNUMEPRODU = C.NNUMEPRODU AND C.CCODIPRODU = 312500025 AND A.NNUMEOPERA = D.NNUMEOPERA AND D.CTIPOOPERA = 'S' AND A.CDESCMOVIM IN('CONSUMO GERAL DA FROTA', 'CONSUMO DA FROTA TERCEIRIZADA', 'DESTILARIA / CONSUMO | PIMS MI 32M')AND C.CCODIPRODU = 312500025 GROUP BY  A.DDATAMOVIM, C.CCODIPRODU ORDER BY A.DDATAMOVIM";

						//Instancia as DataTable's

						DataTable dtpims = new DataTable();
						dtpims = Conspims.getDataTable(abastpims);

						DataTable dtADM = new DataTable();
						dtADM = ConsADM.getDataTable(abastADM);

						//Adiciona duas colunas na DataTable 

						dtADM.Columns.Add("DIFERENÇA");
						dtADM.Columns.Add("STATUS");

						dtpims.Merge(dtADM);// Comando Merge, mescla as duas DataTables

						dtpims.DefaultView.Sort = "MOVIMENTO ASC";// Ordena a DataTable por Data


						dgvConsulta.DataSource = dtpims;
					}

					Laço para bloquear a ordenação da GridView

					foreach (DataGridViewColumn column in dgvConsulta.Columns)
					{
						column.SortMode = DataGridViewColumnSortMode.NotSortable;
					}*/

					//-------------------------------------------------------------------

					// Metódo utilizando Dapper

					dgvConsulta.Columns.Clear();

					if (rbFornecedor.Checked)
					{
						if(txtFornecedor.Text == string.Empty)
						{
							dgvConsulta.DataSource = brocaFornecedor();
						}
						else
						{
							dgvConsulta.DataSource = brocaFornecedorF();
						}
						
					}
					else if (rbParceria.Checked)
					{
						if(txtFornecedor.Text == string.Empty)
						{
							dgvConsulta.DataSource = brocaParceria();
						}
						else
						{
							dgvConsulta.DataSource = brocaParceriaF();
						}
						
					}


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

		public List<BrocaFornecedor> brocaFornecedor() // Método que retorna a os dados de brocas
		{

			string qyBrocaForn = "SELECT FORNECEDOR,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÁREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN UP1.CD_FORNEC = 55200 THEN                   'FABIANO'                  WHEN UP1.CD_FORNEC = 55204 THEN                   'PAULINHO'                  ELSE                   'OUTROS_FORNECEDORES'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND AM.DT_AMOSTRA BETWEEN :Dataini AND :DataFim)  GROUP BY FORNECEDOR UNION ALL SELECT FORNECEDOR,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÀREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC IS NULL THEN                   'NULO'                  ELSE                   'TOTAL_GERAL'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND AM.DT_AMOSTRA BETWEEN :Dataini AND :DataFim)  GROUP BY FORNECEDOR";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var brocaForn = conn.Query<BrocaFornecedor>(qyBrocaForn, param).ToList();

				return brocaForn;
			}
		}

		public List<BrocaFornecedor> brocaFornecedorF() // Método que retorna a os dados de brocas
		{

			string qyBrocaForn = "SELECT FORNECEDOR,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÁREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN UP1.CD_FORNEC = 55200 THEN                   'FABIANO'                  WHEN UP1.CD_FORNEC = 55204 THEN                   'PAULINHO'                  ELSE                   'OUTROS_FORNECEDORES'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND UP1.CD_FORNEC IN (" + txtFornecedor.Text + ")            AND AM.DT_AMOSTRA BETWEEN :Dataini AND :DataFim)  GROUP BY FORNECEDOR UNION ALL SELECT FORNECEDOR,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÀREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC IS NULL THEN                   'NULO'                  ELSE                   'TOTAL_GERAL'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND UP1.CD_FORNEC IN (" + txtFornecedor.Text + ")            AND AM.DT_AMOSTRA BETWEEN :Dataini AND :DataFim)  GROUP BY FORNECEDOR ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var brocaForn = conn.Query<BrocaFornecedor>(qyBrocaForn, param).ToList();

				return brocaForn;
			}
		}

		public List<BrocaParceria> brocaParceria() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyBrocaPar = "SELECT FORNECEDOR,        COD_PARCERIA,        PARCERIA,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÁREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN UP1.CD_FORNEC = 55200 THEN                   'FABIANO'                  WHEN UP1.CD_FORNEC = 55204 THEN                   'PAULINHO'                  ELSE                   'OUTROS_FORNECEDORES'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS COD_PARCERIA,                UP1.DE_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND AM.DT_AMOSTRA BETWEEN :DataIni AND :DataFim)  GROUP BY FORNECEDOR, COD_PARCERIA, PARCERIA  ORDER BY FORNECEDOR, COD_PARCERIA ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var brocaPar = conn.Query<BrocaParceria>(qyBrocaPar, param).ToList();

				return brocaPar;
			}
		}

		public List<BrocaParceria> brocaParceriaF() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyBrocaPar = " SELECT FORNECEDOR,        COD_PARCERIA,        PARCERIA,        SUM(ENTR_BROCADOS) AS ENTR_BROCADOS,        SUM(ENTR_TOTAL) AS ENTR_TOTAL,        SUM(ÁREA) AS ÁREA,        ROUND((SUM(PONDERACAO_ENTRENOS_BROCADOS)) / (SUM(ÁREA)), 2) PERCENTUAL   FROM (SELECT CASE                  WHEN UP1.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN UP1.CD_FORNEC = 55200 THEN                   'FABIANO'                  WHEN UP1.CD_FORNEC = 55204 THEN                   'PAULINHO'                  ELSE                   'OUTROS_FORNECEDORES'                END AS FORNECEDOR,                AM.CD_UPNIVEL1 AS COD_PARCERIA,                UP1.DE_UPNIVEL1 AS PARCERIA,                AM.QT_ENTR_BROC AS ENTR_BROCADOS,                AM.QT_ENTR_TOT AS ENTR_TOTAL,                AM.CD_SAFRA AS SAFRA,                ROUND((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100, 2) AS ENTRENOS_BROCADOS,                UP3.QT_AREA_PROD ÁREA,                ROUND(((AM.QT_ENTR_BROC / AM.QT_ENTR_TOT) * 100) *                      UP3.QT_AREA_PROD,                      2) AS PONDERACAO_ENTRENOS_BROCADOS           FROM PIMSCS.AMOSTBROCA AM,                PIMSCS.UPNIVEL1   UP1,                PIMSCS.UPNIVEL3   UP3          WHERE AM.CD_UPNIVEL1 = UP1.CD_UPNIVEL1            AND AM.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND UP1.CD_UPNIVEL1 = UP3.CD_UPNIVEL1            AND AM.CD_UPNIVEL3 = UP3.CD_UPNIVEL3            AND AM.CD_SAFRA = UP3.CD_SAFRA            AND AM.CD_FITOSS = 1            AND UP3.CD_SAFRA = :Safra            AND UP1.CD_FORNEC IN (" + txtFornecedor.Text + ")            AND AM.DT_AMOSTRA BETWEEN :DataIni AND :DataFim)  GROUP BY FORNECEDOR, COD_PARCERIA, PARCERIA  ORDER BY FORNECEDOR, COD_PARCERIA ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			param.Add(":Safra", cbSafra.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var brocaPar = conn.Query<BrocaParceria>(qyBrocaPar, param).ToList();

				return brocaPar;
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



		public bool VerificaDataMenor() // Verifica se a data final é menor que a data inicial
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

			if (dgvConsulta.Rows.Count > 0)
			{
				btnPDF.Visible = true;
			}

			
		}

		private void dgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			//dgvConsulta.ClearSelection();
		}

		private void btnVoltar_Click(object sender, EventArgs e)
		{
			frmMenu.pnlBody.Controls.Clear();
			frmMenuAgricola frm = new frmMenuAgricola(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frm.Show();

			frmMenu.lbTitulo.Visible = false;
		}

		private void btnPDF_Click(object sender, EventArgs e)
		{

			imprimiPDF();
			
		}

		private void imprimiPDF()
		{
			try
			{

				//Cria a iTextSharp Table da DataTable
				iTextSharp.text.pdf.PdfPTable pdfTable = new iTextSharp.text.pdf.PdfPTable(dgvConsulta.ColumnCount);
				pdfTable.DefaultCell.Padding = 2;
				pdfTable.WidthPercentage = 100;
				pdfTable.DefaultCell.BorderWidth = 0;
				pdfTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;



				//Adiciona a linha do cabeçalho
				foreach (DataGridViewColumn column in dgvConsulta.Columns)
				{
					iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.HeaderText));
					cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
					cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
					cell.BorderWidth = 0;
					pdfTable.AddCell(cell);
				}

				//Adiciona as linhas
				foreach (DataGridViewRow row in dgvConsulta.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						pdfTable.AddCell(cell.Value.ToString());
					}
				}

				//Exporta para PDF
				string folderPath =  @"\\10.0.3.35\d\Debug\report\RELATÓRIO DE " + frmMenu.lbTitulo.Text +  ".pdf";

				using (System.IO.FileStream stream = new System.IO.FileStream(folderPath, System.IO.FileMode.Create))
				{
					//Configurando e adicionando os paragrafos

					iTextSharp.text.Paragraph ph1 = new iTextSharp.text.Paragraph("RELATÓRIO DE " + frmMenu.lbTitulo.Text);
					ph1.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
					ph1.Font.SetStyle(5);

					iTextSharp.text.Paragraph ph2 = new iTextSharp.text.Paragraph(lbDeveloped.Text);
					//ph2.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

					iTextSharp.text.Paragraph ph3 = new iTextSharp.text.Paragraph(lbRaf.Text);
					//ph3.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
					ph3.Font.SetStyle(1); // 1 - negrito;

					iTextSharp.text.Paragraph ph4 = new iTextSharp.text.Paragraph(lLemail.Text);
					//ph4.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

					iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 10, 10);
					iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);

					
					pdfDoc.Open();					
					iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(@"\\10.0.3.35\d\Debug\image\logo_nova.JPG");
					logo.ScalePercent(0.3f * 100);
					logo.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
					pdfDoc.Add(logo);
					pdfDoc.Add(ph1);
					//pdfDoc.Add(new iTextSharp.text.Paragraph(" ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------"));
					pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
					pdfDoc.Add(new iTextSharp.text.Paragraph("Período.......: " + txtInicio.Text + " à " + txtFim.Text));
					pdfDoc.Add(new iTextSharp.text.Paragraph("Usuário.......: " + frmMenu.lbNome.Text));
					pdfDoc.Add(new iTextSharp.text.Paragraph("Emitido em.: " +  DateTime.Now.ToString()));
					pdfDoc.Add(new iTextSharp.text.Paragraph("Área ponderada*"));
					pdfDoc.Add(ph2);
					pdfDoc.Add(ph3);
					pdfDoc.Add(ph4);
					pdfDoc.Add(new iTextSharp.text.Paragraph(" "));
					pdfDoc.Add(pdfTable);					
					pdfDoc.Close();
					stream.Close();
					System.Diagnostics.Process.Start(folderPath);

					//	iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4);
					//	string caminho = Application.StartupPath + @"\Exemplo.pdf";
					//	iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new System.IO.FileStream(caminho, System.IO.FileMode.Create));

					//	try
					//	{

					//		doc.SetMargins(30, 30, 70, 70);
					//		doc.AddCreationDate();
					//		doc.Open();
					//		iTextSharp.text.Paragraph par = new iTextSharp.text.Paragraph(brocaFornecedor().ToString());
					//		par.Alignment = iTextSharp.text.Element.ALIGN_JUSTIFIED;
					//		par.Add("Teste na criação de um arquivo PDF");
					//		doc.Add(par);
					//		doc.Close();
					//		System.Diagnostics.Process.Start(caminho);
					//	}
					//	catch (Exception Ex)
					//	{
					//		MessageBox.Show("Ocorreu um erro ao gerar o PDF - Erro:", Ex.Message);
					//	}
					//}
				}
			}
			catch (Exception ex)
			{

				MessageBox.Show("OPSS.. OCORREU UM ERRO! " + ex.Message);

			}
		}

	}
}
