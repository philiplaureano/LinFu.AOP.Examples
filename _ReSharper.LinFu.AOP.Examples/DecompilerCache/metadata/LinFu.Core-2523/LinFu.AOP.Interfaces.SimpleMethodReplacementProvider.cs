// Type: LinFu.AOP.Interfaces.SimpleMethodReplacementProvider
// Assembly: LinFu.Core, Version=2.3.0.12533, Culture=neutral, PublicKeyToken=a4c63a184389506f
// Assembly location: H:\Development\LinFu.AOP.Examples\lib\LinFu.Core.dll

using System;

namespace LinFu.AOP.Interfaces
{
    public class SimpleMethodReplacementProvider : BaseMethodReplacementProvider
    {
        public SimpleMethodReplacementProvider(IInterceptor replacement);
        public Func<IInvocationInfo, bool> MethodReplacementPredicate { get; set; }
        public IInterceptor MethodReplacement { get; set; }
        protected override bool ShouldReplace(object host, IInvocationInfo context);
        protected override IInterceptor GetReplacement(object host, IInvocationInfo context);
    }
}
