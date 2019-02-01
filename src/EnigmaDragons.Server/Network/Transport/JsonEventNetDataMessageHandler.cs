using System;
using EnigmaDragons.Core.EventSystem;
using Newtonsoft.Json;

namespace EnigmaDragons.Core.Network
{
    public sealed class JsonEventNetDataMessageHandler : INetDataMessageHandler
    {
        private readonly NetMessageTypes _types;

        public JsonEventNetDataMessageHandler(params Type[] types) : this(new NetMessageTypes(types)) {}
        public JsonEventNetDataMessageHandler(NetMessageTypes types)
        {
            _types = types;
        }

        public void Handle(long connectionId, string body)
        {
            var msg = JsonConvert.DeserializeObject<NetJsonMessage>(body);
            if (msg.OriginId.Equals(connectionId))
                return;
            
            var content = JsonConvert.DeserializeObject(msg.JsonContent, _types.Get(msg.Type));
            Event.PublishLocally(content);
        }
    }
}
