namespace Alize.Platform.Infrastructure
{
    public interface ICryptographyService
    {
        string DecryptString(string cipherText);
        string EncryptString(string plainText);
    }
}