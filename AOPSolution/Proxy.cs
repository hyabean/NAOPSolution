using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;

namespace AOPSolution
{
    public class Proxy<T> : RealProxy where T : new()
    {
        private object _obj;

        public Proxy(object obj) : base(typeof(T))
        {
            _obj = obj;
        }

        public override IMessage Invoke(IMessage msg)
        {
            Console.WriteLine("{0}:Invoke前", DateTime.Now);
            var ret = ((IMethodCallMessage)msg).MethodBase.Invoke(_obj, null);

            Console.WriteLine("{0}:Invoke后", DateTime.Now);
            return new ReturnMessage(ret, null, 0, null, null);
        }
    }
    
}
