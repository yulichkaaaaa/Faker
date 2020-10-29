using System;
using System.Collections.Generic;
using FakerLib;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();
            Student Yulia = faker.Create<Student>();

            MyXmlSerializer serializerXml = new MyXmlSerializer();
            ConsoleWriter consoleWriter = new ConsoleWriter();

            string xml = serializerXml.Serialize(Yulia);
            consoleWriter.Write(xml);
            Console.ReadLine();

        }
    }

    public class Student
    {

        public string name;
        public DateTime birthDate; 
        public bool isAlive { get;  set; }
        public int age;
        public List<List<string>> lessons;
        public Group group;
        public Student(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
        Student() { }
        public Student(int age)
        {
            this.age = age;
        }
    }

    public class Group
    {
        public int number;
        public List<string> students;
        public string name;
    }
}
