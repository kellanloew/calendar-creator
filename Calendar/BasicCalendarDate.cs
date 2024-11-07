using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    class BasicCalendarDate
    {
        public int Date { get; set; }
        public string Title { get; set; }
        public string PreTitle { get; set; }
        public bool IsHolyDay { get; set; }
        public bool IsFastDay { get; set; }
        public bool IsAbstinenceDay { get; set; }
        public int Priority { get; set; }
        public string DayOfWeek { get; set; }

        public BasicCalendarDate(int date, string title = "", int priority = 4, bool isHolyDay = false, bool isFast = false, bool isAbstinence = false, string preTitle = "")
        {
            Date = date;
            Title = title;
            IsHolyDay = isHolyDay;
            PreTitle = preTitle;
            Priority = priority;
            if (IsHolyDay)
            {
                isFast = false;
                isAbstinence = false;
                PreTitle = "Holy Day of Obligation";
                priority = 1;
            }
            IsFastDay = isFast;
            IsAbstinenceDay = isAbstinence;
        }
    }
}
