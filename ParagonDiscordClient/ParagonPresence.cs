using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    private static List<KeyValuePair<string, string>> smallAssets = new List<KeyValuePair<string, string>>
    {
      new KeyValuePair<string, string>("aurora", "Aurora"),
      new KeyValuePair<string, string>("belica", "Lt. Belica"),
      new KeyValuePair<string, string>("countess", "Countess"),
      new KeyValuePair<string, string>("crunch", "Crunch"),
      new KeyValuePair<string, string>("dekker", "Dekker"),
      new KeyValuePair<string, string>("drongo", "Drongo"),
      new KeyValuePair<string, string>("feng_mao", "Feng Mao"),
      new KeyValuePair<string, string>("fey", "The Fey"),
      new KeyValuePair<string, string>("gadget", "Gadget"),
      new KeyValuePair<string, string>("gideon", "Gideon"),
      new KeyValuePair<string, string>("greystone", "Greystone"),
      new KeyValuePair<string, string>("grim_exe", "Grim.exe"),
      new KeyValuePair<string, string>("grux", "Grux"),
      new KeyValuePair<string, string>("howitzer", "Howitzer"),
      new KeyValuePair<string, string>("iggy", "Iggy & Scorch"),
      new KeyValuePair<string, string>("kallari", "Kallari"),
      new KeyValuePair<string, string>("khaimera", "Khaimera"),
      new KeyValuePair<string, string>("kwang", "Kwang"),
      new KeyValuePair<string, string>("morigesh", "Morigesh"),
      new KeyValuePair<string, string>("murdock", "Murdock"),
      new KeyValuePair<string, string>("muriel", "Muriel"),
      new KeyValuePair<string, string>("narbash", "Narbash"),
      new KeyValuePair<string, string>("phase", "Phase"),
      new KeyValuePair<string, string>("rampage", "Rampage"),
      new KeyValuePair<string, string>("revenant", "Revenant"),
      new KeyValuePair<string, string>("riktor", "Riktor"),
      new KeyValuePair<string, string>("serath", "Serath"),
      new KeyValuePair<string, string>("sevarog", "Sevarog"),
      new KeyValuePair<string, string>("shinbi", "Shinbi"),
      new KeyValuePair<string, string>("sparrow", "Sparrow"),
      new KeyValuePair<string, string>("steel", "Steel"),
      new KeyValuePair<string, string>("terra", "Terra"),
      new KeyValuePair<string, string>("twinblast", "Twinblast"),
      new KeyValuePair<string, string>("wraith", "Wraith"),
      new KeyValuePair<string, string>("wukong", "Wukong"),
      new KeyValuePair<string, string>("yin", "Yin"),
      new KeyValuePair<string, string>("zinx", "Zinx")
    };
    private static List<KeyValuePair<string, string>> largeAssets = new List<KeyValuePair<string, string>>
    {
      new KeyValuePair<string, string>("legacy_jungle", "Legacy"),
      new KeyValuePair<string, string>("monolith", "Monolith")
    };

    public List<KeyValuePair<string, string>> LargeAssets { get => largeAssets; set => largeAssets = value; }
    public List<KeyValuePair<string, string>> SmallAssets { get => smallAssets; set => smallAssets = value; }

    public ParagonPresence()
    {
      client = new DiscordRpcClient("468591679599935490", true, 0)
      {
        Logger = new ConsoleLogger() { Level = DiscordRPC.Logging.LogLevel.Warning, Colored = true }
      };
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
