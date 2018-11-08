using System;

namespace AOPSolution
{
    public class Person : MarshalByRefObject
    {
        public string Say()
        {
            const string str = "Person's say is called";

            Console.WriteLine(str);

            return str;
        }
    }
    
}
