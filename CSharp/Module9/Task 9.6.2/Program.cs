namespace Task_9._6._2
{
    class IncorrectAnswerException : Exception
    {
        public IncorrectAnswerException(string message) : base(message) { }
    }
    class UserDataProcessor
    {
        public delegate void Process(int num, List<string> list);
        public event Process ProcessEvent;

        public void StartProcess(List<string> list)
        {
            int input = 0;
            bool isCorrect = false;

            while (!isCorrect)
            {
                try
                {
                    Console.WriteLine("Введите 1 для сортировки формата А-Я или введите 2 для сортировки Я-А");
                    input = Convert.ToInt32(Console.ReadLine());

                    if (input != 1 && input != 2)
                    {
                        throw new IncorrectAnswerException("Ошибка! Введите 1 или 2.");
                    }
                    else
                    {
                        isCorrect = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            OnSort(input, list);
        }

        protected virtual void OnSort(int num, List<string> list)
        {
            ProcessEvent?.Invoke(num, list);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> surnames = new List<string>
            {
                "Обама",
                "Пистолетов",
                "Бэк",
                "Шамов",
                "Авдеев"
            };

            var userDataProcessor = new UserDataProcessor();
            userDataProcessor.ProcessEvent += Sorting;
            userDataProcessor.StartProcess(surnames);
        }
        private static void Sorting(int number, List<string> surnames)
        {
            switch (number)
            {
                case 1:
                    Sort(surnames);
                    break;

                case 2:
                    SortDesc(surnames);
                    break;
            }
        }
        private static void Sort(List<string> surnames)
        {
            var sorted = surnames.OrderBy(x => x);
            foreach (var s in sorted)
            {
                Console.WriteLine(s);
            }
        }
        private static void SortDesc(List<string> surnames)
        {
            var sorted = surnames.OrderByDescending(x => x);
            foreach (var s in sorted)
            {
                Console.WriteLine(s);
            }
        }

    }

}