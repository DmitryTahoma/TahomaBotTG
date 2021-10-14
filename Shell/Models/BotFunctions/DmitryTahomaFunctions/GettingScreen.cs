using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Shell.Models.BotFunctions.DmitryTahomaFunctions
{
    [Obsolete]
    internal class GettingScreen : BaseBotFunction
    {
        public override string Name => "получить скрин для DmitryTahoma";

        public override ActionEndStatus Execute(ITelegramBotClient _client, Message _message, MainWindowModel.ActionAddingText _addingText)
        {
            try
            {
                if (isActive && _message.From.Username == "DmitryTahoma" && _message.Text != null && _message.Text == "/Получить скрин")
                {
                    Bitmap printscreen = new Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
                    Graphics graphics = Graphics.FromImage(printscreen);
                    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

                    string tempFilename = "temp_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".png";
                    printscreen.Save(tempFilename, ImageFormat.Png);

                    FileStream fileStream = new FileStream(tempFilename, FileMode.Open);

                    _client.SendMediaGroupAsync(_message.Chat.Id, new List<InputMediaPhoto> { new InputMediaPhoto(new InputMedia(fileStream, tempFilename)) }).Wait();

                    fileStream?.Dispose();
                    System.IO.File.Delete(tempFilename);
                }
            }
            catch
            {
                return ActionEndStatus.UnknownFail;
            }

            return ActionEndStatus.Success;
        }
    }
}
