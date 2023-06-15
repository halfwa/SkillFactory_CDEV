using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Task_11_6.Controllers
{
    internal class TextMessageController
    {
        private readonly ITelegramBotClient _telegramClient;

        public TextMessageController(ITelegramBotClient telegramBotClient)
        {
            _telegramClient = telegramBotClient;
        }
        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    //объект представляющий кнопки 
                    var buttons = new List<InlineKeyboardButton[]>();
                    buttons.Add(new[]
                    {
                    InlineKeyboardButton.WithCallbackData($"Посчитать символы", $"CalcChars"),
                    InlineKeyboardButton.WithCallbackData($"Сложить цифры", $"Sum")
                    });

                    //Передаем кнопки вместе с сообщением (Параметр ReplyMarkup)
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                        $"<b> Наш бот готов посчитать для вас буквы или цифры.</b> {Environment.NewLine}" +
                        $"{Environment.NewLine} 1.Считает символы в сообщение\n" +
                        $"2.Считает сумму всех цифр, записанных через пробел{Environment.NewLine}",
                        cancellationToken: ct,
                        parseMode: ParseMode.Html,
                        replyMarkup: new InlineKeyboardMarkup(buttons));
                    break;

                default:
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, "В меню вы можете узнать, что может бот", cancellationToken: ct);
                    break;
            }
        }
    }
}
