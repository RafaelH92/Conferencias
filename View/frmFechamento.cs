/*************************************
 * Desenvolvido por Rafael H. Souza. *
 * Data: 27/04/2020                  *
 * Atualzado em: 28/09/2020          *
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
	public partial class frmFechamento : Form
	{
		frmMenu frmMenu;
		public frmFechamento(frmMenu form)
		{
			this.frmMenu = form;

			InitializeComponent();

		}



		public void Consultar()
		{
			try
			{
				
				{


					// Metódo utilizando Dapper

					dgvConsulta.Columns.Clear();

					dgvConsulta.DataSource = fechamento();


					for (int contador = 1; contador <= dgvConsulta.Rows.Count; contador++) //Laço que verifica se está sem processar a mais de 3 dias
					{
						DateTime dtAtual = DateTime.Now; //Recupera a data atual

						TimeSpan data = dtAtual - Convert.ToDateTime(dgvConsulta.Rows[contador - 1].Cells[1].Value); //Operação que faz a diferença entre a data atual e a data que está processado

						int totDias = data.Days; //Recupera a diferença dos dias

						if (totDias > 3)
						{
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.IndianRed;
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.ForeColor = Color.White;
						}
						else
						{
							dgvConsulta.Rows[contador - 1].DefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35);
						}
						
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

		public List<Fechamento> fechamento() // Método que retorna os processos do PIMS e suas datas
		{

			string qyFechamento = " SELECT A.DESCRICAO AS PROCESSO,        A.DATA_PROCESSO AS DATA,        A.SECAO,        A.ENTRADA,        CASE          WHEN (B.DATA_ATUAL_FORMATADA - A.DATA_PROCESSO) > 3 THEN           'ATENÇÃO! PROCESSO EM ATRASO'          ELSE           'PROCESSAMENTO OK!'        END STATUS    FROM (                 SELECT P.SECAO AS SECAO,                 P.ENTRADA AS ENTRADA,                 TO_DATE(P.VALOR) AS DATA_PROCESSO,                 P.DESCRICAO           FROM PIMSCS.PARAMETROS P          WHERE P.SECAO IN ('ATRC_MEC',                            'ATRC_PRD',                            'ATRC_INS',                            'RCMP_PRDOP',                            'ATRC_MAN',                            'COLCAM',                            'RCMP_FLUXO',                            'MNF_LUB',                            'RCMP',                            'ATRC_MDI',                            'PRCL_ANM',                            'AGRO_CLIM',                            'AGRO_BROC',                            'AGRO_FORMIGA',                            'ATMEC_RCMP',                            'CSTG_C',                            'MNF_MAN',                            'MNF_PNEUS',                            'ATRC_PLAN',                            'PRCL_MAT',                            'RCMP_PERDA')            AND P.ENTRADA IN ('DT_PROCESSO',                              'DT_HISTMDO',                              'DT_HIST_COLCAM',                              'DT_PROC_DISTCOM',                              'DT_PROC_AGRE',                              'DT_PROC_PROD',                              'DT_PROC_AREA',                              'DT_PROC_PRECIP',                              'DT_MOVTO',                              'DT_PROC_Z_PRECIP',                              'ATMEC_RCMP',                              'RCMP_FLUXO',                              'DT_GERA_ATIVMEC',                              'DT_PRODOPER',                              'ATMEC_RCMP',                              'DT_PROCESSO',                              'DT_PROC_APT_FUNC',                              'DT_PROC_BX_PL_SAFRA',                              'DT_PROC_GAR_EQUIPTO',                              'DT_PROC_OS_SEM_APT',                              'DT_PROC_SERVPREVEXEC',                              'DT_PROC_TEMPO_PER',                              'DT_HISTBOLETIM')          ORDER BY P.DESCRICAO) A,               (SELECT TO_DATE(TO_CHAR(SYSDATE, 'DD/MM/YYYY'), 'DD/MM/YYYY') AS DATA_ATUAL_FORMATADA           FROM DUAL) B   WHERE A.DESCRICAO NOT IN        ('Data do último processamento de distribuição de combustível/lubrificante pelo Manfro para equipamentos no Plantio')   ORDER BY A.SECAO, A.ENTRADA";

			// Atribui os parâmentros dinâmicos

			// Abre a conexão e executa a query


			using (IDbConnection conn = new OracleConnection("Password=pims;User ID=CONSULTOR;Data Source=ORA81_TCP"))
			{
				var fechamento = conn.Query<Fechamento>(qyFechamento).ToList();

				return fechamento;
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
				string folderPath = @"\\10.0.3.35\d\Debug\report\RELATÓRIO DE FECHAMENTO.pdf";

				using (System.IO.FileStream stream = new System.IO.FileStream(folderPath, System.IO.FileMode.Create))
				{
					//Configurando e adicionando os paragrafos

					iTextSharp.text.Paragraph ph1 = new iTextSharp.text.Paragraph("RELATÓRIO DE FECHAMENTO");
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

		private void tmAtualiza_Tick(object sender, EventArgs e)
		{
			while (cbFechamento.Checked)
			{
				Consultar();
				break;
			}
		}
	}
}
