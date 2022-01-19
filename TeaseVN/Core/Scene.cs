using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Xna.Framework.Graphics;


namespace TeaseVN
{
    abstract class Scene
    {
        public String id;
        public Panel currentPanel;
        public Scene nextScene;
        public bool sceneComplete;
        public bool currentPanelHasChoice = false;
        public int selectedChoice = -1;
        public List<Panel> panels;
        public Dictionary<String, Boolean> sceneFlags;
        public Game1 game;
        public Dictionary<string, Panel> panelsById;

        public Scene(Game1 curGame)
        {
            game = curGame;
            sceneComplete = false;
            this.panels = loadPanels();
            this.currentPanel = this.panels[0];
        }

        public abstract List<Panel> loadPanels();
        public abstract Panel getNextPanel();
        public abstract void handlePanelEvents(); //Any logic that needs to run when the current panel ends
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
        public Scene getNextScene()
        {
            return nextScene;
        }
        public void setNextScene(Scene nextScene)
        {
            this.sceneComplete = true;
            this.nextScene = nextScene;
        }
        public bool isComplete()
        {
            return sceneComplete;
        }

    }
}
