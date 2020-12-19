using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Calendar
{
    class CalendarData
    {
        public List<Month> AllDates;
        public int Year;
        public string HTML = "";
        public DateTime Easter;
        public CalendarData(int year)
        {
            Year = year;
            SetEasterSunday();
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
                    new BasicCalendarDate(5, "Vigil / S Telesphorus PM"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "com S Hyginus PM"),
                    new BasicCalendarDate(12),
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

        public string GetSundayFromMonthAndDay(int month, int day)
        {
            
            DateTime inputDate = new DateTime(Year, month, day);
            string sundayName = "";


            //This is a sunday before Easter
            if (DateTime.Compare(inputDate, Easter) < 0)
            {
                int weeksDiffBeforeEaster = WeeksDifferenceBetweenDates(inputDate, Easter);
                
                if(weeksDiffBeforeEaster < 10)
                {
                    switch (weeksDiffBeforeEaster)
                    {
                        case 1:
                            sundayName = "Palm Sunday";
                            break;
                        case 2:
                            sundayName = "Passion Sunday";
                            break;
                        case 3:
                            sundayName = "4th Sunday of Lent";
                            break;
                        case 4:
                            sundayName = "3rd Sunday of Lent";
                            break;
                        case 5:
                            sundayName = "2nd Sunday of Lent";
                            break;
                        case 6:
                            sundayName = "1st Sunday of Lent";
                            break;
                        case 7:
                            sundayName = "Quinquagesima Sunday";
                            break;
                        case 8:
                            sundayName = "Sexagesima Sunday";
                            break;
                        case 9:
                            sundayName = "Septuagesima Sunday";
                            break;
                    }
                }
                else
                {
                    if(day > 1 && day < 6 && month == 1)
                    {
                        sundayName = "Holy Name of Jesus";
                    }
                    else
                    {
                        int weeksDiffEpiphany = WeeksDifferenceBetweenDates(new DateTime(Year, 1, 6), inputDate, true);
                       switch (weeksDiffEpiphany)
                        {
                            case 1:
                                sundayName = "Holy Family / 1st Sunday after Epiphany";
                                break;
                            case 2:
                                sundayName = "2nd Sunday after Epiphany";
                                break;
                            case 3:
                                sundayName = "3rd Sunday after Epiphany";
                                break;
                            case 4:
                                sundayName = "4th Sunday after Epiphany";
                                break;
                            case 5:
                                sundayName = "5th Sunday after Epiphany";
                                break;
                            case 6:
                                sundayName = "6th Sunday after Epiphany";
                                break;
                        }
                    }
                }
               
            }
            //this is a sunday after Easter
            else
            {
                int weeksDiffAfterEaster = WeeksDifferenceBetweenDates(inputDate, Easter);
                switch (weeksDiffAfterEaster)
                {
                    case 1:
                        sundayName = "Low Sunday";
                        break;
                    case 2:
                        sundayName = "2nd Sunday after Easter";
                        break;
                    case 3:
                        sundayName = "3rd Sunday after Easter";
                        break;
                    case 4:
                        sundayName = "4th Sunday after Easter";
                        break;
                    case 5:
                        sundayName = "5th Sunday after Easter";
                        break;
                    case 6:
                        sundayName = "Sunday within Octave Ascension";
                        break;
                    case 7:
                        sundayName = "Pentecost";
                        break;
                    case 8:
                        sundayName = "Trinity Sunday";
                        break;
                    case 9:
                        sundayName = "2nd Sunday after Pentecost";
                        break;
                    case 10:
                        sundayName = "3rd Sunday after Pentecost";
                        break;
                    case 11:
                        sundayName = "4th Sunday after Pentecost";
                        break;
                    case 12:
                        sundayName = "5th Sunday after Pentecost";
                        break;
                    case 13:
                        sundayName = "6th Sunday after Pentecost";
                        break;
                    case 14:
                        sundayName = "7th Sunday after Pentecost";
                        break;
                    case 15:
                        sundayName = "8th Sunday after Pentecost";
                        break;
                    case 16:
                        sundayName = "9th Sunday after Pentecost";
                        break;
                    case 17:
                        sundayName = "10th Sunday after Pentecost";
                        break;
                    case 18:
                        sundayName = "11th Sunday after Pentecost";
                        break;
                    case 19:
                        sundayName = "12th Sunday after Pentecost";
                        break;
                    case 20:
                        sundayName = "13th Sunday after Pentecost";
                        break;
                    case 21:
                        sundayName = "14th Sunday after Pentecost";
                        break;
                    case 22:
                        sundayName = "15th Sunday after Pentecost";
                        break;
                    case 23:
                        sundayName = "16th Sunday after Pentecost";
                        break;
                    case 24:
                        sundayName = "17th Sunday after Pentecost";
                        break;
                    case 25:
                        sundayName = "18th Sunday after Pentecost";
                        break;
                    case 26:
                        sundayName = "19th Sunday after Pentecost";
                        break;
                    case 27:
                        sundayName = "20th Sunday after Pentecost";
                        break;
                    case 28:
                        sundayName = "21st Sunday after Pentecost";
                        break;
                }
            }


            return sundayName;
        }

        public string ReturnPreHTML()
        {
            return "<!DOCTYPE html><html><head><meta http-equiv=\"content - type\" content=\"text / html; charset = utf - 8\"><meta name=\"viewport\" content=\"width = device - width, initial - scale = 1\"><style>table {font-family: \"Century Schoolbook L\", \"Century Schoolbook\", serif; font-size: 10px; border-collapse:collapse; text-align: right; vertical-align: bottom; break-before: page; page-break-before: always;}tr.h {text-align:center;}tr.h, tr.nos {font-size: 2rem;}tr.nos td {border-top: 1px solid black; vertical-align: top;}tr.ss td, tr.nos td {border-left: 1px solid black; border-right: 1px solid black; height: 6.4vh; width: 14vw;}tr.ss {border-bottom: 1px solid black; vertical-align: bottom;}tr.wd {}</style></head><body><table style=\"break-before: page-avoid; page-break-before: avoid;\">";
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
                            if (i == 1)
                            {
                                HTML += GetSundayFromMonthAndDay(m.MonthNumber, monthDay + 1);
                            }
                            HTML += " " + m.SaintsList[monthDay].Saint;
                        }
                        HTML += "</td>";
                        currentBlockSaints++;
                    }
                    HTML += "</tr>";
                }
                HTML += "</table>";
            }

        }

        private void SetEasterSunday()
        {
            int day = 0;
            int month = 0;

            int g = Year % 19;
            int c = Year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((Year + (int)(Year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31)
            {
                month++;
                day -= 31;
            }

            Easter = new DateTime(Year, month, day);
        }
    
        private int WeeksDifferenceBetweenDates(DateTime earlier, DateTime later, bool roundUp = false)
        {
            double diff = (later - earlier).TotalDays;
            diff = diff / 7;
            if (roundUp)
            {
                diff = Math.Ceiling(diff);
            }
            return Convert.ToInt32(diff);
        }
    }

}
