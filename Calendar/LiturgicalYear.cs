using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    /// <summary>
    /// Every celebration of one civil year under the pre-1955 rubrics, with occurrence and
    /// transfers resolved. The ranking rules are documented on <see cref="PrecedenceLevel"/>.
    /// </summary>
    class LiturgicalYear
    {
        public int Year { get; }
        public DateTime Easter { get; }
        public DateTime AshWednesday => Easter.AddDays(-46);
        public DateTime FirstSundayOfAdvent { get; }

        private readonly Dictionary<DateTime, List<Celebration>> occurring = new Dictionary<DateTime, List<Celebration>>();
        private readonly Dictionary<DateTime, LiturgicalDay> days = new Dictionary<DateTime, LiturgicalDay>();
        private readonly HashSet<DateTime> emberDays = new HashSet<DateTime>();
        private readonly HashSet<DateTime> fastingVigils = new HashSet<DateTime>();

        public LiturgicalYear(int year)
        {
            Year = year;
            Easter = ComputeEaster(year);
            FirstSundayOfAdvent = ComputeFirstSundayOfAdvent(year);

            AddSanctoral();
            AddEmberDays(); // before the ferias of Lent and Advent, which skip ember days
            AddSundays();
            AddTemporal();
            AddOctaves();
            AddVigils();
            ResolveOccurrence();
        }

        public LiturgicalDay this[DateTime date] => days[date.Date];

        public bool IsInLent(DateTime date) => date >= AshWednesday && date < Easter;

        private void Add(DateTime date, Celebration celebration)
        {
            if (date.Year != Year) return;
            if (!occurring.TryGetValue(date, out var list))
            {
                list = new List<Celebration>();
                occurring[date] = list;
            }
            list.Add(celebration);
        }

        private void AddSanctoral()
        {
            bool leapYear = DateTime.IsLeapYear(Year);
            foreach (var feast in Sanctoral.Feasts)
            {
                int day = leapYear && feast.Month == 2 && feast.Day >= 24 ? feast.Day + 1 : feast.Day;
                Add(new DateTime(Year, feast.Month, day), feast.Celebration);
            }
        }

        private void AddEmberDays()
        {
            // September: the Wednesday after the Exaltation of the Holy Cross (Sept 14).
            var september = new DateTime(Year, 9, 15);
            while (september.DayOfWeek != DayOfWeek.Wednesday) september = september.AddDays(1);

            var wednesdays = new[]
            {
                Easter.AddDays(-39),              // after the 1st Sunday of Lent
                Easter.AddDays(52),               // after Pentecost
                september,
                FirstSundayOfAdvent.AddDays(17),  // after the 3rd Sunday of Advent
            };
            foreach (var wednesday in wednesdays)
            {
                AddEmberDay(wednesday, "Ember Wednesday");
                AddEmberDay(wednesday.AddDays(2), "Ember Friday");
                AddEmberDay(wednesday.AddDays(3), "Ember Saturday");
            }
        }

        private void AddEmberDay(DateTime date, string name)
        {
            Add(date, Celebration.Feria("", PrecedenceLevel.GreaterFeria, label: name));
            emberDays.Add(date);
        }

        private void AddSundays()
        {
            var sunday = new DateTime(Year, 1, 1);
            while (sunday.DayOfWeek != DayOfWeek.Sunday) sunday = sunday.AddDays(1);
            for (; sunday.Year == Year; sunday = sunday.AddDays(7))
            {
                var celebration = SundayCelebration(sunday);
                if (celebration != null) Add(sunday, celebration);
            }

            // The Sunday within the Octave of Christmas is kept on Dec 29-31 if one is a Sunday, otherwise on Dec 30.
            bool sundayInDec29To31 = Enumerable.Range(29, 3).Any(day => new DateTime(Year, 12, day).DayOfWeek == DayOfWeek.Sunday);
            if (!sundayInDec29To31)
                Add(new DateTime(Year, 12, 30), Celebration.Sunday("Sunday within the Octave of Christmas", PrecedenceLevel.MinorSunday));
        }

        private Celebration SundayCelebration(DateTime date)
        {
            if (date < Easter)
            {
                int weeksBeforeEaster = (Easter - date).Days / 7;
                switch (weeksBeforeEaster)
                {
                    case 1: return Celebration.Sunday("Palm Sunday", PrecedenceLevel.FirstClassDay);
                    case 2: return Celebration.Sunday("Passion Sunday", PrecedenceLevel.FirstClassDay);
                    case 3: return Celebration.Sunday("4th Sunday of Lent", PrecedenceLevel.FirstClassDay);
                    case 4: return Celebration.Sunday("3rd Sunday of Lent", PrecedenceLevel.FirstClassDay);
                    case 5: return Celebration.Sunday("2nd Sunday of Lent", PrecedenceLevel.FirstClassDay);
                    case 6: return Celebration.Sunday("1st Sunday of Lent", PrecedenceLevel.FirstClassDay);
                    case 7: return Celebration.Sunday("Quinquagesima Sunday", PrecedenceLevel.SundaySecondClass);
                    case 8: return Celebration.Sunday("Sexagesima Sunday", PrecedenceLevel.SundaySecondClass);
                    case 9: return Celebration.Sunday("Septuagesima Sunday", PrecedenceLevel.SundaySecondClass);
                }

                // Holy Name: the Sunday between Jan 2 and 5 (otherwise Jan 2, see AddTemporal).
                if (date.Month == 1 && date.Day >= 2 && date.Day <= 5)
                    return Celebration.Feast("Holy Name of Jesus", Rank.DoubleSecondClass, Dignity.Lord);

                int weeksAfterEpiphany = (int)Math.Ceiling((date - new DateTime(Year, 1, 6)).TotalDays / 7);
                if (weeksAfterEpiphany == 1)
                    return Celebration.Sunday("Holy Family / 1st Sunday after Epiphany", PrecedenceLevel.HolyFamily);
                if (weeksAfterEpiphany >= 2)
                    return Celebration.Sunday(Ordinal(weeksAfterEpiphany) + " Sunday after Epiphany", PrecedenceLevel.MinorSunday);
                return null; // Jan 1
            }

            if (date == Easter)
                return Celebration.Sunday("EASTER SUNDAY", PrecedenceLevel.EasterAndPentecost, Exclusion.All);

            if (date < FirstSundayOfAdvent)
            {
                int weeksAfterEaster = (date - Easter).Days / 7;
                switch (weeksAfterEaster)
                {
                    case 1: return Celebration.Sunday("Low Sunday", PrecedenceLevel.FirstClassDay);
                    case 6: return Celebration.Sunday("Sunday within Octave Ascension", PrecedenceLevel.MinorSunday);
                    case 7: return Celebration.Sunday("PENTECOST", PrecedenceLevel.EasterAndPentecost, Exclusion.All);
                    case 8: return Celebration.Sunday("Trinity Sunday", PrecedenceLevel.FirstClassDay);
                }
                if (weeksAfterEaster < 6)
                    return Celebration.Sunday(Ordinal(weeksAfterEaster) + " Sunday after Easter", PrecedenceLevel.MinorSunday);
                return Celebration.Sunday(Ordinal(weeksAfterEaster - 7) + " Sunday after Pentecost", PrecedenceLevel.MinorSunday);
            }

            switch ((date - FirstSundayOfAdvent).Days / 7)
            {
                case 0: return Celebration.Sunday("First Sunday of Advent", PrecedenceLevel.FirstClassDay);
                case 1: return Celebration.Sunday("Second Sunday of Advent", PrecedenceLevel.SundaySecondClass);
                case 2: return Celebration.Sunday("Gaudete Sunday", PrecedenceLevel.SundaySecondClass);
                case 3: return Celebration.Sunday("Fourth Sunday of Advent", PrecedenceLevel.SundaySecondClass);
            }

            // Dec 25-31. On Dec 26-28 the feast is kept and this Sunday's Mass moves to Dec 30 (see AddSundays).
            if (date.Day >= 29)
                return Celebration.Sunday("Sunday within the Octave of Christmas", PrecedenceLevel.MinorSunday);
            return null;
        }

        private void AddTemporal()
        {
            bool holyNameOnSunday = Enumerable.Range(2, 4).Any(day => new DateTime(Year, 1, day).DayOfWeek == DayOfWeek.Sunday);
            if (!holyNameOnSunday)
                Add(new DateTime(Year, 1, 2), Celebration.Feast("Holy Name of Jesus", Rank.DoubleSecondClass, Dignity.Lord));

            // Lent and Passiontide
            Add(AshWednesday, Celebration.Feria("ASH WEDNESDAY", PrecedenceLevel.FirstClassDay));
            var palmSunday = Easter.AddDays(-7);
            for (var date = AshWednesday.AddDays(1); date < palmSunday; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && !emberDays.Contains(date))
                    Add(date, Celebration.Feria("", PrecedenceLevel.GreaterFeria));
            }
            Add(Easter.AddDays(-9), Celebration.Feast("Our Lady of Sorrows", Rank.GreaterDouble, Dignity.BlessedVirgin)); // Friday after Passion Sunday

            // Holy Week
            Add(Easter.AddDays(-6), Celebration.Feria("Monday of Holy Week", PrecedenceLevel.FirstClassDay));
            Add(Easter.AddDays(-5), Celebration.Feria("Tuesday of Holy Week", PrecedenceLevel.FirstClassDay));
            Add(Easter.AddDays(-4), Celebration.Feria("Wednesday of Holy Week", PrecedenceLevel.FirstClassDay));
            Add(Easter.AddDays(-3), Celebration.Feria("HOLY THURSDAY", PrecedenceLevel.Triduum, Exclusion.All));
            Add(Easter.AddDays(-2), Celebration.Feria("GOOD FRIDAY", PrecedenceLevel.Triduum, Exclusion.All));
            Add(Easter.AddDays(-1), Celebration.Feria("HOLY SATURDAY", PrecedenceLevel.Triduum, Exclusion.All));

            // Paschaltide
            Add(Easter.AddDays(17), Celebration.Feast("St. Joseph Husband of the Blessed Virgin Mary, Confessor", Rank.DoubleFirstClass, Dignity.Joseph));
            const int withOctave = PrecedenceLevel.FirstClassWithPrivilegedOctave;
            Add(Easter.AddDays(39), Celebration.Feast("ASCENSION DAY", Rank.DoubleFirstClass, Dignity.Lord, holyDayOfObligation: true, precedence: withOctave));
            Add(Easter.AddDays(60), Celebration.Feast("Corpus Christi", Rank.DoubleFirstClass, Dignity.Lord, precedence: withOctave));
            Add(Easter.AddDays(68), Celebration.Feast("Sacred Heart of Jesus", Rank.DoubleFirstClass, Dignity.Lord, precedence: withOctave));

            // Christ the King: last Sunday of October
            var christTheKing = new DateTime(Year, 10, 31);
            while (christTheKing.DayOfWeek != DayOfWeek.Sunday) christTheKing = christTheKing.AddDays(-1);
            Add(christTheKing, Celebration.Feast("Christ The King", Rank.DoubleFirstClass, Dignity.Lord));

            // All Souls: moved to Monday if Nov 2 is a Sunday
            var allSouls = new DateTime(Year, 11, 2);
            if (allSouls.DayOfWeek == DayOfWeek.Sunday) allSouls = allSouls.AddDays(1);
            Add(allSouls, Celebration.Feast("ALL SOULS", Rank.Double, precedence: PrecedenceLevel.AllSouls));

            // Advent weekdays (Christmas Eve is a vigil)
            var christmasEve = new DateTime(Year, 12, 24);
            for (var date = FirstSundayOfAdvent.AddDays(1); date < christmasEve; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && !emberDays.Contains(date))
                    Add(date, Celebration.Feria("", PrecedenceLevel.AdventFeria));
            }
        }

        private void AddOctaves()
        {
            AddPrivilegedFirstOrderOctave(Easter, "Easter");
            AddPrivilegedFirstOrderOctave(Easter.AddDays(49), "Pentecost");

            AddOctave(new DateTime(Year, 1, 6), "the Epiphany", PrecedenceLevel.PrivilegedOctaveSecondOrder, PrecedenceLevel.PrivilegedOctaveSecondOrder);
            AddOctave(Easter.AddDays(60), "Corpus Christi", PrecedenceLevel.PrivilegedOctaveSecondOrder, PrecedenceLevel.PrivilegedOctaveSecondOrder);

            AddOctave(Easter.AddDays(17), "the Solemnity of St. Joseph");
            AddOctave(Easter.AddDays(39), "the Ascension");
            AddOctave(Easter.AddDays(68), "the Sacred Heart");
            AddOctave(new DateTime(Year, 6, 24), "St. John the Baptist");
            AddOctave(new DateTime(Year, 6, 29), "Sts. Peter & Paul");
            AddOctave(new DateTime(Year, 8, 15), "the Assumption");
            AddOctave(new DateTime(Year, 11, 1), "All Saints");
            AddOctave(new DateTime(Year, 12, 8), "the Immaculate Conception");
            AddOctave(new DateTime(Year, 12, 25), "Christmas");
        }

        /// <summary>Easter and Pentecost weeks: no feast is kept, and none is even commemorated until Wednesday.</summary>
        private void AddPrivilegedFirstOrderOctave(DateTime sunday, string name)
        {
            for (int i = 1; i <= 6; i++)
            {
                var excludes = i <= 2 ? Exclusion.LesserFeasts : Exclusion.None;
                Add(sunday.AddDays(i), Celebration.Octave("Within the Octave of " + name, PrecedenceLevel.FirstClassDay, excludes));
            }
        }

        /// <summary>Days within the octave (skipping Sundays, which have their own Mass) and the octave day itself.</summary>
        private void AddOctave(DateTime feast, string name,
            int withinPrecedence = PrecedenceLevel.CommonOctave, int octaveDayPrecedence = PrecedenceLevel.GreaterDouble)
        {
            for (int i = 1; i <= 6; i++)
            {
                var date = feast.AddDays(i);
                if (date.DayOfWeek != DayOfWeek.Sunday)
                    Add(date, Celebration.Octave("Within the Octave of " + name, withinPrecedence));
            }
            Add(feast.AddDays(7), Celebration.Octave("Octave day of " + name, octaveDayPrecedence));
        }

        private void AddVigils()
        {
            var stMatthias = new DateTime(Year, 2, DateTime.IsLeapYear(Year) ? 25 : 24);

            AddVigil(new DateTime(Year, 1, 5), "Vigil of the Epiphany", PrecedenceLevel.VigilOfEpiphany, anticipate: false);
            AddVigil(stMatthias.AddDays(-1), "Vigil of St. Matthias");
            AddVigil(Easter.AddDays(38), "Vigil of the Ascension");
            AddVigil(Easter.AddDays(48), "Vigil of Pentecost", PrecedenceLevel.FirstClassDay, fasting: true);
            AddVigil(new DateTime(Year, 6, 23), "Vigil of St. John the Baptist");
            AddVigil(new DateTime(Year, 6, 28), "Vigil of Sts. Peter & Paul");
            AddVigil(new DateTime(Year, 7, 24), "Vigil of St. James");
            AddVigil(new DateTime(Year, 8, 9), "Vigil of St. Lawrence");
            AddVigil(new DateTime(Year, 8, 14), "Vigil of the Assumption", fasting: true);
            AddVigil(new DateTime(Year, 8, 23), "Vigil of St. Bartholomew");
            AddVigil(new DateTime(Year, 9, 20), "Vigil of St. Matthew the Apostle");
            AddVigil(new DateTime(Year, 10, 27), "Vigil of Sts. Simon & Jude");
            AddVigil(new DateTime(Year, 10, 31), "Vigil of All Saints", fasting: true);
            AddVigil(new DateTime(Year, 11, 29), "Vigil of St. Andrew");
            AddVigil(new DateTime(Year, 12, 7), "Vigil of the Immaculate Conception", fasting: true);
            AddVigil(new DateTime(Year, 12, 20), "Vigil of St. Thomas the Apostle");
            // Christmas Eve takes precedence over the 4th Sunday of Advent rather than being anticipated.
            AddVigil(new DateTime(Year, 12, 24), "CHRISTMAS EVE", PrecedenceLevel.FirstClassDay, fasting: true, anticipate: false);
        }

        /// <summary>A vigil falling on a Sunday is anticipated on Saturday, together with its fast.</summary>
        private void AddVigil(DateTime date, string title, int precedence = PrecedenceLevel.CommonVigil,
            bool fasting = false, bool anticipate = true)
        {
            if (anticipate && date.DayOfWeek == DayOfWeek.Sunday) date = date.AddDays(-1);
            Add(date, Celebration.Vigil(title, precedence));
            if (fasting) fastingVigils.Add(date);
        }

        /// <summary>
        /// Picks the Mass of each day, keeps the rest as commemorations, and carries impeded
        /// Doubles of the I and II class forward to the next day that can take them.
        /// </summary>
        private void ResolveOccurrence()
        {
            var transferred = new List<Celebration>(); // in the order they were impeded

            for (var date = new DateTime(Year, 1, 1); date.Year == Year; date = date.AddDays(1))
            {
                var candidates = occurring.TryGetValue(date, out var list) ? ByPrecedence(list) : new List<Celebration>();

                // A transferred feast takes the first day not occupied by a Double of the I or II class
                // (or by anything that outranks one), one feast per day.
                if (transferred.Count > 0 && (candidates.Count == 0 || candidates[0].Precedence < PrecedenceLevel.DoubleSecondClass))
                {
                    var next = ByPrecedence(transferred)[0];
                    transferred.Remove(next);
                    candidates = ByPrecedence(candidates.Append(next));
                }

                var kept = new List<Celebration>();
                if (candidates.Count > 0)
                {
                    var principal = candidates[0];
                    kept.Add(principal);
                    foreach (var other in candidates.Skip(1))
                    {
                        if (other.IsTransferable)
                            transferred.Add(other);
                        else if (!Excludes(principal, other))
                            kept.Add(other);
                    }
                }

                days[date] = new LiturgicalDay(date, kept, emberDays.Contains(date), fastingVigils.Contains(date));
            }
        }

        private static bool Excludes(Celebration principal, Celebration other)
        {
            switch (principal.Excludes)
            {
                case Exclusion.All: return true;
                case Exclusion.LesserFeasts: return other.Kind == CelebrationKind.Feast;
                default: return false;
            }
        }

        /// <summary>Highest precedence first, then highest dignity; otherwise keeps the original order.</summary>
        private static List<Celebration> ByPrecedence(IEnumerable<Celebration> celebrations)
            => celebrations.OrderByDescending(c => c.Precedence).ThenByDescending(c => c.Dignity).ToList();

        private static string Ordinal(int n)
        {
            if (n % 100 >= 11 && n % 100 <= 13) return n + "th";
            switch (n % 10)
            {
                case 1: return n + "st";
                case 2: return n + "nd";
                case 3: return n + "rd";
                default: return n + "th";
            }
        }

        /// <summary>Gregorian Easter (anonymous algorithm).</summary>
        private static DateTime ComputeEaster(int year)
        {
            int g = year % 19;
            int c = year / 100;
            int h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
            int i = h - h / 28 * (1 - h / 28 * (29 / (h + 1)) * ((21 - g) / 11));
            int day = i - (year + year / 4 + i + 2 - c + c / 4) % 7 + 28;
            int month = 3;
            if (day > 31)
            {
                month++;
                day -= 31;
            }
            return new DateTime(year, month, day);
        }

        /// <summary>The Sunday nearest St. Andrew (Nov 30).</summary>
        private static DateTime ComputeFirstSundayOfAdvent(int year)
        {
            var stAndrew = new DateTime(year, 11, 30);
            int dayOfWeek = (int)stAndrew.DayOfWeek;
            return dayOfWeek < 4 ? stAndrew.AddDays(-dayOfWeek) : stAndrew.AddDays(7 - dayOfWeek);
        }
    }
}
