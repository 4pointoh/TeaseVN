using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    class Room
    {
        public Texture2D backgroundTexture { get; set; }
        public String id { get; set; }
        public List<Clickable> clickableItems { get; set; }
    }
}
