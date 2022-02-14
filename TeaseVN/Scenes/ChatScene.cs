using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes.Intro
{
    class ChatScene : Scene
    {
        public override string sceneName { get { return "Chat"; } }
        public ChatScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "1")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            if (this.currentPanel.id == "2")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        public override Panel getStartingPanel()
        {
            if (game._flagManager.globalFlags.dinnerCooked == true)
            {
                return this.panelsById["1"];
            }
            else if (game._flagManager.globalFlags.dinnerCooked == false)
            {
                return this.panelsById["2"];
            }

            return null;
        }
    }
}
