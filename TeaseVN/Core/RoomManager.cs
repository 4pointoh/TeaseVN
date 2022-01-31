using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

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
            Room kitchen = new Room();
            kitchen.backgroundTexture = Content.Load<Texture2D>("Rooms/Kitchen");
            kitchen.id = "Kitchen";
            rooms.Add(kitchen);

            Room bathroom = new Room();
            bathroom.backgroundTexture = Content.Load<Texture2D>("Rooms/Bathroom");
            bathroom.id = "bathroom";
            rooms.Add(bathroom);

            Room diningRoom = new Room();
            diningRoom.backgroundTexture = Content.Load<Texture2D>("Rooms/Dining Room");
            diningRoom.id = "DiningRoom";
            rooms.Add(diningRoom);

            Room bed = new Room();
            bed.backgroundTexture = Content.Load<Texture2D>("Rooms/Bed");
            bed.id = "bed";
            rooms.Add(bed);
        }
    }
}
