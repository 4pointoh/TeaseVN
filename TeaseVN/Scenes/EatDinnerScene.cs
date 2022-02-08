using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Linq;
using TeaseVN.Scenes.SleepQuest;
using TeaseVN.Core;
using TeaseVN.Core.SceneUtil;

namespace TeaseVN.Scenes.EatDinnerQuest
{
    class EatDinnerScene : Scene
    {
        public override string sceneName { get { return "EatDinner"; } }
        public EatDinnerScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "3")
            {
                setNextSceneId(SceneStorage.SLEEP_SCENE);
            }

            return new Panel();
        }
    }
}
