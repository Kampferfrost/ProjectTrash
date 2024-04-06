namespace DataPlayers.Services
{
    /// <summary>
    /// Базавая платформа для серверов
    /// </summary>
    internal class ServerPlatform
    {
        private List<Server> Servers { get; }
        public string Name { get; private set; } = "NoName";
        

        public ServerPlatform(List<Server> servers, string name)
        {
            Servers = servers;
            Name = name;
        }

        
    }
}
