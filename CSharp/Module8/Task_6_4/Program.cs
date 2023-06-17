namespace Task_6_4
{
    using Microsoft.VisualBasic.FileIO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml.Linq;
    using System.IO;
    using System;


    class Program
    {
        [Serializable]
        class Student
        {
            public string Name { get; set; }
            public string Group { get; set; }
            public DateTime DateOfBirth { get; set; }
            public Student(string name, string group, DateTime dateOfBirth)
            {
                Name = name;
                Group = group;
                DateOfBirth = dateOfBirth;
            }
        }

        static void Main(string[] args)
        {
            string binaryFilePath = "C:\\Users\\HP\\Desktop\\BinaryFile.bin";
            string studentsDirectoryPath = "C:\\Users\\HP\\Desktop\\Students";

            var student1 = new Student("Алексей", "2п", DateTime.Now);
            var student2 = new Student("Василий", "4п", DateTime.Now);

            BinaryFormatter formatter = new BinaryFormatter();



            using (var fs = new FileStream(binaryFilePath, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, student1);
                formatter.Serialize(fs, student2);
                Console.WriteLine("Объект сериализован");
            }

            using (var fs = new FileStream(binaryFilePath, FileMode.OpenOrCreate))
            {

                var newStudent1 = (Student)formatter.Deserialize(fs);
                var newStudent2 = (Student)formatter.Deserialize(fs);

                string path1 = $"C:\\Users\\HP\\Desktop\\Students{newStudent1.Group}";
                string path2 = $"C:\\Users\\HP\\Desktop\\Students{newStudent1.Group}";

                if (!File.Exists(path1))
                {
                    File.Create(path1);
                }

                StreamWriter sw1 = new StreamWriter(path1);
                StreamWriter sw2 = new StreamWriter(path2);

                sw1.WriteLine($"{newStudent1.Name}, {newStudent1.DateOfBirth}");
                sw2.WriteLine($"{newStudent1.Name}, {newStudent1.DateOfBirth}");
            }

        }
    }
}


