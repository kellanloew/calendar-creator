namespace Calendar
{
    /// <summary>Rite of a feast under the pre-1955 (Divino Afflatu) rubrics, lowest to highest.</summary>
    enum Rank
    {
        /// <summary>Never has its own Mass; only commemorated (e.g. "Com. St. Sabbas").</summary>
        Commemoration,
        Simple,
        Semidouble,
        Double,
        GreaterDouble,
        DoubleSecondClass,
        DoubleFirstClass
    }

    /// <summary>
    /// Tie-breaker between celebrations of equal precedence: the "dignity" of the feast.
    /// A feast of the Lord also outranks minor Sundays whatever its rank.
    /// </summary>
    enum Dignity
    {
        Other,
        Apostle,
        Joseph,
        JohnBaptist,
        Angel,
        BlessedVirgin,
        Lord
    }
}
