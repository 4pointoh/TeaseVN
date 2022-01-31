using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    class Clickable
    {
        Delegate clickLogic { get; set; }
        Rectangle clickableArea { get; set; }
        String id { get; set; }
        public Texture2D texture { get; set; }
    }
}
