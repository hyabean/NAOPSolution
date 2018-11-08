using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOPSolution
{

    public class Program
    {
        static void Main(string[] args)
        {
            var per = new Proxy<Person>(new Person()).GetTransparentProxy() as Person;

            if (per != null)
            {
                var str = per.Say();
                Console.WriteLine("" + str);

            }

            Console.ReadKey();
        }
    }
    
}
