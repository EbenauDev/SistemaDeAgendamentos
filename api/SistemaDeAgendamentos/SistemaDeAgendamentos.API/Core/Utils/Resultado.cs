namespace SistemaDeAgendamentos.API.Core.Utils
{
    public struct Resultado<TSucesso, TFalha>
    {
        private Resultado(
            TSucesso sucesso,
            bool ehSucesso,
            TFalha falha,
            bool ehFalha)
        {
            Sucesso = sucesso;
            EhSucesso = ehSucesso;
            Falha = falha;
            EhFalha = ehFalha;

        }

        public TSucesso Sucesso { get; private set; }
        public bool EhSucesso { get; private set; }

        public TFalha Falha { get; private set; }
        public bool EhFalha { get; private set; }

        public static Resultado<TSucesso, TFalha> NovoSucesso(TSucesso sucesso)
            => new Resultado<TSucesso, TFalha>(sucesso, ehSucesso: true, falha: default, ehFalha: false);

        public static Resultado<TSucesso, TFalha> NovaFalha(TFalha falha)
            => new Resultado<TSucesso, TFalha>(default, ehSucesso: false, falha: falha, ehFalha: true);

        public static implicit operator Resultado<TSucesso, TFalha>(TSucesso sucesso)
        {
            return new Resultado<TSucesso, TFalha>(sucesso, true, default, false);
        }

        public static implicit operator Resultado<TSucesso, TFalha>(TFalha falha)
        {
            return new Resultado<TSucesso, TFalha>(default, false, falha, true);
        }
    }
}
