using System;
using System.Collections.Generic;
using System.Text;
using TeaseVN.Core;

namespace TeaseVN.Rooms
{
    class DiningRoom : Room
    {
        public DiningRoom(Game1 game) : base(game) { }

        public override NextEvent roomDelegate()
        {
            NextEvent ev = new NextEvent();
            ev.setNext(RoomStorage.DINING_ROOM, NextEvent.ROOM_TYPE);
            return ev;
        }
    }
}
