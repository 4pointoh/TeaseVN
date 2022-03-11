using System;
using System.Collections.Generic;
using System.Text;

namespace TeaseVN.Core
{
    public class TimeManager
    {
        public int day = 1;
        public int hour = 8;
        public String dayOfWeek = "Saturday";

        public DateTime time = new System.DateTime(2000, 1, 1, 8, 0, 0, 0);

        public void progressHour(int hoursToAdd)
        {
            int previousDay = time.Day;
            time = time.AddHours(hoursToAdd);
            int nextDay = time.Day;

            if(previousDay != nextDay)
            {
                day++;
            }
            dayOfWeek = time.DayOfWeek.ToString();
            hour = time.Hour;
        }
    }
}
