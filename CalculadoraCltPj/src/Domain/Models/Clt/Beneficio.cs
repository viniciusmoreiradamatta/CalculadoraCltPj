using System;

namespace Domain.Models.Clt
{
    public class Beneficio
    {
        public Beneficio(decimal valor, string nome)
        {
            Validar(valor);

            Valor = valor;
            Nome = nome;
        }

        public decimal Valor { get; private set; }
        public string Nome { get; private set; }

        public void Validar(decimal valor)
        {
            if (valor >= 0)
                throw new InvalidOperationException("O valor nao pode ser igual ou menor que zero");
        }
    }
}