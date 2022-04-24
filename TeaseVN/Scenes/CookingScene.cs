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
            if(this.currentPanel.id == "1")
            {
                if(!this.game.eventManager.getCookEventAvailable())
                {
                    return panelsById["5"];
                }
                else
                {
                    return panelsById["2"];
                }
            }
            if (this.currentPanel.id == "4" || this.currentPanel.id == "6")
            {
                setNextSceneId(SceneStorage.NO_SCENE);
            }

            return new Panel();
        }

        public override void handlePanelEvents()
        {
            if (this.currentPanel.id == "4")
            {
                game.eventManager.setDinnerCooked(true);
            }
        }
    }
}
