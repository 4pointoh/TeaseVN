using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Rooms;

namespace TeaseVN.Core
{
    class RoomStorage
    {
        Dictionary<String, Room> roomById;
        Game1 game;

        public static String KITCHEN_ROOM = "Kitchen";
        public static String BED_ROOM = "Bed";
        public static String DINING_ROOM = "Dining";
        public static String BATHROOM_ROOM = "Bathroom";

        public RoomStorage(Game1 game)
        {
            this.game = game;
            this.roomById = new Dictionary<string, Room>();
            loadRooms();
        }

        public Room getRoom(String id)
        {
            return roomById[id];
        }

        private void loadRooms()
        {
            roomById.Add(KITCHEN_ROOM, loadKitchen());
            roomById.Add(BED_ROOM, loadBed());
            roomById.Add(DINING_ROOM, loadDiningRoom());
            roomById.Add(BATHROOM_ROOM, loadBathroom());
        }

        private Room loadKitchen()
        {
            Kitchen kitchen = new Kitchen(game);
            kitchen.backgroundTexture = game.Content.Load<Texture2D>("Rooms/Kitchen");
            kitchen.id = KITCHEN_ROOM;
            return kitchen;
        }
        private Room loadBed()
        {
            Bed bed = new Bed(game);
            bed.backgroundTexture = game.Content.Load<Texture2D>("Rooms/Bed");
            bed.id = BED_ROOM;
            return bed;
        }
        private Room loadDiningRoom()
        {
            DiningRoom diningRoom = new DiningRoom(game);
            diningRoom.backgroundTexture = game.Content.Load<Texture2D>("Rooms/Dining Room");
            diningRoom.id = DINING_ROOM;
            return diningRoom;
        }
        private Room loadBathroom()
        {
            Bathroom bathroom = new Bathroom(game);
            bathroom.backgroundTexture = game.Content.Load<Texture2D>("Rooms/Bathroom");
            bathroom.id = BATHROOM_ROOM;
            return bathroom;
        }
    }
}
