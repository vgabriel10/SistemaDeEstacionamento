using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamento.Helpers;
using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DAO;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SistemaDeEstacionamento.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly IClienteService _clienteService;
        private readonly IEstacionamentoService _estacionamentoService;
        private readonly IFaturamentoService _faturamentoService;

        public HomeController(IClienteService clienteService, IEstacionamentoService estacionamentoService, IFaturamentoService faturamentoService)
        {
            _clienteService = clienteService;
            _estacionamentoService = estacionamentoService;
            _faturamentoService = faturamentoService;
        }

        public IActionResult Index()
        {
            //GerarRelatorio.GerarRelatorioEntradasSaidasPdf();
            //_clienteService.RetornarTodosClientes();
            return View();
        }


        public IActionResult PartialListarVeiculos()
        {
            var listaVeiculos = _estacionamentoService.RetornarUltimos50Veiculos();
            return PartialView("_PartialListarVeiculos", listaVeiculos);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}