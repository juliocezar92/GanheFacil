namespace GanheFacil.Models
{
    public class NumeroSorteado
    {
        public int Id { get; private set; }
        public int Numero { get; private set; }

        public NumeroSorteado(int numero)
        {
            Numero = numero;
        }
    }
}
