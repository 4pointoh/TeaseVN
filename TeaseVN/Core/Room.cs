using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    abstract public class Room
    {
        public Texture2D backgroundTexture { get; set; }
        public Texture2D icon { get; set; }
        public String id { get; set; }
        private List<Clickable> clickableItems;
        public static Game1 game { get; set; }

        public Room(Game1 curGame)
        {
            game = curGame;
            refreshRoom();
        }

        public void refreshRoom()
        {
            this.clickableItems = new List<Clickable>();
            this.clickableItems.AddRange(getClickables());
        }

        protected virtual List<Clickable> getClickables()
        {
            return new List<Clickable>();
        }

        public List<Clickable> getClickableItems()
        {
            //In the future, add logic to pull "conditional clickables"
            //based on flag logic or something
            return this.clickableItems;
        }

        abstract public NextEvent roomDelegate();
    }
}
