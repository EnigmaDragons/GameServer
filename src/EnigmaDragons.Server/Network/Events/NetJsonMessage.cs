
namespace EnigmaDragons.Core.Network
{  
    public sealed class NetJsonMessage
    {
        public long OriginId { get; set; }
        public string Type { get; set; }
        public string JsonContent { get; set; }
    }
}
