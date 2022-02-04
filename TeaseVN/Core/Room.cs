using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    abstract class Room
    {
        public Texture2D backgroundTexture { get; set; }
        public String id { get; set; }
        private List<Clickable> clickableItems;
        public Game1 game { get; set; }

        public Room(Game1 game)
        {
            this.game = game;
            this.clickableItems = new List<Clickable>();
            this.clickableItems.AddRange(getDefaultClickables());
        }

        protected virtual List<Clickable> getDefaultClickables()
        {
            return new List<Clickable>();
        }

        public List<Clickable> getClickableItems()
        {
            //In the future, add logic to pull "conditional clickables"
            //based on flag logic or something
            return this.clickableItems;
        }
    }
}
