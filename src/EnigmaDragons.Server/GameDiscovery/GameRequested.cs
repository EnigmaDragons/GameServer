namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class GameRequested
    {
        public GameId GameId { get; set; }
        public Connection Player { get; set; } 
        public PlayerRange Players { get; set; }
    }
}
