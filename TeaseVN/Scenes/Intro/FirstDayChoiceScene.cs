using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TeaseVN.Scenes.EatDinnerQuest;
using TeaseVN.Scenes.SleepQuest;

namespace TeaseVN.Scenes.Intro
{
    class FirstDayChoiceScene : Scene
    {
        public FirstDayChoiceScene(Game1 game) : base(game) { }

        //Ideally panels would be loaded from a file of some kind
        //Maybe pass in a scene id, then loadPanels can be in the abstract class
        public override List<Panel> loadPanels()
        {
            this.panels = new List<Panel>();
            Panel panelOne = new Panel();
            panelOne.backgroundTexture = game.Content.Load<Texture2D>("1");
            panelOne.text = "Scene FirstDayChoiceScene Panel 1";
            panelOne.id = "1";
            panelOne.nextPossiblePanels.Add("2");
            Panel panelTwo = new Panel();
            panelTwo.backgroundTexture = game.Content.Load<Texture2D>("2");
            panelTwo.text = "Scene FirstDayChoiceScene Panel 2";
            panelTwo.id = "2";
            panelTwo.nextPossiblePanels.Add("3");
            panelTwo.nextPossiblePanels.Add("NewScene");
            panelTwo.choices.Add("Get Dinner Now");
            panelTwo.choices.Add("Get Dinner Later");
            Panel panelThree = new Panel();
            panelThree.backgroundTexture = game.Content.Load<Texture2D>("3");
            panelThree.text = "Scene FirstDayChoiceScene Panel 3";
            panelThree.id = "3";
            panelThree.choices.Add("Go To Sleep");
            panelThree.choices.Add("Get Dinner");

            this.panels.Add(panelOne);
            this.panels.Add(panelTwo);
            this.panels.Add(panelThree);

            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }

        public override Panel getNextPanel()
        {
            if(this.currentPanel.id == "2")
            {
                if(this.selectedChoice == 0)
                {
                    setNextScene(new EatDinnerScene(game));
                }
                else if(this.selectedChoice == 1)
                {
                    return panelsById["3"];
                }
            }
            else if (this.currentPanel.id == "3")
            {
                if (this.selectedChoice == 0)
                {
                    setNextScene(new SleepScene(game));
                }
                else if (this.selectedChoice == 1)
                {
                    setNextScene(new EatDinnerScene(game));
                }
            }

            return new Panel();
        }
    }
}
