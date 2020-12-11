using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    class CalendarData
    {
        public List<Month> AllDates;
        public int Year;
        public string HTML = "";
        public CalendarData(int year)
        {
            Year = year;
        }
        public string CreateSaintDays()
        {
            AllDates = new List<Month>() { };

            //January saints
            AllDates.Add(new Month(
                "January",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "Circumcision of the Lord", true),
                    new BasicCalendarDate(2),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "Holy Name of Jesus d2 / Vigil / S Telesphorus PM"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "com S Hyginus PM"),
                    new BasicCalendarDate(12, "Holy Family gd"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "S Hilary BCD d / S Felix PrM"),
                    new BasicCalendarDate(15, "S Paul C d / S Maurus Ab"),
                    new BasicCalendarDate(16, "S Marcellus PM sd"),
                    new BasicCalendarDate(17, "S Antony Ab d"),
                    new BasicCalendarDate(18, "Chair of S Peter Ap at Rome gd / S Paul Ap / S Prisca VM"),
                    new BasicCalendarDate(19, "SS Marius &c MM s / S Canute KM"),
                    new BasicCalendarDate(20, "SS Fabianus PM & Sebastian M d"),
                    new BasicCalendarDate(21, "S Agnes VM d"),
                    new BasicCalendarDate(22, "SS Vincent & Anastasius MM sd"),
                    new BasicCalendarDate(23, "S Raymund of Peñafort C sd / S Emerentiana VM"),
                    new BasicCalendarDate(24, "S Timothy BM d"),
                    new BasicCalendarDate(25, "Conversion of S Paul Ap gd / S Peter Ap"),
                    new BasicCalendarDate(26, "S Polycarp BM d"),
                    new BasicCalendarDate(27, "S John Chrysostom BCD d"),
                    new BasicCalendarDate(28, "S Peter Nolasco C d"),
                    new BasicCalendarDate(29, "S Francis of Sales BCD d"),
                    new BasicCalendarDate(30, "S Martina VM sd"),
                    new BasicCalendarDate(30, "S John Bosco C d")
                }
            ));
            CreateHtmlFromSaintData();
            return HTML;
        }

        private void CreateHtmlFromSaintData()
        {
            foreach (Month m in AllDates)
            {
                HTML += "<table><tr class='h'><tr class='h'><td colspan='7'>" + m.MonthName + " " + m.Year.ToString() +
                "</td></tr><tr class='wd'><td>Sunday</td><td>Monday</td><td>Tuesday</td><td>Wednesday</td><td>Thursday</td><td>Friday</td><td>Saturday</td></tr><tr class='nos'>";

                HTML += "</tr>";

                int currentBlockSaints = 1;
                int currentBlockNumbers = 1;
                for (int j = 1; j <= m.numCalendarRows; j++)
                {
                    HTML += "<tr class='nos'>";
                    for (int i = 1; i <= 7; i++)
                    {
                        int monthDay = currentBlockNumbers - m.FirstDay;
                        HTML += "<td>";
                        if (currentBlockNumbers >= m.FirstDay + 1 && monthDay <= m.SaintsList.Count)
                        {
                            if ((currentBlockNumbers + 1) % 7 == 0) HTML += "&#x1f41f;&#xfe0e;";
                            HTML += monthDay.ToString();
                        }
                        HTML += "</td>";
                        currentBlockNumbers++;
                    }
                    HTML += "</tr>";

                    HTML += "<tr class='ss'>";
                    for (int i = 1; i <= 7; i++)
                    {
                        int monthDay = currentBlockSaints - m.FirstDay - 1;
                        HTML += "<td>";
                        if (currentBlockSaints >= m.FirstDay + 1 && monthDay < m.SaintsList.Count)
                        {
                            HTML += m.SaintsList[monthDay].Saint;
                        }
                        HTML += "</td>";
                        currentBlockSaints++;
                    }
                    HTML += "</tr>";
                }
                HTML += "</table>";
            }

        }
    }

}
