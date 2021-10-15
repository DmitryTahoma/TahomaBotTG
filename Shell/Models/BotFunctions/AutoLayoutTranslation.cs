using System;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shell.Models.BotFunctions
{
    [Obsolete]
    internal class AutoLayoutTranslation : BaseBotFunction
    {
        public override string Name => "автоматический перевод английской расскладки на русскую";

        protected override ActionEndStatus FunctionActionExecute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            if (IsNeedToTranslate(_message.Text))
            {
                string translatedText = TranslateLayout(_message.Text);

                _client.SendTextMessageAsync(_message.Chat.Id, translatedText, replyToMessageId: _message.MessageId);

                _addingText?.Invoke("Auto translator sended message: " + translatedText);
            }

            return ActionEndStatus.Success;
        }

        private bool IsNeedToTranslate(string _text)
        {
            _text = _text.ToLower();

            foreach (char ch in _text)
            {
                switch (ch)
                {
                    case 'q': case 'w': case 'e': case 'r': case 't': case 'y': case 'u': case 'i': case 'o': case 'p': case 'a': case 's': case 'd': case 'f': case 'g': case 'h': case 'j': case 'k': case 'l': case 'z': case 'x': case 'c': case 'v': case 'b': case 'n': case 'm': 
                        return true;
                }
            }

            return false;
        }

        private string TranslateLayout(string _text)
        {
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < _text.Length; ++i)
            {
                switch (_text[i])
                {
                    case 'q': res.Append('й'); break;
                    case 'w': res.Append('ц'); break;
                    case 'e': res.Append('у'); break;
                    case 'r': res.Append('к'); break;
                    case 't': res.Append('е'); break;
                    case 'y': res.Append('н'); break;
                    case 'u': res.Append('г'); break;
                    case 'i': res.Append('ш'); break;
                    case 'o': res.Append('щ'); break;
                    case 'p': res.Append('з'); break;
                    case '[': res.Append('х'); break;
                    case ']': res.Append('ъ'); break;
                    case 'a': res.Append('ф'); break;
                    case 's': res.Append('ы'); break;
                    case 'd': res.Append('в'); break;
                    case 'f': res.Append('а'); break;
                    case 'g': res.Append('п'); break;
                    case 'h': res.Append('р'); break;
                    case 'j': res.Append('о'); break;
                    case 'k': res.Append('л'); break;
                    case 'l': res.Append('д'); break;
                    case ';': res.Append('ж'); break;
                    case '\'': res.Append('э'); break;
                    case 'z': res.Append('я'); break;
                    case 'x': res.Append('ч'); break;
                    case 'c': res.Append('с'); break;
                    case 'v': res.Append('м'); break;
                    case 'b': res.Append('и'); break;
                    case 'n': res.Append('т'); break;
                    case 'm': res.Append('ь'); break;
                    case ',': res.Append('б'); break;
                    case '.': res.Append('ю'); break;
                    case '/': res.Append('.'); break;
                    case 'Q': res.Append('Й'); break;
                    case 'W': res.Append('Ц'); break;
                    case 'E': res.Append('У'); break;
                    case 'R': res.Append('К'); break;
                    case 'T': res.Append('Е'); break;
                    case 'Y': res.Append('Н'); break;
                    case 'U': res.Append('Г'); break;
                    case 'I': res.Append('Ш'); break;
                    case 'O': res.Append('Щ'); break;
                    case 'P': res.Append('З'); break;
                    case '{': res.Append('Х'); break;
                    case '}': res.Append('Ъ'); break;
                    case 'A': res.Append('Ф'); break;
                    case 'S': res.Append('Ы'); break;
                    case 'D': res.Append('В'); break;
                    case 'F': res.Append('А'); break;
                    case 'G': res.Append('П'); break;
                    case 'H': res.Append('Р'); break;
                    case 'J': res.Append('О'); break;
                    case 'K': res.Append('Л'); break;
                    case 'L': res.Append('Д'); break;
                    case ':': res.Append('Ж'); break;
                    case '"': res.Append('Э'); break;
                    case '|': res.Append('/'); break;
                    case 'Z': res.Append('Я'); break;
                    case 'X': res.Append('Ч'); break;
                    case 'C': res.Append('С'); break;
                    case 'V': res.Append('М'); break;
                    case 'B': res.Append('И'); break;
                    case 'N': res.Append('Т'); break;
                    case 'M': res.Append('Ь'); break;
                    case '<': res.Append('Б'); break;
                    case '>': res.Append('Ю'); break;
                    case '?': res.Append(','); break;
                    case '@': res.Append('"'); break;
                    case '#': res.Append('№'); break;
                    case '$': res.Append(';'); break;
                    case '^': res.Append(':'); break;
                    case '&': res.Append('?'); break;
                    default: res.Append(_text[i]); break;
                }
            }

            return res.ToString();
        }
    }
}
