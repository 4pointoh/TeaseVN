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
    }
}
