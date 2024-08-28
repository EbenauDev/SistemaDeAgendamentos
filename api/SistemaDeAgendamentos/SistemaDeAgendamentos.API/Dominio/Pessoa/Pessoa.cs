namespace SistemaDeAgendamentos.API.Dominio.Pessoa
{
    public class Pessoa
    {
        public Pessoa(int id, string nome, string email, string celular, string cpf)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Celular = celular;
            Cpf = cpf;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Celular { get; private set; }
        public string Cpf { get; private set; }

        public static Pessoa NovaPessoa(string nome, string email, string celular, string cpf)
            => new Pessoa(0, nome, email, celular, cpf);

        public Pessoa DefinirIdentidade(int id)
        {
            Id = id;
            return this;
        }
    }
}
