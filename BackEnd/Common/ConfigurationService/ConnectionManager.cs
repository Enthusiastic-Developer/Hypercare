namespace ConfigurationService
{
    public static class ConnectionManager
    {
        public static string GetInlineConnectionString()
        {
            return "Data Source=.;Initial Catalog=Test;Integrated Security=True";
        }

        public static string GetSPConnectionString()
        {
            return "Data Source=.;Initial Catalog=Test;Integrated Security=True";
        }
    }
}
