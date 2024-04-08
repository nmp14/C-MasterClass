using DiceRollGame.Dice;
using DiceRollGame.Guess;
using DiceRollGame.Random;

namespace DiceRollGame;

internal class Program
{
    static void Main(string[] args)
    {
        int attempts = 3;
        var isGuessSuccessful = false;
        Console.WriteLine("Welcome! What size dice do you want to roll?");
        var userInputDicSize = Console.ReadLine();

        var successfullyParsed = int.TryParse(userInputDicSize, out int diceSize);
        if (!successfullyParsed)
        {
            Console.WriteLine("Invalid dice size. Defaulting to 6 sided die");
            diceSize = 6;
        }

        Console.WriteLine("Rolling dice...");
        var die = new Die
        {
            NumberOfSides = diceSize,
        };

        die.RollDie();
        Console.WriteLine($"Dice rolled.  You have {attempts} attempts to guess the number");

        GuessValidator guessValidator = new GuessValidator();
        do
        {
            bool successfullyParsedGuess;
            int guessInt;
            do
            {
                var guess = Console.ReadLine();
                successfullyParsedGuess = int.TryParse(guess, out guessInt);
                if (!successfullyParsedGuess) Console.WriteLine("Not a valid number. Try again.");
            } while(!successfullyParsedGuess);
            attempts--;
            isGuessSuccessful = guessValidator.isGuessCorrect(guessInt, die);

            if (isGuessSuccessful)
            {
                Console.WriteLine("Congratulation! You won! The number was " + die.Value);
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Incorrect guess. Try again. {attempts} remaining");
        } while (attempts > 0 && !isGuessSuccessful);
        Console.WriteLine("You lose :(");
        Console.ReadKey();
    }
}
