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
            List<Clickable> clickables = new List<Clickable>();
            clickables.Add(getWashClickable());

            if (game.eventManager.getTempJobAvailable())
            {
                clickables.Add(getTempJobClickable());
            }
            return clickables;
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

        private Clickable getTempJobClickable()
        {
            Clickable tempJob = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 50;
            rect.Y = 400;
            rect.Width = 200;
            rect.Height = 200;
            tempJob.clickableArea = rect;
            tempJob.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            tempJob.id = "TempJob";
            tempJob.processClick = new Clickable.clickProcessor(tempJobDelegate);
            return tempJob;
        }

        public static NextEvent tempJobDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.TEMP_JOB_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }
    }
}
