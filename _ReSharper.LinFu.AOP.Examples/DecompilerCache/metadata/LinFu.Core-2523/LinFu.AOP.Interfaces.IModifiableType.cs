// Type: LinFu.AOP.Interfaces.IModifiableType
// Assembly: LinFu.Core, Version=2.3.0.12533, Culture=neutral, PublicKeyToken=a4c63a184389506f
// Assembly location: H:\Development\LinFu.AOP.Examples\lib\LinFu.Core.dll

namespace LinFu.AOP.Interfaces
{
    public interface IModifiableType : IMethodReplacementHost, IAroundInvokeHost
    {
        bool IsInterceptionDisabled { get; set; }
    }
}
