using System;

namespace CastleWindsorWithoutAttribute
{
        public class Person : IPerson
        {
            public void Say()
            {
                Console.WriteLine("Person's Say Method is called!");
            }
        }
}
