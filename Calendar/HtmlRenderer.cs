using System;
using System.Globalization;
using System.Text;

namespace Calendar
{
    /// <summary>Renders a <see cref="LiturgicalYear"/> as one printable HTML table per month.</summary>
    static class HtmlRenderer
    {
        private const string Head = "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width = device-width, initial-scale=1\"><style>p{margin:0;}.special{font-weight:bold;} table {font-family: \"Century Schoolbook L\", \"Century Schoolbook\", serif; font-size: 10px; border-collapse:collapse; text-align: right; vertical-align: bottom; break-before: page; page-break-before: always;}tr.h {text-align:center;}tr.h, tr.nos {font-size: 1.5rem;}tr.nos td {border-top: 1px solid black; vertical-align: top;} *{font - size: 1em!important;line - height: 1!important;} tr.ss td, tr.nos td {border-left: 1px solid black; border-right: 1px solid black; height: 7.3vh; width: 14vw;}tr.ss {border-bottom: 1px solid black; vertical-align: bottom;}tr.wd {}</style></head><body><table style=\"break-before: page-avoid; page-break-before: avoid;\">";
        private const string Footer = "<p style='font-size: 10px;'>NB (1): We need to do much penance in order to save our souls.  Catholic Candle’s calendar uses the pre-Vatican II rules for fasting and abstinence which are found here: https://catholiccandle.org/2019/12/22/1476/</p><p style='font-size: 10px;'>NB (2): On a date on which two or more feasts are mentioned, the Mass is of the first feast, and the other(s) are only commemorations.</p>";
        private const string WeekdayHeader = "<tr class='wd'><td>Sunday</td><td>Monday</td><td>Tuesday</td><td>Wednesday</td><td>Thursday</td><td>Friday</td><td>Saturday</td></tr>";
        private const string FastSymbol = "&#x1F37D;";
        private const string AbstinenceSymbol = "&#x1f41f;&#xfe0e;";

        public static string Render(LiturgicalYear year)
        {
            var html = new StringBuilder(Head);
            for (int month = 1; month <= 12; month++) RenderMonth(html, year, month);
            html.Append("</body></html>");
            return html.ToString();
        }

        private static void RenderMonth(StringBuilder html, LiturgicalYear year, int month)
        {
            string monthName = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            int firstWeekday = (int)new DateTime(year.Year, month, 1).DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(year.Year, month);
            int weeks = (firstWeekday + daysInMonth + 6) / 7;

            html.Append("<table><tr class='h'><tr class='h'><td colspan='7'>" + monthName + " " + year.Year + "</td></tr>");
            html.Append(WeekdayHeader);
            html.Append("<tr class='nos'></tr>");

            for (int week = 0; week < weeks; week++)
            {
                // Day numbers, with fast and abstinence symbols
                html.Append("<tr class='nos'>");
                for (int weekday = 0; weekday < 7; weekday++)
                {
                    int dayNumber = week * 7 + weekday - firstWeekday + 1;
                    html.Append("<td>");
                    if (dayNumber >= 1 && dayNumber <= daysInMonth)
                    {
                        var date = new DateTime(year.Year, month, dayNumber);
                        if (FastingRules.IsFastDay(year, date)) html.Append(FastSymbol);
                        if (FastingRules.IsAbstinenceDay(year, date)) html.Append(AbstinenceSymbol);
                        html.Append(dayNumber);
                    }
                    html.Append("</td>");
                }
                html.Append("</tr>");

                // Feasts
                html.Append("<tr class='ss'>");
                for (int weekday = 0; weekday < 7; weekday++)
                {
                    int dayNumber = week * 7 + weekday - firstWeekday + 1;
                    html.Append("<td>");
                    if (dayNumber >= 1 && dayNumber <= daysInMonth)
                    {
                        var day = year[new DateTime(year.Year, month, dayNumber)];
                        if (weekday != 0)
                        {
                            foreach (var label in day.Labels) html.Append("<p class='special'>" + label + "</p>");
                        }
                        html.Append(string.Join("; ", day.Titles));
                    }
                    html.Append("</td>");
                }
                html.Append("</tr>");
            }

            html.Append("</table>");
            html.Append(Footer);
        }
    }
}
