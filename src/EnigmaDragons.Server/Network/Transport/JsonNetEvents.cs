using System;
using Lidgren.Network;
using EnigmaDragons.Core.EventSystem;
using Newtonsoft.Json;

namespace EnigmaDragons.Core.Network
{
    public sealed class JsonNetEvents : IInitializable, IDisposable
    {
        private readonly NetGame _game;
        private readonly NetPeer _connection;
        private readonly NetMessageTypes _types;

        public JsonNetEvents(NetGame game, NetMessageTypes types) : this(game, game.Net, types) { }
        private JsonNetEvents(NetGame game, NetPeer connection, NetMessageTypes types)
        {
            _game = game;
            _connection = connection;
            _types = types;
        }

        public void Init() => _types.ForEach(t => Event.NetSubscribe(new EventSubscription(t, Publish, this)));
        
        private void Publish(object payload)
        {
            if (_connection.ConnectionsCount == 0)
                return;
            
            var wrapped = new NetJsonMessage
            {
                OriginId = _connection.UniqueIdentifier, 
                Type = payload.GetType().Name, 
                JsonContent = JsonConvert.SerializeObject(payload)
            };
            var msg = _connection.CreateMessage(JsonConvert.SerializeObject(wrapped));
            _connection.SendMessage(msg, _connection.Connections, NetDeliveryMethod.ReliableUnordered, 0);
            _connection.Connections.ForEach(x => Logger.WriteLine($"Sent: {_connection.UniqueIdentifier} -> {x.RemoteUniqueIdentifier}"));
        }

        public void Dispose() => Event.Unsubscribe(this);
    }
}
