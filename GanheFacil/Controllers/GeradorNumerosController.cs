using GanheFacil.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GanheFacil.Controllers
{
    public class GeradorNumerosController : Controller
    {
        private readonly GanheFacilContext _context;

        public GeradorNumerosController(GanheFacilContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Gerar15Numeros()
        {
            var numerosMaisFrequentes = ObterNumerosMaisFrequentes(15);
            var model = GerarNumerosAleatorios(numerosMaisFrequentes, 15);

            return View("Numeros", model);
        }

        public IActionResult Gerar16Numeros()
        {
            var numerosMaisFrequentes = ObterNumerosMaisFrequentes(16);
            var model = GerarNumerosAleatorios(numerosMaisFrequentes, 16);

            return View("Numeros", model);
        }

        public IActionResult Gerar17Numeros()
        {
            var numerosMaisFrequentes = ObterNumerosMaisFrequentes(17);
            var model = GerarNumerosAleatorios(numerosMaisFrequentes, 17);

            return View("Numeros", model);
        }

        private List<int> ObterNumerosMaisFrequentes(int quantidade)
        {
            var resultados = _context.Resultados.ToList();
            var numerosMaisFrequentes = _context.Sorteios
                .FromSqlInterpolated($@"
            SELECT Id, DataSorteio, NumerosSorteados,Numero, TipoJogo, COUNT(*) AS Quantidade
            FROM dbo.Sorteios
            CROSS APPLY STRING_SPLIT(NumerosSorteados, ',')
            GROUP BY Id, DataSorteio, NumerosSorteados, numero, TipoJogo")
                .AsEnumerable()
                .Select(s => s.NumerosSorteados.Split(','))
                .SelectMany(arr => arr)
                .Select(s => int.Parse(s.Trim()))
                .Take(quantidade)
                .ToList();

            return numerosMaisFrequentes;
        }


        private List<int> GerarNumerosAleatorios(List<int> numerosPossiveis, int quantidade)
        {
            var numerosAleatorios = new List<int>();
            var random = new Random();

            while (numerosAleatorios.Count < quantidade && numerosPossiveis.Count > 0)
            {
                var index = random.Next(numerosPossiveis.Count);
                var numero = numerosPossiveis[index];

                if (!numerosAleatorios.Contains(numero))
                {
                    numerosAleatorios.Add(numero);
                    numerosPossiveis.RemoveAt(index);
                }
            }

            return numerosAleatorios;
        }

    }

}
