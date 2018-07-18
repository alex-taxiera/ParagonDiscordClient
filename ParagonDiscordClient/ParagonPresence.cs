using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParagonDiscordClient
{
  class ParagonPresence
  {
    private static DiscordRpcClient client;
    private static Assets menuAssets = new Assets()
    {
      LargeImageKey = "menu",
      LargeImageText = "In Menus",
      SmallImageKey = "epic",
      SmallImageText = "Epic Games"
    };
    private static Assets draftAssets = new Assets()
    {
      LargeImageKey = "draft",
      LargeImageText = "Drafting",
      SmallImageKey = "epic",
      SmallImageText = "Epic Games"
    };

    public ParagonPresence()
    {
      client = new DiscordRpcClient("468591679599935490", true, -1);
      //{
      //  Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning, Colored = true }
      //};
      client.Initialize();
      client.SetPresence(MenuPresence());
    }

    public async Task<int> MatchmakeAndPlayAsync(KeyValuePair<string, string> selectedHero, KeyValuePair<string, string> selectedMap)
    {
      client.SetPresence(QueuePresence());
      await Task.Delay(45000); // 45000
      client.SetPresence(DraftPresence());
      await Task.Delay(30000); // 30000
      client.SetPresence(MatchPresence(selectedMap.Key, selectedMap.Value, selectedHero.Key, selectedHero.Value));
      await Task.Delay(2100000); // 2100000
      client.SetPresence(MenuPresence());
      return 0;
    }
    private RichPresence MenuPresence() => new RichPresence()
    {
      Details = "In Menus...",
      State = "Solo",
      Assets = menuAssets
    };
    private RichPresence QueuePresence() => new RichPresence()
    {
      Details = "In Queue",
      State = "Solo",
      Assets = menuAssets,
      Timestamps = new Timestamps()
      {
        Start = DateTime.UtcNow
      }
    };
    private RichPresence DraftPresence() => new RichPresence()
    {
      Details = "Drafting...",
      State = "Solo",
      Assets = draftAssets
    };
    private RichPresence MatchPresence(string mapKey, string mapText, string heroKey, string heroText) => new RichPresence()
    {
      Details = "In a match",
      State = "Solo",
      Assets = new Assets()
      {
        LargeImageKey = mapKey,
        LargeImageText = "Playing on " + mapText,
        SmallImageKey = heroKey,
        SmallImageText = "Playing as " + heroText
      },
      Timestamps = new Timestamps()
      {
        Start = DateTime.UtcNow
      }
    };
  }
}
