using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GanheFacil.Models
{
    public class Sorteio
    {
        public int Id { get; private set; }

        public int Numero { get; private set; }
        public DateTime DataSorteio { get; private set; }
        public string NumerosSorteados { get; private set; }
        public string TipoJogo { get; private set; }
        public List<NumeroSorteado> ListaNumeroSorteados { get; private set; }

        public Sorteio()
        {
        }
        public Sorteio(int numero, DateTime dataSorteio, string numerosSorteados, string tipoJogo, List<NumeroSorteado> listaNumeroSorteados)
        {
            Numero = numero;
            DataSorteio = dataSorteio;
            NumerosSorteados = numerosSorteados;
            TipoJogo = tipoJogo;
            ListaNumeroSorteados = listaNumeroSorteados;
        }
    }
}
