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
        public List<Dictionary<int, BasicCalendarDate>> SaintsList { get; set; }
        public int DaysInMonth { get; set; }
        public Month(string name, int year, List<BasicCalendarDate> saintsList)
        {
            MonthName = name;
            Year = year;
            SaintsList = new List<Dictionary<int, BasicCalendarDate>>();
            foreach (BasicCalendarDate bcd in saintsList)
            {
                SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { bcd.Priority, bcd } });
            }
            MonthNumber = DateTime.ParseExact(MonthName, "MMMM", CultureInfo.InvariantCulture).Month;
            DaysInMonth = DateTime.DaysInMonth(Year, MonthNumber);
            setFirstWeekDayOfMonth();
            setNumberOfCalendarRows();
        }

        public void AddSpecialFeast(int monthDay, BasicCalendarDate feast, int priority)
        {
            if(!SaintsList[monthDay].ContainsKey(priority)) SaintsList[monthDay].Add(priority, feast);
            else if(!SaintsList[monthDay].ContainsKey(priority + 1)) SaintsList[monthDay].Add(priority + 1, feast);
        }
       
        public bool isFastDay(int day)
        {
            bool returnBool = false;


            //loop through the priority levels
            for (int i = 1; i < 4; i++)
            {
                if (SaintsList[day].ContainsKey(i))
                {
                    returnBool = SaintsList[day][i].IsFastDay;
                    //if the priority level is greater than three, that takes precedence over level three
                    if (i < 3) break;
                }
            }
            return returnBool;
        }

        public bool isAbstinenceDay(int day, int dayOfWeek)
        {
            bool returnBool = false;

            //sundays are never abstinence days
            if (dayOfWeek == 1) return false;

            //loop through the priority levels
            for (int i = 1; i < 4; i++)
            {
                if (SaintsList[day].ContainsKey(i))
                {
                    returnBool = SaintsList[day][i].IsAbstinenceDay;
                    //if the priority level is greater than three, that takes precedence over level three
                    if (i < 3) break;
                    //but if we got to three and its a Friday, should be abstinence
                    else if (dayOfWeek == 6) returnBool = true;
                }
            }
            return returnBool;
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
