using System.ComponentModel.DataAnnotations;

namespace Coldmart.Auth.Business.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class SenhaRegularExpressionAttribute : RegularExpressionAttribute
{
    public SenhaRegularExpressionAttribute()
        : base(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_])(?=.{6,})(?:(.)(?!.*\1)){6,}$")
    {
    }
}