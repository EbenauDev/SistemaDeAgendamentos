namespace SistemaDeAgendamentos.API.Core.Utils
{
    public class Falha
    {
        public Falha(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; private set; }

        public static Falha Nova(string mensagem)
            => new Falha(mensagem);
    }
}
