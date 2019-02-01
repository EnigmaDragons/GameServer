using System;
using EnigmaDragons.Core.EventSystem;
using EnigmaDragons.Core.Network;
using EnigmaDragons.Server.GameDiscovery;

namespace EnigmaDragons.Server
{
    public sealed class GameServer : IUpdatable, IDisposable, IInitializable
    {
        private static readonly Type[] NetTypes = {};
        private readonly Connections _connections = new Connections();
        private readonly Lobbies _lobbies = new Lobbies();
        private readonly JsonNetGame _host;

        public GameServer(string serverId, int port)
            : this(JsonNetGame.Host(serverId, port, NetTypes)) {}
        
        private GameServer(JsonNetGame host)
        {
            _host = host;
            Event.Subscribe<Connected>(AddConnection, this);
            Event.Subscribe<Disconnected>(RemoveConnection, this);
            Event.Subscribe<GameRequested>(JoinLobby, this);
        }

        private void JoinLobby(GameRequested obj)
        {
            _lobbies.Queue(obj);
        }

        private void RemoveConnection(Disconnected e)
        {
            _connections.Remove(e.Connection);
        }

        private void AddConnection(Connected e)
        {
            _connections.Add(e.Connection);
        }

        public void Update() => _host.Update();
        public void Dispose() => _host.Dispose();
        public void Init() => _host.Init();
    }
}
