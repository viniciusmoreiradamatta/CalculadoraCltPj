using System;
using System.Collections.Generic;
using System.Linq;

namespace calcularPjClt
{
    class Program
    {
        static void Main(string[] args)
        {

            var beneficios = new List<Beneficio>(){
                new Beneficio(400M,"Vale refeicao"),
            };

            CalculoValoresCLT clt = new(2600M, 6, beneficios);

            Console.WriteLine($"Salario bruto: {clt.SalarioCLT}");

            foreach (var item in beneficios)
                Console.WriteLine($"{item.Nome}: {item.Valor}");

            Console.WriteLine($"Percentual Imposto SN: {clt.PercentualImposto}");

            Console.WriteLine($"INSS: {clt.CalcularValorINSS()}");
            Console.WriteLine($"IRRF: {clt.CalcularValorIRFF()}");
        }
    }

    public class CalculoValoresCLT
    {
        public CalculoValoresCLT(decimal salarioCLT, int percentualImposto, List<Beneficio> beneficios)
        {
            SalarioCLT = salarioCLT;
            PercentualImposto = percentualImposto;
            Beneficios = beneficios;
            CalcularValorTotalRendimentoCLT();
        }

        public decimal SalarioCLT { get; private set; }
        public int PercentualImposto { get; private set; }
        public List<Beneficio> Beneficios { get; set; }

        public decimal CalcularValorIRFF()
        {
            var inss = new Aliquota(SalarioCLT);

            return inss.ValorCobrancaIRFF();
        }
        public decimal CalcularValorINSS()
        {
            var inss = new Aliquota(SalarioCLT);

            return inss.ValorCobrancaINSS();
        }
        public decimal CalcularValorFGTS() =>
            Math.Round(((SalarioCLT / 100) * 8), 2);
        public decimal CalcularValorMensalFeriasDecimoTerceiro()
        {
            var vlFerias = Math.Round((SalarioCLT / 12), 2);

            Beneficios.Add(new(vlFerias, "Ferias"));
            Beneficios.Add(new(vlFerias, "Décimo Terceiro Salário"));

            return vlFerias;
        }
        public decimal CalcularUmTercoFerias() =>
            Math.Round((CalcularValorMensalFeriasDecimoTerceiro() / 3), 2);
        public void CalcularValorTotalRendimentoCLT()
        {
            var fgts = CalcularValorFGTS();
            var tercoFerias = CalcularUmTercoFerias();

            Beneficios.Add(new(fgts, "FGTS"));
            Beneficios.Add(new(tercoFerias, "1/3 Férias: "));

            var vlTotalBeneficios = Beneficios.Sum(c => c.Valor) + SalarioCLT;

            var inss = CalcularValorINSS();
            var irff = CalcularValorIRFF();

            vlTotalBeneficios -= (inss + irff);
            Beneficios.Add(new(Math.Round(vlTotalBeneficios), "Valor total: "));
        }
    }
}
