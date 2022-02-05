using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    class NextEvent
    {
        public String nextId;
        public bool nextEventIsRoom;
        public bool nextEventIsScene;
        public static String ROOM_TYPE = "Room";
        public static String SCENE_TYPE = "Scene";

        public void setNext(String id, String type)
        {
            if(type == ROOM_TYPE)
            {
                nextEventIsRoom = true;
                nextEventIsScene = false;
                this.nextId = id;
            }else if(type == SCENE_TYPE)
            {
                nextEventIsRoom = false;
                nextEventIsScene = true;
                this.nextId = id;
            }
        }
    }
}
