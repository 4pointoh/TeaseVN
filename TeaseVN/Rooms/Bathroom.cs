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
    }
}
