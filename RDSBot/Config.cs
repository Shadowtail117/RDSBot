using Newtonsoft.Json;

using System;
using System.IO;

namespace RDSBot
{
    public class Config
    {
        public readonly string version = "0.0.1";

        [JsonIgnore]
        public string token;

        public string prefix = @"#";

        private static readonly string directory = Directory.GetCurrentDirectory();
        private static readonly string saveDirectory = Path.Combine(directory, @"Config");
        private static readonly string saveFile = Path.Combine(saveDirectory, @"config.cfg");

        public void Save()
        {

            Console.WriteLine($"Saving configuration to \"{saveDirectory}\".");
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);
            File.WriteAllText(saveFile, JsonConvert.SerializeObject(this));
            Console.WriteLine($"finished saving configuration to \"{saveDirectory}\".");
        }

        public bool Load(out Config config)
        {
            Console.WriteLine($"Loading configuration from \"{saveDirectory}\".");
            if (!Directory.Exists(saveDirectory) || !File.Exists(saveFile))
            {
                Console.WriteLine("Configuration file does not exist! Aborting.");
                config = null;
                return false;
            }

            config = JsonConvert.DeserializeObject<Config>(File.ReadAllText(saveFile));

            if (!File.Exists(Path.Combine(saveDirectory, @"token.txt")))
            {
                Console.WriteLine("token.txt does not exist! Aborting.");
                config = null;
                return false;
            }
            string token = File.ReadAllText(Path.Combine(saveDirectory, @"token.txt"));
            config.token = token;
            return true; //We cannot check if the token is actually valid here
        }
    }
}
