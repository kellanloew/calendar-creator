namespace Calendar
{
    /// <summary>
    /// Order of precedence under the pre-1955 (Divino Afflatu, 1911-1954) rubrics. When several
    /// celebrations occur on one day, the highest number is the Mass of the day and the rest are
    /// commemorated, except:
    ///  - an impeded Double of the I or II class is transferred to the next day not occupied by a
    ///    Double of the I or II class (or by anything that outranks one);
    ///  - Easter, Pentecost and the Triduum admit nothing else, and Easter/Pentecost Monday and
    ///    Tuesday admit no commemoration of a feast;
    ///  - days within an octave are shown only when they are the Mass of the day.
    /// Ties are broken by Dignity (feast of the Lord > Blessed Virgin > Angels > St. John the
    /// Baptist > St. Joseph > Apostles > others).
    /// </summary>
    static class PrecedenceLevel
    {
        /// <summary>Easter Sunday and Pentecost Sunday.</summary>
        public const int EasterAndPentecost = 100;
        /// <summary>Holy Thursday, Good Friday, Holy Saturday.</summary>
        public const int Triduum = 95;
        /// <summary>
        /// Greater Sundays of the I class (Advent I, Lent I-IV, Passion, Palm, Low Sunday), Trinity
        /// Sunday, privileged ferias (Ash Wednesday, Holy Mon-Wed), days within the Easter and
        /// Pentecost octaves, and the I-class vigils of Christmas and Pentecost. No feast can be
        /// celebrated on these days.
        /// </summary>
        public const int FirstClassDay = 90;
        /// <summary>
        /// Moveable I-class feasts of the Lord with a privileged octave (Ascension, Corpus Christi,
        /// Sacred Heart): win a tie with another I-class feast, e.g. Sacred Heart on July 1 (Precious Blood).
        /// </summary>
        public const int FirstClassWithPrivilegedOctave = 81;
        public const int DoubleFirstClass = 80;
        /// <summary>Holy Family, kept on the Sunday within the octave of the Epiphany.</summary>
        public const int HolyFamily = 76;
        /// <summary>Days within the Epiphany and Corpus Christi octaves (privileged, II order) and their octave days.</summary>
        public const int PrivilegedOctaveSecondOrder = 75;
        /// <summary>Greater Sundays of the II class (Advent II-IV, Septuagesima, Sexagesima, Quinquagesima): yield only to I-class Doubles.</summary>
        public const int SundaySecondClass = 70;
        public const int DoubleSecondClass = 65;
        public const int AllSouls = 64;
        /// <summary>A feast of the Lord below the II class (e.g. Exaltation of the Cross); takes the place of a minor Sunday.</summary>
        public const int LesserFeastOfTheLord = 63;
        /// <summary>Vigil of the Epiphany (II class): yields only to I/II-class Doubles and feasts of the Lord.</summary>
        public const int VigilOfEpiphany = 62;
        /// <summary>Sundays "per annum": yield to I/II-class Doubles and feasts of the Lord.</summary>
        public const int MinorSunday = 60;
        public const int GreaterDouble = 50;
        public const int Double = 45;
        public const int Semidouble = 40;
        /// <summary>Days within common octaves and III-order privileged octaves (Christmas, Ascension, Sacred Heart).</summary>
        public const int CommonOctave = 38;
        /// <summary>Greater non-privileged ferias of Lent and Passiontide, and Ember days: outrank Simple feasts.</summary>
        public const int GreaterFeria = 37;
        /// <summary>Common vigils: outrank only ferias and Simple feasts.</summary>
        public const int CommonVigil = 36;
        /// <summary>Weekdays of Advent (greater non-privileged ferias).</summary>
        public const int AdventFeria = 34;
        public const int Simple = 20;
        public const int Commemoration = 10;

        public static int OfFeast(Rank rank, Dignity dignity)
        {
            switch (rank)
            {
                case Rank.DoubleFirstClass: return DoubleFirstClass;
                case Rank.DoubleSecondClass: return DoubleSecondClass;
                case Rank.GreaterDouble: return dignity == Dignity.Lord ? LesserFeastOfTheLord : GreaterDouble;
                case Rank.Double: return dignity == Dignity.Lord ? LesserFeastOfTheLord : Double;
                case Rank.Semidouble: return Semidouble;
                case Rank.Simple: return Simple;
                default: return Commemoration;
            }
        }
    }
}
