using System.Collections.Generic;
using System.Linq;

namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class AvailableGames
    {
        private readonly List<GameListing> _listings = new List<GameListing>();
        private readonly Dictionary<Connection, GameRequested> _requests = new Dictionary<Connection, GameRequested>();

        public void Queue(GameRequested e)
        {
            _requests[e.Player] = e;
            if (!_listings.Any())
                _listings.Add(new GameListing { Id = Rng.Int(), GameId = e.GameId, PlayerRange = e.Players, Players = new List<Connection>()});
        }

        public void Dequeue(Connection c)
        {
            _requests.Remove(c);
        }
    }
}
