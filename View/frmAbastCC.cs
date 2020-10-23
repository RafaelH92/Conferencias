/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 22/10/2020          *
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
	public partial class frmAbastCC : Form
	{
		frmMenu frmMenu;
		public frmAbastCC(frmMenu form)
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

					if (txtCcusto.Text == string.Empty)
					{
						dgvConsulta.DataSource = abastCCAll();

						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
						}

                        //Laço que verifica se o campo esta nulo e o preenche para exportar para PDF

                        for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
                        {
                            if (dgvConsulta.Rows[contador - 1].Cells[1].Value == null)
                            {
                                dgvConsulta.Rows[contador - 1].Cells[1].Value = "---";
                                
                            }
							if (dgvConsulta.Rows[contador - 1].Cells[2].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[2].Value = "---";

							}
							if (dgvConsulta.Rows[contador - 1].Cells[3].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[3].Value = "---";

							}
						}
                    }
					else
					{


						dgvConsulta.Columns.Clear();

						dgvConsulta.DataSource = abastCC();


						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
						}

						//Laço que verifica se o campo esta nulo e o preenche para exportar para PDF

						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							if (dgvConsulta.Rows[contador - 1].Cells[1].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[1].Value = "---";

							}
							if (dgvConsulta.Rows[contador - 1].Cells[2].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[2].Value = "---";

							}
							if (dgvConsulta.Rows[contador - 1].Cells[3].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[3].Value = "---";

							}
						}

						dgvConsulta.ClearSelection();

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


		public List<AbastCC> abastCCAll() // Método que retorna a conferência dos abastecimentos 
		{

			string qyAbast = " SELECT TO_CHAR(A.NSEQABAST) AS ID_ABAST,        TO_CHAR(A.DDTAABAST) AS DATA,        TO_CHAR(A.CDESABAST) AS OPERACAO,        TO_CHAR((A.NCCAABAST || ' - ' || B.DE_CCUSTO)) AS CCUSTO,        A.NQTDABAST AS QUANTIDADE   FROM ABAST.APTABAST A, PIMSCS.CCUSTOS B  WHERE A.NCCAABAST = B.CD_CCUSTO    AND A.DDTAABAST BETWEEN :DataIni AND :DataFim    AND A.CDESABAST IN        ('Abastecimento por centro de custo', 'Centro de Custo')  UNION ALL  SELECT CASE          WHEN A.NSEQABAST = NULL THEN           'NULO'          ELSE           'TOTAL'        END ID_ABAST,        CASE          WHEN A.DDTAABAST = NULL THEN           'NULO'          ELSE           ''        END DATA,        CASE          WHEN A.CDESABAST = NULL THEN           'NULO'          ELSE           ''        END OPERACAO,        CASE          WHEN A.NCCAABAST || ' - ' || B.DE_CCUSTO = NULL THEN           'NULO'          ELSE           ''        END CCUSTO,        SUM(A.NQTDABAST) AS QUANTIDADE   FROM ABAST.APTABAST A, PIMSCS.CCUSTOS B  WHERE A.NCCAABAST = B.CD_CCUSTO    AND A.DDTAABAST BETWEEN :DataIni AND :DataFim    AND A.CDESABAST IN        ('Abastecimento por centro de custo', 'Centro de Custo')   GROUP BY (CASE             WHEN A.NSEQABAST = NULL THEN              'NULO'             ELSE              'TOTAL'           END),           (CASE             WHEN A.DDTAABAST = NULL THEN              'NULO'             ELSE              ''           END),           (CASE             WHEN A.CDESABAST = NULL THEN              'NULO'             ELSE              ''           END),           (CASE             WHEN A.NCCAABAST || ' - ' || B.DE_CCUSTO = NULL THEN              'NULO'             ELSE              ''           END)   ORDER BY DATA, CCUSTO";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);
			// param.Add(":Frota", txtCcusto.Text);

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var abast = conn.Query<AbastCC>(qyAbast, param).ToList();

				return abast;
			}
		}

		public List<AbastCC> abastCC() // Método que retorna a conferência dos abastecimentos 
		{

			string qyAbast = " SELECT TO_CHAR(A.NSEQABAST) AS ID_ABAST,        TO_CHAR(A.DDTAABAST) AS DATA,        TO_CHAR(A.CDESABAST) AS OPERACAO,        TO_CHAR((A.NCCAABAST || ' - ' || B.DE_CCUSTO)) AS CCUSTO,        A.NQTDABAST AS QUANTIDADE   FROM ABAST.APTABAST A, PIMSCS.CCUSTOS B  WHERE A.NCCAABAST = B.CD_CCUSTO    AND A.NCCAABAST IN (" + txtCcusto.Text + ")    AND A.DDTAABAST BETWEEN :DataIni AND :DataFim    AND A.CDESABAST IN        ('Abastecimento por centro de custo', 'Centro de Custo')  UNION ALL  SELECT CASE          WHEN A.NSEQABAST = NULL THEN           'NULO'          ELSE           'TOTAL'        END ID_ABAST,        CASE          WHEN A.DDTAABAST = NULL THEN           'NULO'          ELSE           ''        END DATA,        CASE          WHEN A.CDESABAST = NULL THEN           'NULO'          ELSE           ''        END OPERACAO,        CASE          WHEN A.NCCAABAST || ' - ' || B.DE_CCUSTO = NULL THEN           'NULO'          ELSE           ''        END CCUSTO,        SUM(A.NQTDABAST) AS QUANTIDADE   FROM ABAST.APTABAST A, PIMSCS.CCUSTOS B  WHERE A.NCCAABAST = B.CD_CCUSTO    AND A.NCCAABAST IN (" + txtCcusto.Text + ")    AND A.DDTAABAST BETWEEN :DataIni AND :DataFim    AND A.CDESABAST IN        ('Abastecimento por centro de custo', 'Centro de Custo')   GROUP BY (CASE             WHEN A.NSEQABAST = NULL THEN              'NULO'             ELSE              'TOTAL'           END),           (CASE             WHEN A.DDTAABAST = NULL THEN              'NULO'             ELSE              ''           END),           (CASE             WHEN A.CDESABAST = NULL THEN              'NULO'             ELSE              ''           END),           (CASE             WHEN A.NCCAABAST || ' - ' || B.DE_CCUSTO = NULL THEN              'NULO'             ELSE              ''           END)   ORDER BY DATA, CCUSTO";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var abast = conn.Query<AbastCC>(qyAbast, param).ToList();

				return abast;
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

			if (dgvConsulta.Rows.Count > 0)
			{
				btnPDF.Visible = true;
			}
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
				var font = iTextSharp.text.FontFactory.GetFont("Arial", 8.5f);
				pdfTable.DefaultCell.Phrase = new iTextSharp.text.Phrase() { Font = font };



				//Adiciona a linha do cabeçalho
				foreach (DataGridViewColumn column in dgvConsulta.Columns)
				{
					iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(column.HeaderText));
					cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
					cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
					cell.BorderWidth = 0;
					pdfTable.AddCell(new iTextSharp.text.Phrase(column.HeaderText.ToString(), font));
					//pdfTable.AddCell(cell);
					//pdfTable.AddCell(new Phrase(cell.ToString(), font));

				}

				//Adiciona as linhas
				foreach (DataGridViewRow row in dgvConsulta.Rows)
				{
					foreach (DataGridViewCell cell in row.Cells)
					{
						pdfTable.AddCell(new iTextSharp.text.Phrase(cell.Value.ToString(), font));
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

		private void btnVoltar_Click_1(object sender, EventArgs e)
		{
			frmMenu.pnlBody.Controls.Clear();

			frmAbastecimento frm = new frmAbastecimento(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frmMenu.lbTitulo.Text = "ERROS DE APONTAMENTOS DE ABASTECIMENTO";

			frm.Show();
		}
	}

}
