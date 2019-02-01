using EnigmaDragons.Core.Network;
using NUnit.Framework;

namespace EnigmaDragons.Server.Tests
{
    [TestFixture]
    public class GameServerTests
    {
        private const string AppId = "TestGameServer";
        private const int Port = 55235;
        private static GameServer _server;
        
        [SetUp]
        public static void Setup()
        {
            _server = new GameServer(AppId, Port);
            _server.Init();
        }
        
        [Test]
        public void GameServer_OnRequestGame_IsInLobby()
        {
            var client = JsonNetGame.ConnectTo(AppId, "127.0.0.1", Port);
            client.Init();
            
            _server.Update();
            client.Update();

            int i = 0;
        }
    }
}
