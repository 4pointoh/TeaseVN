using Microsoft.Xna.Framework;
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
        public List<Clickable> currentTravelOptions { get; set; }
        public ContentManager Content { get; set; }

        public Game1 game;

        public RoomManager(Game1 game, Room startingRoom)
        {
            this.game = game;
            this.Content = game.Content;
            this.currentRoom = startingRoom;
            this.currentTravelOptions = new List<Clickable>();
            this.setCurrentTravelOptions();
        }

        public void setCurrentRoom(Room room)
        {
            room.refreshRoom();
            this.currentRoom = room;
        }

        public void refreshCurrentRoom()
        {
            this.currentRoom.refreshRoom();
        }

        public Texture2D getCurrentBackground()
        {
            return currentRoom.backgroundTexture;
        }

        public List<Clickable> getCurrentRoomClickables()
        {
            List<Clickable> allClickables = new List<Clickable>();
            allClickables.AddRange(this.currentRoom.getClickableItems());
            allClickables.AddRange(this.getCurrentTravelOptions());
            return allClickables;
        }

        public void processHoveredClickables(MouseState mouseState)
        {
            foreach (Clickable item in this.getCurrentRoomClickables())
            {
                if (UiManager.clickableIsHovered(mouseState, item))
                {
                    this.game.uiManager.enablePointerCursor();
                    return;
                }
            }

            this.game.uiManager.disablePointerCursor();
        }

        public NextEvent processClickedClickables(MouseState mouseState)
        {
            foreach (Clickable item in this.getCurrentRoomClickables())
            {
                if (UiManager.clickableIsHovered(mouseState, item))
                {
                    return item.processClick();
                }
            }

            return null;
        }

        public List<Clickable> getCurrentTravelOptions()
        {
            return this.currentTravelOptions;
        }

        private void setCurrentTravelOptions()
        {
            var roomById = game.roomStorage.roomById;

            Rectangle gameBounds = game.GraphicsDevice.Viewport.Bounds;

            int iconHeight = 70;
            int iconWidth = 70;
            int iconDistanceFromBottom = 80;
            int iconDistanceFromLeft = 50;
            int iconHorizontalSpacing = 80;

            foreach (Room room in roomById.Values)
            {
                Clickable roomClickable = new Clickable();
                Rectangle rect = new Rectangle();
                rect.X = iconDistanceFromLeft;
                rect.Y = gameBounds.Height - iconDistanceFromBottom;
                rect.Width = iconWidth;
                rect.Height = iconHeight;
                roomClickable.clickableArea = rect;
                roomClickable.texture = room.icon;
                roomClickable.id = room.id;
                roomClickable.processClick = room.roomDelegate;
                iconDistanceFromLeft += iconHorizontalSpacing;
                this.currentTravelOptions.Add(roomClickable);
            }
        }
    }
}
