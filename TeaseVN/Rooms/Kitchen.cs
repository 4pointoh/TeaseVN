using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Core;
using TeaseVN.Scenes.EatDinnerQuest;

namespace TeaseVN.Rooms
{
    class Kitchen : Room
    {
        public Kitchen(Game1 game) : base(game) { }
        protected override List<Clickable> getDefaultClickables()
        {
            List<Clickable> defaults = new List<Clickable>();
            defaults.Add(getCookingClickable());
            defaults.Add(getChatClickable());
            return defaults;
        }
        private Clickable getCookingClickable()
        {
            Clickable cooking = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 200;
            rect.Y = 300;
            rect.Width = 200;
            rect.Height = 200;
            cooking.clickableArea = rect;
            cooking.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            cooking.id = "Cooking";
            cooking.processClick = new Clickable.clickProcessor(cookingDelegate);
            return cooking;
        }
        private Clickable getChatClickable()
        {
            Clickable chat = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 1000;
            rect.Y = 100;
            rect.Width = 200;
            rect.Height = 200;
            chat.clickableArea = rect;
            chat.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            chat.id = "Chat";
            chat.processClick = new Clickable.clickProcessor(chatDelegate);
            return chat;
        }

        public static NextEvent cookingDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.DINNER_SCENE, NextEvent.SCENE_TYPE);
            Debug.WriteLine("Running Cooking Logic");
            return ev;
        }

        public static NextEvent chatDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.DINING_ROOM, NextEvent.ROOM_TYPE);
            Debug.WriteLine("Running Chat Logic");
            return ev;
        }
    }
}
