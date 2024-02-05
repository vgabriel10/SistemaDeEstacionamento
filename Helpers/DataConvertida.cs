using SistemaDeEstacionamento.Service;
using System.Globalization;

namespace SistemaDeEstacionamento.Helpers
{
    public class DataConvertida
    {

    
        public static DateTime FormatoPt_Br(string dataRecebida)
        {
            try
            {
                DateTime data;
                string formatoData = "dd/MM/yyyy";
                if (DateTime.TryParseExact(dataRecebida, formatoData,null, System.Globalization.DateTimeStyles.None, out data))
                    return data;


                throw new Exception("Data Inválida!");
            }
            catch
            {
                throw new Exception("Data Inválida!");
            }
            
               
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
