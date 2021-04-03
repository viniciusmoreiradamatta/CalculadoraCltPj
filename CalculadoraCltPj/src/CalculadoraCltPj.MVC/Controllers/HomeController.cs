using CalculadoraCltPj.MVC.Models;
using CalculadoraCltPj.MVC.ViewModel;
using Domain.Models.Clt;
using Domain.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace CalculadoraCltPj.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalcularValoresCltService _calcularValoresCltService;

        public HomeController(ILogger<HomeController> logger, ICalcularValoresCltService calcularValoresCltService)
        {
            _logger = logger;
            _calcularValoresCltService = calcularValoresCltService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calcular([FromBody] CalculoViewModel valoresCLT)
        {
            List<Beneficio> list = new();

            if (valoresCLT is not null && valoresCLT.Beneficios is not null)
            {
                foreach (var item in valoresCLT.Beneficios)
                    list.Add(new(item.Valor, item.Nome));
            }

            var valores = new ValoresCLT(valoresCLT.SalarioCLT, list);

            _calcularValoresCltService.Calcular(valores);

            return PartialView(valores);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}