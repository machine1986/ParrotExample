// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Parrot.cs" company="dotnet Services UG">
//   dotnet Services UG (haftungsbeschränkt)
// </copyright>
// <summary>
//   Defines the parrot type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ParrotExample
{
    using System;

    /// <summary>
    /// The parrot.
    /// </summary>
    public class Parrot
    {
        /// <summary>
        /// The parrots name.
        /// </summary>
        private readonly string name;

        /// <summary>
        /// The parrots color.
        /// </summary>
        private readonly ParrotColor color;

        /// <summary>
        /// The word repository.
        /// Holds all words, the parrot can already say.
        /// </summary>
        private string[] words;

       /// <summary>
        /// Initializes a new instance of the <see cref="Parrot"/> class.
        /// </summary>
        /// <param name="n">
        /// The name.
        /// </param>
        /// <param name="color">
        /// The color.
        /// </param>
        public Parrot(string n, ParrotColor color)
        {
            this.name = n;
            this.color = color;

            // initialize words
            this.words = new string[0];
        }

        /// <summary>
        /// Determines, if the parrot already can talk or not
        /// </summary>
        private bool CanTalk => this.words.Length > 0;

        /// <summary>
        /// Returns the parrots name.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetName()
        {
            return this.name;
        }

        /// <summary>
        /// The learn word method.
        /// </summary>
        /// <param name="newWord">
        /// The new word to learn.
        /// </param>
        public void LearnWord(string newWord)
        {
            var tmpArray = this.words;
            var countAlreadyLearnedWords = tmpArray.Length;
            this.words = new string[countAlreadyLearnedWords + 1];
            for (var i = 0; i < countAlreadyLearnedWords; i++)
            {
                this.words[i] = tmpArray[i];
            }

            this.words[countAlreadyLearnedWords] = newWord;
        }

        /// <summary>
        /// The tell some word method.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Exception, that the parrot can't talk yet.
        /// </exception>
        public string TellSomeWord()
        {
            if (!this.CanTalk)
            {
                throw new Exception($"The {this.color} parrot named {this.name} currently knows any words.");
            }

            return this.words[new Random().Next(0, this.words.Length - 1)];
        }
    }
}