using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN
{
    class DialogueBox
    {
        public Texture2D boxTexture { get; set; }
        public String boxText {get; set;}
        public Rectangle boxRect;
        public Vector2 textPosition;

        public DialogueBox()
        {
            this.boxText = "";
            this.textPosition = new Vector2(0, 0);
        }
    }
}
