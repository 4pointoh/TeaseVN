using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Scenes
{
    class WorkoutScene : Scene
    {
        public override string sceneName { get { return "Workout"; } }
        public WorkoutScene(Game1 game) : base(game) { }

        //Logic to determine panel routing
        public override Panel getNextPanel()
        {
            //End of this scene
            if (this.currentPanel.id == "4")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        //To set flags, modify stats, etc...
        //in the middle of a scene. eg:
        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "4")
            {
                game.eventManager.workoutEvent();
                Debug.WriteLine("I worked out.");
            }
        }
    }
}
