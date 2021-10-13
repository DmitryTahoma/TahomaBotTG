using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Shell.ViewModels.UIAddiction
{
    internal class FlowDocumentFormatter
    {
        private FlowDocument textDocument;

        public FlowDocumentFormatter(FlowDocument _document)
        {
            textDocument = _document;
        }

        public void AddReceivedBotsText(DateTime _time, string _username, string _text)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new TextBlock() { Text = "[" + _time.ToString() + "] ", Foreground = System.Windows.Media.Brushes.DarkGray });
                paragraph.Inlines.Add(new TextBlock() { Text = _username + " ", Foreground = System.Windows.Media.Brushes.CadetBlue });
                paragraph.Inlines.Add(new TextBlock() { Text = _text });

                textDocument.Blocks.Add(paragraph);
            });
        }

        public void AddOrangeText(string _text)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Paragraph paragraph = new Paragraph();
                paragraph.Inlines.Add(new TextBlock() { Text = _text, Foreground = System.Windows.Media.Brushes.Orange });

                textDocument.Blocks.Add(paragraph);
            });
        }
    }
}
