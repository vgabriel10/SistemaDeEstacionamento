using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DAO;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SistemaDeEstacionamento.Controllers
{
    public class EstacionamentoController : Controller
    {

        private readonly IClienteService _clienteService;
        private readonly IEstacionamentoService _estacionamentoService;
        private readonly IFaturamentoService _faturamentoService;

        public EstacionamentoController(IClienteService clienteService, IEstacionamentoService estacionamentoService, IFaturamentoService faturamentoService)
        {
            _clienteService = clienteService;
            _estacionamentoService = estacionamentoService;
            _faturamentoService = faturamentoService;
        }

        //public IActionResult Index()
        //{
        //    _clienteService.RetornarTodosClientes();
        //    return View();
        //}

        public IActionResult AdicionarEntradaVeiculo()
        {
            List<TipoVeiculo> tiposVeiculos = _estacionamentoService.TiposVeiculos();
            ViewBag.TiposVeiculos = tiposVeiculos;
            List<TipoDia> diaAtual = _estacionamentoService.RetornaTiposDias();
            ViewBag.TipoDia = diaAtual;
            return View();
        }

        [HttpPost]
        public VeiculosNoEstacionamentoDTO RegistrarEntradaVeiculo(VeiculosNoEstacionamentoDTO veiculo)
        {
            _estacionamentoService.RegistrarEntradaVeiculo(veiculo);
            TempData["ok"] = "Tarefa criada com sucesso!";
            Response.Redirect("/Estacionamento/AdicionarEntradaVeiculo");
            return null;
        }

        public IActionResult ListarVeiculos()
        {
            var veiculosEstracionados = _estacionamentoService.RetornarVeiculosEstacionados();
            ViewBag.VeiculosEstacionados = veiculosEstracionados;
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult RegistrarSaida(int idVeiculo, int idCliente)
        {
            Veiculo veiculo = _estacionamentoService.RetornarVeiculoPorId(idVeiculo);
            Cliente cliente = _estacionamentoService.RetornarClientePorId(idCliente);
            List<TipoPagamento> formasDePagamento = _faturamentoService.RetornarFormasPagamento();
            ViewBag.Veiculo = veiculo;
            ViewBag.Cliente = cliente;
            ViewBag.TiposPagamentos = formasDePagamento;
            //Response.Redirect("/Home/RegistrarSaida");
            return View();
        }

        public RegistrarSaidaDTO CalcularValorPorHora(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            return _faturamentoService.CalcularValorPorHora(dadosVeiculoSaida);
        }

        public void RegistrarSaidaVeiculo(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            _estacionamentoService.RegistrarSaidaVeiculo(dadosVeiculoSaida.IdVeiculo, dadosVeiculoSaida.HoraSaida);
            _faturamentoService.RegistrarPagamentoPorHoraEstacionada(dadosVeiculoSaida);
        }

        public void RegistrarSaidaAvulsaVeiculo(RegistrarSaidaDTO dadosVeiculoSaida)
        {
            _estacionamentoService.RegistrarSaidaVeiculo(dadosVeiculoSaida.IdVeiculo, dadosVeiculoSaida.HoraSaida);
            _faturamentoService.RegistrarPagamentoAvulso(dadosVeiculoSaida);
        }

        public IActionResult PartialListarVeiculos()
        {
            var listaVeiculos = _estacionamentoService.RetornarUltimos50Veiculos();
            //ViewBag.VeiculosEstacionados = listaVeiculos;
            //var listarPrecos = _faturamentoService.ListarPrecosVeiculos(dia);
            //ViewBag.PrecoDia = listarPrecos;
            return PartialView("_PartialListarVeiculos", listaVeiculos);
        }

        public IActionResult PartialRetornarVagas()
        {
            Vaga infoVagas = _estacionamentoService.informacoesSobreVagas();
            return PartialView("_PartialRetornarVagas", infoVagas);
        }

        public IActionResult PartialLembretes()
        {
            List<Lembrete> lembretes = _estacionamentoService.RetornarLembretes();
            return PartialView("_PartialLembretes", lembretes);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}