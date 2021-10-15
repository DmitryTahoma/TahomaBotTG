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

        protected abstract ActionEndStatus FunctionActionExecute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText);

        public ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            if(isActive)
            {
                try
                {
                    FunctionActionExecute(_client, _message, _addingText);
                }
                catch (Exception e)
                {
                    _addingText?.Invoke("!!!UnknownFail!!!\n" + e.ToString());

                    return ActionEndStatus.UnknownFail;
                }
            }

            return ActionEndStatus.Success;
        }

        public void SetActiveStatus(bool _isActive)
        {
            isActive = _isActive;
        }
    }
}
