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
        public ContentManager Content { get; set; }

        public Game1 game;

        public RoomManager(Game1 game, Room startingRoom)
        {
            this.game = game;
            this.Content = game.Content;
            this.currentRoom = startingRoom;

        }

        public void setCurrentRoom(Room room)
        {
            this.currentRoom = room;
        }

        public Texture2D getCurrentBackground()
        {
            return currentRoom.backgroundTexture;
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

        public NextEvent processClickedClickables(MouseState mouseState)
        {
            foreach (Clickable item in this.getCurrentRoomClickables())
            {
                if (SceneUiHelper.clickableIsHovered(mouseState, item))
                {
                    return item.processClick();
                }
            }

            return null;
        }
    }
}
