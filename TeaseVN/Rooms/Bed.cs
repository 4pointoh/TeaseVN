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
    }
}
