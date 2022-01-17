using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TeaseVN
{
    class SceneUiHelper
    {
        public static void checkHoveringChoice(MouseState mouseState, SceneManager sceneManager)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);

            List<Button> choiceButtons = sceneManager.currentSceneChoiceButtons;
            foreach (Button choiceButton in choiceButtons)
            {
                if (choiceButton.buttonRect.Contains(mousePoint))
                {
                    //Debug.WriteLine("Hovering button " + choiceButton.buttonText);
                    sceneManager.setChoiceButtonHovered(choiceButton.id);
                }
                else
                {
                    sceneManager.setChoiceButtonNotHovered(choiceButton.id);
                }
            }
        }

        public static void checkClickedChoice(MouseState mouseState, SceneManager sceneManager)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);

            List<Button> choiceButtons = sceneManager.currentSceneChoiceButtons;
            foreach (Button choiceButton in choiceButtons)
            {
                if(sceneManager.currentHoveredButtonId == -1)
                {
                    return;
                }

                if (sceneManager.currentHoveredButtonId == choiceButton.id && choiceButton.buttonRect.Contains(mousePoint))
                {
                    Debug.WriteLine("Clicked button " + choiceButton.buttonText);
                    sceneManager.setChoiceButtonClicked(choiceButton.id);
                }
            }
        }
    }
}
