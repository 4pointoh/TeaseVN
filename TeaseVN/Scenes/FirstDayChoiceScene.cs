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
    class FirstDayChoiceScene : Scene
    {
        public override string sceneName { get { return "FirstDay"; } }
        public FirstDayChoiceScene(Game1 game) : base(game) { }

        /*
         * 
         * Can potentially use the json to handle the "set next scene" functionality
         * Create a Contants class of Scene Name (String) > Scene Object
         * Then just pull the scene based on that
         * 
         * BUT need a way to return to "rooms" after the scene is done
         * Can potentially use the same method, just have a scene called
         * "Scene Over" or something, which maps to the current room the
         * player was in
         * 
         * Probably want some way to handle basic "Select choice A > go to Scene A"
         * in the JSON. Worth considering. 
         * 
         */


        public override Panel getNextPanel()
        {
            if(this.currentPanel.id == "2")
            {
                if(this.selectedChoice == 0)
                {
                    setNextSceneId(SceneStorage.DINNER_SCENE);
                }
                else if(this.selectedChoice == 1)
                {
                    return panelsById["3"];
                }
                else if (this.selectedChoice == 2)
                {
                    setNextSceneId(SceneStorage.WORK_SCENE);
                }
            }
            else if (this.currentPanel.id == "3")
            {
                if (this.selectedChoice == 0)
                {
                    setNextSceneId(SceneStorage.SLEEP_SCENE);
                }
                else if (this.selectedChoice == 1)
                {
                    setNextSceneId(SceneStorage.DINNER_SCENE);
                }
            }

            return new Panel();
        }

    }
}
