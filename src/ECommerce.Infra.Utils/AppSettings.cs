namespace ECommerce.Infra.Utils
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; } = new();
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; } = string.Empty;
        public string MongoConnection { get; set; } = string.Empty;
    }
}
