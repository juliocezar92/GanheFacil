namespace GanheFacil.Models
{
    public class Resultado
    {
        public int Id { get; set; }
        public DateTime DataSorteio { get; set; }
        public List<int> NumerosSorteados { get; set; }
        public decimal ValorPremio { get; set; }

    }

    public class Rootobject
    {
        public bool acumulado { get; set; }
        public string dataApuracao { get; set; }
        public string dataProximoConcurso { get; set; }
        public string[] dezenasSorteadasOrdemSorteio { get; set; }
        public bool exibirDetalhamentoPorCidade { get; set; }
        public object id { get; set; }
        public int indicadorConcursoEspecial { get; set; }
        public string[] listaDezenas { get; set; }
        public object listaDezenasSegundoSorteio { get; set; }
        public Listamunicipioufganhadore[] listaMunicipioUFGanhadores { get; set; }
        public Listarateiopremio[] listaRateioPremio { get; set; }
        public object listaResultadoEquipeEsportiva { get; set; }
        public string localSorteio { get; set; }
        public string nomeMunicipioUFSorteio { get; set; }
        public string nomeTimeCoracaoMesSorte { get; set; }
        public int numero { get; set; }
        public int numeroConcursoAnterior { get; set; }
        public int numeroConcursoFinal_0_5 { get; set; }
        public int numeroConcursoProximo { get; set; }
        public int numeroJogo { get; set; }
        public string observacao { get; set; }
        public object premiacaoContingencia { get; set; }
        public string tipoJogo { get; set; }
        public int tipoPublicacao { get; set; }
        public bool ultimoConcurso { get; set; }
        public float valorArrecadado { get; set; }
        public float valorAcumuladoConcurso_0_5 { get; set; }
        public float valorAcumuladoConcursoEspecial { get; set; }
        public float valorAcumuladoProximoConcurso { get; set; }
        public float valorEstimadoProximoConcurso { get; set; }
        public float valorSaldoReservaGarantidora { get; set; }
        public float valorTotalPremioFaixaUm { get; set; }
    }

    public class Listamunicipioufganhadore
    {
        public int ganhadores { get; set; }
        public string municipio { get; set; }
        public string nomeFatansiaUL { get; set; }
        public int posicao { get; set; }
        public string serie { get; set; }
        public string uf { get; set; }
    }

    public class Listarateiopremio
    {
        public string descricaoFaixa { get; set; }
        public int faixa { get; set; }
        public int numeroDeGanhadores { get; set; }
        public float valorPremio { get; set; }
    }

}
