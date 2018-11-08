using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleWindsorInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.Register(Component.For<Person, IPerson>());
                container.Register(Component.For<LogInterceptor, IInterceptor>());
                var person = container.Resolve<IPerson>();
                person.Say();
            }
            Console.ReadKey();
        }
    }
}
