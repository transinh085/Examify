using System.Security.Cryptography;
using System.Text;

namespace Examify.Identity.Utilities;

public class PasswordGenerator
{
    public static string GenerateSecurePassword()
    {
        const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
        const string numberChars = "0123456789";
        const string specialChars = "!@#$%^&*()_-+=<>?";

        var password = new StringBuilder();
        using var rng = RandomNumberGenerator.Create();

        password.Append(GetRandomChar(upperChars, rng));
        password.Append(GetRandomChar(lowerChars, rng));
        password.Append(GetRandomChar(numberChars, rng));
        password.Append(GetRandomChar(specialChars, rng));

        var allChars = upperChars + lowerChars + numberChars + specialChars;
        for (int i = 4; i < 16; i++) 
        {
            password.Append(GetRandomChar(allChars, rng));
        }

        return new string(password.ToString().ToCharArray().OrderBy(x => GetRandomInt(rng)).ToArray());
    }

    private static char GetRandomChar(string characters, RandomNumberGenerator rng)
    {
        return characters[GetRandomInt(rng) % characters.Length];
    }

    private static int GetRandomInt(RandomNumberGenerator rng)
    {
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0) & int.MaxValue;
    }
}