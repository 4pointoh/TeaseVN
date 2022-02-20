using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Rooms
{
    class Bathroom : Room
    {
        public Bathroom(Game1 game) : base(game) { }

        public override NextEvent roomDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.BATHROOM_ROOM, NextEvent.ROOM_TYPE);
            return ev;
        }

        protected override List<Clickable> getClickables()
        {
            List<Clickable> defaults = new List<Clickable>();
            defaults.Add(getWashClickable());
            return defaults;
        }
        private Clickable getWashClickable()
        {
            Clickable wash = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 900;
            rect.Y = 50;
            rect.Width = 200;
            rect.Height = 200;
            wash.clickableArea = rect;
            wash.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            wash.id = "Wash";
            wash.processClick = new Clickable.clickProcessor(washDelegate);
            return wash;
        }

        public static NextEvent washDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.WASH_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }
    }
}
