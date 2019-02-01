using System;

namespace EnigmaDragons.Server
{
    internal class Program
    {
        private const string AppId = "Enigma Dragons Game Server";
        private const int Port = 9021;
        private static bool _isExiting;
        
        public static void Main(string[] args)
        {
            Console.CancelKeyPress += (s, e) => _isExiting = true;
            Logger.AddSink(Console.WriteLine);
            
            var server = new GameServer(AppId, Port);
            server.Init();
            while (!_isExiting)
                server.Update();
            server.Dispose();
        }
    }
}
