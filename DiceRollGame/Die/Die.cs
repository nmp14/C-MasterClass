using DiceRollGame.Random;

namespace DiceRollGame.Dice;

public class Die
{
    public int Value { get; private set; }
    public int NumberOfSides { get; init; }

    public void RollDie()
    {
        Value = CustomRandomNumberGenerator.GenerateRandomNumber(NumberOfSides);
    }
}
