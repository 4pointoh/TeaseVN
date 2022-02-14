using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes.Intro
{
    class CookingScene : Scene
    {
        public override string sceneName { get { return "Cooking"; } }
        public CookingScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "4")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "1")
            {
                game._flagManager.globalFlags.dinnerCooked = true;
                Debug.WriteLine("Dinner has been cooked.");
            }
        }
    }
}
