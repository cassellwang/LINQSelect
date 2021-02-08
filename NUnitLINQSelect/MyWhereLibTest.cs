using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace MyWhereTest
{
    public class MyWhereLibTest
    {
        [Test]
        public void Where_Adult()
        {
            var people = new List<Person>
            {
                new Person() {Name = "James", Age = 17},
                new Person() {Name = "CC", Age = 19},
                new Person() {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person() {Name = "CC", Age = 19},
                new Person() {Name = "Frank", Age = 20}
            };
            Assert.AreEqual(expected, people.HiWhere(person => person.Age >= 18));
        }

        [Test]
        public void Where_Name_Has_a()
        {
            var people = new List<Person>
            {
                new Person() {Name = "James", Age = 17},
                new Person() {Name = "CC", Age = 19},
                new Person() {Name = "Frank", Age = 20}
            };
            var expected = new List<Person>
            {
                new Person() {Name = "James", Age = 17},
                new Person() {Name = "Frank", Age = 20}
            };
            Assert.AreEqual(expected, people.HiWhere(person => person.Name.Contains("a")));
        }

        [Test]
        public void Where_numbers_should_more_than_3()
        {
            var numbers = new[] {1, 2, 3, 4, 5};
            var expected = new[] {4, 5};
            Assert.AreEqual(expected, numbers.HiWhere(number => number > 3));
        }

        [Test]
        public void Select_Person_Name()
        {
            //MySelect mySelect = new MySelect();
            var people = new List<Person>
            {
                new Person() {Name = "James", Age = 17},
                new Person() {Name = "CC", Age = 19},
                new Person() {Name = "Frank", Age = 20}
            };
            var expected = new List<string>() { "James", "CC", "Frank" };
            //Assert.AreEqual(expected, mySelect.HiSelect(people, x => x.Name));
            Assert.AreEqual(expected, people.HiSelect(x => x.Name));
        }

        [Test]
        public void Select_Person_Age()
        {
            //MySelect mySelect = new MySelect();
            var people = new List<Person>
            {
                new Person() {Name = "James", Age = 17},
                new Person() {Name = "CC", Age = 19},
                new Person() {Name = "Frank", Age = 20}
            };
            var expected = new List<int>() { 17, 19, 20 };
            //Assert.AreEqual(expected, mySelect.HiSelect(people, x => x.Age));
            Assert.AreEqual(expected, people.HiSelect(x => x.Age));
        }

        [Test]
        public void Select_Person_Number()
        {
            //MySelect mySelect = new MySelect();
            var numbers = new List<int> { 17, 19, 20 };
            var expected = new List<int>() { 17, 19, 20 };
            //Assert.AreEqual(expected, mySelect.HiSelect(numbers, x => x));
            Assert.AreEqual(expected, numbers.HiSelect(x => x));
        }
    }

    public struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public static class MyWhere
    {
        public static IEnumerable<T> HiWhere<T>(this IEnumerable<T> source, Func<T, bool> condition)
        {
            foreach (var s in source)
                if (condition(s))
                    yield return s;
        }
    }
}