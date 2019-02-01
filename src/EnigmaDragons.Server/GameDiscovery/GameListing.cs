using System.Collections.Generic;

namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class GameListing
    {
        public long Id { get; set; }
        public GameId GameId { get; set; }
        public PlayerRange PlayerRange { get; set; }
        public List<Connection> Players { get; set; }
    }
}
