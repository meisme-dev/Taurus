using Discord.WebSocket;
using Discord;
using Discord.Net;
using Newtonsoft.Json;

public class SlashCommandCreator {
    public async Task CreateSlashCommand(DiscordSocketClient _client, String name, ApplicationCommandOptionType type, 
    String description, bool isRequired, bool isDefault, bool isAutocomplete, ulong guildId = 0)
    {
        SocketGuild guild = _client.GetGuild(guildId);
        SlashCommandBuilder slashCommmand = new SlashCommandBuilder();
        slashCommmand.WithName(name)
        .WithDescription(description)
        .AddOption(name, type, description, isRequired, isDefault, isAutocomplete);
        try
        {
            if(guildId != 0)
            {
                await guild.CreateApplicationCommandAsync(slashCommmand.Build());
            }
            else
            {
                await _client.CreateGlobalApplicationCommandAsync(slashCommmand.Build());
            }
        }
        catch(HttpException exception)
        {
            var json = JsonConvert.SerializeObject(exception.Data, Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}