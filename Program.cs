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
                Console.WriteLine($"{item.Nome}: {item.Valor:c}");

            Console.WriteLine($"Percentual Imposto SN: {clt.PercentualImposto}");

            Console.WriteLine($"INSS: {clt.ValorCobrancaInss}");
            Console.WriteLine($"IRRF: {clt.ValorCobrancaIrff}");
        }
    }
}
