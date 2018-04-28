// AUTHOR: Winona Azure
// FILENAME: Program.cs
// DATE: April 28, 2018
// REVISION HISTORY: 1.0
// REFERENCES (optional): Random word: http://www.cplusplus.com/reference/cstdlib/rand/
// Caesar Cipher Shift (partial): http://www.geeksforgeeks.org/caesar-cipher/
//
// DESCRIPTION: Processes words to encrypt them by shifting each letter a constant random number
// to the right. Saves states of the original word, encrypted word, and user guesses. Computes
// user guesses into statistics. Encrypting of a word can only be done if "on" with onOff boolean.
// After encryption word switches "off" so it cannot be further encrypted. Words from an array
// for testing should not be changed elsewhere in the function calls. At the end of each game
// printStats() is called and produces statistics for that game.
//
// ASSUMPTIONS: Both constructors must be used before anything else happens. Two variables keep
// iterating throughout a game and are not reset after it finishes: numberOfGames and
// index (for the EncryptWord array). Once created, orignal and encrypted word do not change.
// After game is won, totalGuesses determines values for min, max, and average guesses. All guesses
// reset only after user finishes one game.

namespace EncryptWord
{
    public class EncryptWord
    {
        private string originalWord; // user-entered word
        private bool isOn; // allows word to be encrypted or not
        private int randomN; // the one number of shifts a word has (may be 1 - 9)
        private int totalGuesses; // total number of user guesses on encrypted word
        private int highGuess; // maximum shift value, guessed by user, e.g. 9, of encrypted word
        private int lowGuess; // minimum shift value, guessed by user, e.g. 1, of encrypted word
        private int aveGuess; // averaged number of max and min shift value


        public EncryptWord()
        {
            originalWord = "";
            isOn = true;
            randomN = 0;
            totalGuesses = 0;
            highGuess = 0;
            lowGuess = 0;
            aveGuess = 0;
        }

        public int CreateRandomNumber()
        {
            System.Random rnd = new System.Random();
            int ran = rnd.Next(1, 6);
            return ran;
        }

        public string Encrypt(string []wordArray, ref int index)
        {
            string shiftedWord = "";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (isOn)
            {
                randomN = CreateRandomNumber();

                originalWord = SelectWord(wordArray, ref index);

                for (int i = 0; i < originalWord.Length; i++)
                {
                    sb.Append((char)((int)(originalWord[i] + randomN - 97) % 26 + 97));
                }

                isOn = false; // word has been encrypted, set isOn to false
            }
            shiftedWord = sb.ToString();

            return shiftedWord;
        }

        public string Decrypt()
        {
            isOn = true; // word has been decrypted, OK to encrypt again

            return originalWord;
        }

        private string SelectWord(string []array, ref int index)
        {
            // object must have a 4-char minimum original word
            const int CHAR_LIMIT = 4;
            string word = "";
            while (array[index].Length < CHAR_LIMIT)
            {
                index++;
                word = array[index];
            }
            if (array[index].Length >= CHAR_LIMIT)
                word = array[index];

            index++; // iterate for next word, next time selectWord is called

            return word;
        }

        public bool Guess(int number)
        {
            totalGuesses++; // each guess iterates no matter if right or not
            CalculateGuesses(number); // calculates stats with each guess

            return number == randomN;
        }

        public void reset()
        {
            randomN = 0;
            totalGuesses = 0;
            highGuess = 0;
            lowGuess = 0;
            aveGuess = 0;
        }

        void CalculateGuesses(int userGuess)
        {
            if (userGuess > 5 || userGuess == 0) // pop out of function if not a valid guess
                return;

            if (totalGuesses == 1)
            {
                highGuess = userGuess;
                lowGuess = userGuess;
            }
            else
            {
                if (highGuess < userGuess)
                    highGuess = userGuess;

                if (lowGuess > userGuess || lowGuess == 0)
                    lowGuess = userGuess;

                aveGuess = (highGuess + lowGuess) / 2;
            }
        }

        public string PrintStats(int numberOfGames) 
        {
            string stats = 
                "Games played: "            + numberOfGames.ToString()+ "\n" +
                "Total number of guesses: " + totalGuesses.ToString() + "\n" +
                "Lowest shift guess: "      + lowGuess.ToString()     + "\n" +
                "Highest shift guess: "     + highGuess.ToString()    + "\n" +
                "Average of shift guesses: "+ aveGuess.ToString()     + "\n";

            return stats;
        }
    }
}
