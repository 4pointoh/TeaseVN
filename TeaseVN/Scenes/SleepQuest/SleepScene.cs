using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TeaseVN.Scenes.Ending;

namespace TeaseVN.Scenes.SleepQuest
{
    class SleepScene : Scene
    {
        public SleepScene(Game1 game) : base(game) { }

        public override List<Panel> loadPanels()
        {
            this.panels = new List<Panel>();
            Panel panelOne = new Panel();
            panelOne.backgroundTexture = game.Content.Load<Texture2D>("7");
            panelOne.text = "Alright, time for sleep";
            panelOne.id = "1";
            panelOne.guaranteedNextPanel = "2";
            Panel panelTwo = new Panel();
            panelTwo.backgroundTexture = game.Content.Load<Texture2D>("8");
            panelTwo.text = "I set my alarm for 10am";
            panelTwo.id = "2";
            panelTwo.guaranteedNextPanel = "3";
            Panel panelThree = new Panel();
            panelThree.backgroundTexture = game.Content.Load<Texture2D>("9");
            panelThree.text = "Good night";
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
                setNextScene(new EndingScene(game));
            }

            return new Panel();
        }
        public override void handlePanelEvents()
        {

        }
    }
}
