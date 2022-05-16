namespace Alize.Platform.Services
{
    public interface ICryptographyService
    {
        string DecryptString(string cipherText);
        string EncryptString(string plainText);
    }
}