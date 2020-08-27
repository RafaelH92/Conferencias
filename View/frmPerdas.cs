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
	public partial class frmPerdas : Form
	{
		frmMenu frmMenu;
		public frmPerdas(frmMenu form)
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
						dgvConsulta.DataSource = perdaFornecedor();
					}
					else if (rbParceria.Checked)
					{
						dgvConsulta.DataSource = perdaParceria();
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

		public List<PerdaFornecedor> perdaFornecedor() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyPerdasForn = " SELECT   FORNECEDOR,  TOCO,  CANA_INTEIRA,  CANA_PONTA,  TOLETE,  LASCA,  PEDAÇO,  TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO AS TOTAL_PERDAS,  ROUND(((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,        2) AS PORCENTAGEM_PERDAS,  TCH,  ÁREA_PONDERADA,  ROUND((((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *        ÁREA_PONDERADA),        2) TON_PERDIDAS    FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'DEMAIS_FORNECEDORES_MENORES'                END FORNECEDOR,                                                                  ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                               ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA_PONDERADA                   FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2                  GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'DEMAIS_FORNECEDORES_MENORES'                   END)                 ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'DEMAIS_FORNECEDORES_MENORES'                   END) DESC         )  UNION ALL  SELECT   FORNECEDOR,  TOCO,  CANA_INTEIRA,  CANA_PONTA,  TOLETE,  LASCA,  PEDAÇO,  TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO AS TOTAL_PERDAS,  ROUND(((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,        2) AS PORCENTAGEM_PERDAS,  TCH,  ÁREA_PONDERADA,  ROUND((((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *        ÁREA_PONDERADA),        2) TON_PERDIDAS    FROM (SELECT CASE                  WHEN U.CD_FORNEC IS NULL THEN                   'NULO'                  ELSE                   'TOTAL_GERAL'                END FORNECEDOR,                                                                  ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                               ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA_PONDERADA                   FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2                  GROUP BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END)                  ORDER BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END)         )"; 

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters(); 
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var perdasForn = conn.Query<PerdaFornecedor>(qyPerdasForn, param).ToList();

				return perdasForn;
			}
		}

		public List<PerdaParceria> perdaParceria() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyPerdaPar = "  SELECT  FORNECEDOR,  COD_PARCERIA,  PARCERIA,  TOCO,  CANA_INTEIRA,  CANA_PONTA,  TOLETE,  LASCA,  PEDAÇO,  TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO AS TOTAL_PERDAS,  ROUND(((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,        2) AS PORCENTAGEM_PERDAS,  TCH,  ÁREA_PONDERADA,  ROUND((((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) /        ((TOCO + CANA_INTEIRA + CANA_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *        ÁREA_PONDERADA),        2) TON_PERDIDAS    FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'DEMAIS_FORNECEDORES_MENORES'                END FORNECEDOR,                               U.CD_UPNIVEL1 AS COD_PARCERIA,                U.DE_UPNIVEL1 AS PARCERIA,                               ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CANA_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                               ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA_PONDERADA                   FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2                  GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'DEMAIS_FORNECEDORES_MENORES'                   END),                   U.CD_UPNIVEL1,                   U.DE_UPNIVEL1          ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'DEMAIS_FORNECEDORES_MENORES'                   END) DESC,                   U.CD_UPNIVEL1)";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var perdasPar = conn.Query<PerdaParceria>(qyPerdaPar, param).ToList();

				return perdasPar;
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
			frmMenuAgricola frm = new frmMenuAgricola(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frm.Show();

			frmMenu.lbTitulo.Visible = false;
		}
	}

}
