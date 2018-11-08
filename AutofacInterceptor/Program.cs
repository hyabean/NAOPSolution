using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Castle.DynamicProxy;

namespace AutofacInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Person>().As<IPerson>().EnableInterfaceInterceptors();
            builder.RegisterType<LogInterceptor>();
            using (var container = builder.Build())
            {
                container.Resolve<IPerson>().Say();
            }
            Console.ReadLine();
        }
    }
    class LogInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("{0}:拦截{1}方法{2}前,", DateTime.Now.ToString("O"), invocation.InvocationTarget.GetType().BaseType, invocation.Method.Name);
            invocation.Proceed();
            Console.WriteLine("{0}:拦截{1}方法{2}后,", DateTime.Now.ToString("O"), invocation.InvocationTarget.GetType().BaseType, invocation.Method.Name);
        }
    }

    public interface IPerson
    {
        void Say();
    }

    [Intercept(typeof(LogInterceptor))]
    public class Person : IPerson
    {
        public void Say()
        {
            Console.WriteLine("Person's Say Method is called!");
        }
    }
}
