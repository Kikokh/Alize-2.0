
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Alize.Platform.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class PasswordAttribute : ValidationAttribute
    {
        private const string _errorMessage = "Password must be at least 8 characters and have at least one uppercase, one lowercase, one special character and one number";

        public PasswordAttribute() : base(_errorMessage)
        {

        }

        public override bool IsValid(object? value)
        {
            if (value is null || value is not string)
                return false;

            return Regex.IsMatch((string)value, @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
        }
    }
}