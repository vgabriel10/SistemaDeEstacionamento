﻿using Microsoft.AspNetCore.Mvc;
using SistemaDeEstacionamento.Models;
using SistemaDeEstacionamento.Models.DAO;
using SistemaDeEstacionamento.Models.DTO;
using SistemaDeEstacionamento.Service;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SistemaDeEstacionamento.Controllers
{
    public class FaturamentoController : Controller
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
        private readonly IEstacionamentoService _estacionamentoService;
        private readonly IFaturamentoService _faturamentoService;

        public FaturamentoController(IClienteService clienteService, IEstacionamentoService estacionamentoService, IFaturamentoService faturamentoService)
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

        public IActionResult AlterarPreco()
        {
            var listaDias = _estacionamentoService.RetornaTiposDias();
            ViewBag.listaDias = listaDias;
            var listarPrecos = _faturamentoService.ListarPrecosVeiculos(1);
            ViewBag.PrecoDia = listarPrecos;
            return View();
        }

        public IActionResult PartialExibirCrudPrecoDia(int dia)
        {
            var listarPrecos = _faturamentoService.ListarPrecosVeiculos(dia);
            ViewBag.PrecoDia = listarPrecos;
            return PartialView("_PartialExibirCrudPrecoDia", listarPrecos);
        }

        public IActionResult PartialRetornarPrecoDia(int dia)
        {
            var listarPrecos = _faturamentoService.ListarPrecosVeiculos(dia);
            return PartialView("_PartialRetornarPrecoDia", listarPrecos);
        }

        public void AdicionarNovoTipoVeiculo(string nomeTipo, decimal valorPadrao)
        {
            _faturamentoService.AdicionarNovoTipoVeiculo(nomeTipo, valorPadrao);
            Response.Redirect("/Home/AlterarPreco");
        }

        public void AlterarPrecoDia(int tipoVeiculo, int dia, decimal valor)
        {
            _faturamentoService.AlterarValorTipoVeiculo(tipoVeiculo, dia, valor);
            //Response.Redirect("/Home/AlterarPreco");
        }

        public void ExcluirTipoVeiculo(int idTipoVeiculo)
        {
            _faturamentoService.ExcluirTipoVeiculo(idTipoVeiculo);
            //Response.Redirect("/Home/AlterarPreco");
        }


        public IActionResult Faturamento()
        {
            var entradasNoDia = _faturamentoService.RetornarEntradaDeValoresPeloDia(DateTime.Now);

            return View();
        }

        public IActionResult PartialRetornarEntradasValores(DateTime? data)
        {
            if (data == null)
                data = DateTime.Now;
            var entradasNoDia = _faturamentoService.RetornarEntradaDeValoresPeloDia((DateTime)data);
            return PartialView("_PartialRetornarEntradasValores", entradasNoDia);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}