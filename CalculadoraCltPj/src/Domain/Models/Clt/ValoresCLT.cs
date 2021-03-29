using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Clt
{
    public class ValoresCLT
    {
        public ValoresCLT(decimal salarioCLT, List<Beneficio> beneficios)
        {
            Validar(salarioCLT);

            SalarioCLT = salarioCLT;
            _Beneficios = beneficios;
        }

        public decimal SalarioCLT { get; private set; }
        public decimal AliquotaInss { get; private set; }
        public decimal ValorCobrancaInss { get; private set; }
        public decimal AliquotaIrff { get; private set; }
        public decimal ValorCobrancaIrff { get; private set; }
        public decimal ValorFGTS { get => CalcularValorFGTS(); }
        public decimal ProporcionalFeriasDecimoTerceiro { get => CalcularUmTercoFerias(); }
        public decimal FeriasDecimoTerceiro { get => CalcularValorMensalFeriasDecimoTerceiro(); }

        private List<Beneficio> _Beneficios { get; set; }

        public IReadOnlyCollection<Beneficio> Beneficios => _Beneficios;

        public void AdicionarBeneficio(Beneficio novoBeneficio) => _Beneficios.Add(novoBeneficio);

        public decimal ValorTotalBeneficios() => _Beneficios.Sum(c => c.Valor);

        private decimal CalcularValorFGTS() => ((SalarioCLT / 100) * 8);

        private decimal CalcularValorMensalFeriasDecimoTerceiro() => (SalarioCLT / 12);

        public decimal CalcularUmTercoFerias() => (FeriasDecimoTerceiro / 3);

        public void DefinirValoresIrff(decimal aliquotaImposto, decimal valorCobranca)
        {
            AliquotaIrff = aliquotaImposto;
            ValorCobrancaIrff = valorCobranca;
        }

        public void DefinirValoresInss(decimal aliquotaImposto, decimal valorCobranca)
        {
            AliquotaInss = aliquotaImposto;
            ValorCobrancaInss = valorCobranca;
        }

        public void Validar(decimal salario)
        {
            if (salario >= 0)
                throw new InvalidOperationException("O salario nao pode ser menor ou igual a zero!");
        }
    }
}