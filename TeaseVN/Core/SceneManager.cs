using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Texture2D standardUiBackground { get; set; }
        public Texture2D choiceButtonTextureHover { get; set; }
        public List<Button> currentSceneChoiceButtons { get; set; }
        public int currentHoveredButtonId { get; set; }

        //Dialogue Box
        public DialogueBox dialogueBox { get; set; }

        public SceneManager(Game1 game, Scene firstScene)
        {
            this.currentScene = firstScene;
            this.game = game;
            this.Content = game.Content;
            this.standardUiBackground = Content.Load<Texture2D>("assets/ui-background-3");
            this.choiceButtonTextureHover = Content.Load<Texture2D>("assets/ui-background2");
            this.currentSceneChoiceButtons = getChoiceButtons();
            this.currentHoveredButtonId = -1;
            prepareDialogueBox();
            refreshDialogueBoxText();
        }
        private void prepareDialogueBox()
        {
            this.dialogueBox = new DialogueBox();

            const int BOTTOM_PADDING = 10;
            const float PERCENTAGE_OF_SCREEN_HEIGHT = .20f;
            const float PERCENTAGE_OF_SCREEN_WIDTH = .70f;

            Rectangle gameBounds = game.GraphicsDevice.Viewport.Bounds;
            int boxHeight = (int)(gameBounds.Height * PERCENTAGE_OF_SCREEN_HEIGHT);
            int boxWidth = (int)(gameBounds.Width * PERCENTAGE_OF_SCREEN_WIDTH);
            
            this.dialogueBox.boxRect.Height = boxHeight;
            this.dialogueBox.boxRect.Y = (int)(gameBounds.Height - BOTTOM_PADDING - boxHeight);
            this.dialogueBox.boxRect.Width = boxWidth;
            this.dialogueBox.boxRect.X = (gameBounds.Width - boxWidth) / 2;

            this.dialogueBox.boxTexture = this.standardUiBackground;

            Vector2 textPosition = new Vector2();
            textPosition.X = this.dialogueBox.boxRect.X + 10;
            textPosition.Y = this.dialogueBox.boxRect.Y + 10;
            this.dialogueBox.textPosition = textPosition;
        }

        public void refreshDialogueBoxText()
        {
            String text = currentScene.getSceneText();
            this.dialogueBox.boxText = TextBlockHelper.formatText(text, this.game.font, this.dialogueBox.boxRect.Width - 10);
        }
        
        public void setChoiceButtonClicked(int buttonId)
        {
            this.currentScene.selectedChoice = buttonId;
            this.currentHoveredButtonId = -1;
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
                        choiceButton.buttonTexture = this.standardUiBackground;
                        currentHoveredButtonId = -1;
                    }
                }
            }
        }
        public Texture2D getCurrentBackground()
        {
            return currentScene.currentPanel.backgroundTexture;
        }
        public List<String> getCurrentSceneChoices()
        {
            return currentScene.getCurrentPanelChoices();
        }
        public bool currentSceneHasChoices()
        {
            return currentScene.getCurrentPanelChoices()?.Count != 0;
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
                    this.standardUiBackground,
                    choice,
                    new Rectangle(positionX, positionY, choiceButtonWidth, choiceButtonHeight),
                    positionX + 10,
                    positionY + 10,
                    buttonId
                    );
                positionY += choiceButtonHeight + 20;
                buttonId++;
                buttons.Add(button);
            }

            return buttons;
        }
        public void processHoveredButtons(MouseState mouseState)
        {
            foreach (Button choiceButton in this.currentSceneChoiceButtons)
            {
                if (SceneUiHelper.buttonIsHovered(mouseState, choiceButton))
                {
                    this.setChoiceButtonHovered(choiceButton.id);
                }
                else
                {
                    this.setChoiceButtonNotHovered(choiceButton.id);
                }
            }
        }
        public void processClickedButtons(MouseState mouseState)
        {
            foreach (Button choiceButton in this.currentSceneChoiceButtons)
            {
                if (SceneUiHelper.buttonIsHovered(mouseState, choiceButton))
                {
                    this.setChoiceButtonClicked(choiceButton.id);
                }
            }
        }

        public void progress()
        {
            currentScene.progress();

            if (currentScene.isComplete())
            {
                currentScene = currentScene.getNextScene();
            }

            refreshDialogueBoxText();

            this.currentSceneChoiceButtons = getChoiceButtons();
            Debug.WriteLine(currentScene.currentPanel.text + " (" + currentScene.currentPanel.id + ")");
        }
    }
}
