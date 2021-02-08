using Telegram.Bot.Types.Enums;
namespace OPIS
{
    class Msg
    {
        public long id;
        public string msg;
        public string firstName;
        public Telegram.Bot.Types.Enums.MessageType msgtype;
        public override string ToString()
        {
            return $"{firstName}: {msg}";
        }
    }
}
