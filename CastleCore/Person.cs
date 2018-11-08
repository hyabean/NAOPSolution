using System;

namespace CastleCoreInterceptor
{
    public abstract class Person
    {
        public virtual void SayHello()
        {
            Console.WriteLine("我是{0}方法", "SayHello");
        }

        public virtual void SayName(string name)
        {
            Console.WriteLine("我是{0}方法，参数值：{1}", "SayName", name);
        }

        public abstract void AbstactSayOther();

        public void SayOther()
        {
            Console.WriteLine("我是{0}方法", "SayOther");
        }
    }
}
