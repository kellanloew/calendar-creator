using System;
using System.Collections.Generic;
using System.Linq;

namespace Calendar
{
    /// <summary>One resolved date: the Mass of the day first, then what is commemorated.</summary>
    class LiturgicalDay
    {
        public DateTime Date { get; }
        public IReadOnlyList<Celebration> Celebrations { get; }
        public bool IsEmberDay { get; }
        public bool IsFastingVigil { get; }

        public LiturgicalDay(DateTime date, IReadOnlyList<Celebration> celebrations, bool isEmberDay, bool isFastingVigil)
        {
            Date = date;
            Celebrations = celebrations;
            IsEmberDay = isEmberDay;
            IsFastingVigil = isFastingVigil;
        }

        public Celebration Principal => Celebrations.Count > 0 ? Celebrations[0] : null;

        public bool IsHolyDayOfObligation => Celebrations.Any(c => c.IsHolyDayOfObligation);

        /// <summary>Bold notes shown above the titles on weekdays.</summary>
        public IEnumerable<string> Labels
        {
            get
            {
                if (IsHolyDayOfObligation) yield return "Holy Day of Obligation";
                foreach (var celebration in Celebrations)
                {
                    if (celebration.Label.Length > 0) yield return celebration.Label;
                }
            }
        }

        /// <summary>
        /// Titles to print: the Mass of the day first, then commemorations. Octaves are printed
        /// only when they are the Mass. When the Mass is of an unnamed feria (Lent, Advent, Ember
        /// days), everything printed is a commemoration and is marked "Com.".
        /// </summary>
        public IEnumerable<string> Titles
        {
            get
            {
                var principal = Principal;
                if (principal == null) yield break;

                bool massIsOfFeria = !principal.HasTitle;
                foreach (var celebration in Celebrations)
                {
                    if (!celebration.HasTitle) continue;
                    if (celebration != principal && celebration.Kind == CelebrationKind.Octave) continue;

                    if (massIsOfFeria && !celebration.Title.StartsWith("Com.", StringComparison.Ordinal))
                        yield return "Com. " + celebration.Title;
                    else
                        yield return celebration.Title;
                }
            }
        }
    }
}
