using Shell.Models.BotFunctions;
using Shell.Models.BotFunctions.DmitryTahomaFunctions;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Shell.Models
{
    [Obsolete]
    internal class MainWindowModel
    {
        private readonly string token = "2085683392:AAHe80bTvm_y-QCLDmEnoEk7zhhBoQPLudw";
        private TelegramBotClient client;
        private List<IBotFunction> botFunctions;

        private event ActionAddingReceivedText addedReceivedText;
        private event ActionAddingText addedText;

        public delegate void ActionCallback(ActionEndStatus _endStatus);
        public delegate void ActionAddingReceivedText(DateTime _time, string _username, string _text);
        public delegate void ActionAddingText(string _text);

        public MainWindowModel()
        {
            client = new TelegramBotClient(token);
            client.OnMessage += OnMessage;

            botFunctions = new List<IBotFunction>
            {
                new AutoLayoutTranslation(),
                new GenerateButtonsForDmitryTahoma(),
                new ShutdownPC(),
                new GettingScreen()
            };
        }

        public IEnumerable<IBotFunction> BotFunctions => botFunctions;

        public void ActivateBotReceiving(ActionCallback _callback = null)
        {
            ActionEndStatus endStatus = ActionEndStatus.Success;
            try
            {
                client.StartReceiving();
            }
            catch
            {
                endStatus = ActionEndStatus.UnknownFail;
            }

            _callback?.Invoke(endStatus);
        }

        public void DeactivateBotReceiving(ActionCallback _callback = null)
        {
            ActionEndStatus endStatus = ActionEndStatus.Success;
            try
            {
                client.StopReceiving();
            }
            catch
            {
                endStatus = ActionEndStatus.UnknownFail;
            }

            _callback?.Invoke(endStatus);
        }

        public void SubscribeOnAddingReceivedText(ActionAddingReceivedText _action)
        {
            addedReceivedText += _action;
        }

        public void SubscribeOnAddingText(ActionAddingText _action)
        {
            addedText += _action;
        }

        private void OnMessage(object s, MessageEventArgs e)
        {
            if (e != null && e.Message != null)
            {
                addedReceivedText?.Invoke(DateTime.Now, e.Message.From.Username, e.Message.Text);

                foreach(IBotFunction fn in BotFunctions)
                {
                    ActionEndStatus status = fn.Execute(client, e.Message, addedText);

                    if(status == ActionEndStatus.UnknownFail)
                    {
                        addedText?.Invoke("!!!UnknownFail!!! во время: " + fn.Name);
                    }
                }
            }
        }
    }
}
