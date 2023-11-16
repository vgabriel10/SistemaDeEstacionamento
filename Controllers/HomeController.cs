using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamento.Models;
using System.Diagnostics;

namespace SistemaDeEstacionamento.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdicionarEntradaVeiculo()
        {
            return View();
        }

        public IActionResult ListarVeiculos()
        {
            return View();
        }

        public IActionResult AlterarPreco()
        {
            return View();
        }

        public IActionResult Faturamento()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}