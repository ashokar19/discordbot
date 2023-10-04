using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using discordbot.config;
using DSharpPlus.EventArgs;
using System.Net.WebSockets;
using discordbot.commands;

//using dsharp+
namespace discordbot 
{
    internal class Program
    {   
        //this represents the client itself
        private static DSharpPlus.DiscordClient Client { 
            get;
            
            set;}
            //this property sets up command
        private static CommandsNextExtension Commands {
            get; 
            
            set; 
        }
        static async Task Main(string[] args)
        {
            //setup the token and prefix of bot
            //read from json file
            var jsonReader = new JSONReader();
            await jsonReader.ReadJSON();

            //setup configuration of bot
            var discordConfig = new DSharpPlus.DiscordConfiguration() {
                Intents = DiscordIntents.All,
                Token = jsonReader.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };


            //test if it can come online
            Client = new DiscordClient(discordConfig);
            Client.Ready += Client_Ready;

            //enables use of commands
            var commandsConfig = new CommandsNextConfiguration() {
                StringPrefixes = new string[] {
                    jsonReader.prefix
                },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = true
            };
 
            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<TestCommands>();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args) {
            return Task.CompletedTask;
        }
    }
}