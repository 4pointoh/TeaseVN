using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Scenes.Intro
{
    class NoScene : Scene
    {
        public override string sceneName { get { return "NoScene"; } }
        public NoScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            return new Panel();
        }
    }
}
