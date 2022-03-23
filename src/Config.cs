using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class BotConfig
{ 
	public BotConfig()
	{
		dynamic? Token = "";
	}

	public String? Token
	{
		get; set;
	}
	
	public void ReadConfig(String ConfigPath)
	{
		String? data = System.IO.File.ReadAllText(ConfigPath);
		Console.WriteLine(data);
		JObject? JSON = (JObject?)JsonConvert.DeserializeObject(data);
        Token = JSON?["Token"]?.Value<string>();
	}
}