using Discord;
using Discord.WebSocket;

using RDSBot.Generators;

using System;
using System.Threading.Tasks;

namespace RDSBot
{
    class Program
    {
        private DiscordSocketClient client;
        static Config config = new Config();

        static void Main(string[] args)
        {
            if(!config.Load(out config))
            {
                Console.WriteLine("Couldn't load config. Aborting. Press any key to exit.");
                Console.ReadKey();
                return;
            }

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnExit);

            Console.WriteLine($"RDS Bot version {config.version} starting up!\n");
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            client.Log += Log;
            client.MessageReceived += MessageReceived;

            await client.LoginAsync(TokenType.Bot, config.token);
            await client.StartAsync();

            await Task.Delay(-1);
        }

        private static Task Log(LogMessage message)
        {
            switch (message.Severity)
            {
                case LogSeverity.Critical:
                case LogSeverity.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogSeverity.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogSeverity.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogSeverity.Verbose:
                case LogSeverity.Debug:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine($"{DateTime.Now,-19} [{message.Severity,8}] {message.Source}: {message.Message} {message.Exception}");
            Console.ResetColor();
            return Task.CompletedTask;
        }

        private Task MessageReceived(SocketMessage message)
        {
            if (!(message is SocketUserMessage userMessage)) return Task.CompletedTask;
            if (!(userMessage.Channel is SocketTextChannel textChannel)) return Task.CompletedTask;

            if (!(userMessage.Content.StartsWith(config.prefix))) return Task.CompletedTask;

            string input = userMessage.Content;

            string command = input.Split(' ')[0].Substring(config.prefix.Length);
            string[] arguments = input.Split(' ')[1..];

            string output = "Invalid command!";

            foreach (Generator generator in Generator.generators)
            {
                if (command == generator.Command)
                {
                    output = $"{generator.Name} - {generator.Output()}";
                }
            }

            return textChannel.SendMessageAsync(output);
        }

        private static void OnExit(object sender, EventArgs e)
        {
            Console.WriteLine("\nShutting down!");
            config.Save();
        }
    }
}