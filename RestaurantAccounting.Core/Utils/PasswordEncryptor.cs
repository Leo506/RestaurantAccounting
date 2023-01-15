using System.Security.Cryptography;

namespace RestaurantAccounting.Core.Utils;

public static class PasswordEncryptor
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Iterations = 1_000_000;
    private static readonly HashAlgorithmName AlgorithmName = HashAlgorithmName.SHA256;
    
    public static string EncryptPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, AlgorithmName, KeySize);
        return string.Join(":", Convert.ToHexString(hash), Convert.ToHexString(salt), Iterations, AlgorithmName);
    }

    public static bool Verify(string inputPassword, string dbPassword)
    {
        var segments = dbPassword.Split(":");
        var hash = Convert.FromHexString(segments[0]);
        var salt = Convert.FromHexString(segments[1]);
        var iterations = int.Parse(segments[2]);
        var algorithm = new HashAlgorithmName(segments[3]);
        var inputPasswordHash = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, iterations, algorithm, hash.Length);

        return CryptographicOperations.FixedTimeEquals(inputPasswordHash, hash);
    }
}