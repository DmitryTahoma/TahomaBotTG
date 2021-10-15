using Shell.Models.BotFunctions;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Shell.ViewModels.UIAddiction
{
    [Obsolete]
    internal class ControlBuilder
    {
        public IEnumerable<CheckBox> GetBotFunctionCheckBox(IBotFunction _botFunction, double leftMargin = 0)
        {
            List<CheckBox> result = new List<CheckBox>();

            CheckBox checkBox = new CheckBox() 
            {
                Content = _botFunction.Name,
                DataContext = _botFunction,
                Margin = new Thickness(leftMargin, 0, 0, 0)
            };

            RoutedEventHandler action = (s, e) =>
            {
                ((IBotFunction)checkBox.DataContext).SetActiveStatus(checkBox.IsChecked.HasValue && checkBox.IsChecked.Value);
            };
            checkBox.Unchecked += action;
            checkBox.Checked += action;
            action(null, null);

            result.Add(checkBox);

            if(_botFunction is IBotFunctionList functionList)
            {
                foreach(IBotFunction innerBotFunction in functionList.InnerFunctions)
                {
                    result.AddRange(GetBotFunctionCheckBox(innerBotFunction, leftMargin + 20));
                }
            }

            return result;
        }
    }
}
