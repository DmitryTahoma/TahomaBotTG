using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal abstract class BaseBotFunction : IBotFunction
    {
        protected bool isActive;

        public BaseBotFunction()
        {
            isActive = false;
        }

        public abstract string Name { get; }

        public abstract ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText);

        public void SetActiveStatus(bool _isActive)
        {
            isActive = _isActive;
        }
    }
}
