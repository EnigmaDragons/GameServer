using System.Collections.Generic;

namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class Lobbies
    {
        private readonly Dictionary<GameId, AvailableGames> _lobbies = new Dictionary<GameId, AvailableGames>();

        public Lobbies()
        {
            
        }

        public void Queue(GameRequested e)
        {
            if (!_lobbies.ContainsKey(e.GameId))
                _lobbies[e.GameId] = new AvailableGames();
            _lobbies[e.GameId].Queue(e);
        }

        public void Dequeue(Connection c)
        {
            _lobbies.Values.ForEach(x => x.Dequeue(c));
        }
    }
}
