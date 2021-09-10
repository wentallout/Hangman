using System;
using System.Threading;

namespace Hangman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] messages =
                {
            @" __    __       ___      .__   __.   _______ .___  ___.      ___      .__   __.
|  |  |  |     /   \     |  \ |  |  /  _____||   \/   |     /   \     |  \ |  |
|  |__|  |    /  ^  \    |   \|  | |  |  __  |  \  /  |    /  ^  \    |   \|  |
|   __   |   /  /_\  \   |  . `  | |  | |_ | |  |\/|  |   /  /_\  \   |  . `  |
|  |  |  |  /  _____  \  |  |\   | |  |__| | |  |  |  |  /  _____  \  |  |\   |
|__|  |__| /__/     \__\ |__| \__|  \______| |__|  |__| /__/     \__\ |__| \__|",

            @"  _______      ___      .___  ___.  _______      ______   ____    ____  _______ .______       __
 /  _____|    /   \     |   \/   | |   ____|    /  __  \  \   \  /   / |   ____||   _  \     |  |
|  |  __     /  ^  \    |  \  /  | |  |__      |  |  |  |  \   \/   /  |  |__   |  |_)  |    |  |
|  | |_ |   /  /_\  \   |  |\/|  | |   __|     |  |  |  |   \      /   |   __|  |      /     |  |
|  |__| |  /  _____  \  |  |  |  | |  |____    |  `--'  |    \    /    |  |____ |  |\  \----.|__|
 \______| /__/     \__\ |__|  |__| |_______|    \______/      \__/     |_______|| _| `._____|(__)",

            @"____    ____  ______    __    __     ____    __    ____  __  .__   __.  __
\   \  /   / /  __  \  |  |  |  |    \   \  /  \  /   / |  | |  \ |  | |  |
 \   \/   / |  |  |  | |  |  |  |     \   \/    \/   /  |  | |   \|  | |  |
  \_    _/  |  |  |  | |  |  |  |      \            /   |  | |  . `  | |  |
    |  |    |  `--'  | |  `--'  |       \    /\    /    |  | |  |\   | |__|
    |__|     \______/   \______/         \__/  \__/     |__| |__| \__| (__)"
        };
            string[] counting =
                {
            @" __
/_ |
 | |
 | |
 | |
 |_|",
            @" ___
|__ \
   ) |
  / /
 / /_
|____|",
            @" ____
|___ \
  __) |
 |__ <
 ___) |
|____/",
            @" _  _
| || |
| || |_
|__   _|
   | |
   |_| ", @" _____
| ____|
| |__
|___ \
 ___) |
|____/"
        };
            string answer = "pizza";
            string currentGuessedCharacter = string.Empty;
            string guessedCharactersList = string.Empty;

            char[] hiddenAnswer = new string('-', answer.Length).ToCharArray();

            bool gameOver = false;

            int guessingTries = answer.Length * 2;
            int violations = 0;

            Console.CursorVisible = false;

            while (!gameOver)
            {
                Console.Clear();
                Console.WriteLine("Guess the word {0}", new string(hiddenAnswer));
                Console.WriteLine("Guessed characters: {0}", guessedCharactersList);
                Console.WriteLine("You have {0} tries left", guessingTries);
                Console.WriteLine();
                Console.WriteLine("Your next guess is: ");

                currentGuessedCharacter = Console.ReadLine();
                if (currentGuessedCharacter != null)
                {
                    guessedCharactersList += currentGuessedCharacter[0] + ", ";

                    if (currentGuessedCharacter.Length > 1)
                    {
                        if (violations >= 1)
                        {
                            guessingTries--;
                        }

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You have to input only ONE single character!");
                        Console.WriteLine("You will lose 2 tries if you violate the rules again");
                        Thread.Sleep(3000);
                        Console.ResetColor();

                        violations++;
                    }

                    if (answer.Contains(currentGuessedCharacter[0].ToString()))
                    {
                        for (int i = 0; i < answer.Length; i++)
                        {
                            if (answer[i] == currentGuessedCharacter[0])
                            {
                                hiddenAnswer[i] = currentGuessedCharacter[0];
                            }
                        }
                    }
                }

                guessingTries--;

                Console.Clear();
                if (guessingTries == 0)
                {
                    gameOver = true;
                    Console.WriteLine(messages[1]);
                }
                else if (!new string(hiddenAnswer).Contains("-"))
                {
                    gameOver = true;
                    Console.WriteLine(messages[2]);
                    Console.WriteLine("The answer was {0}", answer);
                }
            }
        }

        public static void CountDown(string[] counting, string[] messages)
        {
            for (int i = counting.Length; i > 0; i--)
            {
                Console.WriteLine(messages[0]);
                Console.WriteLine(counting[i - 1]);
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}