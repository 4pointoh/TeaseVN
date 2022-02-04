using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN
{
    class SceneUiHelper
    {
        public static bool buttonIsHovered(MouseState mouseState, Button button)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            return button.buttonRect.Contains(mousePoint);
        }

        public static bool clickableIsHovered(MouseState mouseState, Clickable clickable)
        {
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            return clickable.clickableArea.Contains(mousePoint);
        }

        public static void setCursorToPointer(Game1 game)
        {
            game.IsMouseVisible = false;
            game.usePointerCursor = true;
        }

        public static void setCursorToDefault(Game1 game)
        {
            game.IsMouseVisible = true;
            game.usePointerCursor = false;
        }
    }
}
