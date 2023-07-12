using GanheFacil.Data;
using GanheFacil.Models;
using System.Globalization;

namespace GanheFacil.Service
{
    public interface IGanheFacilService
    {
        Task<bool> ColetarERegistrarResultados();
    }

    public class GanheFacilService : IGanheFacilService
    {
        private readonly GanheFacilContext _context;

        public GanheFacilService(GanheFacilContext context)
        {
            _context = context;
        }

        public async Task<bool> ColetarERegistrarResultados()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Faz a requisição HTTP para obter o HTML da página de resultados
                    var html = await httpClient.GetStringAsync("https://servicebus2.caixa.gov.br/portaldeloterias/api/lotofacil/2812");

                    // Analisa o HTML utilizando o HtmlAgilityPack
                    var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.LoadHtml(html);

                    // Extrai as informações relevantes do HTML, como data do sorteio e números sorteados
                    var dataSorteioNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='title-bar']//strong");
                    var numerosSorteadosNodes = htmlDocument.DocumentNode.SelectNodes("//ul[@class='numbers']//li");

                    var resultado = new Resultado
                    {
                        DataSorteio = DateTime.ParseExact(dataSorteioNode.InnerText.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                        NumerosSorteados = numerosSorteadosNodes.Select(n => int.Parse(n.InnerText)).ToList(),
                        ValorPremio = 0.0m // Defina o valor do prêmio conforme necessário
                    };

                    await _context.Resultados.AddAsync(resultado);
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception )
            {
                // Tratar erros ou exceções
                return false;
            }
        }
        
    }
}