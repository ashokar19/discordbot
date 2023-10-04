using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

//using dsharp+
namespace discordbot.commands 
{
   public class TestCommands : BaseCommandModule {
    //declare command like this
    [Command("test")]
    //must use command context, its the very class that allows us to add any discord action
    //declaring asynchronous Task (Task = void function) to run, since every task is asynchronous, we need an await command
    public async Task myCommand(CommandContext ctx)
    {
        //try ctx. you'll see everything regarding a discord action like the users, channels, etc.
        //await for a message from the ctx.channel
        ctx.Channel.SendMessageAsync($"Hello {ctx.User.Username}");
        // you need to register the command class in the config
    }

    [Command("add")]
    //the syntax using the parameters would be $add 1 1
    public async Task Add(CommandContext ctx, int numOne, int numTwo) {
        //remember to put $ after the first round bracket in sendmessageasync
        ctx.Channel.SendMessageAsync($"yo {ctx.User.Username}, you need {numOne + numTwo}");
    }
   }
}