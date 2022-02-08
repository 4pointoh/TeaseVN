using System;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TeaseVN.Scenes.Intro;
using TeaseVN.Core;

namespace TeaseVN.Scenes.Ending
{
    class EndingScene : Scene
    {
        public override string sceneName { get { return "Ending"; } }
        public EndingScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            setNextSceneId(SceneStorage.NO_SCENE);
            return new Panel();
        }

    }
}
