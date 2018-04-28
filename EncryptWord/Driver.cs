using System;
namespace EncryptWord
{
    public class Driver
    {
        static void Main(string[] args)
        {
            EncryptWord e1 = new EncryptWord();
            EncryptWord e2 = new EncryptWord();

            const int ARRAY_SIZE = 8;
            string[] testArray = new string[ARRAY_SIZE];

            Main m = new Main();

            m.CreateArray(testArray);

            // Introduction to game
            Console.WriteLine(
                "--------- Welcome to GUESS THAT SHIFTY NUMBER game!---------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(
                "Each letter of the scrambled word is right-shifted by a certain ");
            Console.WriteLine(
                "number of letters. The number could be 1 through 5. You have to ");
            Console.WriteLine(
                "guess how many shifts happened to that word! Example: \'cjuf\' ");
            Console.WriteLine(
                "(encrypted) is actually \'bite\' (solved) shifted by 1. The answer is 1.");
            Console.WriteLine(
                "Let's Play!!");


            m.PlayGame(e1, testArray, ARRAY_SIZE); // tests entire array on 1st EW object

            Console.WriteLine("But let's try again, improve your score!");
            Console.WriteLine();

            m.PlayGame(e2, testArray, ARRAY_SIZE); // tests entire array on 2nd EW object (but with different shifts)


            // Goodbye message
            Console.WriteLine("Thank you for playing GUESS THAT SHIFTY NUMBER!!");
        }
    }
}
