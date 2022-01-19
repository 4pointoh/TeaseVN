using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    class TimeManager
    {
        int MAX_TIME = 24; // 8 = 8am 
        int MAX_DAY = 7; // 1 = Sun, 7 = Sat
        public int day { get; set; }
        public int hour { get; set; }

        public bool progressHour(int hoursToAdd)
        {
            if(hoursToAdd + hour > MAX_TIME)
            {
                return false;
            }
            else
            {
                hour += hoursToAdd;
                return true;
            }
        }

        public void nextDay()
        {
            if(day == MAX_DAY)
            {
                day = 1;
            }
            else
            {
                day++;
            }
            hour = 8;
        }
    }
}
