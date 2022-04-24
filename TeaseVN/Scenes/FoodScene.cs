using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class FoodScene : Scene
    {
        public override string sceneName { get { return "Food"; } }
        public FoodScene(Game1 game) : base(game) { }

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
                this.game.eventManager.setFoodFound(true);
                Debug.WriteLine("Found some food!");
            }
        }
    }
}
