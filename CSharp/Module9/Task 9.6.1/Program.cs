namespace Task_9._6._1
{
    class IncorrectStringLengthException : Exception
    {
        public IncorrectStringLengthException(string message) : base(message) { }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Exception> listException = new List<Exception>();
            listException.Add(new IncorrectStringLengthException("Некорректная длина строки!"));
            listException.Add(new ArgumentNullException());
            listException.Add(new RankException());
            listException.Add(new ArgumentException());
            listException.Add(new InvalidOperationException());

            foreach (var ex in listException)
            {
                try
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}