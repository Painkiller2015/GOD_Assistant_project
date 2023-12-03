using DSharpPlus;
using GOD_Assistant.DiscordObject;

namespace GOD_Assistant
{
    internal class MessageQueue
    {
        struct typeOfMessage
        {
            public Message mBuild;
            public MessageType mMessageType;
        }
        private List<typeOfMessage> mQueue;
        private List<typeOfMessage> mDeleteQueue;
        private Thread mthread;
        private int Delay;

        public MessageQueue()
        {
            mthread = new Thread(QueueHandler);
            mthread.Start();

            mQueue = new List<typeOfMessage>();
            mDeleteQueue = new List<typeOfMessage>();
        }
        public void AddDelay() => Delay++;

        public void MessageToQueue(Message Build, MessageType mtype)
        {
            typeOfMessage newMessage = new();
            newMessage.mBuild = Build;
            newMessage.mMessageType = mtype;

            mQueue.Add(newMessage);
        }
        public void MessageToDeleteQueue(Message Build, MessageType mtype)
        {
            typeOfMessage newMessage = new();
            newMessage.mBuild = Build;
            newMessage.mMessageType = mtype;

            mDeleteQueue.Add(newMessage);
        }
        public async void QueueHandler()
        {
            //deleteTimer
            for (int i = 0; i < mDeleteQueue.Count; i++)
            {
                mDeleteQueue[i].mBuild.deleteTime--;
                if (mDeleteQueue[i].mBuild.deleteTime < 1)
                {
                    mQueue.Add(mDeleteQueue[i]);
                    mDeleteQueue.RemoveAt(i);
                }
            }
            //Delay
            if (Delay > 0)
            {
                Delay--;
                return;
            }
            //Notif.Handler
            if (mQueue.Count > 0)
            {
                typeOfMessage mes = mQueue.First();
                mQueue.Remove(mes);
            }
        }
    }
}
