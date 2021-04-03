using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain.Models.Clt
{
    public class ValoresCLT
    {
        private ValoresCLT()
        {
        }

        public ValoresCLT(decimal salarioCLT, List<Beneficio> beneficios)
        {
            Validar(salarioCLT);

            SalarioCLT = salarioCLT;
            _Beneficios = beneficios;
        }

        [DisplayName("Salario")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal SalarioCLT { get; private set; }

        [DisplayName("Remuneração líquida efetiva")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal SalarioTotal { get; private set; }

        [DisplayName("INSS(%)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal AliquotaInss { get; private set; }

        [DisplayName("INSS")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorCobrancaInss { get; private set; }

        [DisplayName("IRFF(%)")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal AliquotaIrff { get; private set; }

        [DisplayName("IRFF")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorCobrancaIrff { get; private set; }

        [DisplayName("FGTS")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ValorFGTS { get => CalcularValorFGTS(); }

        [DisplayName("ProprcionalDecimo Terceiro/Ferias")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ProporcionalFeriasDecimoTerceiro { get => CalcularUmTercoFerias(); }

        [DisplayName("Decimo Terceiro/Ferias")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal FeriasDecimoTerceiro { get => CalcularValorMensalFeriasDecimoTerceiro(); }

        private List<Beneficio> _Beneficios { get; set; }

        public IReadOnlyCollection<Beneficio> Beneficios => _Beneficios;

        public void AdicionarBeneficio(Beneficio novoBeneficio) => _Beneficios.Add(novoBeneficio);

        public decimal ValorTotalBeneficios() => _Beneficios.Sum(c => c.Valor);

        private decimal CalcularValorFGTS() => ((SalarioCLT / 100) * 8);

        private decimal CalcularValorMensalFeriasDecimoTerceiro() => (SalarioCLT / 12);

        public decimal CalcularUmTercoFerias() => (FeriasDecimoTerceiro / 3);

        public void SomarSalarioLiquido() =>
            SalarioTotal = _Beneficios.Sum(c => c.Valor) - (ValorCobrancaInss + ValorCobrancaIrff) + SalarioCLT;

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
            if (salario <= 0)
                throw new InvalidOperationException("O salario nao pode ser menor ou igual a zero!");
        }
    }
}