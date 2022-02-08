using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using TeaseVN.Core;
using TeaseVN.Scenes.EatDinnerQuest;
using TeaseVN.Scenes.SleepQuest;

namespace TeaseVN.Scenes.Intro
{
    class GoToWorkScene : Scene
    {
        public override string sceneName { get { return "Work"; } }
        public GoToWorkScene(Game1 game) : base(game) { }

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
                setNextSceneId(SceneStorage.NO_SCENE);
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
