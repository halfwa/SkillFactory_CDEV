using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.ConstrainedExecution;

namespace Task_13_6_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var path = "C:\\Users\\HP\\Desktop\\Downloads\\text.txt";
            var text = File.ReadAllText(path);

            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            string[] words = noPunctuationText.Split(new char[] { ' ' });

            var wordDictionary = new Dictionary<string,int>(); 

            foreach (var word in words) 
            {
                if (!wordDictionary.ContainsKey(word))
                {
                    wordDictionary.Add(word, 1);
                }
                else
                {
                    wordDictionary[word]++;
                }
            }

            var result = wordDictionary.Values.OrderDescending().Take(10);

            foreach (var count in result)
            {
                Console.WriteLine(count);
            }
            Console.ReadKey();
        }
    }
}