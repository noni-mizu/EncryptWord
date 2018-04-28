using System;
namespace EncryptWord
{
    public class Main
    {
        int numberOfGames = 1; // tracks how many games are played
        int indexArr = 0; // iterates after encrypt() is called, for string array

        public void CreateArray(string[] eArray)
        {
            eArray[0] = "kite";
            eArray[1] = "hi";
            eArray[2] = "fire";
            eArray[3] = "grass";
            eArray[4] = "patch";
            eArray[5] = "kitten";
            eArray[6] = "desk";
            eArray[7] = "space";
        }

        private int GetUserGuess()
        {
            // user's guess, from whole line (if enter incorrect guess)
            string guessedInput = Console.ReadLine();

            // int for user's guess
            int number = 0;

            // convert line to int
            Int32.TryParse(guessedInput, out number);

            return number;
        }

        public void PlayGame(EncryptWord e, string[] testArray, int size)
        {
            string encryptedWord = e.Encrypt(testArray, ref indexArr);

            // Asks user to guess the number
            Console.WriteLine("What number was this word shifted by?");
            Console.WriteLine(encryptedWord);

            int number = GetUserGuess();
            bool isRightGuess = e.Guess(number);

            // checks if number is right guess
            while (!isRightGuess)
            {
                if (number > size)
                {
                    Console.WriteLine("Enter a number between 1 and 5.");
                }
                else if (number < size)
                {
                    Console.WriteLine("You guessed: " + number);
                    Console.WriteLine("Nope, try again!");
                }

                number = GetUserGuess();
                isRightGuess = e.Guess(number);
            }

            // when guess is correct
            Console.WriteLine("You guessed: " + number);
            Console.WriteLine("THAT'S CORRECT!!");
            Console.WriteLine("Decrypted word: " + e.Decrypt());
            Console.WriteLine();

            Console.WriteLine(e.PrintStats(numberOfGames));  // print user stats to console

            // stops game if end of array
            const int GAME_OVER = 7;
            if (numberOfGames == GAME_OVER)
            {
                // reset variables for 2nd EW object
                numberOfGames = 1;
                indexArr = 0;

                Console.WriteLine("All out of games!");
                return;
            }

            Console.WriteLine("Play again? Type 'y' for yes, 'n' for no.");

            string replayAnswer = Console.ReadLine();

            while (replayAnswer != "y" && replayAnswer != "n")
            {
                if (replayAnswer.Length > 1)
                {
                    Console.WriteLine("Enter only 1 character: 'y' for yes or 'n' no.");
                }
                else
                {
                    Console.WriteLine("Enter 'y' for yes, or 'n' for no.");
                }

                replayAnswer = Console.ReadLine();
            }

            Console.WriteLine(); // formatting

            if (replayAnswer == "y")
            {
                numberOfGames++; // next game begins
                e.reset(); // resets most EncryptWord class variables

                while (Console.KeyAvailable)
                    Console.ReadKey(true);
                //// reset cin
                //cin.clear();
                //cin.ignore(std::numeric_limits < std::streamsize >::max(), '\n');

                PlayGame(e, testArray, size);
            }
        }
    }
}