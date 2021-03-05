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

            Console.WriteLine($"RDS Bot version {Config.version} starting up!\n");
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

        /// <summary>
        /// Logs a message. Use this over <see cref="Console.WriteLine()"/> when possible.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
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

            Log(new LogMessage(LogSeverity.Info, $"{textChannel.Guild.Name} - {textChannel.Name} - {userMessage.Author}", userMessage.Content));

            string input = userMessage.Content;

            string command = input.Split(' ')[0].Substring(config.prefix.Length);
            string[] arguments = input.Split(' ')[1..];

            string output = "Invalid command!";

            foreach (Generator generator in Generator.generators)
            {
                if (command == generator.Command)
                {
                    output = $"{generator.Name} - {generator.Output()}";
                    break;
                }
            }
            switch(command)
            {
                case "version":
                    output = $"RDSBot is currently running version {Config.version}.";
                    break;
                case "config":
                    if (arguments.Length < 1)
                    {
                        output = "Please specify an argument!";
                        break;
                    }
                    switch(arguments[0])
                    {
                        case "set":
                            if(arguments.Length < 3)
                            {
                                output = "Please specify at least three arguments!";
                                break;
                            }
                            switch(arguments[1])
                            {
                                case "prefix":
                                    config.prefix = arguments[2];
                                    output = $"Set prefix to \"{config.prefix}\"!";
                                    break;
                            }
                            break;
                        case "get":
                            if (arguments.Length < 2)
                            {
                                output = "Please specify at least two arguments!";
                                break;
                            }
                            switch (arguments[1])
                            {
                                case "prefix":
                                    output = $"Current prefix is \"{config.prefix}\".";
                                    break;
                            }
                            break;
                    }
                    break;
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