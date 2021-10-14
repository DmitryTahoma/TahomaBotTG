using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal class GenerateButtonsForDmitryTahoma : BaseBotFunction
    {
        public override string Name => "генерация кнопок для DmitryTahoma";

        public override ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            if(_message.From.Username == "DmitryTahoma")
            {
                try
                {
                    _client.SendTextMessageAsync(_message.Chat.Id, "Спец.возможности для DmitryTahoma", replyMarkup: new ReplyKeyboardMarkup
                    {
                        Keyboard = new List<List<KeyboardButton>>
                        {
                            new List<KeyboardButton>{ new KeyboardButton { Text = "/Выключить ПК" }, new KeyboardButton { Text = "/Получить скрин" } }
                        }
                    });
                }
                catch
                {
                    return ActionEndStatus.UnknownFail;
                }
            }

            return ActionEndStatus.Success;
        }
    }
}
