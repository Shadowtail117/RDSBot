using System.Collections.Generic;

namespace RDSBot.Generators
{
    /// <summary>
    /// Base class for a generator.
    /// </summary>
    public abstract class Generator
    {
        /// <summary>
        /// The name of the generator to be shown to the user.
        /// </summary>
        public abstract string Name { get; set; }
        /// <summary>
        /// The command the user must type along with the prefix.
        /// </summary>
        public abstract string Command { get; set; }

        /// <summary>
        /// What to output to the user.
        /// </summary>
        /// <param name="args">A list of arguments to pass to the generator if necessary.</param>
        /// <returns>A dice roll along with a description of the result.</returns>
        public abstract string Output(string[] args);

        /// <summary>
        /// A list of all generators.
        /// </summary>
        public static List<Generator> generators = new List<Generator>()
        {
            new Room(),
            new Loot()
        };
    }
}
