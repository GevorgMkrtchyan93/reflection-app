using System;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionApp
{
    [AgeValidation(18)]
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public void Display()
        {
            Console.WriteLine($"Name: {Name}  Age: {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}
