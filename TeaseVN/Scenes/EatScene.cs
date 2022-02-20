using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class EatScene : Scene
    {
        public override string sceneName { get { return "Eat"; } }
        public EatScene(Game1 game) : base(game) { }

        //Logic to determine panel routing
        public override Panel getNextPanel()
        {

            //End of this scene
            if (this.currentPanel.id == "1")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }
            if (this.currentPanel.id == "3")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        public override Panel getStartingPanel()
        {
            //To start the scene from anywhere other than 
            //on 1st panel eg:

            if (!game.eventManager.getEatEventSufficientHygiene())
            {
                return this.panelsById["1"];
            }
            else
            {
                return this.panelsById["2"];
            }
        }
    }
}
