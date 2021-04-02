﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace VseChitayutBot
{
    internal class Bot : TelegramBotClient
    {
        public const string SETTINGSFILE = "settings.txt";
        public List<int> admins = new List<int>()
        {
            98071669, // Egor
            577400792 // Inna
        };
        public bool Exit { get; private set; } = false;
        private long channelId;
        private long chatId;
        private bool productiveMode = false;
        public Bot(string token, HttpClient httpClient = null) : base(token, httpClient)
        {
            LoadSettings();
            OnMessage += ProcessMessage;
        }

        private void ProcessMessage(object sender, MessageEventArgs e)
        {
            if (admins.Contains(e.Message.From.Id) && e.Message.ForwardFromChat != null)
            {
                SetChannelSettings(e.Message);
            }
        }

        private void SetChannelSettings(Message message)
        {
            long id = message.ForwardFromChat.Id;
            Chat chat = GetChatAsync(id).Result;
            if (chat.Type == Telegram.Bot.Types.Enums.ChatType.Channel)
                channelId = id;
            if (chat.Type == ChatType.Group||chat.Type==ChatType.Supergroup)
                chatId = id;
            if (channelId != 0 && chatId != 0) SaveSettings();
        }
        private void LoadSettings()
        {
            if (System.IO.File.Exists(SETTINGSFILE))
            {
                try
                {
                    string[] lines = System.IO.File.ReadAllLines(SETTINGSFILE);
                    channelId = Convert.ToInt64(lines[0]);
                    chatId = Convert.ToInt64(lines[1]);
                    productiveMode = true;
                }
                catch (Exception err)
                {
                    productiveMode = false;
                }
            }
            else
            {
                productiveMode = false;
            }
        }
        private void SaveSettings()
        {
            System.IO.File.WriteAllLines(SETTINGSFILE, new string[]
                 {
                     Convert.ToString(channelId),
                     Convert.ToString(chatId)
                 });
        }
    }
}
