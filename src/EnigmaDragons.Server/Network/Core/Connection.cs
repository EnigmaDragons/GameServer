namespace EnigmaDragons.Server.GameDiscovery
{
    public sealed class Connection
    {
        private readonly string _address;
        private readonly long _id;

        public Connection(string address, long id)
        {
            _address = address;
            _id = id;
        }

        public override string ToString() => $"{_address}-{_id}";
        public override int GetHashCode() => ToString().GetHashCode();
        public override bool Equals(object obj) => string.Equals(obj, ToString());
    }
}
