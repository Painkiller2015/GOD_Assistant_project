using DSharpPlus.Entities;

namespace GOD_Assistant.DiscordObject
{
    public class Message
    {
        public DiscordChannel Сhannel { get; set; }
        public DiscordMessage DMessage { get; set; }
        public bool deleteFlag { get; set; }
        public int deleteTime { get; set; } = 5;
        public Dictionary<string, Stream> files = null;
        public bool MentionsAll = true;
        public DiscordSelectComponent SelMenu; //сделать приватным                        
        public Message()
        {
        }
        //public async Task<DiscordMessage> SendMessageWithQ()
        //{
        //    StaticValues sv = StaticValues.Instance();
        //    sv.mQueue.MessageToQueue(this, MessageType.Default);
        //    return DMessage;
        //}
        //public void DeleteMessage()
        //{
        //    StaticValues sv = StaticValues.Instance();
        //    sv.mQueue.MessageToQueue(this, MessageType.RecipientRemove);
        //}
        //public void UpdateMessage()
        //{
        //    //OldMessage = BuildMessage();
        //    StaticValues sv = StaticValues.Instance();
        //    sv.mQueue.MessageToQueue(this, MessageType.RecipientAdd);
        //}
    }
}
