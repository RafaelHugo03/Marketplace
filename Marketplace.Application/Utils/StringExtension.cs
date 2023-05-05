
using SecureIdentity.Password;

namespace Marketplace.Application.Utils
{
    public static class StringExtension
    {
        public static string StringHasher(this string value)
        {
            return PasswordHasher.Hash(value);
        }
    }
}