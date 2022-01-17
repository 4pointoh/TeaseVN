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
        public static bool buttonIsHovered(MouseState mouseState, Button button)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            return button.buttonRect.Contains(mousePoint);
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
