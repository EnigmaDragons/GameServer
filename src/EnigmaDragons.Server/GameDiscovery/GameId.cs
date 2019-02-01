namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class GameId
    {
        public string AppId { get; }
        public string Version { get; }

        public GameId(string appId, string version)
        {
            AppId = appId;
            Version = version;
        }

        public override bool Equals(object obj) => string.Equals(ToString(), obj.ToString());
        public override int GetHashCode() => ToString().GetHashCode();
        public override string ToString() => $"{AppId}-{Version}";
    }
}
