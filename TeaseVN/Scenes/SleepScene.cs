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
        public override string sceneName { get { return "Sleep"; } }
        public SleepScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "3")
            {
                setNextScene(new EndingScene(game));
            }

            return new Panel();
        }
    }
}
