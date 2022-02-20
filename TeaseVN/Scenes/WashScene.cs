using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class WashScene : Scene
    {
        public override string sceneName { get { return "Wash"; } }
        public WashScene(Game1 game) : base(game) { }

        public override Panel getNextPanel()
        {
            if (this.currentPanel.id == "2")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "2")
            {
                this.game.eventManager.washEvent();
            }
        }
    }
}
