using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN
{
    class Panel
    {
        public Texture2D backgroundTexture { get; set; }
        public String text { get; set; }
        public List<String> choices { get; set; }
        public String id { get; set; }
        public List<String> nextPossiblePanels { get; set; }
        public Panel()
        {
            this.nextPossiblePanels = new List<String>();
            this.choices = new List<String>();
        }

        public bool hasChoices()
        {
            return choices.Count > 0;
        }
    }
}
