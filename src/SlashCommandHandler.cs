using System.Xml.Linq;
using System.Linq;
using Discord.WebSocket;

public class SlashCommandHandler{
    public async Task HandleSlashCommand(SocketSlashCommand command){
        await command.RespondAsync($"You entered {command.Data.Options.First().Value}");
    }
}