using System.Collections.Generic;
using System.Windows.Forms;

namespace ParagonDiscordClient
{
  partial class PlayParagonForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayParagonForm));
      this.heroLabel = new System.Windows.Forms.Label();
      this.mapLabel = new System.Windows.Forms.Label();
      this.Play = new System.Windows.Forms.Button();
      this.heroBox = new System.Windows.Forms.ComboBox();
      this.mapBox = new System.Windows.Forms.ComboBox();
      this.Forfeit = new System.Windows.Forms.Button();
      this.loopCheck = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // heroLabel
      // 
      this.heroLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.heroLabel.AutoSize = true;
      this.heroLabel.Location = new System.Drawing.Point(8, 16);
      this.heroLabel.Name = "heroLabel";
      this.heroLabel.Size = new System.Drawing.Size(69, 13);
      this.heroLabel.TabIndex = 2;
      this.heroLabel.Text = "Choose Hero";
      // 
      // mapLabel
      // 
      this.mapLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.mapLabel.AutoSize = true;
      this.mapLabel.Location = new System.Drawing.Point(8, 48);
      this.mapLabel.Name = "mapLabel";
      this.mapLabel.Size = new System.Drawing.Size(67, 13);
      this.mapLabel.TabIndex = 3;
      this.mapLabel.Text = "Choose Map";
      // 
      // Play
      // 
      this.Play.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.Play.Location = new System.Drawing.Point(56, 112);
      this.Play.Name = "Play";
      this.Play.Size = new System.Drawing.Size(136, 23);
      this.Play.TabIndex = 4;
      this.Play.Text = "Matchmake and Play!";
      this.Play.UseVisualStyleBackColor = true;
      this.Play.Click += new System.EventHandler(this.Play_Click);
      // 
      // heroBox
      // 
      this.heroBox.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.heroBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.heroBox.FormattingEnabled = true;
      this.heroBox.Location = new System.Drawing.Point(112, 16);
      this.heroBox.Name = "heroBox";
      this.heroBox.Size = new System.Drawing.Size(121, 21);
      this.heroBox.Sorted = true;
      this.heroBox.TabIndex = 0;
      // 
      // mapBox
      // 
      this.mapBox.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.mapBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mapBox.FormattingEnabled = true;
      this.mapBox.Location = new System.Drawing.Point(112, 48);
      this.mapBox.Name = "mapBox";
      this.mapBox.Size = new System.Drawing.Size(121, 21);
      this.mapBox.TabIndex = 1;
      // 
      // Forfeit
      // 
      this.Forfeit.Enabled = false;
      this.Forfeit.Location = new System.Drawing.Point(200, 112);
      this.Forfeit.Name = "Forfeit";
      this.Forfeit.Size = new System.Drawing.Size(32, 23);
      this.Forfeit.TabIndex = 5;
      this.Forfeit.Text = "FF";
      this.Forfeit.UseVisualStyleBackColor = true;
      // 
      // loopCheck
      // 
      this.loopCheck.AutoSize = true;
      this.loopCheck.Location = new System.Drawing.Point(8, 80);
      this.loopCheck.Name = "loopCheck";
      this.loopCheck.Size = new System.Drawing.Size(83, 17);
      this.loopCheck.TabIndex = 6;
      this.loopCheck.Text = "Auto Queue";
      this.loopCheck.UseVisualStyleBackColor = true;
      // 
      // PlayParagonForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(244, 141);
      this.Controls.Add(this.loopCheck);
      this.Controls.Add(this.Forfeit);
      this.Controls.Add(this.Play);
      this.Controls.Add(this.mapLabel);
      this.Controls.Add(this.heroLabel);
      this.Controls.Add(this.mapBox);
      this.Controls.Add(this.heroBox);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximumSize = new System.Drawing.Size(260, 180);
      this.MinimumSize = new System.Drawing.Size(260, 180);
      this.Name = "PlayParagonForm";
      this.Text = "Play Paragon";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PlayParagonForm_FormClosed);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private Label heroLabel;
    private Label mapLabel;
    private Button Play;
    private ComboBox heroBox;
    private ComboBox mapBox;
    private Button Forfeit;
    private CheckBox loopCheck;
  }
}

