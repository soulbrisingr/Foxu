using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foxu_bot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] Foxes;

        public MyBot()
        {
            rand = new Random();

            Foxes = new string[]
            {
                "Fox Images/Fox 1.jpg",
                "Fox Images/Fox 2.jpg",
                "Fox Images/Fox 3.jpg", 
                "Fox Images/Fox 4.jpg",
                "Fox Images/Fox 5.jpg", 
                "Fox Images/Fox 6.jpg", 
                "Fox Images/Fox 7.jpg", 
                "Fox Images/Fox 8.jpg", 
                "Fox Images/Fox 9.jpg", 
                "Fox Images/Fox 10.jpg",
                "Fox Images/Fox 11.jpg", 
                "Fox Images/Fox 12.jpg", 
                "Fox Images/Fox 13.jpg",
                "Fox Images/Fox 14.jpg"
            };

            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;
            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '!';
                x.AllowMentionPrefix = true;
            });
            
            commands = discord.GetService<CommandService>();

            RegisterFoxCommand();

            commands.CreateCommand("hello")
                .Do(async (e) =>
                {
                   await e.Channel.SendMessage("Hi!");
                });

            discord.ExecuteAndWait(async () =>
            {
                await discord.Connect("MzY4NzU1MTkwMDAzNzkzOTMy.DMOyCw.Vv2oHHlaC6O9VF3RTe-JqoNa4yA", TokenType.Bot);
            });
        }

        private void RegisterFoxCommand()
        {
            commands.CreateCommand("Fox")
                .Do(async (e) =>
                {
                   int randomFoxIndex = rand.Next(Foxes.Length);
                   string FoxToPost = Foxes[randomFoxIndex];
                   await e.Channel.SendFile(FoxToPost);
                });
        }

        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
    
}
