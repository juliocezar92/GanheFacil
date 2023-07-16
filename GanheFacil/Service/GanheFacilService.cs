using GanheFacil.Data;
using GanheFacil.Models;
using Newtonsoft.Json;



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
                    // Fazer a solicitação HTTP para obter o JSON com os resultados
                    var response = await httpClient.GetAsync("https://servicebus2.caixa.gov.br/portaldeloterias/api/lotofacil/");

                    if (response.IsSuccessStatusCode)
                    {
                        // Ler a resposta como uma string
                        var responseBody = await response.Content.ReadAsStringAsync();

                        // Converter o JSON para um objeto Resultado usando a classe Resultado do seu modelo
                        var resultado = JsonConvert.DeserializeObject<Rootobject>(responseBody);
                        var listaNumerosSorteados = string.Join(',',resultado.listaDezenas).Select(x => new NumeroSorteado(Convert.ToInt32(x))).ToList();
                        var sorteio = new Sorteio(resultado.numero, Convert.ToDateTime(resultado.dataApuracao), string.Join(',', resultado.listaDezenas), resultado.tipoJogo, listaNumerosSorteados);

                        // Salvar o resultado no banco de dados
                        await _context.Sorteios.AddAsync(sorteio);
                        await _context.SaveChangesAsync();

                        return true;
                    }
                    else
                    {
                        // Lidar com o erro da solicitação HTTP
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                // Tratar erros ou exceções
                return false;
            }
        }
    }

        public class ResultadoApi
    {
        public string Data { get; set; }
        public List<int> Numeros { get; set; }
    }
}