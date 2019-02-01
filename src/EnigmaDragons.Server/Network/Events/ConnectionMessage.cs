using EnigmaDragons.Server.GameDiscovery;

namespace EnigmaDragons.Core.Network
{
    public sealed class ConnectionMessage<T>
    {
        public Connection Connection { get; }
        public T Payload { get; }

        public ConnectionMessage(Connection c, T payload)
        {
            Connection = c;
            Payload = payload;
        }
    }
}
