using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpInterviewQuestion
{
   public class Person
    {
        public int Age { get; set; }
        public string Greet()
        {
            return "Hello!";
        }

        public void SetAge(int age)
        {
            Age = age;
        }
        public string ShowAge()
        {
            return "My age is: "+Age.ToString()+" years old";
        }
    }
}
