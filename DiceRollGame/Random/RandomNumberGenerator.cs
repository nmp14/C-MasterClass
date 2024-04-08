using System.Security.Cryptography;

namespace DiceRollGame.Random;

public static class CustomRandomNumberGenerator
{
    public static int GenerateRandomNumber(int max)
    {
        return RandomNumberGenerator.GetInt32(1, max + 1);
    }
}
