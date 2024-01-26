using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;
using SistemaDeEstacionamento.Enums;
using SistemaDeEstacionamento.Helpers;

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

        public string RetornarCaminhoArquivo(string nomeArquivo)
        {
            string caminho = Path.Combine(_hostingEnvironment.ContentRootPath, "Arquivos", nomeArquivo);
            return caminho;
        }

        public string RetornarCaminhoImagens(string nomeImagem)
        {
            string caminho = Path.Combine(_hostingEnvironment.ContentRootPath, "wwwroot", "assets", nomeImagem);
            return caminho;
        }

        public bool VerficarDataValida(DateTime dataInicio, DateTime? dataFinal)
        {
            if(dataFinal == null)
                dataFinal = DateTime.Now.Date;
            return true;
        }

        public string GerarRelatorioEntradasSaidasPdf(DateTime dataInicio, DateTime? dataFinal /*, Enum formato*/ )
        {
            List<RelatorioEntradaSaidaValorDTO> dadosRelatorio = new List<RelatorioEntradaSaidaValorDTO>();
            if (VerficarDataValida(dataInicio.Date, dataFinal))
                dadosRelatorio = _faturamentoService.RetornarEntradaSaidaValorPorData(dataInicio, dataFinal);


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
            var informacoes = new Paragraph($"Dados referente as datas {dataInicio.ToString().Substring(0, 10)} e {dataFinal.ToString().Substring(0, 10)}\n\n", fonteInfo);
            informacoes.Alignment = Element.ALIGN_LEFT;
            informacoes.SpacingAfter = 4;
            pdf.Add(informacoes);


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



            List<RelatorioEntradaSaidaValorDTO> dados = new List<RelatorioEntradaSaidaValorDTO>
        {
            new RelatorioEntradaSaidaValorDTO { Tipo = "Compra", DataPagamento = DateTime.Now, FormaPagamento = "Cartão", Valor = 100.50m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Serviço", DataPagamento = DateTime.Now.AddDays(-1), FormaPagamento = "Boleto", Valor = 75.20m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Aluguel", DataPagamento = DateTime.Now.AddDays(-2), FormaPagamento = "Transferência", Valor = 200.75m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Compra", DataPagamento = DateTime.Now.AddDays(-3), FormaPagamento = "Dinheiro", Valor = 50.00m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Serviço", DataPagamento = DateTime.Now.AddDays(-4), FormaPagamento = "Cartão", Valor = 120.80m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Aluguel", DataPagamento = DateTime.Now.AddDays(-5), FormaPagamento = "Boleto", Valor = 180.30m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Compra", DataPagamento = DateTime.Now.AddDays(-6), FormaPagamento = "Transferência", Valor = 90.60m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Serviço", DataPagamento = DateTime.Now.AddDays(-7), FormaPagamento = "Dinheiro", Valor = 60.40m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Aluguel", DataPagamento = DateTime.Now.AddDays(-8), FormaPagamento = "Cartão", Valor = 150.25m },
            new RelatorioEntradaSaidaValorDTO { Tipo = "Compra", DataPagamento = DateTime.Now.AddDays(-9), FormaPagamento = "Boleto", Valor = 110.90m }
        };

            //foreach (var item in dadosRelatorio)
            //{
            //    CriarCelulaTexto(tabela, item.Tipo, PdfPCell.ALIGN_CENTER);
            //    CriarCelulaTexto(tabela, item.DataPagamento.ToString(), PdfPCell.ALIGN_CENTER);
            //    CriarCelulaTexto(tabela, item.FormaPagamento, PdfPCell.ALIGN_CENTER);
            //    CriarCelulaTexto(tabela, item.Valor.ToString("C2"), PdfPCell.ALIGN_RIGHT);


            //    //var caminhoImagemCelula = p.Empregado ?
            //    //    "img\\emoji_feliz.png" : "img\\emoji_triste.png";
            //    //caminhoImagemCelula = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
            //    //    caminhoImagemCelula);
            //    //criarCelulaImagem(tabela, caminhoImagemCelula, 20, 20);
            //}

            foreach (var item in dadosRelatorio)
            {
                if (item.Tipo.Equals("Entrada"))
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.Green, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.Green, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.Green, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Green, PdfPCell.ALIGN_RIGHT);
                }
                else
                {
                    CriarCelulaTextoCorPersonalizada(tabela, item.Tipo, BaseColor.Red, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.DataPagamento.ToString(), BaseColor.Red, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.FormaPagamento, BaseColor.Red, PdfPCell.ALIGN_CENTER);
                    CriarCelulaTextoCorPersonalizada(tabela, item.Valor.ToString("C2"), BaseColor.Red, PdfPCell.ALIGN_RIGHT);
                }
                


                //var caminhoImagemCelula = p.Empregado ?
                //    "img\\emoji_feliz.png" : "img\\emoji_triste.png";
                //caminhoImagemCelula = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                //    caminhoImagemCelula);
                //criarCelulaImagem(tabela, caminhoImagemCelula, 20, 20);
            }

            pdf.Add(tabela);

            // Fechando pdf e arquivo
            pdf.Close();
            arquivo.Close();

            //Gerando pdf
            var caminhoPDF = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nomeArquivo);
            //var caminhoPDF = System.Web.HttpContext.Current.Server.MapPath("/");
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
            return caminhoDoArquivo;


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



        // ===============================================================================


        private void CriarCelulaTextoCorPersonalizada(PdfPTable tabela, string texto, BaseColor cor ,
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

            //var bgColor = iTextSharp.text.BaseColor.Gray;
            //if (tabela.Rows.Count % 2 == 1)
            //    bgColor = new BaseColor(0.95f, 0.95f, 0.95f);

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
    }
}


