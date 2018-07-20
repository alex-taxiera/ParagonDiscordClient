using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParagonDiscordClient
{
  public partial class PlayParagonForm : Form
  {
    ParagonPresence presence;
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
    public PlayParagonForm()
    {
      InitializeComponent();
      presence = new ParagonPresence(
        this,
        new KeyValuePair<string, Button>[]
        {
          new KeyValuePair<string, Button>("forfeit", Forfeit),
          new KeyValuePair<string, Button>("play", Play)
        },
        new KeyValuePair<string, CheckBox>[]
        {
          new KeyValuePair<string, CheckBox>("loop", loopCheck)
        }
      );
      mapBox.DataSource = new BindingSource(largeAssets, null);
      mapBox.DisplayMember = "Value";
      mapBox.ValueMember = "Key";
      heroBox.DataSource = new BindingSource(smallAssets, null);
      heroBox.DisplayMember = "Value";
      heroBox.ValueMember = "Key";
    }

    private async void Play_Click(object sender, EventArgs e)
    {
      KeyValuePair<string, string> selectedHero = (KeyValuePair<string, string>)heroBox.SelectedItem;
      KeyValuePair<string, string> selectedMap = (KeyValuePair<string, string>)mapBox.SelectedItem;
      await presence.MatchmakeAndPlayAsync(selectedHero, selectedMap);
    }

    private void PlayParagonForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      presence.Close();
    }

    private void PartyBox_SelectedValueChanged(object sender, EventArgs e)
    {
      presence.UpdateParty(Int32.Parse(PartyBox.SelectedItem.ToString()));
    }
  }
}
