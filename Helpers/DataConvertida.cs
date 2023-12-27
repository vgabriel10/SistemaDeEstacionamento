using SistemaDeEstacionamento.Service;
using System.Globalization;

namespace SistemaDeEstacionamento.Helpers
{
    public class DataConvertida
    {

        private readonly IEstacionamentoService _estacionamentoService;
        private readonly IFaturamentoService _faturamentoService;

        public DataConvertida(IEstacionamentoService estacionamentoService, IFaturamentoService faturamentoService)
        {
            _estacionamentoService = estacionamentoService;
            _faturamentoService = faturamentoService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Retorna o nome do dia no padrão brasileiro</returns>
        public static string RetornarNomeDia(DateTime data)
        {
            try
            {
                string nomeDiaBrasileiro = data.ToString("dddd", CultureInfo.GetCultureInfo("pt-BR"));
                return nomeDiaBrasileiro;
            }
            catch(Exception ex)
            {
                throw new Exception("A data informada é invalida");
            }
            
        }

        public static int RetornarIdTipoDia(DateTime data)
        {
            try
            {
                var nome = RetornarNomeDia(data);
                //int idDia = _estacionamentoService.RetornarIdDiaPeloNome(nome);
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception("A data informada é invalida");
            }
        }

    }
}
