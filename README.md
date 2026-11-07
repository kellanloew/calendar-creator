# calendar-creator
Creates an HTML file of a pre-1962 Catholic calendar for a given year. Displays fast and abstinence days symbollically on the calendar also.
The file produced is named like so: calendar_{year}.html

## Liturgical rules

The calendar follows the **pre-1955 (Divino Afflatu) rubrics** and the 1954 General Roman Calendar.

- **Ranks.** Each feast has its real rite: Double of the I class, Double of the II class, Greater Double, Double, Semidouble, Simple, or Commemoration (`Calendar/Sanctoral.cs`). Sundays, ferias, vigils and octave days have their own ranks.
- **Precedence.** When several celebrations fall on one day, the highest-ranking one is the Mass. The rest are printed after it as commemorations. The full order is documented in `Calendar/PrecedenceLevel.cs`. In outline:
  - Greater Sundays of the I class (Advent I, Lent, Passiontide, Easter, Low Sunday, Pentecost) and privileged days (Ash Wednesday, Holy Week, Easter and Pentecost weeks) exclude every feast.
  - Greater Sundays of the II class (Advent II–IV, Septuagesima–Quinquagesima) admit only I-class feasts.
  - Other Sundays admit I- and II-class feasts and feasts of the Lord.
- **Transfers.** A Double of the I or II class that is impeded moves to the next day not occupied by another such feast. For example, the Annunciation in Holy Week moves to the Monday after Low Sunday. Lower feasts are only commemorated.
- **Octaves** are printed only on days where they are the Mass (e.g. "Within the Octave of the Immaculate Conception").
- **Fast and abstinence** follow the 1917 Code as given by [Catholic Candle](https://catholiccandle.org/2019/12/22/1476/) (`Calendar/FastingRules.cs`):
  - **Lent:** fasting every day. Abstinence on Ash Wednesday, Fridays and Saturdays.
  - **Fridays:** abstinence all year.
  - **Ember days and the vigils of Christmas, Pentecost, the Assumption, All Saints and the Immaculate Conception:** fasting and abstinence. A vigil falling on Sunday is kept on Saturday.
  - **Exceptions:** never on Sundays or holy days of obligation.
