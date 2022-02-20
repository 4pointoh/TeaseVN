using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class BedtimeScene : Scene
    {
        public override string sceneName { get { return "Bedtime"; } }
        public BedtimeScene(Game1 game) : base(game) { }

        //Logic to determine panel routing
        public override Panel getNextPanel()
        {

            //End of this scene
            if (this.currentPanel.id == "3")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }
    }
}
