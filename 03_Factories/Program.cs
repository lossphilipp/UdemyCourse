using System;
using System.Collections.Generic;

namespace Coding.Exercise
{
    public class PersonFactory
    {
        public List<Person> createdPersons = new List<Person>();

        public Person CreatePerson(string name)
        {
            var p = new Person(createdPersons.Count, name);
            createdPersons.Add(p);
            return p;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal Person(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
