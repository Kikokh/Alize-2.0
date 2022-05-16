using Microsoft.AspNetCore.DataProtection;

namespace Alize.Platform.Services
{
    public class CryptographyService : ICryptographyService
    {
        private readonly IDataProtector _dataProtector;

        public CryptographyService(IDataProtectionProvider dataProtectionProvider)
        {
            _dataProtector = dataProtectionProvider.CreateProtector("Alize");
        }

        public string EncryptString(string plainText) => _dataProtector.Protect(plainText);

        public string DecryptString(string cipherText) => _dataProtector.Unprotect(cipherText);
    }
}
