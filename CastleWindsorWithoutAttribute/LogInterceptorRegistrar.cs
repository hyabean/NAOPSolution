using Castle.Core;
using Castle.MicroKernel;
using Castle.Windsor;

namespace CastleWindsorWithoutAttribute
{
        internal static class LogInterceptorRegistrar
        {
            public static void Initialize(WindsorContainer container)
            {
                container.Kernel.ComponentRegistered += Kernel_ComponentRegistered;
            }
            private static void Kernel_ComponentRegistered(string key, IHandler handler)
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(LogInterceptor)));
            }
        }
}
