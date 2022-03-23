using Discord;
using Discord.WebSocket;

public class Program
{
	public static Task Main(string[] args) => new Program().MainAsync();
	private Task Log(LogMessage msg)
	{
		Console.WriteLine(msg.ToString());
		return Task.CompletedTask;
	}

	private static DiscordSocketClient? _client;

	public async Task MainAsync()
	{
		SlashCommandHandler slashCommandHandler = new SlashCommandHandler();
		_client = new DiscordSocketClient();
		_client.Log += Log;
        _client.MessageReceived += ClientOnMessageReceived;
		_client.Ready += ClientOnReady;
		_client.SlashCommandExecuted += slashCommandHandler.HandleSlashCommand;
		var botConfig = new BotConfig();
		try
		{
			botConfig.ReadConfig("config/config.json");
		}		 
		catch(Exception ex)
		{
			Console.WriteLine(ex);
		}

		String? token = botConfig.Token;
		Console.WriteLine(token);
		await _client.LoginAsync(TokenType.Bot, token);
		await _client.StartAsync();
		await Task.Delay(-1);
	}

    private static Task ClientOnMessageReceived(SocketMessage arg)
    {
        if (arg.Content.StartsWith("!currenttime"))
        {
            arg.Channel.SendMessageAsync($"{System.DateTime.Now.ToString("h:mm tt")}");
        }
        return Task.CompletedTask;
    }

	private static Task ClientOnReady(){
		SlashCommandCreator slashCommands = new SlashCommandCreator();
		slashCommands?.CreateSlashCommand(_client, "test", ApplicationCommandOptionType.String, "testdescription", true, false, true, 841427023011250186);
		Console.WriteLine("henlo");
		return Task.CompletedTask;
	}
}