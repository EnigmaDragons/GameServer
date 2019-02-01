using EnigmaDragons.Server.GameDiscovery;

namespace EnigmaDragons.Core.Network
{
    public sealed class Disconnected
    {
        public Connection Connection { get; }

        public Disconnected(Connection c) => Connection = c;
    }
}
