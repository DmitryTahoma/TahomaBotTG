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

        protected override ActionEndStatus FunctionActionExecute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            if (_message.Text != null && _message.Text == "/Выключить ПК")
            {
                _client.SendTextMessageAsync(_message.Chat.Id, "Ок, выключаю через 30 сек!");
                Process.Start("shutdown", "-s -t 30");
            }

            return ActionEndStatus.Success;
        }
    }
}
