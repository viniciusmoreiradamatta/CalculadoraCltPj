using System.Collections.Generic;

namespace CalculadoraCltPj.MVC.ViewModel
{
    public class BeneficioViewModel
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }

    public class CalculoViewModel
    {
        public decimal SalarioCLT { get;  set; }
        public IEnumerable<BeneficioViewModel> Beneficios { get; set; }
    }
}