using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinFu.AOP.Interfaces;
using SampleLibrary;

namespace LinFu.AOP.Examples
{
    public class ConsoleInterceptor : IInterceptor
    {
        public object Intercept(IInvocationInfo info)
        {
            var targetType = info.TargetMethod.DeclaringType;
            var target = info.Target;
            var targetMethod = info.TargetMethod;
            var arguments = info.Arguments;

            Console.WriteLine("Intercepted method named '{0}'", targetMethod.Name);

            // Call the original WriteLine method
            targetMethod.Invoke(null, arguments);

            // Console.WriteLine doesn't have a return value so it's OK to return null)
            return null;
        }
    }

    public class WriteLineMethodReplacementProvider : IMethodReplacementProvider
    {
        public bool CanReplace(object host, IInvocationInfo info)
        {
            var declaringType = info.TargetMethod.DeclaringType;
            if (declaringType != typeof(System.Console))
                return false;

            // We're only interested in replacing Console.WriteLine()
            var targetMethod = info.TargetMethod;
            return targetMethod.Name == "WriteLine";
        }

        public IInterceptor GetMethodReplacement(object host, IInvocationInfo info)
        {
            return new ConsoleInterceptor();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount(100);

            // LinFu.AOP automatically implements IModifiableType so you can intercept/replace method calls at runtime
            var modifiableType = account as IModifiableType;
            if (modifiableType != null)
                modifiableType.MethodCallReplacementProvider = new WriteLineMethodReplacementProvider();

            account.Deposit(100);

            return;
        }
    }
}
