using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class KnifeScene : Scene
    {
        public override string sceneName { get { return "Knife"; } }
        public KnifeScene(Game1 game) : base(game) { }

        //Logic to determine panel routing
        public override Panel getNextPanel()
        {

            //End of this scene
            if (this.currentPanel.id == "2")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        //To set flags, modify stats, etc...
        //in the middle of a scene. eg:
        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "1")
            {
                this.game.eventManager.setKnifeFound(true);
                Debug.WriteLine("Found a knife!");
            }
        }
    }
}
