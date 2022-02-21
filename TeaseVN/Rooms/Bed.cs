using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Rooms
{
    class Bed : Room
    {
        public Bed(Game1 game) : base(game) { }

        public override NextEvent roomDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.BED_ROOM, NextEvent.ROOM_TYPE);
            return ev;
        }
        protected override List<Clickable> getClickables()
        {
            List<Clickable> clickables = new List<Clickable>();
            clickables.Add(getBedtimeClickable());
            clickables.Add(getWorkoutClickable());
            return clickables;
        }
        private Clickable getBedtimeClickable()
        {
            Clickable eat = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 500;
            rect.Y = 100;
            rect.Width = 400;
            rect.Height = 400;
            eat.clickableArea = rect;
            eat.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            eat.id = "Bedtime";
            eat.processClick = new Clickable.clickProcessor(bedtimeDelegate);
            return eat;
        }

        public static NextEvent bedtimeDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.BEDTIME_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }

        private Clickable getWorkoutClickable()
        {
            Clickable workout = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 100;
            rect.Y = 300;
            rect.Width = 200;
            rect.Height = 200;
            workout.clickableArea = rect;
            workout.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            workout.id = "Workout";
            workout.processClick = new Clickable.clickProcessor(workoutDelegate);
            return workout;
        }

        public static NextEvent workoutDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.WORKOUT_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }
    }
}
