﻿using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;

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
            panelOne.text = "Scene EatDinnerScene Panel 1";
            panelOne.id = "1";
            panelOne.nextPossiblePanels.Add("2");
            Panel panelTwo = new Panel();
            panelTwo.backgroundTexture = game.Content.Load<Texture2D>("5");
            panelTwo.text = "Scene EatDinnerScene Panel 2";
            panelTwo.id = "2";
            panelTwo.nextPossiblePanels.Add("3");
            Panel panelThree = new Panel();
            panelThree.backgroundTexture = game.Content.Load<Texture2D>("6");
            panelThree.text = "Scene EatDinnerScene Panel 3";
            panelThree.id = "3";

            this.panels.Add(panelOne);
            this.panels.Add(panelTwo);
            this.panels.Add(panelThree);

            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }

        public override Panel getNextPanel()
        {
            throw new NotImplementedException();
        }
    }
}
