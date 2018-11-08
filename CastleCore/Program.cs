using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;

namespace CastleCoreInterceptor
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new ProxyGenerator();       //实例化【代理类生成器】  
            var interceptor = new SimpleInterceptor();  //实例化【拦截器】  

            //使用【代理类生成器】创建Person对象，而不是使用new关键字来实例化  
            var person = generator.CreateClassProxy<Person>(interceptor);

            Console.WriteLine("当前类型:{0},父类型:{1}", person.GetType(), person.GetType().BaseType);
            Console.WriteLine();

            person.SayHello();//拦截
            Console.WriteLine();

            person.SayName("Never、C");//拦截
            Console.WriteLine();

            person.SayOther();//普通方法,无法拦截     
            person.AbstactSayOther();//抽象方法,可以拦截     

            Console.ReadLine();

        }
    }
}
