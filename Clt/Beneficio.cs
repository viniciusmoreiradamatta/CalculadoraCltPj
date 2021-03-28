namespace calcularPjClt
{
    public class Beneficio
    {
        public Beneficio(decimal valor, string nome)
        {
            Valor = valor;
            Nome = nome;
        }

        public decimal Valor { get; private set; }
        public string Nome { get; private set; }
    }
}