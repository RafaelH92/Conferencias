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
using iTextSharp.text;

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
				else if (VerificaDataProcsPerda() == true)
				{
					MessageBox.Show("DATA NÃO PODE SER MAIOR QUE A DATA DE PROCESSAMENTO DE PERDAS --> " + processoPerdas());
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
						if (txtFornecedor.Text == string.Empty)
						{
							dgvConsulta.DataSource = perdaFornecedor();
						}
						else
						{
							dgvConsulta.DataSource = perdaFornecedorF();
						}

					}
					else if (rbParceria.Checked)
					{
						if (txtFornecedor.Text == string.Empty)
						{
							dgvConsulta.DataSource = perdaParceria();
						}
						else
						{
							dgvConsulta.DataSource = perdaParceriaF();
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

		public List<PerdaFornecedor> perdaFornecedor() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyPerdasForn = " SELECT FORNEC,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *              ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'OUTROS_FORNEC'                END FORNEC,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2          GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END)          ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END) DESC) UNION ALL SELECT FORNEC,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *              ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC IS NULL THEN                   'NULO'                  ELSE                   'TOTAL_GERAL'                END FORNEC,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2          GROUP BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END)          ORDER BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END))  "; 

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

		public List<PerdaFornecedor> perdaFornecedorF() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyPerdasForn = " SELECT FORNEC,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *              ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'OUTROS_FORNEC'                END FORNEC,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2            AND U.CD_FORNEC IN (" + txtFornecedor.Text + ")          GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END)          ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END) DESC) UNION ALL SELECT FORNEC,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *              ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC IS NULL THEN                   'NULO'                  ELSE                   'TOTAL_GERAL'                END FORNEC,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2            AND U.CD_FORNEC IN (" + txtFornecedor.Text + ")          GROUP BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END)          ORDER BY (CASE                     WHEN U.CD_FORNEC IS NULL THEN                      'NULO'                     ELSE                      'TOTAL_GERAL'                   END)) ";

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

			string qyPerdaPar = " SELECT FORNEC,        COD,        PARCERIA,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH *              ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'OUTROS_FORNEC'                END FORNEC,                U.CD_UPNIVEL1 AS COD,                U.DE_UPNIVEL1 AS PARCERIA,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2          GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END),                   U.CD_UPNIVEL1,                   U.DE_UPNIVEL1          ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END) DESC,                   U.CD_UPNIVEL1)   ";

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

		public List<PerdaParceria> perdaParceriaF() // Método que retorna a os dados de perdas mecanizadas
		{

			string qyPerdaPar = " SELECT FORNEC,        COD,        PARCERIA,        TOCO,        CN_INTEIRA,        CN_PONTA,        TOLETE,        LASCA,        PEDAÇO,        TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO AS TOT_PERD,        ROUND(((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * 100,              2) AS PERCENTUAL,        TCH,        ÁREA,        ROUND((((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) /              ((TOCO + CN_INTEIRA + CN_PONTA + TOLETE + LASCA + PEDAÇO) + TCH)) * TCH * ÁREA),              2) TN_PERDIDAS   FROM (SELECT CASE                  WHEN U.CD_FORNEC = 55145 THEN                   'TESTON'                  WHEN U.CD_FORNEC = 55204 THEN                   'PAULINHO'                  WHEN U.CD_FORNEC = 55200 THEN                   'FABIANO'                  ELSE                   'OUTROS_FORNEC'                END FORNEC,                U.CD_UPNIVEL1 AS COD,                U.DE_UPNIVEL1 AS PARCERIA,                ROUND(((SUM((((H.QT_TOTAL_P1) / 100) / (H.QT_AREA_P1)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOCO,                ROUND(((SUM((((H.QT_TOTAL_P2) / 100) / (H.QT_AREA_P2)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_INTEIRA,                ROUND(((SUM((((H.QT_TOTAL_P3) / 100) / (H.QT_AREA_P3)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS CN_PONTA,                ROUND(((SUM((((H.QT_TOTAL_P4) / 100) / (H.QT_AREA_P4)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS TOLETE,                ROUND(((SUM((((H.QT_TOTAL_P5) / 100) / (H.QT_AREA_P5)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS LASCA,                ROUND(((SUM((((H.QT_TOTAL_P6) / 100) / (H.QT_AREA_P6)) *                            H.QT_POND_LOC))) / SUM(H.QT_POND_LOC),                      2) AS PEDAÇO,                ROUND((SUM(H.QT_POND_LOC) / SUM(H.QT_AREA_LOC)) / 1000, 2) AS TCH,                ROUND(SUM(H.QT_AREA_LOC), 2) AS ÁREA           FROM PIMSCS.HISTPERDLOC H, PIMSCS.UPNIVEL1 U          WHERE H.CD_UPNIVEL1 = U.CD_UPNIVEL1            AND H.DT_HISTORICO >= :DataIni            AND H.DT_HISTORICO <= :DataFim            AND H.CD_SIST_COLH = 2 		   AND U.CD_FORNEC IN (" + txtFornecedor.Text + ")          GROUP BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END),                   U.CD_UPNIVEL1,                   U.DE_UPNIVEL1          ORDER BY (CASE                     WHEN U.CD_FORNEC = 55145 THEN                      'TESTON'                     WHEN U.CD_FORNEC = 55204 THEN                      'PAULINHO'                     WHEN U.CD_FORNEC = 55200 THEN                      'FABIANO'                     ELSE                      'OUTROS_FORNEC'                   END) DESC,                   U.CD_UPNIVEL1) ";

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

		public string processoPerdas() // Método que retorna a data de processamento de apontamento de perdas
		{

			string qyProcessoPerdas = " SELECT P.VALOR FROM  PARAMETROS P WHERE P.SECAO = 'RCMP_PERDA' AND P.ENTRADA = 'DT_PROCESSO' ";


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var param = conn.Query<PerdaProc>(qyProcessoPerdas).ToList();

				string dataProcesso = param[0].VALOR.ToString();

				return dataProcesso;
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

		public bool VerificaDataProcsPerda() // Verifica se a data inicial é menor que a data inicial
		{
			DateTime dataIni = DateTime.ParseExact(txtInicio.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
			DateTime dataFim = DateTime.ParseExact(txtFim.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
			DateTime dataProcesso = DateTime.ParseExact(processoPerdas(), "dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));

			if (dataIni > dataProcesso || dataFim > dataProcesso)
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
				pdfTable.DefaultCell.Padding = 0;
				pdfTable.DefaultCell.PaddingBottom = 5;
				pdfTable.DefaultCell.PaddingTop = 5;
				pdfTable.WidthPercentage = 100;
				pdfTable.DefaultCell.BorderWidth = 0;
				pdfTable.DefaultCell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
				var font = iTextSharp.text.FontFactory.GetFont("Arial", 9);
				pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };



				//Adiciona a linha do cabeçalho
				foreach (DataGridViewColumn column in dgvConsulta.Columns)
				{
					iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.HeaderText));
					cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
					cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
					cell.BorderWidth = 0;
					pdfTable.AddCell(new Phrase(column.HeaderText.ToString(), font));
					//pdfTable.AddCell(cell);
					//pdfTable.AddCell(new Phrase(cell.ToString(), font));

				}

				//Adiciona as linhas
				foreach (DataGridViewRow row in dgvConsulta.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
					}
				}

				//Exporta para PDF
				string folderPath = @"\\10.0.3.35\d\Debug\report\RELATÓRIO DE " + frmMenu.lbTitulo.Text + ".pdf";

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
					pdfDoc.Add(new iTextSharp.text.Paragraph("Emitido em.: " + DateTime.Now.ToString()));
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
