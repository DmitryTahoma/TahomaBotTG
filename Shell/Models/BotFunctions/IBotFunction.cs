using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal interface IBotFunction
    {
        string Name { get; }

        ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText);
        void SetActiveStatus(bool _isActive);
    }
}
