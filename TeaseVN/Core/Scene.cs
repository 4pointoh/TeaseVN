using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TeaseVN.Core;

namespace TeaseVN
{
    abstract class Scene
    {
        public String id;
        public Panel currentPanel;
        public String nextSceneId;
        public bool sceneComplete;
        public bool currentPanelHasChoice = false;
        public int selectedChoice = -1;
        public List<Panel> panels;
        public Dictionary<string, bool> sceneFlags;
        public Game1 game;
        public Dictionary<string, Panel> panelsById;

        public abstract String sceneName {get;}

        public Scene(Game1 curGame)
        {
            game = curGame;
            sceneComplete = false;
            this.panels = loadPanels();
            this.currentPanel = this.panels[0];
            this.sceneFlags = new Dictionary<string, bool>();
        }

        public List<Panel> loadPanels()
        {
            this.panels = SceneJsonParser.loadScene(this.sceneName, game);
            this.panelsById = this.panels.ToDictionary(panel => panel.id, panel => panel);

            return this.panels;
        }
        public void completeScene()
        {
            this.sceneComplete = false;
            this.currentPanel = this.panels[0];
            this.selectedChoice = -1;
            this.sceneFlags = new Dictionary<string, bool>();
            this.currentPanelHasChoice = false;
        }
        public abstract Panel getNextPanel();
        public virtual void handlePanelEvents()
        {
            //Any logic that needs to run when the current panel ends
        }
        public String getSceneText()
        {
            return this.currentPanel.text;
        }
        public List<String> getCurrentPanelChoices()
        {
            if (currentPanel.choices?.Count == 0)
            {
                return new List<String>();
            }
            else
            {
                return currentPanel.choices;
            }
        }
        public void progress()
        {
            if (this.currentPanelHasChoice && this.selectedChoice == -1)
            {
                //there's a choice, but none was chosen
                return;
            }

            else if (!this.currentPanelHasChoice && this.currentPanel.guaranteedNextPanel != null)
            {
                progressPanel(this.panelsById[this.currentPanel.guaranteedNextPanel]);
            }

            else if (this.currentPanelHasChoice && this.selectedChoice != -1)
            {
                progressPanel(getNextPanel());
                this.selectedChoice = -1;
            }

            else if (!this.currentPanelHasChoice)
            {
                progressPanel(getNextPanel());
            }
        }
        public void progressPanel(Panel nextPanel)
        {
            handlePanelEvents();

            if (isComplete())
            {
                //Current scene is completed, there is no next panel
                return;
            }

            this.currentPanel = nextPanel;
            if (nextPanel.choices.Count > 0)
            {
                this.currentPanelHasChoice = true;
            }
            else
            {
                this.currentPanelHasChoice = false;
            }
        }
        public String getNextSceneId()
        {
            return this.nextSceneId;
        }
        public void setNextSceneId(String nextSceneId)
        {
            this.sceneComplete = true;
            this.nextSceneId = nextSceneId;
        }
        public bool isComplete()
        {
            return sceneComplete;
        }

    }
}
