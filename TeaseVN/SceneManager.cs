using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Scenes.Intro;

namespace TeaseVN
{
    class SceneManager
    {
        //Init
        public ContentManager Content { get; set; }
        public Game1 game { get; set; }
        public Scene currentScene { get; set; }

        //Choice Buttons
        public Texture2D choiceButtonTexture { get; set; }
        public Texture2D choiceButtonTextureHover { get; set; }
        public List<Button> currentSceneChoiceButtons { get; set; }
        public int currentHoveredButtonId { get; set; }        

        public SceneManager(Game1 game, Scene firstScene)
        {
            this.currentScene = firstScene;
            this.game = game;
            this.Content = game.Content;
            this.choiceButtonTexture = Content.Load<Texture2D>("assets/ui-background");
            this.choiceButtonTextureHover = Content.Load<Texture2D>("assets/ui-background2");
            this.currentSceneChoiceButtons = getChoiceButtons();
            this.currentHoveredButtonId = -1;
        }

        public List<String> getCurrentSceneChoices()
        {
            return currentScene.getCurrentPanelChoices();
        }

        public bool currentSceneHasChoices()
        {
            return currentScene.getCurrentPanelChoices()?.Count != 0;
        }

        public void setChoiceButtonHovered(int buttonId)
        {
            if (this.currentHoveredButtonId == buttonId)
            {
                return; //already hovering
            }
            else
            {
                foreach (Button choiceButton in this.currentSceneChoiceButtons)
                {
                    if (choiceButton.id == buttonId)
                    {
                        choiceButton.buttonTexture = this.choiceButtonTextureHover;
                        this.currentHoveredButtonId = buttonId;
                    }
                }
            }  
        }

        public void setChoiceButtonClicked(int buttonId)
        {
            this.currentScene.selectedChoice = buttonId;
            this.currentHoveredButtonId = -1;
        }

        public void setChoiceButtonNotHovered(int buttonId)
        {
            if (currentHoveredButtonId != buttonId)
            {
                return; //already not hovering
            }
            else
            {
                foreach (Button choiceButton in this.currentSceneChoiceButtons)
                {
                    if (choiceButton.id == buttonId)
                    {
                        choiceButton.buttonTexture = this.choiceButtonTexture;
                        currentHoveredButtonId = -1;
                    }
                }
            }
        }

        public Texture2D getCurrentBackground()
        {
            return currentScene.currentPanel.backgroundTexture;
        }

        private List<Button> getChoiceButtons()
        {
            List<Button> buttons = new List<Button>();
            if (!currentSceneHasChoices())
            {
                return buttons;
            }
            
            List<String> choices = getCurrentSceneChoices();

            Rectangle gameBounds = game.GraphicsDevice.Viewport.Bounds;

            int choiceButtonHeight = 50;
            int choiceButtonWidth = (int)(gameBounds.Width * .50f);
            int positionX = ((gameBounds.Width - choiceButtonWidth) / 2);
            int positionY = (int)(gameBounds.Height * .50f);
            int buttonId = 0;
            foreach(String choice in choices)
            {
                Button button = new Button(
                    this.choiceButtonTexture,
                    choice,
                    new Rectangle(positionX, positionY, choiceButtonWidth, choiceButtonHeight),
                    positionX + 10,
                    positionY + 10,
                    buttonId
                    );
                positionY += choiceButtonHeight + 50;
                buttonId++;
                buttons.Add(button);
            }

            return buttons;
        }

        public void progress()
        {
            currentScene.progress();

            if (currentScene.isComplete())
            {
                currentScene = currentScene.getNextScene();
            }

            this.currentSceneChoiceButtons = getChoiceButtons();
        }
    }
}
