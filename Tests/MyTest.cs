using Microsoft.VisualStudio.TestTools.UnitTesting;
using FakerLib;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MyTest
    {
        private Faker faker;
        private Student student;

        [TestInitialize]
        public void Init()
        {
            faker = new Faker();
            student = faker.Create<Student>();
        }

        [TestMethod]
        public void Test_List_Not_Null()
        {
            Assert.AreNotEqual(null, student.lessons);
        }

        [TestMethod]
        public void Test_age_Not_Zero()
        {
            Assert.AreNotEqual(0, student.age);
        }

        [TestMethod]
        public void Test_Group_Not_Null()
        {
            Assert.AreNotEqual(null, student.group);
        } 
    }

    class Student
    {
        public string name;
        public bool isAlive { get; set; }
        public int age;
        public List<List<string>> lessons;
        public Group group;
        public Student(int age, string name)
        {
            this.age = age;
            this.name = name;
        }
        public Student(int age)
        {
            this.age = age;
        }
    }

    class Group
    {
        public int number;
        public List<string> students;
        public string name;
    }
}
