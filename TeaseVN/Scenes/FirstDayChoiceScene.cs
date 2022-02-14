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

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "3")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }
            return new Panel();
        }

    }
}
