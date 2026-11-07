using System;

namespace Calendar
{
    /// <summary>
    /// Fast and abstinence under the 1917 Code, per the Catholic Candle chart
    /// (https://catholiccandle.org/2019/12/22/1476/). Independent of liturgical rank.
    ///  - Lent (Ash Wednesday to Holy Saturday): fast every day; abstinence on Ash Wednesday, Fridays and Saturdays.
    ///  - Every Friday: abstinence.
    ///  - Ember days and the vigils of Christmas, Pentecost, the Assumption, All Saints and the
    ///    Immaculate Conception: fast and abstinence (a vigil falling on Sunday is anticipated on Saturday).
    ///  - Never on a Sunday or a holy day of obligation.
    /// </summary>
    static class FastingRules
    {
        public static bool IsFastDay(LiturgicalYear year, DateTime date)
        {
            var day = year[date];
            if (IsExempt(day)) return false;
            return year.IsInLent(date) || day.IsEmberDay || day.IsFastingVigil;
        }

        public static bool IsAbstinenceDay(LiturgicalYear year, DateTime date)
        {
            var day = year[date];
            if (IsExempt(day)) return false;
            return date.DayOfWeek == DayOfWeek.Friday
                || date == year.AshWednesday
                || (year.IsInLent(date) && date.DayOfWeek == DayOfWeek.Saturday)
                || day.IsEmberDay
                || day.IsFastingVigil;
        }

        private static bool IsExempt(LiturgicalDay day)
            => day.Date.DayOfWeek == DayOfWeek.Sunday || day.IsHolyDayOfObligation;
    }
}
