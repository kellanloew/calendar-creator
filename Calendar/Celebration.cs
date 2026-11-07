namespace Calendar
{
    enum CelebrationKind
    {
        Feast,
        Sunday,
        Feria,
        Vigil,
        Octave
    }

    /// <summary>What the Mass of the day suppresses among the other celebrations occurring with it.</summary>
    enum Exclusion
    {
        None,
        /// <summary>Feasts are not even commemorated (Easter and Pentecost Monday and Tuesday).</summary>
        LesserFeasts,
        /// <summary>Nothing else is mentioned (Easter, Pentecost, the Triduum).</summary>
        All
    }

    /// <summary>One liturgical observance (feast, Sunday, feria, vigil or octave day) on a given date.</summary>
    class Celebration
    {
        public string Title { get; }
        public CelebrationKind Kind { get; }
        /// <summary>See <see cref="PrecedenceLevel"/>.</summary>
        public int Precedence { get; }
        public Rank Rank { get; }
        public Dignity Dignity { get; }
        public bool IsHolyDayOfObligation { get; }
        public Exclusion Excludes { get; }
        /// <summary>Bold note shown above the titles on weekdays, e.g. "Ember Wednesday".</summary>
        public string Label { get; }

        private Celebration(string title, CelebrationKind kind, int precedence, Rank rank = Rank.Commemoration,
            Dignity dignity = Dignity.Other, bool isHolyDayOfObligation = false, Exclusion excludes = Exclusion.None, string label = "")
        {
            Title = title;
            Kind = kind;
            Precedence = precedence;
            Rank = rank;
            Dignity = dignity;
            IsHolyDayOfObligation = isHolyDayOfObligation;
            Excludes = excludes;
            Label = label;
        }

        public bool HasTitle => Title.Length > 0;

        /// <summary>An impeded Double of the I or II class is transferred; anything lower is only commemorated.</summary>
        public bool IsTransferable => Kind == CelebrationKind.Feast && Rank >= Rank.DoubleSecondClass;

        public static Celebration Feast(string title, Rank rank, Dignity dignity = Dignity.Other,
            bool holyDayOfObligation = false, int? precedence = null)
            => new Celebration(title, CelebrationKind.Feast, precedence ?? PrecedenceLevel.OfFeast(rank, dignity),
                rank, dignity, holyDayOfObligation);

        public static Celebration Sunday(string title, int precedence, Exclusion excludes = Exclusion.None)
            => new Celebration(title, CelebrationKind.Sunday, precedence, excludes: excludes);

        public static Celebration Feria(string title, int precedence, Exclusion excludes = Exclusion.None, string label = "")
            => new Celebration(title, CelebrationKind.Feria, precedence, excludes: excludes, label: label);

        public static Celebration Vigil(string title, int precedence)
            => new Celebration(title, CelebrationKind.Vigil, precedence);

        public static Celebration Octave(string title, int precedence, Exclusion excludes = Exclusion.None)
            => new Celebration(title, CelebrationKind.Octave, precedence, excludes: excludes);
    }
}
