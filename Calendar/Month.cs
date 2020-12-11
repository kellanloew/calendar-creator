﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    class Month
    {
        public string MonthName { get; set; }
        public int MonthNumber { get; set; }
        public int Year { get; set; }
        public int FirstDay { get; set; }
        public int numCalendarRows { get; set; }
        public List<BasicCalendarDate> SaintsList { get; set; }
        public Month(string name, int year, List<BasicCalendarDate> saintsList)
        {
            MonthName = name;
            Year = year;
            SaintsList = saintsList;
            MonthNumber = DateTime.ParseExact(MonthName, "MMMM", CultureInfo.InvariantCulture).Month;
            setFirstWeekDayOfMonth();
            setNumberOfCalendarRows();
        }

        private void setFirstWeekDayOfMonth()
        {
            FirstDay = (int)new DateTime(Year, 1, MonthNumber).DayOfWeek;
        }
        private void setNumberOfCalendarRows()
        {
            int numDays = DateTime.DaysInMonth(Year, MonthNumber);
            numCalendarRows = 4;
            if (numDays > 28)
            {
                int leftOver = numDays - 28;
                if (FirstDay != 0) numCalendarRows++;
                if (leftOver - 7 + FirstDay > 0) numCalendarRows++;
            }
        }
    }

}
