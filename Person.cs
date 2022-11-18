using System;

namespace WordScambler
{
    // struct Person acts like class but its less basic and it is a
    // value type has uses stack data structure and does not change the value
    public class Person
    {
        public Person(string argFirstName, string argLastName)
        {
            FirstName = argFirstName;
            LastName = argLastName;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
