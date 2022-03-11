using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN
{
    public class Button
    {
        public Texture2D buttonTexture;
        public String buttonText;
        public Rectangle buttonRect;
        public Vector2 buttonPosition;
        public int id;

        public Button(Texture2D texture, String text, Rectangle rect, int buttonTextPositionX, int buttonTextPositionY, int id)
        {
            this.buttonTexture = texture;
            this.buttonText = text;
            this.buttonRect = rect;
            this.buttonPosition.X = buttonTextPositionX;
            this.buttonPosition.Y = buttonTextPositionY;
            this.id = id;
        }
    }
}
