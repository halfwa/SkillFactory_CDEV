using System.Diagnostics;

namespace Task_13_6_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\HP\\Desktop\\Downloads\\text.txt";
            var symbols = File.ReadAllText(path).ToCharArray();   

            Stopwatch sw = new Stopwatch();

            sw.Start();

            List<char> chars = new List<char>(); // 24ms
            foreach (char s in symbols)
            {
                chars.Add(s);
      
            }

            //LinkedList<char> chars = new LinkedList<char>(); // 1400ms

            //var firstChar = chars.AddFirst(' ');

            //foreach (char s in symbols)
            //{
            //    chars.AddAfter(firstChar,s);   
            //}

            sw.Stop();

            Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            Console.ReadKey();
        }
    }
}