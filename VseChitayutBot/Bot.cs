using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace VseChitayutBot
{
    internal class Bot : TelegramBotClient
    {
        public List<int> admins = new List<int>();
        public bool Exit { get; private set; } = false;
        public Bot(string token, HttpClient httpClient = null) : base(token, httpClient)
        {
            OnMessage += ProcessMessage;
        }

        private void ProcessMessage(object sender, MessageEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
