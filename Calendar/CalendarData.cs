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
        public DateTime FirstSundayAdvent;
        public string EasterName { get; } = "EASTER SUNDAY";
        public int LowestPriority = 4;
        public string FooterText { get; } = "<p style='font-size: 10px;'>NB (1): We need to do much penance in order to save our souls.  Catholic Candle’s calendar uses the pre-Vatican II rules for fasting and abstinence which are found here: https://catholiccandle.org/2019/12/22/1476/</p><p style='font-size: 10px;'>NB (2): On a date on which two or more feasts are mentioned, the Mass is of the first feast, and the other(s) are only commemorations.</p>";

        private bool AnnunciationFallsDuringHolyWeek() 
        {
           return DateTime.Compare(new DateTime(Year, 3, 25), Easter.AddDays(-1)) < 0 && DateTime.Compare(new DateTime(Year, 3, 25), Easter.AddDays(-7)) > 0;
        }
        
        public CalendarData(int year)
        {
            Year = year;
            SetDateOfEaster();
            SetFirstSundayAdvent();
        }
        public string CreateSaintDays()
        {
            AllDates = new List<Month>() { };

            //January saints
            AllDates.Add(new Month(
                "January", 
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "Circumcision of the Lord", 1, true, false, false),
                    new BasicCalendarDate(2, "Octave day of St. Stephen"),
                    new BasicCalendarDate(3, "Octave day of St. John Apostle"),
                    new BasicCalendarDate(4, "Octave day of the Holy Innocents"),
                    new BasicCalendarDate(5, "Vigil of the Epihpany; St. Telesphorus, Pope Martyr"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "Com. St. Hyginus, Pope Martyr"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "St. Hilary, Bishop Confessor Doctor; St. Felix, Martyr"),
                    new BasicCalendarDate(15, "St. Paul, Confessor; St. Maurus, Abbot"),
                    new BasicCalendarDate(16, "St. Marcellus, Pope Martyr"),
                    new BasicCalendarDate(17, "St. Antony, Abbot"),
                    new BasicCalendarDate(18, "Chair of St. Peter Ap at Rome; St. Paul Apostle; St. Prisca Virgin Martyr"),
                    new BasicCalendarDate(19, "Sts. Marius and Comp., Martyrs; St. Canute, King Martyr"),
                    new BasicCalendarDate(20, "St. Fabianus, Pope Martyr; St. Sebastian, Martyr"),
                    new BasicCalendarDate(21, "St. Agnes, Virgin Martyr"),
                    new BasicCalendarDate(22, "Sts. Vincent & Anastasius, Martyrs"),
                    new BasicCalendarDate(23, "St. Raymund of Peñafort, Confessor; St. Emerentiana, Virgin Martyr"),
                    new BasicCalendarDate(24, "St. Timothy, Bishop Martyr"),
                    new BasicCalendarDate(25, "Conversion of St. Paul Apostle; St. Peter Apostle"),
                    new BasicCalendarDate(26, "St. Polycarp, Bishop Martyr"),
                    new BasicCalendarDate(27, "St. John Chrysostom, Bishop Confessor Doctor"),
                    new BasicCalendarDate(28, "St. Peter Nolasco, Confessor; St. Agnes, Virgin Martyr"),
                    new BasicCalendarDate(29, "St. Francis of Sales, Bishop Confessor Doctor"),
                    new BasicCalendarDate(30, "St. Martina, Virgin Martyr"),
                    new BasicCalendarDate(30, "St. John Bosco, Confessor")
                }
            ));
            int holyName = NthWeekDayOfMonthYear(1, Year, "Sunday", 1).Day;
            DayOfWeek holyNameDayOfWeek = NthWeekDayOfMonthYear(1, Year, "Sunday", 1).DayOfWeek;
            if ( holyName > 0 && holyName < 6 && holyNameDayOfWeek != DayOfWeek.Sunday)
            {
                AllDates[0].AddSpecialFeast(2, new BasicCalendarDate(2, "Holy Name of Jesus"), 3);
            }

            //February saints
            AllDates.Add(new Month(
                "February",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "St. Ignatius"),
                    new BasicCalendarDate(2, "Purification of the Blessed Virgin Mary", 2),
                    new BasicCalendarDate(3, "St. Blase"),
                    new BasicCalendarDate(4, "St. Andrew Corsini"),
                    new BasicCalendarDate(5, "St. Agatha"),
                    new BasicCalendarDate(6, "St. Titus; St. Dorothea"),
                    new BasicCalendarDate(7, "St. Romuald"),
                    new BasicCalendarDate(8, "St. John of Matha"),
                    new BasicCalendarDate(9, "St. Cyril; St. Apollonia"),
                    new BasicCalendarDate(10, "St. Scholastica"),
                    new BasicCalendarDate(11, "Apparition of BVM at Lourdes"),
                    new BasicCalendarDate(12, "Seven Holy Founders of the Servites"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "St. Valentine, Martyr"),
                    new BasicCalendarDate(15, "Sts. Faustinus and Jovita, Martyrs"),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18, "St. Bernadette Marie Soubirous; St. Simeon, Bishop Martyr"),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21),
                    new BasicCalendarDate(22, "Chair of St. Peter Ap at Antioch; St. Paul, Apostle"),
                    new BasicCalendarDate(23, "St. Peter Damian, Bishop Confessor Doctor")
                }
            ));

            //add Leap year determined saints days
            int offset = 0;
            if (AllDates[1].DaysInMonth == 29)
            {
                offset = 1;
                AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(24) } });
            }

            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { 2, new BasicCalendarDate(24 + offset, "St. Matthias, Apostle", 3) } });
            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(25 + offset) } });
            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(26 + offset) } });
            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(27 + offset, "St. Gabriel of the Sorrowful Virgin, Confessor") } });
            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(28 + offset) } });
            AllDates[1].SaintsList.Add(new Dictionary<int, BasicCalendarDate> { { Environment.LowestPriority, new BasicCalendarDate(29 + offset) } });


            string Annunciation = "Annunciation to the Blessed Virgin Mary";
            if (this.AnnunciationFallsDuringHolyWeek())
            {
                Annunciation = "";
            }
            //March saints
            AllDates.Add(new Month(
                "March",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "St. Casimir, Confessor; St. Lucius, Pope Martyr"),
                    new BasicCalendarDate(5),
                    new BasicCalendarDate(6, "Sts. Perpetua & Felicitas, Martyrs"),
                    new BasicCalendarDate(7, "St. Thomas Aquinas, Confessor Doctor"),
                    new BasicCalendarDate(8, "St. John of God, Confessor"),
                    new BasicCalendarDate(9, "St. Francesca, Widow"),
                    new BasicCalendarDate(10, "Forty Martyrs"),
                    new BasicCalendarDate(11),
                    new BasicCalendarDate(12, "St. Gregory, Confessor Doctor"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17, "St. Patrick, Bishop Confessor"),
                    new BasicCalendarDate(18, "St. Cyril, Bishop Confessor Doctor"),
                    new BasicCalendarDate(19, "St. Joseph, Confessor", 3),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21, "St. Benedict, Abbot"),
                    new BasicCalendarDate(22, "St. Isidore the Farmer, Confessor"),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "St. Gabriel Archangel"),
                    new BasicCalendarDate(25, Annunciation),
                    new BasicCalendarDate(26),
                    new BasicCalendarDate(27, "Our Lady of Sorrows; St. John of Damascus, Confessor Doctor"),
                    new BasicCalendarDate(28, "St. John of Capestrano, Confessor"),
                    new BasicCalendarDate(29),
                    new BasicCalendarDate(30),
                    new BasicCalendarDate(31)
                }
            ));

            //April saints
            AllDates.Add(new Month(
                "April",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2, "St. Francis of Paola, Confessor"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "St. Isidore, Bishop Confessor Doctor"),
                    new BasicCalendarDate(5, "St. Vincent Ferrer, Confessor"),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "St. Leo I, Pope Confessor Doctor"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "St. Hermenegild, Martyr"),
                    new BasicCalendarDate(14, "St. Justin, Martyr; Sts. Tiburtius and Comp., Martyrs"),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17, "St. Anicetus, Pope Martyr"),
                    new BasicCalendarDate(18),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21, "St. Anselm, Bishop Confessor Doctor"),
                    new BasicCalendarDate(22, "Sts. Soter and Caius, Popes Martyrs"),
                    new BasicCalendarDate(23, "St. George, Martyr"),
                    new BasicCalendarDate(24, "St. Fidelis of Sigmaringen, Martyr"),
                    new BasicCalendarDate(25, "St. Mark, Evangelist", 3),
                    new BasicCalendarDate(26, "Sts. Cletus and Marcellinus, Popes Martyrs"),
                    new BasicCalendarDate(27, "St. Peter Canisius, Confessor Doctor"),
                    new BasicCalendarDate(28, "St. Paul of the Cross, Confessor; St. Vitalis, Martyr"),
                    new BasicCalendarDate(29, "St. Peter of Verona, Martyr"),
                    new BasicCalendarDate(30, "St. Catherine of Siena, Virgin")
                }
            ));

            if (AnnunciationFallsDuringHolyWeek())
            {
                AllDates[Easter.AddDays(7).Month - 1].AddSpecialFeast(Easter.AddDays(7).Day, new BasicCalendarDate(Easter.AddDays(7).Day, "Annunciation to the Blessed Virgin Mary"), 3);
            }

            //May saints
            AllDates.Add(new Month(
                "May",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "Sts. Philip & James, Apostles", 2),
                    new BasicCalendarDate(2, "St. Athanasius, Bishop Confessor Doctor"),
                    new BasicCalendarDate(3, "Sts. Alexander & Comp., Martyrs"),
                    new BasicCalendarDate(4, "St. Monica, Widow"),
                    new BasicCalendarDate(5, "St. Pius V, Pope Confessor"),
                    new BasicCalendarDate(6, "St. John the Apostle before the Latin gate"),
                    new BasicCalendarDate(7, "St. Stanislaus, Bishop Martyr"),
                    new BasicCalendarDate(8, "Apparition of St. Michael Archangel"),
                    new BasicCalendarDate(9, "St. Gregory of Nazianzus, Bishop Confessor Doctor"),
                    new BasicCalendarDate(10, "St. Antoninus, Bishop Confessor; Sts. Gordianus & Epimachus Martyrs"),
                    new BasicCalendarDate(11),
                    new BasicCalendarDate(12, "Sts. Nereus & Comp., Martyrs"),
                    new BasicCalendarDate(13 , "St. Robert Bellarmine, Bishop Confessor Doctor"),
                    new BasicCalendarDate(14, "St. Boniface, Confessor"),
                    new BasicCalendarDate(15, "St. John Baptist de la Salle, Confessor"),
                    new BasicCalendarDate(16, "St. Ubaldus, Bishop Confessor"),
                    new BasicCalendarDate(17, "St. Paschal Baylon, Confessor"),
                    new BasicCalendarDate(18, "St. Venantius, Martyr"),
                    new BasicCalendarDate(19, "St. Peter Celestine, Pope Confessor; St. Prudentia, Virgin"),
                    new BasicCalendarDate(20, "St. Bernardinus of Siena, Confessor"),
                    new BasicCalendarDate(21),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24),
                    new BasicCalendarDate(25, "St. Gregory, Pope Confessor; St. Urbanus, Pope Martyr"),
                    new BasicCalendarDate(26, "St. Philip Neri, Confessor; St. Eleutherius, Pope Martyr"),
                    new BasicCalendarDate(27, "St. Bede, Confessor Doctor; St. John Pope Martyr"),
                    new BasicCalendarDate(28, "St. Augustine, Bishop Confessor"),
                    new BasicCalendarDate(29, "St. Mary Magdalen de Pazzi, Virgin"),
                    new BasicCalendarDate(30, "St. Felix, Pope Martyr"),
                    new BasicCalendarDate(31, "Queenship of the Blessed Virgin; St. Petronilla, Virgin")
                }
            ));
            AllDates[4].AddSpecialFeast(2, new BasicCalendarDate(2, "Finding of the Holy Cross"), 2);

            //June saints
            AllDates.Add(new Month(
                "June",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "St. Angela Merici, Virigin"),
                    new BasicCalendarDate(2, "St. Marcellinus and Comp., Martyrs"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "St. Francis Caracciolo, Confessor"),
                    new BasicCalendarDate(5, "St. Boniface, Bishop Martyr"),
                    new BasicCalendarDate(6, "St. Norbert, Bishop Confessor"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9, "Sts. Primus and Felicianus, Martyrs"),
                    new BasicCalendarDate(10, "St. Margaret, Queen Widow"),
                    new BasicCalendarDate(11, "St. Barnabas, Apostle"),
                    new BasicCalendarDate(12, "St. John of St. Facundus, Confessor; Sts. Basilides and Comp., Martyrs"),
                    new BasicCalendarDate(13, "St. Antony of Padua, Confessor"),
                    new BasicCalendarDate(14, "St. Basil, Bishop Confessor Doctor"),
                    new BasicCalendarDate(15, "Sts. Vitus and Comp., Martyrs"),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18, "St. Ephrem, Doctor Confessor; Sts. Marcus and Marcellianus, Martyrs"),
                    new BasicCalendarDate(19, "St. Juliana of Falconeri, Virgin; Sts. Gervasius and Protasius, Martyrs"),
                    new BasicCalendarDate(20, "St. Silverius, Martyr"),
                    new BasicCalendarDate(21, "St. Aloysius. of Gonzaga, Confessor"),
                    new BasicCalendarDate(22, "St. Paulinus, Bishop Confessor"),
                    new BasicCalendarDate(23, "Vigil of St. John the Baptist"),
                    new BasicCalendarDate(24, "Birth of St. John the Baptist, Confessor"),
                    new BasicCalendarDate(25, "St. William of Montevergine. , Abbot"),
                    new BasicCalendarDate(26, "Sts. John & Paul, Martyrs"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28, "St. Irenaeus, Bishop Martyr"),
                    new BasicCalendarDate(29, "Sts. Peter & Paul, Apostles", 2),
                    new BasicCalendarDate(30, "St. Paul Apostle; St. Peter, Apostle")
                }
            ));

            //July saints
            AllDates.Add(new Month(
                "July",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "Most Precious Blood of Jesus"),
                    new BasicCalendarDate(2, "Sts. Processus and Martinianus, Martyrs"),
                    new BasicCalendarDate(3, "St. Leo II, Pope Confessor"),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "St. Antony Maria Zaccaria, Confessor"),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7, "Sts. Cyril & Methodius, Bishops Confessors"),
                    new BasicCalendarDate(8, "St. Elizabeth, Queen Widow"),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10, "Seven Brothers, Martyrs; Sts. Rufina & Secunda, Virgins Martyrs"),
                    new BasicCalendarDate(11, "St. Pius I, Pope Martyr"),
                    new BasicCalendarDate(12, "St. John Gualbert, Abbot; Sts. Nabor & Felix, Martyrs"),
                    new BasicCalendarDate(13, "St. Anacletus, Pope Martyr"),
                    new BasicCalendarDate(14, "St. Bonaventure, Bishop Confessor Doctor"),
                    new BasicCalendarDate(15, "St. Henry, King Confessor"),
                    new BasicCalendarDate(16, "Blessed Virgin Mary of Mount Carmel"),
                    new BasicCalendarDate(17, "St. Alexius Confessor"),
                    new BasicCalendarDate(18, "St. Camillus of Lellis, Confessor; Sts. Symphorosa & her seven sons, Martyrs"),
                    new BasicCalendarDate(19, "St. Vincent of Paul, Confessor"),
                    new BasicCalendarDate(20, "St. Jerome Æmilianus; Confessor; St. Margaret, Virgin Martyr"),
                    new BasicCalendarDate(21, "St. Praxedes, Virgin"),
                    new BasicCalendarDate(22, "St. Mary Magdalen Penitent"),
                    new BasicCalendarDate(23, "St. Apollinaris, Bishop Martyr; St. Liborius, Bishop Confessor"),
                    new BasicCalendarDate(24, "St. Christina, Virgin Martyr"),
                    new BasicCalendarDate(25, "St. Christopher, Martyr"),
                    new BasicCalendarDate(26, "St. Anne Mother of the Blessed Virgin Mary", 2),
                    new BasicCalendarDate(27, "St. Pantaleon, Martyr"),
                    new BasicCalendarDate(28, "Sts. Nazarius and Comp., Martyrs"),
                    new BasicCalendarDate(29, "St. Martha, Virgin; Sts. Felix &c Comp., Martyrs"),
                    new BasicCalendarDate(30, "Sts. Abdon & Sennen, Martyrs"),
                    new BasicCalendarDate(31, "St. Ignatius, Confesor")
                }
            ));
            AllDates[6].AddSpecialFeast(24, new BasicCalendarDate(24, "St. James, Apostle"), 3);
            AllDates[6].AddSpecialFeast(1, new BasicCalendarDate(1, "Visitation of the Blessed Virgin Mary"), 3);

            //August saints
            AllDates.Add(new Month(
                "August",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "St. Peter Apostle in Chains; St. Paul Apostle; Holy Machabees, Martyrs"),
                    new BasicCalendarDate(2, "St. Alphonsus de Liguori, Bishop Confessor Doctor; St. Stephen, Pope Martyr"),
                    new BasicCalendarDate(3, "Finding of the body of St. Stephen Martyr"),
                    new BasicCalendarDate(4, "St. Dominic, Confessor"),
                    new BasicCalendarDate(5, "Dedication of the Basilica of Our Lady of the Snows"),
                    new BasicCalendarDate(6, "Sts. Xystus and Comp., Martyrs"),
                    new BasicCalendarDate(7, "St. Cajetan, Confessor; St. Donatus Bishop Martyr"),
                    new BasicCalendarDate(8, "Sts. Cyriacus and Comp., Martyrs"),
                    new BasicCalendarDate(9, "St. John Vianney, Confessor; St. Romanus Martyr"),
                    new BasicCalendarDate(10, "St. Lawrence, Martyr", 3),
                    new BasicCalendarDate(11, "Sts. Tiburtius, Martyr & Susanna, Virgin Martyr"),
                    new BasicCalendarDate(12, "St. Clare, Virgin"),
                    new BasicCalendarDate(13, "Sts. Hippolytus and Cassianus, Martyrs"),
                    new BasicCalendarDate(14, "St. Eusebius, Confessor"),
                    new BasicCalendarDate(15, "Assumption of the Blessed Virgin Mary", 1, true, false, false),
                    new BasicCalendarDate(16, "St. Joachim Father of the Blessed Virgin Mary, Confessor"),
                    new BasicCalendarDate(17, "St. Hyacinth, Confessor"),
                    new BasicCalendarDate(18, "St. Agapitus, Martyr"),
                    new BasicCalendarDate(19, "St. John Eudes, Confessor"),
                    new BasicCalendarDate(20, "St. Bernard, Confessor Doctor Abbot"),
                    new BasicCalendarDate(21, "St. Jane Frances de Chantal, Widow"),
                    new BasicCalendarDate(22, "Sts. Timothy & Comp., Martyrs"),
                    new BasicCalendarDate(23, "St. Philip Benizi, Confessor"),
                    new BasicCalendarDate(24, "St. Bartholomew, Apostle", 3),
                    new BasicCalendarDate(25, "St. Louis, King Confessor"),
                    new BasicCalendarDate(26, "St. Zephyrinus, Pope Martyr"),
                    new BasicCalendarDate(27, "St. Joseph Calasanctius, Confessor"),
                    new BasicCalendarDate(28, "St. Augustine, Bishop Confessor Doctor; St. Hermes, Martyr"),
                    new BasicCalendarDate(29, "Beheading of St. John the Baptist; St. Sabina, Martyr"),
                    new BasicCalendarDate(30, "St. Rose of Lima, Virgin; Sts. Felix & Adauctus, Martyrs"),
                    new BasicCalendarDate(31, "St. Raymond Nonnatus, Confessor")
                }
            ));
            AllDates[7].AddSpecialFeast(21, new BasicCalendarDate(21, "Immaculate Heart of the Blessed Virgin Mary"), 3);
            AllDates[7].AddSpecialFeast(5, new BasicCalendarDate(5, "Transfiguration of the Lord"), 3);

            //September saints
            AllDates.Add(new Month(
                "September",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "St. Ægidius Abbot; Twelve Brothers, Martyrs"),
                    new BasicCalendarDate(2, "St. Stephen, King Confessor"),
                    new BasicCalendarDate(3, "St. Piux X, Pope"),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "St. Lawrence Justinian Bishop Confessor"),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8, "St. Hadrian Martyr"),
                    new BasicCalendarDate(9, "St. Gorgonius Martyr"),
                    new BasicCalendarDate(10, "St. Nicholas of Tolentino, Confessor"),
                    new BasicCalendarDate(11, "St. Protus and Hyacinthus, Martyrs"),
                    new BasicCalendarDate(12, "Most Holy Name of the Blessed Virgin Mary"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "Exaltation of the Holy Cross"),
                    new BasicCalendarDate(15, "St. Nicomedes Martyr"),
                    new BasicCalendarDate(16, "St. Cornelius Martyr; St. Cyprian, Bishop Martyr; SS. Euphemia & comp., Martyrs"),
                    new BasicCalendarDate(17, "Impression of stigmata on St. Francis"),
                    new BasicCalendarDate(18, "St. Joseph of Cupertino, Confessor"),
                    new BasicCalendarDate(19, "Sts. Ianuarius and comp., Martyrs"),
                    new BasicCalendarDate(20, "Sts. Eustachius and comp. Martyrs", 4, false, false, false, "Vigil of St. Matthew the Apostle"),
                    new BasicCalendarDate(21, "St. Matthew, Apostle Evangelist", 3),
                    new BasicCalendarDate(22, "St. Thomas of Villanova, Bishop Confessor; Sts. Mauritius and comp., Martyrs"),
                    new BasicCalendarDate(23, "St. Linus, Pope Martyr; St. Thecla, Virgin Martyr"),
                    new BasicCalendarDate(24, "Blessed Virgin Mary of Ransom"),
                    new BasicCalendarDate(25),
                    new BasicCalendarDate(26, "Sts. Cyprian Martyr & Justina Virgin Martyr"),
                    new BasicCalendarDate(27, "Sts. Cosmas and Damian, Martyrs"),
                    new BasicCalendarDate(28, "St. Wenceslaus, King Martyr"),
                    new BasicCalendarDate(29, "Dedication of the Basilica of St. Michael Archangel"),
                    new BasicCalendarDate(30, "St. Jerome, Confessor Doctor"),
                }
            ));
            AllDates[8].AddSpecialFeast(7, new BasicCalendarDate(7, "Birth of the Blessed Virgin Mary"), 3);
            AllDates[8].AddSpecialFeast(14, new BasicCalendarDate(14, "Seven Sorrows of the Blessed Virgin Mary"), 3);


            //October saints
            AllDates.Add(new Month(
                "October",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "St. Remigius, Bishop Confessor"),
                    new BasicCalendarDate(2, "Holy Guardian Angels"),
                    new BasicCalendarDate(3, "St. Teresa of the Child Jesus, Virgin"),
                    new BasicCalendarDate(4, "St. Francis Confessor"),
                    new BasicCalendarDate(5, "SS. Placidus and Comp. Martyrs"),
                    new BasicCalendarDate(6, "St. Bruno, Confessor"),
                    new BasicCalendarDate(7, "St. Mark Confessor; Sts. Sergius and Comp. Martyrs"),
                    new BasicCalendarDate(8, "St. Brigid Widow"),
                    new BasicCalendarDate(9, "St. John Leonard, Confessor; Sts. Dionysius and Comp. Martyrs"),
                    new BasicCalendarDate(10, "St. Francis Borgia Confessor"),
                    new BasicCalendarDate(11, "Motherhood of the Blessed Virgin Mary", 2),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "St. Edward, Confessor"),
                    new BasicCalendarDate(14, "St. Callistus I, Pope Martyr"),
                    new BasicCalendarDate(15, "St. Teresa, Virgin"),
                    new BasicCalendarDate(16, "St. Hedwig, Widow"),
                    new BasicCalendarDate(17, "St. Margaret Mary Alacoque Virgin"),
                    new BasicCalendarDate(18, "St. Luke Evangelist", 3),
                    new BasicCalendarDate(19, "St. Peter of Alcántara Confessor"),
                    new BasicCalendarDate(20, "St. John Cantius, Confessor"),
                    new BasicCalendarDate(21, "St. Hilarion, Abbot; Sts. Ursula & Comp., Virgin Martyrs"),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "St. Raphael the Archangel"),
                    new BasicCalendarDate(25, "Sts. Chrysanthus and Daria, Martyrs"),
                    new BasicCalendarDate(26, "St. Evaristus, Pope Martyr"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28, "Sts. Simon & Jude, Apostles"),
                    new BasicCalendarDate(29),
                    new BasicCalendarDate(30),
                    new BasicCalendarDate(31)
                }
            ));
            AllDates[9].AddSpecialFeast(6, new BasicCalendarDate(6, "Most Holy Rosary of the Blessed Virgin Mary"), 3);


            //November saints
            AllDates.Add(new Month(
                "November",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "ALL SAINTS", 1, true, false, false),
                    new BasicCalendarDate(2, "ALL SOULS"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "St. Charles Borromeo, Confessor; Sts. Vitalis and Agricola, Martyrs"),
                    new BasicCalendarDate(5),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8, "Holy Four Crowned Martyrs"),
                    new BasicCalendarDate(9, "St. Theodorus, Martyr"),
                    new BasicCalendarDate(10, "St. Andrew Avellino; St. Tryphon & Comp., Martyrs"),
                    new BasicCalendarDate(11, "St. Martin, Bishop Confessor; St. Mennas, Martyr"),
                    new BasicCalendarDate(12, "St. Martin I, Pope Martyr"),
                    new BasicCalendarDate(13, "St. Didacus, Confessor"),
                    new BasicCalendarDate(14, "St. Josaphat, Bishop Martyr"),
                    new BasicCalendarDate(15, "St. Albert, Bishop Confessor Doctor"),
                    new BasicCalendarDate(16, "St. Gertrude Virgin"),
                    new BasicCalendarDate(17, "St. Gregory, Confessor"),
                    new BasicCalendarDate(18, "Dedication of Sts. Peter & Paul"),
                    new BasicCalendarDate(19, "St. Elisabeth, Widow; St. Pontianus, Martyr"),
                    new BasicCalendarDate(20, "St. Felix of Valois, Confessor"),
                    new BasicCalendarDate(21, "Presentation of the Blessed Virgin Mary"),
                    new BasicCalendarDate(22, "St. Cæcilia, Virgin Martyr"),
                    new BasicCalendarDate(23, "St. Clement I, Pope Martyr; St. Felicitas, Martyr"),
                    new BasicCalendarDate(24, "St. John of the Cross, Confessor; St. Chrysogonus, Martyr"),
                    new BasicCalendarDate(25, "St. Catherine, Virgin Martyr"),
                    new BasicCalendarDate(26, "St. Silvester, Abbot; St. Peter of Alexandria, Martyr"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28),
                    new BasicCalendarDate(29, "St. Saturninus, Martyr"),
                    new BasicCalendarDate(30, "St. Andrew the Apostle", 1)
                }
            ));
            AllDates[10].AddSpecialFeast(8, new BasicCalendarDate(8, "Dedication of the Basilica of Our Most Holy Redeemer", 3), 3);


            //December saints
            AllDates.Add(new Month(
                "December",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2, "St. Bibiana, Virgin Martyr"),
                    new BasicCalendarDate(3, "St. Francis Xavier, Confessor"),
                    new BasicCalendarDate(4, "St. Peter Chrysologus, Bishop Confessor Doctor; Com. St. Barbara, Virgin Martyr"),
                    new BasicCalendarDate(5, "Com. St. Sabbas, Abbot"),
                    new BasicCalendarDate(6, "St. Nicholas, Bishop Confessor"),
                    new BasicCalendarDate(7, "St. Ambrose, Bishop Confessor"),
                    new BasicCalendarDate(8, "IMMACULATE CONCEPTION", 1, true, false, false),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10, "St. Melchiades, Pope Martyr"),
                    new BasicCalendarDate(11, "St. Damasus, Pope"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "St. Lucia, Virgin Martyr"),
                    new BasicCalendarDate(14),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16, "St. Eusebius, Bishop Martyr"),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20, "Vigil of St. Thomas the Apostle"),
                    new BasicCalendarDate(21, "St. Thomas the Apostle, Martyr", 2),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "CHRISTMAS EVE", 2, false, true, true),
                    new BasicCalendarDate(25, "CHRISTMAS DAY; Com. St. Anastasia, Martyr", 1, true),
                    new BasicCalendarDate(26, "St. Stephen, Martyr", 2),
                    new BasicCalendarDate(27, "St. John the Apostle", 2),
                    new BasicCalendarDate(28, "Holy Innocents, Martyrs", 2),
                    new BasicCalendarDate(29, "St. Thomas of Canterbury, Bishop Martyr"),
                    new BasicCalendarDate(30),
                    new BasicCalendarDate(31, "St. Silvester, Pope Martyr")
                }
            ));

            SetMovableDaysForAllMonths();
            SetVigilDaysForFeasts();
            CreateHtmlFromSaintData();
            return HTML;
        }

        public string GetSundayFromMonthAndDay(int month, int day)
        {
            
            DateTime inputDate = new DateTime(Year, month, day);
            string sundayName = "";


            //this is a sunday before Easter
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
            // Easter Sunday
            else if (DateTime.Compare(inputDate, Easter) == 0)
            {
                //Add Easter to List of Special feasts
                sundayName = this.EasterName;
            }
            //this is a sunday after Easter
            else
            {
                int weeksDiffAfterEaster = WeeksDifferenceBetweenDates(Easter, inputDate);
                if(inputDate < FirstSundayAdvent)
                {
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
                            sundayName = "PENTECOST";
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
                        case 29:
                            sundayName = "22nd Sunday after Pentecost";
                            break;
                        case 30:
                            sundayName = "23rd Sunday after Pentecost";
                            break;
                        case 31:
                            sundayName = "24th Sunday after Pentecost";
                            break;
                        case 32:
                            sundayName = "25th Sunday after Pentecost";
                            break;
                        case 33:
                            sundayName = "26th Sunday after Pentecost";
                            break;
                        case 34:
                            sundayName = "27th Sunday after Pentecost";
                            break;
                    }
                }
                else
                {
                    int weeksDiffAfterAdvent = WeeksDifferenceBetweenDates(FirstSundayAdvent, inputDate);
                    switch (weeksDiffAfterAdvent)
                    {
                        case 0:
                            sundayName = "First Sunday of Advent";
                            break;
                        case 1:
                            sundayName = "Second Sunday of Advent";
                            break;
                        case 2:
                            sundayName = "Gaudete Sunday";
                            break;
                        case 3:
                            sundayName = "Fourth Sunday of Advent";
                            break;
                        case 4:
                            if(DateTime.Compare(inputDate, new DateTime(Year, 12, 25)) != 0) sundayName = "Sunday within the Octave of Christmas";
                            break;
                    }
                }
            }


            return sundayName;
        }

        public string ReturnPreHTML()
        {
            return "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width = device-width, initial-scale=1\"><style>p{margin:0;}.special{font-weight:bold;} table {font-family: \"Century Schoolbook L\", \"Century Schoolbook\", serif; font-size: 10px; border-collapse:collapse; text-align: right; vertical-align: bottom; break-before: page; page-break-before: always;}tr.h {text-align:center;}tr.h, tr.nos {font-size: 1.5rem;}tr.nos td {border-top: 1px solid black; vertical-align: top;} *{font - size: 1em!important;line - height: 1!important;} tr.ss td, tr.nos td {border-left: 1px solid black; border-right: 1px solid black; height: 7.3vh; width: 14vw;}tr.ss {border-bottom: 1px solid black; vertical-align: bottom;}tr.wd {}</style></head><body><table style=\"break-before: page-avoid; page-break-before: avoid;\">";
        }

        private void CreateHtmlFromSaintData()
        {
            //loop through all months
            foreach (Month m in AllDates)
            {
                HTML += "<table><tr class='h'><tr class='h'><td colspan='7'>" + m.MonthName + " " + m.Year.ToString() +
                "</td></tr><tr class='wd'><td>Sunday</td><td>Monday</td><td>Tuesday</td><td>Wednesday</td><td>Thursday</td><td>Friday</td><td>Saturday</td></tr><tr class='nos'>";

                HTML += "</tr>";

                int currentBlockSaints = 1;
                int currentBlockNumbers = 1;
                bool fastingPosted = false;

                //loop through all calendar rows for this month
                for (int j = 1; j <= m.numCalendarRows; j++)
                {
                    //subrow for numbers and symbols
                    HTML += "<tr class='nos'>";
                    for (int i = 1; i <= 7; i++)
                    {
                        int monthDay = currentBlockNumbers - m.FirstDay;
                        HTML += "<td>";
                        if (currentBlockNumbers >= m.FirstDay + 1 && monthDay <= m.DaysInMonth)
                        {
                            //if it's a fast day, show the plate symbol
                            if
                                (i != 1 && m.isFastDay(monthDay - 1)) HTML += "&#x1F37D;";

                            //if it's a abstinence day, show the fish symbol
                            if(m.isAbstinenceDay(monthDay - 1, m.MonthNumber, i)) HTML += "&#x1f41f;&#xfe0e;";

                            HTML += monthDay.ToString();
                        }
                        HTML += "</td>";
                        currentBlockNumbers++;
                    }
                    HTML += "</tr>";

                    //subrow for saints title
                    HTML += "<tr class='ss'>";
                    for (int day = 1; day <= 7; day++)
                    {
                        int monthDay = currentBlockSaints - m.FirstDay - 1;
                        HTML += "<td>";
                        //
                        if (currentBlockSaints >= m.FirstDay + 1 && monthDay < m.DaysInMonth)
                        {
                            //only show the pretitle if it's not a sunday
                            if(day != 1)
                            {
                                for(int k = 1; k <= Environment.LowestPriority; k++)
                                {
                                    if (m.SaintsList[monthDay].ContainsKey(k) && m.SaintsList[monthDay][k].PreTitle.Length > 0)
                                    {
                                        HTML += "<p class='special'>" + m.SaintsList[monthDay][k].PreTitle + "</p>";
                                    }
                                }
                            }

                            string tempHTML = "";
                            bool previousTitleExists = false;
                            bool currentTitleExists = false;
                            string sundayName = "";

                            for(int c = 1; c <= Environment.LowestPriority; c++)
                            {
                                tempHTML = "";

                                if (m.SaintsList[monthDay].ContainsKey(c) && m.SaintsList[monthDay][c].Title.Length > 0)
                                {
                                    tempHTML += m.SaintsList[monthDay][c].Title;
                                    currentTitleExists = true;
                                }
                                else
                                {
                                    currentTitleExists = false;
                                }

                                //if this is a sunday
                                if (c == 3 && day == 1)
                                {
                                    tempHTML += sundayName = GetSundayFromMonthAndDay(m.MonthNumber, monthDay + 1);
                                    if(tempHTML.Length > 1) currentTitleExists = true;
                                }
                                if (currentTitleExists && previousTitleExists && tempHTML.Length > 0 && (m.MonthNumber != 11 || monthDay != 24)) HTML += "; ";

                                if (currentTitleExists) previousTitleExists = true;

                                HTML += tempHTML;

                                if (c == 1 && currentTitleExists && m.SaintsList[monthDay][c].IsSolo || ( day == 1 && sundayName.IndexOf(this.EasterName) != -1 ) ) break;
                            }

                        }
                        HTML += "</td>";
                        currentBlockSaints++;
                    }
                    HTML += "</tr>";
                }
                HTML += "</table>";
                HTML += this.FooterText;
            }

        }

        private void SetDateOfEaster()
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
    
        private void SetFirstSundayAdvent()
        {
            DateTime StAndrew = new DateTime(Year, 11, 30);
            int dayOfWeek = (int)StAndrew.DayOfWeek;
            if (dayOfWeek < 4)
            {
                FirstSundayAdvent = StAndrew.AddDays(-dayOfWeek);
            }
            else
            {
                FirstSundayAdvent = StAndrew.AddDays(7 - dayOfWeek);
            }
        }

        private void SetMovableDaysForAllMonths()
        {
            //set Ash Wednesday
            DateTime AshWednesday = Easter.AddDays(-46);
            AllDates[AshWednesday.Month - 1].AddSpecialFeast(AshWednesday.Day - 1, new BasicCalendarDate(AshWednesday.Day, "ASH WEDNESDAY", 1, false, true, true), 1);

            //set holy thursday - holy saturday
            DateTime HolyThursday = Easter.AddDays(-3);
            AllDates[HolyThursday.Month - 1].AddSpecialFeast(HolyThursday.Day - 1, new BasicCalendarDate(HolyThursday.Day, "HOLY THURSDAY", 1, false, true, false, "", true), 1);

            DateTime GoodFriday = Easter.AddDays(-2);
            AllDates[GoodFriday.Month - 1].AddSpecialFeast(GoodFriday.Day - 1, new BasicCalendarDate(GoodFriday.Day, "GOOD FRIDAY", 1, false, true, true), 1);

            DateTime HolySaturday = Easter.AddDays(-1);
            AllDates[HolySaturday.Month - 1].AddSpecialFeast(HolySaturday.Day - 1, new BasicCalendarDate(HolySaturday.Day, "HOLY SATURDAY", 1, false, true, true, "", true), 1);

            //set first ember day of year
            DateTime emberDay = new DateTime(Year, Easter.AddDays(-39).Month, Easter.AddDays(-39).Day);

            int emberMonth = 0;
            int ember_day = 0;
                        for (int i = 1; i <= 4; i++)

            //Set ember days
            {
                
                switch (i)
                {
                    case 2:
                        //the week after Pentecost
                        emberDay = new DateTime(Year, Easter.AddDays(52).Month, Easter.AddDays(52).Day);
                        break;
                    case 3:
                        //the third week of September
                        emberDay = NthWeekDayOfMonthYear(9, Year, "Wednesday", 3);
                        break;
                    case 4:
                        //the third week of Advent
                        emberDay = new DateTime(Year, FirstSundayAdvent.AddDays(17).Month, FirstSundayAdvent.AddDays(17).Day);
                        break;
                }
                //set ember wednesday
                AllDates[emberDay.Month - 1].AddEmberDay(emberDay.Day - 1, "Ember Wednesday"); // AllDates[emberDay.Month - 1].EmberDays.Add(emberDay.Day - 1, new BasicCalendarDate(emberDay.Day - 1, "", Environment.LowestPriority - 1, false, true, true, "Ember Wednesday"));
                //set ember friday
                emberMonth = emberDay.Month - 1;
                ember_day = emberDay.Day + 1;
                if ( emberDay.Day <= DateTime.DaysInMonth(Year, emberDay.Month) )
                {
                    var tomorrow = new DateTime(Year, emberDay.Month, emberDay.Day).AddDays(2).Date;
                    ember_day = tomorrow.Day - 1;
                    emberMonth = tomorrow.Month - 1;
                }
                AllDates[emberMonth].AddEmberDay(ember_day, "Ember Friday"); //AllDates[emberMonth].EmberDays.Add(emberDay.Day, new BasicCalendarDate(emberDay.Day, "", Environment.LowestPriority - 1, false, true, true, "Ember Friday"));

                //set ember saturday
                AllDates[emberMonth].AddEmberDay(ember_day + 1, "Ember Saturday"); // EmberDays.Add(emberDay.Day + 1, new BasicCalendarDate(emberDay.Day + 1, "", Environment.LowestPriority - 1, false, true, true, "Ember Saturday"));
            }

            //Ascension Thursday
            DateTime Ascension = Easter.AddDays(39);
            AllDates[Ascension.Month - 1].AddSpecialFeast(Ascension.Day - 1, new BasicCalendarDate(Ascension.Day, "ASCENSION DAY", 1, true, false, false), 1);

            //Vigil of Pentecost
            DateTime VigilPentecost = Easter.AddDays(48);
            AllDates[VigilPentecost.Month - 1].AddSpecialFeast(VigilPentecost.Day - 1, new BasicCalendarDate(VigilPentecost.Day, "Vigil of Pentecost", 2, false, true, true), 2);

            //Corpus Christi (Thursday after Trinity Sunday)
            DateTime CorpusChristi = Easter.AddDays(60);
            AllDates[CorpusChristi.Month - 1].AddSpecialFeast(CorpusChristi.Day - 1, new BasicCalendarDate(CorpusChristi.Day, "Corpus Christi", 2, false, false, false), 2);

            //Sacred Heart
            DateTime SacredHeart = Easter.AddDays(68);
            AllDates[SacredHeart.Month - 1].AddSpecialFeast(SacredHeart.Day - 1, new BasicCalendarDate(SacredHeart.Day, "Sacred Heart of Jesus", 2, false, false, true), 2);

            //Christ The King
            DateTime CK = new DateTime(Year, 10, 1);
            CK = CK.AddMonths(1).AddDays(-1);
            while (CK.DayOfWeek != DayOfWeek.Sunday) CK = CK.AddDays(-1);
            AllDates[CK.Month - 1].AddSpecialFeast(CK.Day - 1, new BasicCalendarDate(CK.Day, "Christ The King", 1), 1);

            DateTime StJoseph = Easter.AddDays(17);
            AllDates[StJoseph.Month - 1].AddSpecialFeast(StJoseph.Day - 1, new BasicCalendarDate(StJoseph.Day, "St. Joseph Husband of the Blessed Virgin Mary, Confessor", 2), 2);

            //set all days of Lent as fast days
            setDaysOfLentAsFastDays();

        }

        private void SetVigilDaysForFeasts()
        {
            //Assumption
            DateTime Assumption = new DateTime(Year, 8, 14);
            if (Assumption.DayOfWeek == DayOfWeek.Sunday) Assumption = Assumption.AddDays(-1);
            AllDates[Assumption.Month - 1].AddSpecialFeast(Assumption.Day - 1, new BasicCalendarDate(Assumption.Day, "Vigil of the Assumption", 2, false, false, true), 1);


            //All saints
            DateTime AllSaints = new DateTime(Year, 10, 31);
            if (AllSaints.DayOfWeek == DayOfWeek.Sunday) AllSaints = AllSaints.AddDays(-1);
            AllDates[AllSaints.Month - 1].AddSpecialFeast(AllSaints.Day - 1, new BasicCalendarDate(AllSaints.Day, "Vigil of All Saints", 2, false, true, true), 2);

            //Immaculate Conception
            DateTime ImmConception = new DateTime(Year, 12, 7);
            if (ImmConception.DayOfWeek == DayOfWeek.Sunday) ImmConception = ImmConception.AddDays(-1);
            AllDates[ImmConception.Month - 1].AddSpecialFeast(ImmConception.Day - 1, new BasicCalendarDate(ImmConception.Day, "Vigil of the Immaculate Conception", 3, false, true, true), 2);
        }

        private void setDaysOfLentAsFastDays()
        {
            DateTime currentLentDay = Easter.AddDays(-46);
            for(int i = 0; i < 44; i++)
            {
                if (currentLentDay.DayOfWeek != 0)
                {
                    if(AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(4)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][4].IsFastDay = true;
                    if (AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(3)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][3].IsFastDay = true;
                    if (AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(2)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][2].IsFastDay = true;

                }
                if (currentLentDay.DayOfWeek == System.DayOfWeek.Saturday) {
                    if (AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(4)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][4].IsAbstinenceDay = true;
                    if (AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(3)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][3].IsAbstinenceDay = true;
                    if (AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].ContainsKey(2)) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1][2].IsAbstinenceDay = true;
                }
                currentLentDay = currentLentDay.AddDays(1);
            }
        }

        private DateTime NthWeekDayOfMonthYear(int month, int year, string givenWeekDay, int whichWeek)
        {
            if (month < 1 || month > 12)
            {
                throw new ArgumentOutOfRangeException("Invalid month value.");
            }

            // validate the nth value
            if (whichWeek < 0 || whichWeek > 5)
            {
                throw new ArgumentOutOfRangeException("Invalid nth value.");
            }

            // start from the first day of the month
            DateTime dt = new DateTime(year, month, 1);

            // loop until we find our first match day of the week
            while (dt.DayOfWeek.ToString() != givenWeekDay)
            {
                dt = dt.AddDays(1);
            }

            if (dt.Month != month)
            {
                // we skip to the next month, we throw an exception
                throw new ArgumentOutOfRangeException(string.Format("The given month has less than {0} {1}s", whichWeek, givenWeekDay));
            }

            // Complete the gap to the nth week
            dt = dt.AddDays((whichWeek - 1) * 7);
            return dt;
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
