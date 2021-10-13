using Shell.Models.BotFunctions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Shell.ViewModels.UIAddiction
{
    [Obsolete]
    internal class ControlBuilder
    {
        public CheckBox GetBotFunctionCheckBox(IBotFunction _botFunction)
        {
            CheckBox checkBox = new CheckBox() { Content = _botFunction.Name, DataContext = _botFunction };

            RoutedEventHandler action = (s, e) =>
            {
                ((IBotFunction)checkBox.DataContext).SetActiveStatus(checkBox.IsChecked.HasValue && checkBox.IsChecked.Value);
            };
            checkBox.Unchecked += action;
            checkBox.Checked += action;
            action(null, null);

            return checkBox;
        }
    }
}
