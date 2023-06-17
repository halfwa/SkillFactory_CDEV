namespace Task_1_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User { Login = "1", Name = "Den", IsPremium = true },
                new User { Login = "2", Name = "Brown", IsPremium = false }
            };

            foreach (var u in users)
            {
                if (u.IsPremium)
                {
                    Console.WriteLine("Вы имеете статус Премиум!");
                }
                else
                {
                    ShowAds();
                }
            }
        }
        static void ShowAds()
        {
            Console.WriteLine("Посетите наш новый сайт с бесплатными играми free.games.for.a.fool.com");
            // Остановка на 1 с
            Thread.Sleep(1000);

            Console.WriteLine("Купите подписку на МыКомбо и слушайте музыку везде и всегда.");
            // Остановка на 2 с
            Thread.Sleep(2000);

            Console.WriteLine("Оформите премиум-подписку на наш сервис, чтобы не видеть рекламу.");
            // Остановка на 3 с
            Thread.Sleep(3000);
        }
    }
}