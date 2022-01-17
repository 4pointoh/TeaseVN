using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TeaseVN.Scenes.Ending
{
    class EndingScene : Scene
    {
        public EndingScene(Game1 game) : base(game) { }

        public override List<Panel> loadPanels()
        {
            this.panels = new List<Panel>();
            Panel panelOne = new Panel();
            panelOne.backgroundTexture = game.Content.Load<Texture2D>("10");
            panelOne.text = "The end :)";
            panelOne.id = "1";

            this.panels.Add(panelOne);

            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }

        public override Panel getNextPanel()
        {
            throw new NotImplementedException();
        }
    }
}
