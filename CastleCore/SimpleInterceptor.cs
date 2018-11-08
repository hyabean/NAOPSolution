using System;
using System.Reflection;
using Castle.DynamicProxy;

namespace CastleCoreInterceptor
{
    public class SimpleInterceptor : StandardInterceptor
    {
        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("拦截器调用方法前，方法名是：{0}。", invocation.Method.Name);
        }

        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine("拦截器开始调用方法，方法名是：{0}。", invocation.Method.Name);
            var attrs = invocation.MethodInvocationTarget.Attributes.HasFlag(MethodAttributes.Abstract);//过滤abstract方法
            if (!attrs)
            {
                base.PerformProceed(invocation);//此处会调用真正的方法 invocation.Proceed();
            }
        }

        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine("拦截器调用方法后，方法名是：{0}。", invocation.Method.Name);
        }
    }
}
