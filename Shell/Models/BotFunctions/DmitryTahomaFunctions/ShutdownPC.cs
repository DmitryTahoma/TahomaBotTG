using System;
using System.Diagnostics;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shell.Models.BotFunctions.DmitryTahomaFunctions
{
    [Obsolete]
    internal class ShutdownPC : BaseBotFunction
    {
        public override string Name => "выключение ПК";

        public override ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            try
            {
                if (isActive && _message.Text != null && _message.Text == "/Выключить ПК")
                {
                    _client.SendTextMessageAsync(_message.Chat.Id, "Ок, выключаю через 30 сек!");
                    Process.Start("shutdown", "-s -t 30");
                }
            }
            catch
            {
                return ActionEndStatus.UnknownFail;
            }

            return ActionEndStatus.Success;
        }
    }
}
