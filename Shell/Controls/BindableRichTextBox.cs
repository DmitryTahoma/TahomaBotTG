using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Shell.Controls
{
    internal class BindableRichTextBox : RichTextBox
    {
        public new FlowDocument Document
        {
            get => (FlowDocument)GetValue(DocumentProperty);
            set => SetValue(DocumentProperty, value);
        }
        public static readonly DependencyProperty DocumentProperty = DependencyProperty.Register("Document", typeof(FlowDocument), typeof(BindableRichTextBox), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnDocumentChanged)));

        private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e != null && e.NewValue != null)
            {
                RichTextBox richTextBox = (BindableRichTextBox)d;
                richTextBox.Document = (FlowDocument)e.NewValue;
            }
        }
    }
}
