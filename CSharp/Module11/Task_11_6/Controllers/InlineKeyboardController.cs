using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Task_11_6.Controllers
{
    internal class InlineKeyboardController
    {
        private readonly object _telegramClient;

        public InlineKeyboardController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(CallbackQuery? callbackQuery, CancellationToken ct)
        {
            if (callbackQuery?.Data == null)
            {
                return;
            }

            switch (callbackQuery.Data)
            {
                case "CalcChars": 
                    return;
                case "Sum":
                    return;
                default:
                    return;
            }
        }
    }
}
