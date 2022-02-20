using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class $safeitemname$ : Scene
    {
        public override string sceneName { get { return "<Scene File Name>"; } }
        public $safeitemname$(Game1 game) : base(game) { }

        //Logic to determine panel routing
        public override Panel getNextPanel()
        {

            //End of this scene
            if (this.currentPanel.id == "<Ending Panel Id>")
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
                game._flagManager.globalFlags.dinnerCooked = true;
                Debug.WriteLine("Dinner has been cooked.");
            }
        }

        public override Panel getStartingPanel()
        {
            //To start the scene from anywhere other than 
            //on 1st panel eg:

            if (game._flagManager.globalFlags.dinnerCooked == true)
            {
                return this.panelsById["1"];
            }

            return null;
        }
    }
}
