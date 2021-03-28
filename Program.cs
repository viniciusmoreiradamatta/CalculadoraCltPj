using System;
using System.Collections.Generic;

namespace calcularPjClt
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var beneficios = new List<Beneficio>(){
                new Beneficio(400M,"Vale refeicao"),
            };

            CalculoValoresCLT clt = new(2600M, 6, beneficios);

            Console.WriteLine($"Salario bruto: {clt.SalarioCLT}");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("---------- Beneficios -----------");
            Console.WriteLine("---------------------------------");

            foreach (var item in beneficios)
                Console.WriteLine($"{item.Nome}: {item.Valor:c}");

            Console.WriteLine("---------------------------------");
            Console.WriteLine("------------ Impostos -----------");
            Console.WriteLine("---------------------------------");

            Console.WriteLine($"INSS: {clt.ValorCobrancaInss:c}");
            Console.WriteLine($"IRRF: {clt.ValorCobrancaIrff:c}");

            Console.WriteLine($"Percentual Imposto SN: {clt.PercentualImposto}");

        }
    }
}