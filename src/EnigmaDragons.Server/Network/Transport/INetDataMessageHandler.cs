namespace EnigmaDragons.Core.Network
{
    public interface INetDataMessageHandler
    {
        void Handle(long connectionId, string body);
    }
}
