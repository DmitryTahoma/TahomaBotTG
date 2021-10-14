using Catel.Data;
using Catel.MVVM;
using Shell.Models;
using Shell.Models.BotFunctions;
using Shell.ViewModels.UIAddiction;
using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Shell.ViewModels
{
    [Obsolete]
    public class MainWindowViewModel : ViewModelBase
    {
        private MainWindowModel model;
        private FlowDocumentFormatter documentFormatter;
        private ControlBuilder controlBuilder;
        private NotifyIcon notifyIcon;

        public MainWindowViewModel()
        {
            model = new MainWindowModel();
            controlBuilder = new ControlBuilder();

            InitializeNotifyIcon();
            InitializeCommands();

            TextDocument = new FlowDocument();
        }

        private void InitializeNotifyIcon()
        {
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Resources\\Icons\\logo.ico")).Stream;
            Icon icon = new Icon(iconStream);
            notifyIcon = new NotifyIcon()
            {
                Icon = icon,
                Text = Title
            };
            notifyIcon.Click += OnNotifyIconClick;
        }

        private void InitializeCommands()
        {
            AddEnabledBotFunctions = new Command<StackPanel>(OnAddEnabledBotFunctionsExecute);
            SendMessage = new Command<string>(OnSendMessageExecute);
            StartBot = new Command<Grid>(OnStartBotExecute);
            StopBot = new Command<Grid>(OnStopBotExecute);
            DisposeViewModel = new Command(OnDisposeViewModelExecute);
            HideToBackground = new Command(OnHideToBackgroundExecute);
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

        public Visibility WindowVisibility
        {
            get => GetValue<Visibility>(WindowVisibilityProperty);
            set => SetValue(WindowVisibilityProperty, value);
        }
        public static readonly PropertyData WindowVisibilityProperty = RegisterProperty(nameof(WindowVisibility), typeof(Visibility), Visibility.Visible);

        public Command<StackPanel> AddEnabledBotFunctions { get; private set; }
        private void OnAddEnabledBotFunctionsExecute(StackPanel _stackPanel)
        {
            documentFormatter = new FlowDocumentFormatter(TextDocument);
            model.SubscribeOnAddingText(documentFormatter.AddOrangeText);
            model.SubscribeOnAddingReceivedText(documentFormatter.AddReceivedBotsText);

            foreach (IBotFunction botFunction in model.BotFunctions)
            {
                _stackPanel.Children.Add(controlBuilder.GetBotFunctionCheckBox(botFunction));
            }
        }

        public Command<string> SendMessage { get; private set; }
        private void OnSendMessageExecute(string _message)
        { }

        public Command<Grid> StartBot { get; private set; }
        private void OnStartBotExecute(Grid _statusGrid)
        {
            _statusGrid.Background = System.Windows.Media.Brushes.Yellow;
            IsEnabledStartBotButton = false;

            model.ActivateBotReceiving((endStatus) => 
            {
                if(endStatus == ActionEndStatus.Success)
                {
                    _statusGrid.Background = System.Windows.Media.Brushes.Green;
                    IsEnabledStopBotButton = true;
                }
            });
        }

        public Command<Grid> StopBot { get; private set; }
        private void OnStopBotExecute(Grid _statusGrid)
        {
            _statusGrid.Background = System.Windows.Media.Brushes.Yellow;
            IsEnabledStopBotButton = false;

            model.DeactivateBotReceiving((endStatus) => 
            { 
                if(endStatus == ActionEndStatus.Success)
                {
                    _statusGrid.Background = System.Windows.Media.Brushes.Red;
                    IsEnabledStartBotButton = true;
                }
            });
        }

        public Command DisposeViewModel { get; private set; }
        private void OnDisposeViewModelExecute()
        {
            notifyIcon?.Dispose();
        }

        public Command HideToBackground { get; private set; }
        private void OnHideToBackgroundExecute()
        {
            WindowVisibility = Visibility.Hidden;
            notifyIcon.Visible = true;
        }

        private void OnNotifyIconClick(object sender, EventArgs e)
        {
            WindowVisibility = Visibility.Visible;
            notifyIcon.Visible = false;
        }
    }
}
