using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    class Clickable
    {
        public delegate void clickProcessor();
        public clickProcessor processClick;
        public Rectangle clickableArea { get; set; }
        public String id { get; set; }
        public Texture2D texture { get; set; }
    }
}
