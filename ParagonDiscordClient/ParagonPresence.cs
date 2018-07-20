using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParagonDiscordClient
{
  class ParagonPresence
  {
    private PlayParagonForm form;
    private static DiscordRpcClient client;
    private Random rng = new Random();
    private bool playing = false;
    private KeyValuePair<string, Button>[] buttons;
    private KeyValuePair<string, CheckBox>[] checks;
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

    public ParagonPresence(PlayParagonForm mainForm, KeyValuePair<string, Button>[] managedButtons, KeyValuePair<string, CheckBox>[] managedChecks)
    {
      form = mainForm;
      buttons = managedButtons;
      checks = managedChecks;
      Button ff = FindButtonByName("forfeit");
      ff.Click += new System.EventHandler(this.Forfeit_Click);

      client = new DiscordRpcClient("468591679599935490", true, -1);
      client.OnReady += (sender, e) => DisplayMessage("Get ready for a fight!");
      client.OnError += (sender, e) => DisplayMessage(e.Message);
      #pragma warning disable CS4014
      UpdateLoop();
      #pragma warning restore CS4014
      client.Initialize();
      EnterMenu();
    }
    public async Task MatchmakeAndPlayAsync(KeyValuePair<string, string> hero, KeyValuePair<string, string> map)
    {
      DisablePlay();
      do
      {
        // 45000
        await EnterQueue(45000);
        // 30000
        await EnterDraft(30000);
        // between 1500000 and 2100000
        await EnterMatch(rng.Next(1500000, 2100000), map.Key, map.Value, hero.Key, hero.Value);
        EnterMenu();
        // Requeue/match ending delay
        await Task.Delay(5000);
      } while (FindCheckByName("loop").Checked);
      EnablePlay();
    }

    // GAME WORKFLOW //
    private void EnterMenu()
    {
      client.SetPresence(new RichPresence()
      {
        Details = "In Menus",
        State = "Solo",
        Assets = menuAssets
      });
    }
    private async Task EnterQueue(int queueTime)
    {
      client.SetPresence(new RichPresence()
      {
        Details = "In Queue",
        State = "Solo",
        Assets = menuAssets
      });
      await Task.Delay(queueTime);
    }
    private async Task EnterDraft(int draftLength)
    {
      client.SetPresence(new RichPresence()
      {
        Details = "Drafting...",
        State = "Solo",
        Assets = draftAssets
      });
      await Task.Delay(draftLength);
    }
    private async Task EnterMatch(int matchLength, string mapKey, string mapText, string heroKey, string heroText)
    {
      client.SetPresence(new RichPresence()
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
      });
      playing = true;
      EnableForfeit();
      for (int i = 0; i < matchLength / 1000; i++)
      {
        if (playing == false) break;
        await Task.Delay(1000);
      }
      DisableForfeit();
    }
    // END GAME WORKFLOW //

    // FORM CONTROL //
    private void Forfeit_Click(object sender, EventArgs e)
    {
      playing = false;
      DisableForfeit();
    }
    private void DisplayMessage(string message)
    {
      using (new CenterWindow(form))
      {
        MessageBox.Show(message);
      }
    }
    private void EnablePlay()
    {
      Button play = FindButtonByName("play");
      if (play.Enabled == false)
      {
        play.Enabled = true;
      }
    }
    private void DisablePlay()
    {
      Button play = FindButtonByName("play");
      if (play.Enabled == true)
      {
        play.Enabled = false;
      }
    }
    private void EnableForfeit()
    {
      Button ff = FindButtonByName("forfeit");
      if (ff.Enabled == false)
      {
        ff.Enabled = true;
      }
    }
    private void DisableForfeit()
    {
      Button ff = FindButtonByName("forfeit");
      if (ff.Enabled == true)
      {
        ff.Enabled = false;
      }
    }
    // END FORM CONTROL //

    // RPC CLIENT HELPERS //
    public void Close() => client.Dispose();
    private async Task UpdateLoop()
    {
      while (true)
      {
        client.Invoke();
        await Task.Delay(500);
      }
    }
    // END RPC CLIENT HELPERS //

    // UTILITIES //
    private Button FindButtonByName(string name) => Array.Find(buttons, (KeyValuePair<string, Button> b) => b.Key == name).Value;
    private CheckBox FindCheckByName(string name) => Array.Find(checks, (KeyValuePair<string, CheckBox> b) => b.Key == name).Value;
    // END UTILITIES //
  }
}
