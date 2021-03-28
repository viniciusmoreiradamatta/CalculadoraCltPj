using System;
using System.Collections.Generic;
using System.Linq;

namespace calcularPjClt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class CalcularDiferenca
    {
        public CalcularDiferenca(decimal salarioCLT, int percentualImposto, List<Beneficio> beneficios)
        {
            SalarioCLT = salarioCLT;
            PercentualImposto = percentualImposto;
            Beneficios = beneficios;
        }

        public decimal SalarioCLT { get; private set; }
        public int PercentualImposto { get; private set; }
        public List<Beneficio> Beneficios { get; set; }

        public decimal CalcularValorINSS()
        {
            var inss = new AliquotaINSS(SalarioCLT);

            return inss.ValorCobrancaINSS();
        }
        public decimal CalcularValorFGTS() =>
            Math.Round(((SalarioCLT / 100) * 8), 2);
        public decimal CalcularValorMensalFeriasDecimoTerceiro() => Math.Round((SalarioCLT / 12), 2);
        public decimal CalcularUmTercoFerias() =>
            Math.Round((CalcularValorMensalFeriasDecimoTerceiro() / 3), 2);
        public decimal CalcularValorTotalRendimentoCLT() => Beneficios.Sum(c => c.Valor) + SalarioCLT;

    }

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

    public class AliquotaINSS
    {
        public AliquotaINSS(decimal faixaSalarial)
        {
            FaixaSalarial = faixaSalarial;
            DefinirValorAliquota();
        }

        public decimal FaixaSalarial { get; private set; }
        public decimal Valor { get; private set; }

        public void DefinirValorAliquota()
        {
            if (FaixaSalarial >= 1100.01M && FaixaSalarial <= 2203.45M)
                Valor = 7.5M;
            else if (FaixaSalarial >= 2203.49M && FaixaSalarial <= 3305.22M)
                Valor = 12;
            else if (FaixaSalarial >= 3305.23M && FaixaSalarial <= 6433.57M)
                Valor = 14;
        }

        public decimal ValorCobrancaINSS() =>
            Math.Round((FaixaSalarial * 100) / Valor, 2);
    }

    public enum TipoEmpresa
    {
        Comercio,
        Fabricas,
        Servicos
    }
}
