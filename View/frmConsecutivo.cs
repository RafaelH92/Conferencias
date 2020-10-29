/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 16/10/2020          *
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
	public partial class frmConsecutivo : Form
	{
		frmMenu frmMenu;
		public frmConsecutivo(frmMenu form)
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

					
					
					{


						dgvConsulta.Columns.Clear();

						dgvConsulta.DataSource = consecutivo();


						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);

						}

						//Laço que verifica se o campo esta nulo e o preenche para exportar para PDF

						for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++)
						{
							if (dgvConsulta.Rows[contador - 1].Cells[1].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[1].Value = "Sem Consecutivo" ;

							}
							if (dgvConsulta.Rows[contador - 1].Cells[2].Value == null)
							{
								dgvConsulta.Rows[contador - 1].Cells[2].Value = "Sem Sequencia";

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


		public List<Consecutivo> consecutivo() // Método que retorna a conferência dos consecutivos
		{

			string qyConsec = " SELECT DISTINCT A.LIBERACAO,                 TO_CHAR(A.CONSECUTIVO) AS CONSECUTIVO,                 TO_CHAR(A.SEQUENCIA) AS SEQUENCIA,                 TO_CHAR(A.COD_PARCERIA || ' - ' || A.PARCERIA) AS PARCERIA,                 TO_CHAR(A.DATA_MOVIMENTO) AS DATA_MOVIMENTO,                 TO_CHAR(A.CAMINHAO || ' - ' || A.MODELO) AS CAMINHAO,                 A.USUARIO    FROM (SELECT G.NO_LIBERACAO    AS LIBERACAO,                 G.NO_PESAGEM      AS CONSECUTIVO,                 G.NO_SEQUENCIA    AS SEQUENCIA,                 G.CD_UPNIVEL1     AS COD_PARCERIA,                 U.DE_UPNIVEL1     AS PARCERIA,                 G.DT_MOVIMENTO    AS DATA_MOVIMENTO,                 R.CD_EQUIPTO      AS CAMINHAO,                 M.DE_MODELO       AS MODELO,                 G.CD_USUARIO_ENTR AS USUARIO                     FROM PIMSCS.APT_CARGAS     G,                 PIMSCS.APT_CARGAS_REC R,                 PIMSCS.UPNIVEL1       U,                 PIMSCS.EQUIPTOS       E,                 PIMSCS.MODELOS        M                    WHERE                    G.NO_LIBERACAO = R.NO_LIBERACAO        AND G.CD_UPNIVEL1 = U.CD_UPNIVEL1        AND E.CD_MODELO = M.CD_MODELO        AND R.CD_EQUIPTO = E.CD_EQUIPTO        AND R.CD_TP_RECURSO = 'CM'        AND G.DT_MOVIMENTO BETWEEN :DataIni AND :DataFim                    ORDER BY G.NO_PESAGEM, G.NO_SEQUENCIA) A,               (SELECT G.NO_LIBERACAO    AS LIBERACAO,                 G.NO_PESAGEM      AS CONSECUTIVO,                 G.NO_SEQUENCIA    AS SEQUENCIA,                 G.CD_UPNIVEL1     AS COD_PARCERIA,                 U.DE_UPNIVEL1     AS PARCERIA,                 G.DT_MOVIMENTO    AS DATA_MOVIMENTO,                 R.CD_EQUIPTO      AS CAMINHAO,                 M.DE_MODELO       AS MODELO,                 G.CD_USUARIO_ENTR AS USUARIO                     FROM PIMSCS.APT_CARGAS     G,                 PIMSCS.APT_CARGAS_REC R,                 PIMSCS.UPNIVEL1       U,                 PIMSCS.EQUIPTOS       E,                 PIMSCS.MODELOS        M                    WHERE                    G.NO_LIBERACAO = R.NO_LIBERACAO        AND G.CD_UPNIVEL1 = U.CD_UPNIVEL1        AND E.CD_MODELO = M.CD_MODELO        AND R.CD_EQUIPTO = E.CD_EQUIPTO        AND R.CD_TP_RECURSO = 'CM'        AND G.DT_MOVIMENTO BETWEEN :DataIni AND :DataFim                    ORDER BY G.NO_PESAGEM, G.NO_SEQUENCIA) B   WHERE A.LIBERACAO != B.LIBERACAO    AND A.CONSECUTIVO = B.CONSECUTIVO    AND A.SEQUENCIA = B.SEQUENCIA    AND A.CAMINHAO != B.CAMINHAO     OR (A.SEQUENCIA IS NULL OR A.CONSECUTIVO IS NULL)   ORDER BY A.CONSECUTIVO, A.SEQUENCIA ";

			// Atribui os parâmentros dinâmicos

			var param = new DynamicParameters();
			param.Add(":DataIni", txtInicio.Text);
			param.Add(":DataFim", txtFim.Text);


			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var consec = conn.Query<Consecutivo>(qyConsec, param).ToList();

				return consec;
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
			frmMenuTransporte frm = new frmMenuTransporte(frmMenu);
			frm.TopLevel = false;
			frmMenu.pnlBody.Controls.Add(frm);

			frm.Show();

			frmMenu.lbTitulo.Visible = false;
		}
	}

}
