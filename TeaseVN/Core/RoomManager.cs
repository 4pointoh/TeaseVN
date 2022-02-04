using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TeaseVN.Rooms;

namespace TeaseVN.Core
{
    class RoomManager
    {
        public Room currentRoom { get; set; }
        public List<Room> currentTravelOptions { get; set; }
        public List<Room> rooms { get; set; }
        public ContentManager Content { get; set; }

        public Game1 game;

        public RoomManager(Game1 game)
        {
            this.game = game;
            this.Content = game.Content;
            this.rooms = new List<Room>();
            loadRooms();
            this.currentRoom = rooms[0];

        }

        public Texture2D getCurrentBackground()
        {
            return currentRoom.backgroundTexture;
        }

        private void loadRooms()
        {
            Kitchen kitchen = new Kitchen(game);
            kitchen.backgroundTexture = Content.Load<Texture2D>("Rooms/Kitchen");
            kitchen.id = "Kitchen";
            rooms.Add(kitchen);

            Bathroom bathroom = new Bathroom(game);
            bathroom.backgroundTexture = Content.Load<Texture2D>("Rooms/Bathroom");
            bathroom.id = "bathroom";
            rooms.Add(bathroom);

            DiningRoom diningRoom = new DiningRoom(game);
            diningRoom.backgroundTexture = Content.Load<Texture2D>("Rooms/Dining Room");
            diningRoom.id = "DiningRoom";
            rooms.Add(diningRoom);

            Bed bed = new Bed(game);
            bed.backgroundTexture = Content.Load<Texture2D>("Rooms/Bed");
            bed.id = "bed";
            rooms.Add(bed);
        }

        public List<Clickable> getCurrentRoomClickables()
        {
            return this.currentRoom.getClickableItems();
        }

        public bool processHoveredClickables(MouseState mouseState)
        {
            foreach (Clickable item in this.getCurrentRoomClickables())
            {
                if (SceneUiHelper.clickableIsHovered(mouseState, item))
                {
                    return true;
                }
            }

            return false;
        }

        public void processClickedClickables(MouseState mouseState)
        {
            foreach (Clickable item in this.getCurrentRoomClickables())
            {
                if (SceneUiHelper.clickableIsHovered(mouseState, item))
                {
                    item.processClick();
                }
            }
        }
    }
}
