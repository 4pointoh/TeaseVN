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
    class GoToWorkScene : Scene
    {
        public GoToWorkScene(Game1 game) : base(game) { }

        //Ideally panels would be loaded from a file of some kind
        //Maybe pass in a scene id, then loadPanels can be in the abstract class
        public override List<Panel> loadPanels()
        {
            this.panels = new List<Panel>();
            Panel panelOne = new Panel();
            panelOne.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelOne.text = "I'm at work";
            panelOne.id = "1";
            panelOne.guaranteedNextPanel = "2";
            Panel panelTwo = new Panel();
            panelTwo.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelTwo.text = "Should I clean dishes (10) or sweep floors? (20)";
            panelTwo.id = "2";
            panelTwo.choices.Add("Clean Dishes (10)");
            panelTwo.choices.Add("Sweep Floors (20)");
            Panel panelThree = new Panel();
            panelThree.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelThree.text = "I decided to clean the dishes";
            panelThree.id = "3";
            panelThree.guaranteedNextPanel = "4";
            Panel panelFour = new Panel();
            panelFour.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelFour.text = "I earned $10";
            panelFour.id = "4";
            Panel panelFive = new Panel();
            panelFive.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelFive.text = "I earned $20";
            panelFive.id = "5";
            Panel panelSix = new Panel();
            panelSix.backgroundTexture = game.Content.Load<Texture2D>("SceneTemplate");
            panelSix.text = "I decided to sweep the floors";
            panelSix.id = "6";
            panelSix.guaranteedNextPanel = "5";


            this.panels.Add(panelOne);
            this.panels.Add(panelTwo);
            this.panels.Add(panelThree);
            this.panels.Add(panelFour);
            this.panels.Add(panelFive);
            this.panels.Add(panelSix);

            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }

        public override Panel getNextPanel()
        {
            if(this.currentPanel.id == "2")
            {
                if(this.selectedChoice == 0)
                {
                    return panelsById["3"];
                }
                else if(this.selectedChoice == 1)
                {
                    return panelsById["6"];
                }
            }
            else if (this.currentPanel.id == "4" || this.currentPanel.id == "5")
            {
                setNextScene(new SleepScene(game));
            }

            return new Panel();
        }

        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "4")
            {
                Debug.WriteLine("You earned $10");
            }
            else if(this.currentPanel.id == "5")
            {
                Debug.WriteLine("You earned $20");
            }
        }
    }
}
