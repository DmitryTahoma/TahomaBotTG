using Catel.Data;
using Catel.MVVM;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Shell.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            AddEnabledBotFunctions = new Command<StackPanel>(OnAddEnabledBotFunctionsExecute);
            SendMessage = new Command<string>(OnSendMessageExecute);
            StartBot = new Command<Grid>(OnStartBotExecute);
            StopBot = new Command<Grid>(OnStopBotExecute);

            TextDocument = new FlowDocument();
        }

        public override string Title => "TahomaBot";

        public FlowDocument TextDocument
        {
            get => GetValue<FlowDocument>(TextDocumentProperty);
            set => SetValue(TextDocumentProperty, value);
        }
        public static readonly PropertyData TextDocumentProperty = RegisterProperty(nameof(TextDocument), typeof(FlowDocument), null);

        public bool IsEnabledStartBotButton
        {
            get => GetValue<bool>(IsEnabledStartBotButtonProperty);
            set => SetValue(IsEnabledStartBotButtonProperty, value);
        }
        public static readonly PropertyData IsEnabledStartBotButtonProperty = RegisterProperty(nameof(IsEnabledStartBotButton), typeof(bool), true);

        public bool IsEnabledStopBotButton
        {
            get => GetValue<bool>(IsEnabledStopBotButtonProperty);
            set => SetValue(IsEnabledStopBotButtonProperty, value);
        }
        public static readonly PropertyData IsEnabledStopBotButtonProperty = RegisterProperty(nameof(IsEnabledStopBotButton), typeof(bool), false);

        public Command<StackPanel> AddEnabledBotFunctions { get; private set; }
        private void OnAddEnabledBotFunctionsExecute(StackPanel _stackPanel)
        { }

        public Command<string> SendMessage { get; private set; }
        private void OnSendMessageExecute(string _message)
        { }

        public Command<Grid> StartBot { get; private set; }
        private void OnStartBotExecute(Grid _statusGrid)
        { }

        public Command<Grid> StopBot { get; private set; }
        private void OnStopBotExecute(Grid _statusGrid)
        { }
    }
}
