using System;

namespace EnigmaDragons.Core.Network
{
    public sealed class JsonNetGame : IInitializable, IDisposable, IUpdatable
    {
        private readonly NetGame _net;
        private readonly JsonNetEvents _events;

        public long Id => _net.Net.UniqueIdentifier;
        
        public static JsonNetGame Host(string appId, int port, params Type[] types)
        {
            var netMessageTypes = new NetMessageTypes(types);
            var net = NetGame.CreateHost(appId, port, new JsonEventNetDataMessageHandler(netMessageTypes));
            return new JsonNetGame(net, new JsonNetEvents(net, netMessageTypes));
        }
        
        public static JsonNetGame ConnectTo(string appId, string host, int port, params Type[] types)
        {
            var netMessageTypes = new NetMessageTypes(types);
            var net = NetGame.CreateClient(appId, host, port, new JsonEventNetDataMessageHandler(netMessageTypes));
            return new JsonNetGame(net, new JsonNetEvents(net, netMessageTypes));
        }

        private JsonNetGame(NetGame net, JsonNetEvents events)
        {
            _net = net;
            _events = events;
        }
        
        public void Init()
        {
            _net.Init();
            _events.Init();
        }

        public void Dispose()
        {
            _net.Dispose();
            _events.Dispose();
        }

        public void Update() => _net.Update();
    }
}
