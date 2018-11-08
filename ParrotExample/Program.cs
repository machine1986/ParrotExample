// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="dotnet Services UG">
//   dotnet Services UG (haftungsbeschränkt)
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParrotExample
{
    using System;
    using System.Threading;

    /// <summary>
    /// The main program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point.
        /// </summary>
        /// <param name="args">
        /// The command line args.
        /// </param>
        public static void Main(string[] args)
        {
            try
            {
                // get the name from user
                Console.WriteLine("What's your parrots name?");
                var name = Console.ReadLine();

                // check for null
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Name should not be empty!");
                }

                // create new parrot instance
                var parrot = new Parrot(name, ParrotColor.redblue);

                // let parrot lean some words
                LearnWords(parrot);

                // let him speak 10 words
                SaySomeWords(parrot, 10);
            }
            catch (Exception ex)
            {
                // show exception
                Console.WriteLine(ex.Message);
            }
            
            // wait for user input to end
            Console.ReadLine();
        }

        /// <summary>
        /// Let the parrot speak.
        /// </summary>
        /// <param name="parrot">
        /// The parrot.
        /// </param>
        /// <param name="wordsToSay">
        /// The words to say.
        /// </param>
        private static void SaySomeWords(Parrot parrot, int wordsToSay)
        {
            for (var i = 0; i <= wordsToSay; i++)
            {
                Console.WriteLine(parrot.TellSomeWord());
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Lets the parrot learn words.
        /// </summary>
        /// <param name="parrot">
        /// The parrot.
        /// </param>
        private static void LearnWords(Parrot parrot)
        {
            var enough = false;
            while (!enough)
            {
                // read a word from user input
                Console.WriteLine("Okay, gimme a word to learn!");
                var word = Console.ReadLine();

                // check the input
                if (string.IsNullOrEmpty(word))
                {
                    Console.WriteLine("That's not a word. Try again.");
                    continue;   
                }

                // learn the word
                parrot.LearnWord(word);

                // check, if user want's to input another word
                Console.WriteLine($"Ok, {parrot.GetName()} learned it. Finished learning? Then type 'y'.");
                var input = Console.ReadLine() ?? string.Empty;
                enough = input.ToLower() == "y";
            }
        }
    }
}
