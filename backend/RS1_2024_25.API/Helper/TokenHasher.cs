using System.Security.Cryptography;
using System.Text;

public static class TokenHasher
{
    public static string HashToken(string token)
    {
        using (var sha256 = SHA256.Create())
        {
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
            return Convert.ToBase64String(bytes);
        }
    }

    public static bool VerifyToken(string inputToken, string storedHash)
    {
        return HashToken(inputToken) == storedHash;
    }
}