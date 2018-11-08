using System;
using Castle.Core;

namespace CastleWindsorInterceptor
{
    [Interceptor(typeof(LogInterceptor))]
    public class Person : IPerson
    {
        public void Say()
        {
            Console.WriteLine("Person's Say Method is called!");
        }
    }
}
