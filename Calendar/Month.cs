using System;
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
        public Dictionary<int, BasicCalendarDate> MovableDays { get; set;}
        public int DaysInMonth { get; set; }
        public Month(string name, int year, List<BasicCalendarDate> saintsList)
        {
            MonthName = name;
            Year = year;
            SaintsList = saintsList;
            MovableDays = new Dictionary<int, BasicCalendarDate>();
            MonthNumber = DateTime.ParseExact(MonthName, "MMMM", CultureInfo.InvariantCulture).Month;
            DaysInMonth = DateTime.DaysInMonth(Year, MonthNumber);
            setFirstWeekDayOfMonth();
            setNumberOfCalendarRows();
        }

        private void setFirstWeekDayOfMonth()
        {
            FirstDay = (int)new DateTime(Year, MonthNumber, 1).DayOfWeek;
        }
        private void setNumberOfCalendarRows()
        {
            numCalendarRows = 4;
            //Console.WriteLine(MonthNumber.ToString() + " " + DaysInMonth.ToString());
            if (DaysInMonth > 28 || FirstDay > 0)
            {
                numCalendarRows++;
            }
            //if ()
            //{
                int leftOver = DaysInMonth - 28;
                if (leftOver - (7 - FirstDay) > 0) numCalendarRows++;
            //}
        }
    }

}
