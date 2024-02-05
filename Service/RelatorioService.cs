using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;
using SistemaDeEstacionamento.Enums;
using SistemaDeEstacionamento.Helpers;
using System.Runtime.ConstrainedExecution;
using System.Drawing;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using SistemaDeEstacionamento.Exceptions;

namespace SistemaDeEstacionamento.Models.DAO
{
    public class RelatorioService : IRelatorioService
    {
        #region Injeção de dependencia
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IFaturamentoService _faturamentoService;

        public RelatorioService(IWebHostEnvironment hostingEnvironment, IFaturamentoService faturamentoService)
        {
            _hostingEnvironment = hostingEnvironment;
            _faturamentoService = faturamentoService;
        }
        #endregion

        #region Métodos Auxiliares
        private string RetornarCaminhoArquivo(string nomeArquivo)
        {
            string caminho = Path.Combine(_hostingEnvironment.ContentRootPath, "Arquivos", nomeArquivo);
            return caminho;
        }

        private string RetornarCaminhoImagens(string nomeImagem)
        {
            string caminho = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "assets", nomeImagem);
            return caminho;
        }

        private bool VerficarDataValida(DateTime dataInicio, DateTime dataFinal)
        {
            string dataInicioString = dataInicio.Date.ToString("dd/MM/yyyy");
            string dataFinalString = dataFinal.Date.ToString("dd/MM/yyyy");
            if (!DateTime.TryParseExact(dataInicioString, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None,out dataInicio) && !DateTime.TryParseExact(dataFinalString, "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out dataFinal))
                throw new RelatorioException("Data Inválida!");
            return true;
        }

        private void CriarCelulaTexto(PdfPTable tabela, string texto,
            int alinhamento = PdfPCell.ALIGN_LEFT,
            bool negrito = false, bool italico = false,
            int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int estilo = iTextSharp.text.Font.NORMAL;
            if (negrito && italico)
            {
                estilo = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                estilo = iTextSharp.text.Font.ITALIC;
            }

            BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font fonte = new iTextSharp.text.Font(fonteBase, tamanhoFonte,
                estilo, iTextSharp.text.BaseColor.Black);

            //cor de fundo diferente para linhas pares e ímpares
            var bgColor = iTextSharp.text.BaseColor.White;
            if (tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95f, 0.95f, 0.95f);

            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.PaddingBottom = 5; //pra alinhar melhor verticalmente
            celula.FixedHeight = alturaCelula;
            celula.BackgroundColor = bgColor;
            tabela.AddCell(celula);
        }

        private void criarCelulaImagem(PdfPTable tabela, string caminhoImagem,
            int larguraImagem, int alturaImagem, int alturaCelula = 25)
        {
            //cor de fundo diferente para linhas pares e ímpares
            var bgColor = iTextSharp.text.BaseColor.White;
            if (tabela.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95f, 0.95f, 0.95f);

            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image imagem =
                    iTextSharp.text.Image.GetInstance(caminhoImagem);
                imagem.ScaleToFit(larguraImagem, alturaImagem);
                PdfPCell celula = new PdfPCell(imagem);
                celula.HorizontalAlignment = PdfCell.ALIGN_CENTER;
                celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                celula.Border = 0;
                celula.BorderWidthBottom = 1;
                celula.FixedHeight = alturaCelula;
                celula.BackgroundColor = bgColor;
                tabela.AddCell(celula);
            }
            else
            {
                tabela.AddCell("ERRO");
            }
        }

        private void CriarCelulaTextoCorPersonalizada(PdfPTable tabela, string texto, BaseColor cor,
            int alinhamento = PdfPCell.ALIGN_LEFT,
            bool negrito = false, bool italico = false,
            int tamanhoFonte = 12, int alturaCelula = 25)
        {
            int estilo = iTextSharp.text.Font.NORMAL;
            if (negrito && italico)
            {
                estilo = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                estilo = iTextSharp.text.Font.BOLD;
            }
            else if (italico)
            {
                estilo = iTextSharp.text.Font.ITALIC;
            }
            BaseFont fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font fonte = new iTextSharp.text.Font(fonteBase, tamanhoFonte,
                estilo, iTextSharp.text.BaseColor.Black);
            PdfPCell celula = new PdfPCell(new Phrase(texto, fonte));
            celula.HorizontalAlignment = alinhamento;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.PaddingBottom = 5; //pra alinhar melhor verticalmente
            celula.FixedHeight = alturaCelula;
            celula.BackgroundColor = cor;
            tabela.AddCell(celula);
        }
        #endregion

        public string GerarRelatorioEntradasSaidasPdf(DateTime dataInicio, DateTime dataFinal /*, Enum formato*/ )
        {
            List<RelatorioEntradaSaidaValorDTO> dadosRelatorio = new List<RelatorioEntradaSaidaValorDTO>();
            if (VerficarDataValida(dataInicio.Date, dataFinal.Date))
                dadosRelatorio = _faturamentoService.RetornarEntradaSaidaValorPorData(dataInicio, dataFinal);
            if (dadosRelatorio == null || dadosRelatorio.Count == 0)
                throw new RelatorioException("Não existe dados no período selecionado!",204);

            #region Configurações do PDF
            //Calculando o total de páginas
            int totalPaginas = 1;
            if (dadosRelatorio.Count > 24)
                totalPaginas += (int)Math.Ceiling(
                    (dadosRelatorio.Count - 24) / 29F);

            //configurar dados do PDF
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm,
                15 * pxPorMm, 20 * pxPorMm);
            var nomeArquivo = $"Teste-relatorio.{DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss")}.pdf";
            string caminhoDoArquivo = RetornarCaminhoArquivo(nomeArquivo);
            FileStream arquivo = new FileStream(caminhoDoArquivo, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            writer.PageEvent = new RodapeRelatorioPDF(totalPaginas);
            pdf.Open();


            //Definindo fonte
            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            #endregion

            #region Cabeçalho
            //adiciona um título
            var fonteParagrafo = new iTextSharp.text.Font(fonteBase, 26,
                iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório de Entrada e Saída de Valores\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            titulo.SpacingAfter = 4;
            pdf.Add(titulo);

            // Adiciona informações sobre a data 
            var fonteInfo = new iTextSharp.text.Font(fonteBase, 12,
                iTextSharp.text.Font.COURIER, BaseColor.Black);
            var informacoes = new Paragraph($"Dados referente à {dataInicio.ToString().Substring(0, 10)} até {dataFinal.ToString().Substring(0, 10)}\n\n", fonteInfo);
            informacoes.Alignment = Element.ALIGN_LEFT;
            informacoes.SpacingAfter = 4;
            pdf.Add(informacoes);

            // Total Entradas e Total Saídas

            decimal totalEntradas = 0, totalSaidas = 0, saldo = 0;
            foreach (var item in dadosRelatorio)
            {
                if (item.Tipo.Equals("Entrada"))
                    totalEntradas += item.Valor;
                else
                    totalSaidas += item.Valor;

                saldo = totalEntradas - totalSaidas;
            }

            var fonteNegativo = new iTextSharp.text.Font(fonteBase, 12,
            iTextSharp.text.Font.COURIER, BaseColor.Red);
            var fontePositivo = new iTextSharp.text.Font(fonteBase, 12,
            iTextSharp.text.Font.COURIER, BaseColor.Green);

            var totalEntradasSaidas = new Paragraph($"Total de Entradas: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", totalEntradas)} | Total de Saídas: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", totalSaidas)} | ", fonteInfo);
            totalEntradasSaidas.Alignment = Element.ALIGN_LEFT;
            totalEntradasSaidas.SpacingAfter = 4;

            var paragrafo = new Paragraph();

            if (saldo >= 0)
                paragrafo = new Paragraph($"Saldo: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", saldo)}\n", fontePositivo);
            else
                paragrafo = new Paragraph($"Saldo: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", saldo)}\n", fonteNegativo);
            
            totalEntradasSaidas.Add(paragrafo);

            pdf.Add(totalEntradasSaidas);

            //adiciona uma imagem
            var caminhoImagem = RetornarCaminhoImagens("dinheiro-png.png");
            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo =
                    iTextSharp.text.Image.GetInstance(caminhoImagem);
                float razaoLarguraAltura = logo.Width / logo.Height;
                float alturaLogo = 32;
                float larguraLogo = alturaLogo * razaoLarguraAltura;
                logo.ScaleToFit(larguraLogo, alturaLogo);
                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                writer.DirectContent.AddImage(logo, false);
            }

            #endregion

            //adiciona uma tabela
            var tabela = new PdfPTable(4);
            float[] larguras = { 0.6f, 2f, 1.5f, 1f };
            tabela.SetWidths(larguras);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriarCelulaTextoCorPersonalizada(tabela, "Tipo", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Data", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Forma de Pagamento", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Valor", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);

            foreach (var item in dadosRelatorio)
            {
                if (item.Tipo.Equals("Entrada"))
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Green, PdfPCell.ALIGN_RIGHT);
                }
                else
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Red, PdfPCell.ALIGN_RIGHT);
                }

            }
            pdf.Add(tabela);
            // Fechando pdf e arquivo
            pdf.Close();
            arquivo.Close();
            return caminhoDoArquivo;
        }

        public void AbrirRelatorioEntradasSaidasValores(DateTime dataInicio, DateTime dataFinal)
        {
            List<RelatorioEntradaSaidaValorDTO> dadosRelatorio = new List<RelatorioEntradaSaidaValorDTO>();
            if (VerficarDataValida(dataInicio.Date, dataFinal.Date))
                dadosRelatorio = _faturamentoService.RetornarEntradaSaidaValorPorData(dataInicio, dataFinal);
            if (dadosRelatorio == null || dadosRelatorio.Count == 0)
                throw new Exception("Não existe dados no período selecionado!");
            //Calculando o total de páginas
            int totalPaginas = 1;
            if (dadosRelatorio.Count > 24)
                totalPaginas += (int)Math.Ceiling(
                    (dadosRelatorio.Count - 24) / 29F);

            //configurar dados do PDF
            var pxPorMm = 72 / 25.2F;
            var pdf = new Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm,
                15 * pxPorMm, 20 * pxPorMm);
            var nomeArquivo = $"Teste-relatorio.{DateTime.Now.ToString("yyyy.MM.dd.hh.mm.ss")}.pdf";
            string caminhoDoArquivo = RetornarCaminhoArquivo(nomeArquivo);
            FileStream arquivo = new FileStream(caminhoDoArquivo, FileMode.Create);
            var writer = PdfWriter.GetInstance(pdf, arquivo);
            writer.PageEvent = new RodapeRelatorioPDF(totalPaginas);
            pdf.Open();


            //Definindo fonte
            var fonteBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

            //adiciona um título
            var fonteParagrafo = new iTextSharp.text.Font(fonteBase, 26,
                iTextSharp.text.Font.NORMAL, BaseColor.Black);
            var titulo = new Paragraph("Relatório de Entrada e Saída de Valores\n", fonteParagrafo);
            titulo.Alignment = Element.ALIGN_LEFT;
            titulo.SpacingAfter = 4;
            pdf.Add(titulo);

            // Adiciona informações sobre a data 
            var fonteInfo = new iTextSharp.text.Font(fonteBase, 12,
                iTextSharp.text.Font.COURIER, BaseColor.Black);
            var informacoes = new Paragraph($"Dados referente à {dataInicio.ToString().Substring(0, 10)} até {dataFinal.ToString().Substring(0, 10)}\n\n", fonteInfo);
            informacoes.Alignment = Element.ALIGN_LEFT;
            informacoes.SpacingAfter = 4;
            pdf.Add(informacoes);

            // Total Entradas e Total Saídas

            decimal totalEntradas = 0, totalSaidas = 0, saldo = 0;
            foreach (var item in dadosRelatorio)
            {
                if (item.Tipo.Equals("Entrada"))
                    totalEntradas += item.Valor;
                else
                    totalSaidas += item.Valor;

                saldo = totalEntradas - totalSaidas;
            }

            var fonteNegativo = new iTextSharp.text.Font(fonteBase, 12,
            iTextSharp.text.Font.COURIER, BaseColor.Red);
            var fontePositivo = new iTextSharp.text.Font(fonteBase, 12,
            iTextSharp.text.Font.COURIER, BaseColor.Green);

            var totalEntradasSaidas = new Paragraph($"Total de Entradas: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", totalEntradas)} | Total de Saídas: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", totalSaidas)} | ", fonteInfo);
            totalEntradasSaidas.Alignment = Element.ALIGN_LEFT;
            totalEntradasSaidas.SpacingAfter = 4;

            var paragrafo = new Paragraph();

            if (saldo >= 0)
                paragrafo = new Paragraph($"Saldo: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", saldo)}\n", fontePositivo);
            else
                paragrafo = new Paragraph($"Saldo: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", saldo)}\n", fonteNegativo);

            totalEntradasSaidas.Add(paragrafo);

            pdf.Add(totalEntradasSaidas);

            //adiciona uma imagem
            var caminhoImagem = RetornarCaminhoImagens("dinheiro-png.png");
            if (File.Exists(caminhoImagem))
            {
                iTextSharp.text.Image logo =
                    iTextSharp.text.Image.GetInstance(caminhoImagem);
                float razaoLarguraAltura = logo.Width / logo.Height;
                float alturaLogo = 32;
                float larguraLogo = alturaLogo * razaoLarguraAltura;
                logo.ScaleToFit(larguraLogo, alturaLogo);
                var margemEsquerda = pdf.PageSize.Width - pdf.RightMargin - larguraLogo;
                var margemTopo = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(margemEsquerda, margemTopo);
                writer.DirectContent.AddImage(logo, false);
            }

            //adiciona uma tabela
            var tabela = new PdfPTable(4);
            float[] larguras = { 0.6f, 2f, 1.5f, 1f };
            tabela.SetWidths(larguras);
            tabela.DefaultCell.BorderWidth = 0;
            tabela.WidthPercentage = 100;

            //adiciona os títulos das colunas
            CriarCelulaTextoCorPersonalizada(tabela, "Tipo", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Data", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Forma de Pagamento", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);
            CriarCelulaTextoCorPersonalizada(tabela, "Valor", BaseColor.LightGray, PdfPCell.ALIGN_CENTER, true);

            foreach (var item in dadosRelatorio)
            {
                if (item.Tipo.Equals("Entrada"))
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Green, PdfPCell.ALIGN_RIGHT);
                }
                else
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.White, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Red, PdfPCell.ALIGN_RIGHT);
                }
            }

            pdf.Add(tabela);

            // Fechando pdf e arquivo
            pdf.Close();
            arquivo.Close();

            //Gerando pdf
            if (File.Exists(caminhoDoArquivo))
            {
                Process.Start(new ProcessStartInfo()
                {
                    //Arguments = $"/c start firefox {caminhoPDF}",
                    Arguments = $"/c start {caminhoDoArquivo}",
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
        }

    }
}


