using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace CastleWindsorWithoutAttribute
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var container = new WindsorContainer())
            {
                container.Register(Component.For<IInterceptor, LogInterceptor>());//先注入拦截器
                LogInterceptorRegistrar.Initialize(container);
                container.Register(Component.For<IPerson, Person>());
                var person = container.Resolve<IPerson>();
                person.Say();
            }
            Console.ReadKey();
        }
    }
}
