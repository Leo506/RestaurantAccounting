using System.Text;

namespace RestaurantAccounting.Core.Utils;

public static class PasswordEncryptor
{
    public static string EncryptPassword(string password)
    {
        var data = Encoding.ASCII.GetBytes(password);
        data = System.Security.Cryptography.SHA256.Create().ComputeHash(data);
        return Encoding.ASCII.GetString(data);
    }
}