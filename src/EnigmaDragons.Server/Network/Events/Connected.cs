using EnigmaDragons.Server.GameDiscovery;

namespace EnigmaDragons.Core.Network
{
    public sealed class Connected
    {
        public Connection Connection { get; }

        public Connected(Connection c) => Connection = c;
    }
}
