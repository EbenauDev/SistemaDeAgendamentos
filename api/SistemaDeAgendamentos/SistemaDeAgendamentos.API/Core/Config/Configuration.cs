namespace SistemaDeAgendamentos.API.Core.Config
{
    public class Configuration
    {
        public string ConnectionString { get; private set; }

        public Configuration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }
    }
}
