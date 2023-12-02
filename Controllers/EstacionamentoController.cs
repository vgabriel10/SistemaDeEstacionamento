using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DAO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;

namespace SistemaDeEstacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        //private readonly IClienteDAO _clienteDAO;

        //public HomeController(IClienteDAO clienteDAO)
        //{
        //    _clienteDAO = clienteDAO;
        //}

        private readonly IClienteService _clienteService;

        public EstacionamentoController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public IActionResult Index()
        {
            _clienteService.RetornarTodosClientes();
            return View();
        }

        public IActionResult AdicionarEntradaVeiculo()
        {
            //_clienteService.AdicionarCliente();
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