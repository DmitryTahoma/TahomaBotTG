using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shell.Models.BotFunctions.DmitryTahomaFunctions
{
    [Obsolete]
    internal class DmitryTahomaFunctions : BaseBotFunctionList
    {
        public DmitryTahomaFunctions() : base(new ShutdownPC(), new GettingScreen()) { }

        public override string Name => "спец.возможности для DmitryTahoma";

        protected override ActionEndStatus FunctionActionExecute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            ActionEndStatus fStatus = ActionEndStatus.Success;

            if (_message.From.Username == "DmitryTahoma")
            {
                foreach (IBotFunction botFunction in innerFunctions)
                {
                    if (botFunction.Execute(_client, _message, _addingText) != ActionEndStatus.Success)
                    {
                        fStatus = ActionEndStatus.InnerFunctionFail;
                        _addingText?.Invoke("!!!InnerFunctionFail!!! во время " + Name);
                    }
                }

                _client.SendTextMessageAsync(_message.Chat.Id, "Спец.возможности для DmitryTahoma", replyMarkup: new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                        {
                            new List<KeyboardButton>{ new KeyboardButton { Text = "/Выключить ПК" }, new KeyboardButton { Text = "/Получить скрин" } }
                        }
                });
            }

            return fStatus;
        }
    }
}
