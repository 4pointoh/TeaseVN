using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using TeaseVN.Scenes.SleepQuest;

namespace TeaseVN.Scenes.EatDinnerQuest
{
    class EatDinnerScene : Scene
    {
        public EatDinnerScene(Game1 game) : base(game) { }
        public override List<Panel> loadPanels()
        {
            this.panels = new List<Panel>();
            Panel panelOne = new Panel();
            panelOne.backgroundTexture = game.Content.Load<Texture2D>("4");
            panelOne.text = "Let's see what is for dinner.";
            panelOne.id = "1";
            panelOne.nextPossiblePanels.Add("2");
            Panel panelTwo = new Panel();
            panelTwo.backgroundTexture = game.Content.Load<Texture2D>("5");
            panelTwo.text = "Yum, potatoes and mash.";
            panelTwo.id = "2";
            panelTwo.nextPossiblePanels.Add("3");
            Panel panelThree = new Panel();
            panelThree.backgroundTexture = game.Content.Load<Texture2D>("6");
            panelThree.text = "I'm tired now, I think I'll go to sleep.";
            panelThree.id = "3";

            this.panels.Add(panelOne);
            this.panels.Add(panelTwo);
            this.panels.Add(panelThree);

            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "3")
            {
                setNextScene(new SleepScene(game));
            }

            return new Panel();
        }
    }
}
