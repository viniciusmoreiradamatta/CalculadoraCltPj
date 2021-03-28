namespace calcularPjClt.PJ
{
    public class CalcularValoresPJ
    {
        public CalcularValoresPJ(decimal salarioMensal)
        {
            SalarioMensal = salarioMensal;
            DefinirAliquota();
        }

        public decimal SalarioMensal { get; private set; }
        public decimal ReceitaBruta { get => SalarioMensal * 12M; }
        public decimal Aliquota { get; set; }
        public decimal ParcelaDeducao { get; set; }

        public decimal RemuneacaoEfetiva
        {
            get
            {
                var aliquota = Calcular();
                return (ReceitaBruta/ 100) * aliquota;
            }
        }

        public decimal Calcular() =>
            ((ReceitaBruta * Aliquota) - ParcelaDeducao) / ReceitaBruta;

        public void DefinirAliquota()
        {
            if (ReceitaBruta >= 180.00000M)
            {
                Aliquota = 15.5M;
                ParcelaDeducao = 0;
            }
            else if (ReceitaBruta >= 180000.01M && ReceitaBruta <= 360000.00M)
            {
                Aliquota = 18M;
                ParcelaDeducao = 4500.00M;
            }
            else if (ReceitaBruta >= 360000.01M && ReceitaBruta <= 720000.00M)
            {
                Aliquota = 19.5M;
                ParcelaDeducao = 9900.00M;
            }
            else if (ReceitaBruta >= 720000.01M && ReceitaBruta <= 1800000.00M)
            {
                Aliquota = 20.5M;
                ParcelaDeducao = 17100.00M;
            }
            else if (ReceitaBruta >= 1800000.01M && ReceitaBruta <= 3600000.00M)
            {
                Aliquota = 23M;
                ParcelaDeducao = 62100.00M;
            }
            else if (ReceitaBruta >= 3600000.01M && ReceitaBruta <= 4800000.00M)
            {
                Aliquota = 30.5M;
                ParcelaDeducao = 540000.00M;
            }
        }
    }
}