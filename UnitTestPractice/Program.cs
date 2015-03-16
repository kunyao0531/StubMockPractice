using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestPractice
{
    public interface INewThings
    {
        string CreateNewMember(PersonInfo person);
    };

    public class PersonInfo
    {
        public string Name { get; set; }
        public int age { get; set; }
    }

    public class Program
    {

        static void Main(string[] args)
        {

        }

        public string humanresource(INewThings NewThings, PersonInfo Newguy)
        {
            //call function
            return NewThings.CreateNewMember(Newguy);
        }
    }

    class Implement
    {
        public class company : INewThings
        {
            string INewThings.CreateNewMember(PersonInfo PI)
            {
                //呼叫Dal
                Dal dal = new Dal();
                int age = dal.GetSomethingbyName(PI.Name);

                if (age < 18)
                {
                    return "too young to work";
                }
                else if (age > 65)
                {
                    return "too old to work";
                }
                else
                {
                    return PI.Name + "-" + age;
                }
            }
        }
    }
}
