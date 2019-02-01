using System.Collections.Generic;

namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class ListingsUpdated
    {
        public List<GameListing> Games { get; }

        public ListingsUpdated(List<GameListing> games) => Games = games;
    }
}
