using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Rooms
{
    class DiningRoom : Room
    {
        public DiningRoom(Game1 game) : base(game) { }

        public override NextEvent roomDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.DINING_ROOM, NextEvent.ROOM_TYPE);
            return ev;
        }

        protected override List<Clickable> getClickables()
        {
            List<Clickable> clickables = new List<Clickable>();
            
            if (game.eventManager.getEatEventAvailable())
            {
                clickables.Add(getEatClickable());
            }
            return clickables;
        }
        private Clickable getEatClickable()
        {
            Clickable eat = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 800;
            rect.Y = 400;
            rect.Width = 200;
            rect.Height = 200;
            eat.clickableArea = rect;
            eat.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            eat.id = "Eat";
            eat.processClick = new Clickable.clickProcessor(eatDelegate);
            return eat;
        }

        public static NextEvent eatDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.EAT_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }
    }
}
