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
        protected override List<Clickable> getClickables()
        {
            List<Clickable> defaults = new List<Clickable>();
            defaults.Add(getCookingClickable());
            defaults.Add(getChatClickable());
            defaults.Add(getDebugClickable());
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

        private Clickable getDebugClickable()
        {
            Clickable chat = new Clickable();
            Rectangle rect = new Rectangle();
            rect.X = 1000;
            rect.Y = 600;
            rect.Width = 50;
            rect.Height = 50;
            chat.clickableArea = rect;
            chat.texture = game.Content.Load<Texture2D>("assets/ui-background-3");
            chat.id = "Debug";
            chat.processClick = new Clickable.clickProcessor(debugDelegate);
            return chat;
        }

        public override NextEvent roomDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.KITCHEN_ROOM, NextEvent.ROOM_TYPE);
            return ev;
        }

        public static NextEvent cookingDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.COOKING_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }

        public static NextEvent chatDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.CHAT_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }

        public static NextEvent debugDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(SceneStorage.WORK_SCENE, NextEvent.SCENE_TYPE);
            return ev;
        }
    }
}
