using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Net.Security;
using System.Runtime.InteropServices;

namespace Task_14_3_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBook = new List<Contact>();

            // добавляем контакты
            phoneBook.Add(new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"));
            phoneBook.Add(new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"));
            phoneBook.Add(new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"));
            phoneBook.Add(new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"));
            phoneBook.Add(new Contact("Сергей", "Брин", 799900000013, "serg@example.com"));
            phoneBook.Add(new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com"));

            while (true)
            {
                Console.WriteLine("Введите номер страницы для загрузки: 1, 2, 3.");
                var input = Console.ReadLine();
                var parsed = Int32.TryParse(input, out int pageNumber);
                Console.Clear();

                if (!parsed || pageNumber < 1 || pageNumber > 3)
                {
                    Console.WriteLine("Страницы не существует!");
                }
                else
                {
                    var pageContent = phoneBook.Skip((pageNumber - 1) * 2).Take(2);

                    var sortedContent = pageContent.OrderBy(c => c.Name).ThenBy(c => c.LastName); // Решение задания
                    foreach (var contact in pageContent)
                    {
                        Console.WriteLine($"{contact.Name} {contact.LastName} - {contact.PhoneNumber} - {contact.Email}");
                    }
                }
                Console.ReadLine();
            }
        }
    }
    public class Contact 
    {
        public Contact(string name, string lastName, long phoneNumber, String email)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public String Name { get; }
        public String LastName { get; }
        public long PhoneNumber { get; }
        public String Email { get; }
    }
}