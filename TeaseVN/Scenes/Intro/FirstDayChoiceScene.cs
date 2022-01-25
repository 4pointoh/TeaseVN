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
        public override string sceneName { get { return "FirstDay"; } }
        public FirstDayChoiceScene(Game1 game) : base(game) { }
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
                else if (this.selectedChoice == 2)
                {
                    setNextScene(new GoToWorkScene(game));
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

        public override void handlePanelEvents()
        {

        }
    }
}
