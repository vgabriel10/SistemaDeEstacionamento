namespace SistemaDeEstacionamento.Exceptions
{
    public class RelatorioException : Exception
    {
        public RelatorioException() { }

        public RelatorioException(string mensagem)
            : base(mensagem) { }

        public RelatorioException(string mensagem, int codigoErro)
            : base(mensagem) 
        {
            Mensagem = mensagem;
            CodigoErro = codigoErro;
        }

        public string Mensagem { get; set; }
        public int CodigoErro { get; set; }
    }
}
