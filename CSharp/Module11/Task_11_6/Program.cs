using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Task_11_6.Controllers;
using Telegram.Bot;

namespace Task_11_6
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) => ConfigureServices(services))
                .UseConsoleLifetime()
                .Build();

            Console.WriteLine("Сервер запущен");
            await host.RunAsync();
        }
        static void ConfigureServices(IServiceCollection services)
        {
            string botToken = "5878584274:AAHIwb0jnFKPbiyBMV57RNZiDrQK8fuDaGo";


            services.AddTransient<InlineKeyboardController>();
            services.AddSingleton<TextMessageController>();
            services.AddTransient<DefaultMessageController>();

            services.AddSingleton<ITelegramBotClient>(provider => new TelegramBotClient(botToken));

            services.AddHostedService<Bot>();
        }
    }
}