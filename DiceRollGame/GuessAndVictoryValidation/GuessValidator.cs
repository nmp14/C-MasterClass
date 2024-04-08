using DiceRollGame.Dice;

namespace DiceRollGame.Guess;

public class GuessValidator
{
    public bool isGuessCorrect(int guess, Die die)
    {
        if (guess > die.NumberOfSides)
        {
            Console.WriteLine("You guessed a number larger than the die...");
        }
        return guess == die.Value;
    }
}
