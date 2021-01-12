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
                    new BasicCalendarDate(1, "Circumcision of the Lord", true),
                    new BasicCalendarDate(2),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "S Telesphorus, Pope Martyr"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "Com. S Hyginus, Pope Martyr"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "S Hilary, Bishop Confessor Doctor; S Felix, Martyr"),
                    new BasicCalendarDate(15, "S Paul, Confessor; S Maurus Abbot"),
                    new BasicCalendarDate(16, "S Marcellus, Pope Martyr"),
                    new BasicCalendarDate(17, "S Antony, Abbot"),
                    new BasicCalendarDate(18, "Chair of S Peter Ap at Rome; S Paul Apostle; S Prisca Virgin Martyr"),
                    new BasicCalendarDate(19, "SS Marius & Comp., Martyrs; S Canute, King Martyr"),
                    new BasicCalendarDate(20, "S Fabianus, Pope Martyr; S Sebastian, Martyr"),
                    new BasicCalendarDate(21, "S Agnes, Virgin Martyr"),
                    new BasicCalendarDate(22, "SS Vincent & Anastasius, Martyrs"),
                    new BasicCalendarDate(23, "S Raymund of Peñafort, Confessor; S Emerentiana, Virgin Martyr"),
                    new BasicCalendarDate(24, "S Timothy, Bishop Martyr"),
                    new BasicCalendarDate(25, "Conversion of S Paul Apostle; S Peter Apostle"),
                    new BasicCalendarDate(26, "S Polycarp, Bishop Martyr"),
                    new BasicCalendarDate(27, "S John Chrysostom, Bishop Confessor Doctor"),
                    new BasicCalendarDate(28, "S Peter Nolasco, Confessor"),
                    new BasicCalendarDate(29, "S Francis of Sales, Bishop Confessor Doctor"),
                    new BasicCalendarDate(30, "S Martina, Virgin Martyr"),
                    new BasicCalendarDate(30, "S John Bosco, Confessor")
                }
            ));

            //February saints
            AllDates.Add(new Month(
                "February",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "S Ignatius"),
                    new BasicCalendarDate(2, "Purification of the Blessed Virgin Mary"),
                    new BasicCalendarDate(3, "S Blase"),
                    new BasicCalendarDate(4, "S Andrew Corsini"),
                    new BasicCalendarDate(5, "S Agatha"),
                    new BasicCalendarDate(6, "S Titus / S Dorothea"),
                    new BasicCalendarDate(7, "S Romuald"),
                    new BasicCalendarDate(8, "S John of Matha"),
                    new BasicCalendarDate(9, "S Cyril / S Apollonia"),
                    new BasicCalendarDate(10, "S Scholastica"),
                    new BasicCalendarDate(11, "Com. S Hyginus, Pope Martyr"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "S Valentine, Martyr"),
                    new BasicCalendarDate(15, "SS Faustinus & Iovita, Martyrs"),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18, "S Simeon, Bishop Martyr"),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21),
                    new BasicCalendarDate(22, "Chair of S Peter Ap at Antioch; S Paul, Apostle"),
                    new BasicCalendarDate(23, "S Peter Damian, Bishop Confessor Doctor"),
                    new BasicCalendarDate(24),
                    new BasicCalendarDate(25, "S Matthias, Apostle"),
                    new BasicCalendarDate(26),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28, "S Gabriel of the Sorrowful Virgin, Confessor"),
                    new BasicCalendarDate(29)
                }
            ));

            //March saints
            AllDates.Add(new Month(
                "March",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "S Casimir, Confessor; S Lucius, Pope Martyr"),
                    new BasicCalendarDate(5),
                    new BasicCalendarDate(6, "SS Perpetua & Felicitas, Martyrs"),
                    new BasicCalendarDate(7, "S Thomas Aquinas, Confessor Doctor"),
                    new BasicCalendarDate(8, "S John of God, Confessor"),
                    new BasicCalendarDate(9, "S Francesca, Widow"),
                    new BasicCalendarDate(10, "Forty Martyrs"),
                    new BasicCalendarDate(11),
                    new BasicCalendarDate(12, "S Gregory, Confessor Doctor"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17, "S Patrick, Bishop Confessor"),
                    new BasicCalendarDate(18, "S Cyril, Bishop Confessor Doctor"),
                    new BasicCalendarDate(19, "S Joseph, Husband of the Blessed Virgin Mary, Confessor"),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21, "S Benedict, Abbot"),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "S Gabriel Archangel"),
                    new BasicCalendarDate(25, "Annunciation to the Blessed Virgin Mary"),
                    new BasicCalendarDate(26),
                    new BasicCalendarDate(27, "S John of Damascus, Confessor Doctor"),
                    new BasicCalendarDate(28, "S John of Capestrano, Confessor"),
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
                    new BasicCalendarDate(2, "S Francis of Paola, Confessor"),
                    new BasicCalendarDate(3, "Seven Sorrows of the Blessed Virgin Mary"),
                    new BasicCalendarDate(4, "S Isidore, Bishop Confessor Doctor"),
                    new BasicCalendarDate(5, "S Vincent Ferrer, Confessor"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "S Leo, Pope Confessor Doctor"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "S Hermenegild, Martyr"),
                    new BasicCalendarDate(14, "S Justin, Martyr; SS Tiburtius & Comp., Martyrs"),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17, "S Anicetus, Pope Martyr"),
                    new BasicCalendarDate(18),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21, "S Anselm, Bishop Confessor Doctor"),
                    new BasicCalendarDate(22, "SS Soter and Caius, Popes Martyrs"),
                    new BasicCalendarDate(23, "S George, Martyr"),
                    new BasicCalendarDate(24, "S Fidelis of Sigmaringen, Martyr"),
                    new BasicCalendarDate(25, "S Mark, Evangelist"),
                    new BasicCalendarDate(26, "SS Cletus & Marcellinus, Popes Martyrs"),
                    new BasicCalendarDate(27, "S Peter Canisius, Confessor Doctor"),
                    new BasicCalendarDate(28, "S Paul of the Cross, Confessor; S Vitalis, Martyr"),
                    new BasicCalendarDate(29, "S Joseph Husband of the Blessed Virgin Mary, Confessor; S Peter, Martyr"),
                    new BasicCalendarDate(30, "S Catherine of Siena, Virgin")
                }
            ));

            //May saints
            AllDates.Add(new Month(
                "May",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "SS Philip & James, Apostles"),
                    new BasicCalendarDate(2, "S Athanasius, Bishop Confessor Doctor"),
                    new BasicCalendarDate(3, "Finding of the Holy Cross; SS Alexander & Comp., Martyrs"),
                    new BasicCalendarDate(4, "S Monica, Widow"),
                    new BasicCalendarDate(5, "S Pius, Pope Confessor"),
                    new BasicCalendarDate(6, "S John Apostle before the Latin gate"),
                    new BasicCalendarDate(7, "S Stanislaus, Bishop Martyr"),
                    new BasicCalendarDate(8, "Apparition of S Michael Archangel"),
                    new BasicCalendarDate(9, "S Gregory of Nazianzus, Bishop Confessor Doctor"),
                    new BasicCalendarDate(10, "S Antoninus, Bishop Confessor; SS Gordianus & Epimachus Martyrs"),
                    new BasicCalendarDate(11),
                    new BasicCalendarDate(12, "SS Nereus & Comp., Martyrs"),
                    new BasicCalendarDate(13 , "S Robert Bellarmine, Bishop Confessor Doctor"),
                    new BasicCalendarDate(14, "S Boniface, Confessor"),
                    new BasicCalendarDate(15, "S John Baptist de la Salle, Confessor"),
                    new BasicCalendarDate(16, "S Ubaldus, Bishop Confessor"),
                    new BasicCalendarDate(17, "S Paschal Baylon, Confessor"),
                    new BasicCalendarDate(18, "S Venantius, Martyr"),
                    new BasicCalendarDate(19, "S Peter Celestine, Pope Confessor"),
                    new BasicCalendarDate(20, "S Bernardinus of Siena, Confessor"),
                    new BasicCalendarDate(21),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24),
                    new BasicCalendarDate(25, "S Gregory, Pope Confessor; S Urbanus, Pope Martyr"),
                    new BasicCalendarDate(26, "S Philip Neri, Confessor; S Eleutherius, Pope Martyr"),
                    new BasicCalendarDate(27, "S Bede, Confessor Doctor; S John Pope Martyr"),
                    new BasicCalendarDate(28, "S Augustine, Bishop Confessor"),
                    new BasicCalendarDate(29, "S Mary Magdalen de’ Pazzi, Virgin"),
                    new BasicCalendarDate(30, "S Felix, Pope Martyr"),
                    new BasicCalendarDate(31, "S Angela Merici, Virigin; S Petronilla, Virgin")
                }
            ));

            //June saints
            AllDates.Add(new Month(
                "June",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2, "S Marcellinus & Comp., Martyrs"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4, "S Francis Caracciolo, Confessor"),
                    new BasicCalendarDate(5, "S Bonifatius, Bishop Martyr"),
                    new BasicCalendarDate(6, "St. Norbert, Bishop Confessor"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8),
                    new BasicCalendarDate(9, "SS Primus & Felicianus, Martyrs"),
                    new BasicCalendarDate(10, "S Margaret, Queen Widow"),
                    new BasicCalendarDate(11, "S Barnabas, Apostle"),
                    new BasicCalendarDate(12, "S John of Sahagún, Confessor; SS Basilides & Comp., Martyrs"),
                    new BasicCalendarDate(13, "S Antony of Padua, Confessor"),
                    new BasicCalendarDate(14, "S Basil, Bishop Confessor Doctor"),
                    new BasicCalendarDate(15, "SS Vitus & Comp., Martyrs"),
                    new BasicCalendarDate(16),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18, "S Ephrem, Doctor Confessor; SS Marcus & Marcellianus, Martyrs"),
                    new BasicCalendarDate(19, "S Juliana of Falconeri, Virgin; SS Gervasius & Protasius, Martyrs"),
                    new BasicCalendarDate(20, "S Silverius, Martyr"),
                    new BasicCalendarDate(21, "S Aloysius of Gonzaga, Confessor"),
                    new BasicCalendarDate(22, "S Paulinus, Bishop Confessor"),
                    new BasicCalendarDate(23, "S Raymund of Peñafort C sd / S Emerentiana VM"),
                    new BasicCalendarDate(24, "Birth of S John the Baptist, Confessor"),
                    new BasicCalendarDate(25, "S Gulielmus, Abbot"),
                    new BasicCalendarDate(26, "SS John & Paul, Martyrs"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28, "S Irenaeus, Bishop Martyr"),
                    new BasicCalendarDate(29, "SS Peter & Paul, Apostles"),
                    new BasicCalendarDate(30, "S Paul Apostle; S Peter, Apostle")
                }
            ));

            //July saints
            AllDates.Add(new Month(
                "July",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "Most Precious Blood of Jesus"),
                    new BasicCalendarDate(2, "Visitation of the Blessed Virgin Mary; SS Processus & Martinianus, Martyrs"),
                    new BasicCalendarDate(3, "S Leo, Pope Confessor"),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "S Antony Maria Zaccaria, Confessor"),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7, "SS Cyril & Methodius, Bishops Confessors"),
                    new BasicCalendarDate(8, "S Elizabeth, Queen Widow"),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10, "Seven Brothers, Martyrs; SS Rufina & Secunda, Virgins Martyrs"),
                    new BasicCalendarDate(11, "S Pius, Pope Martyr"),
                    new BasicCalendarDate(12, "S John Gualbert, Abbot; SS Nabor & Felix, Martyrs"),
                    new BasicCalendarDate(13, "S Anacletus, Pope Martyr"),
                    new BasicCalendarDate(14, "S Bonaventure, Bishop Confessor Doctor"),
                    new BasicCalendarDate(15, "S Henry, King Confessor"),
                    new BasicCalendarDate(16, "Blessed Virgin Mary of Mount Carmel"),
                    new BasicCalendarDate(17, "S Alexius Confessor"),
                    new BasicCalendarDate(18, "S Camillus of Lellis, Confessor; SS Symphorosa & her seven sons, Martyrs"),
                    new BasicCalendarDate(19, "S Vincent of Paul, Confessor"),
                    new BasicCalendarDate(20, "S Jerome Æmilianus; Confessor; S Margaret, Virgin Martyr"),
                    new BasicCalendarDate(21, "S Praxedes, Virgin"),
                    new BasicCalendarDate(22, "S Mary Magdalen Penitent"),
                    new BasicCalendarDate(23, "S Apollinaris, Bishop Martyr; S Liborius, Bishop Confessor"),
                    new BasicCalendarDate(24, "S Christina, Virgin Martyr"),
                    new BasicCalendarDate(25, "S Christopher, Martyr"),
                    new BasicCalendarDate(26, "S Anne Mother of the Blessed Virgin Mary"),
                    new BasicCalendarDate(27, "S Pantaleon, Martyr"),
                    new BasicCalendarDate(28, "SS Nazarius & Comp., Martyrs"),
                    new BasicCalendarDate(29, "S Martha, Virgin; SS Felix &c Comp., Martyrs"),
                    new BasicCalendarDate(30, "SS Abdon & Sennen, Martyrs"),
                    new BasicCalendarDate(31, "S Ignatius, Confesor")
                }
            ));
            AllDates[6].MovableDays.Add(24, new BasicCalendarDate(24, "S James, Apostle", false, false, false, 1));

            //August saints
            AllDates.Add(new Month(
                "August",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "S Peter Apostle in Chains; S Paul Apostle; Holy Machabees, Martyrs"),
                    new BasicCalendarDate(2, "S Alphonsus de Liguori, Bishop Confessor Doctor; S Stephen, Priest Martyr"),
                    new BasicCalendarDate(3, "Finding of St. Stephen Martyr"),
                    new BasicCalendarDate(4, "St. Dominic, Confessor"),
                    new BasicCalendarDate(5, "Dedication of S Mary at the snow"),
                    new BasicCalendarDate(6, "Transfiguration of the Lord; SS Xystus & Comp., Martyrs"),
                    new BasicCalendarDate(7, "S Cajetan, Confessor; S Donatus Bishop Martyr"),
                    new BasicCalendarDate(8, "SS Cyriacus & Comp., Martyrs"),
                    new BasicCalendarDate(9, "S John Vianney, Confessor; S Romanus Martyr"),
                    new BasicCalendarDate(10, "S Lawrence, Martyr"),
                    new BasicCalendarDate(11, "SS Tiburtius, Martyr & Susanna, Virgin Martyr"),
                    new BasicCalendarDate(12, "S Clare, Virgin"),
                    new BasicCalendarDate(13, "SS Hippolytus & Cassianus, Martyrs"),
                    new BasicCalendarDate(14, "S Eusebius, Confessor", false, true, true),
                    new BasicCalendarDate(15, "Assumption of the Blessed Virgin Mary", true),
                    new BasicCalendarDate(16, "S Joachim Father of the Blessed Virgin Mary, Confessor"),
                    new BasicCalendarDate(17, "S Hyacinth, Confessor"),
                    new BasicCalendarDate(18),
                    new BasicCalendarDate(19, "S John Eudes, Confessor"),
                    new BasicCalendarDate(20, "S Bernard, Confessor Doctor Abbot"),
                    new BasicCalendarDate(21, "S Jane Frances de Chantal, Widow"),
                    new BasicCalendarDate(22, "SS Timothy & Comp., Martyrs"),
                    new BasicCalendarDate(23, "S Philip Benizi, Confessor"),
                    new BasicCalendarDate(24, "S Bartholomew, Apostle"),
                    new BasicCalendarDate(25, "S Louis, King Confessor"),
                    new BasicCalendarDate(26, "S Zephyrinus, Martyr"),
                    new BasicCalendarDate(27, "S Joseph Calasanctius, Confessor"),
                    new BasicCalendarDate(28, "S Augustine, Bishop Confessor Doctor; S Hermes, Martyr"),
                    new BasicCalendarDate(29, "Beheading of S John the Baptist; S Sabina, Martyr"),
                    new BasicCalendarDate(30, "S Rose of Lima, Virgin; SS Felix & Adauctus, Martyrs"),
                    new BasicCalendarDate(31, "S Raymond Nonnatus, Confessor")
                }
            ));
            AllDates[7].MovableDays.Add(21, new BasicCalendarDate(21, "Immaculate Heart of the Blessed Virgin Mary", false, false, false, 1));

            //September saints
            AllDates.Add(new Month(
                "September",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "S Ægidius Abbot; Twelve Brothers, Martyrs"),
                    new BasicCalendarDate(2, "S Stephen, King Confessor"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5, "S Lawrence Justinian Bishop Confessor"),
                    new BasicCalendarDate(6, "Epiphany of the Lord"),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8, "Birth of the Blessed Virgin Mary; S Hadrian Martyr"),
                    new BasicCalendarDate(9, "S Gorgonius"),
                    new BasicCalendarDate(10, "S Nicholas of Tolentino, Confessor"),
                    new BasicCalendarDate(11, "S Protus & Hyacinthus, Martyrs"),
                    new BasicCalendarDate(12, "Most Holy Name of the Blessed Virgin Mary"),
                    new BasicCalendarDate(13),
                    new BasicCalendarDate(14, "Exaltation of the Holy Cross"),
                    new BasicCalendarDate(15, "Seven Sorrows of the Blessed Virgin Mary; S Nicomedes Martyr"),
                    new BasicCalendarDate(16, "S Cornelius Martyr; S Cyprian, Bishop Martyr; SS. Euphemia & comp., Martyrs"),
                    new BasicCalendarDate(17, "Impression of stigmata on S Francis"),
                    new BasicCalendarDate(18, "S Joseph of Cupertino, Confessor"),
                    new BasicCalendarDate(19, "SS Ianuarius & comp., Martyrs"),
                    new BasicCalendarDate(20, "SS Eustachius & comp. Martyrs"),
                    new BasicCalendarDate(21, "S Matthew, Apostle Evangelist"),
                    new BasicCalendarDate(22, "S Thomas of Villanova, Bishop Confessor; SS Mauritius & comp., Martyrs"),
                    new BasicCalendarDate(23, "S Linus, Pope Martyr; S Thecla Virgin Martyr"),
                    new BasicCalendarDate(24, "Blessed Virgin Mary of Ransom"),
                    new BasicCalendarDate(25),
                    new BasicCalendarDate(26, "SS Cyprian Martyr & Justina Virgin Martyr"),
                    new BasicCalendarDate(27, "SS Cosmas & Damian, Martyrs"),
                    new BasicCalendarDate(28, "S Wenceslaus, King Martyr"),
                    new BasicCalendarDate(29, "Dedication of S Michael Archangel"),
                    new BasicCalendarDate(30, "S Jerome, Confessor Doctor"),
                }
            ));

            //October saints
            AllDates.Add(new Month(
                "October",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "S Remigius Bishop, Confessor"),
                    new BasicCalendarDate(2, "Holy Guardian Angels"),
                    new BasicCalendarDate(3, "S Teresa of the Child Jesus V"),
                    new BasicCalendarDate(4, "S Francis Confessor"),
                    new BasicCalendarDate(5, "SS Placidus & MM"),
                    new BasicCalendarDate(6, "S Bruno, Confessor"),
                    new BasicCalendarDate(7, "Most Holy Rosary of the Blessed Virgin Mary; S Mark Confessor; SS Sergius & MM"),
                    new BasicCalendarDate(8, "S Brigid Widow"),
                    new BasicCalendarDate(9, "SS Dionysius & MM"),
                    new BasicCalendarDate(10, "S Francis Borgia Confessor"),
                    new BasicCalendarDate(11, "Motherhood of the Blessed Virgin Mary"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "S Edward, Confessor"),
                    new BasicCalendarDate(14),
                    new BasicCalendarDate(15, "S Teresa, Virgin"),
                    new BasicCalendarDate(16, "S Hedwig, Widow"),
                    new BasicCalendarDate(17, "S Margaret Mary Alacoque Virgin"),
                    new BasicCalendarDate(18, "S Luke Evangelist"),
                    new BasicCalendarDate(19, "S Peter of Alcántara Confessor"),
                    new BasicCalendarDate(20, "S John Cantius Confessor"),
                    new BasicCalendarDate(21, "S Hilarion, Abbot; SS. Ursula & Comp., Virgin Martyrs"),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "S Raphael Archangel"),
                    new BasicCalendarDate(25, "SS Chrysanthus & Daria, Martyrs"),
                    new BasicCalendarDate(26, "S Evaristus Martyr"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28, "SS Simon & Jude, Apostles"),
                    new BasicCalendarDate(29),
                    new BasicCalendarDate(30),
                    new BasicCalendarDate(31)
                }
            ));

            //November saints
            AllDates.Add(new Month(
                "November",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1, "ALL SAINTS", true),
                    new BasicCalendarDate(2, "ALL SOULS"),
                    new BasicCalendarDate(3),
                    new BasicCalendarDate(4),
                    new BasicCalendarDate(5),
                    new BasicCalendarDate(6),
                    new BasicCalendarDate(7),
                    new BasicCalendarDate(8, "com Four Martyrs"),
                    new BasicCalendarDate(9, "Dedication of the Most Holy Redeemer; S Theodorus, Martyr"),
                    new BasicCalendarDate(10, "S Andrew Avellino; S Tryphon & Comp., Martyrs"),
                    new BasicCalendarDate(11, "S Martin, Bishop Confessor; S Mennas, Martyr"),
                    new BasicCalendarDate(12),
                    new BasicCalendarDate(13, "S Didacus, Confessor"),
                    new BasicCalendarDate(14, "S Josaphat, Bishop Martyr"),
                    new BasicCalendarDate(15, "S Albert, Bishop Confessor Doctor"),
                    new BasicCalendarDate(16, "S Gertrude Virgin"),
                    new BasicCalendarDate(17, "S Gregory, Confessor"),
                    new BasicCalendarDate(18, "Dedication of SS Peter & Paul"),
                    new BasicCalendarDate(19, "S Elisabeth, Widow; S Pontianus, Martyr"),
                    new BasicCalendarDate(20, "S Felix of Valois, Confessor"),
                    new BasicCalendarDate(21, "Presentation of the Blessed Virgin Mary"),
                    new BasicCalendarDate(22, "S Cæcilia, Virgin Martyr"),
                    new BasicCalendarDate(23, "S Clement I, Pope Martyr; S Felicitas, Martyr"),
                    new BasicCalendarDate(24, "S John of the Cross, Confessor; S Chrysogonus, Martyr"),
                    new BasicCalendarDate(25, "S Catherine, Virgin Martyr"),
                    new BasicCalendarDate(26, "S Silvester, Abbot; S Peter of Alexandria, Martyr"),
                    new BasicCalendarDate(27),
                    new BasicCalendarDate(28),
                    new BasicCalendarDate(29, "S Saturninus, Martyr"),
                    new BasicCalendarDate(30, "S Andrew, Apostle")
                }
            ));

            //December saints
            AllDates.Add(new Month(
                "December",
                Year,
                new List<BasicCalendarDate>{
                    new BasicCalendarDate(1),
                    new BasicCalendarDate(2, "S Bibiana, Virgin Martyr"),
                    new BasicCalendarDate(3, "S Francis Xavier, Confessor"),
                    new BasicCalendarDate(4, "S Peter Chrysologus, Bishop Confessor Doctor; Com. S Barbara, Virgin Martyr"),
                    new BasicCalendarDate(5, "Com. S Sabbas, Abbot"),
                    new BasicCalendarDate(6, "S Nicholas, Bishop Confessor"),
                    new BasicCalendarDate(7, "S Ambrose, Bishop Confessor"),
                    new BasicCalendarDate(8, "IMMACULATE CONCEPTION", true),
                    new BasicCalendarDate(9),
                    new BasicCalendarDate(10),
                    new BasicCalendarDate(11, "S Damasus, Pope"),
                    new BasicCalendarDate(12, "Our Lady of Guadalupe"),
                    new BasicCalendarDate(13, "S Lucia, Virgin Martyr"),
                    new BasicCalendarDate(14),
                    new BasicCalendarDate(15),
                    new BasicCalendarDate(16, "S Eusebius, Bishop Martyr"),
                    new BasicCalendarDate(17),
                    new BasicCalendarDate(18),
                    new BasicCalendarDate(19),
                    new BasicCalendarDate(20),
                    new BasicCalendarDate(21, "S Thomas the Apostle"),
                    new BasicCalendarDate(22),
                    new BasicCalendarDate(23),
                    new BasicCalendarDate(24, "CHRISTMAS EVE", false, true, true),
                    new BasicCalendarDate(25, "CHRISTMAS DAY; Com. S Anastasia, Martyr", true),
                    new BasicCalendarDate(26, "S Stephen, Martyr"),
                    new BasicCalendarDate(27, "S John the Apostle"),
                    new BasicCalendarDate(28, "Holy Innocents, Martyrs"),
                    new BasicCalendarDate(29, "S Thomas Cantebury, Bishop Martyr"),
                    new BasicCalendarDate(30, "S Martina, Virgin Martyr"),
                    new BasicCalendarDate(31, "S Silvester, Pope Martyr")
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
            else if (DateTime.Compare(inputDate, Easter) == 0)
            {
                //Add Easter to List of Special feasts
                sundayName = "EASTER SUNDAY";
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
                            sundayName = "Laetare Sunday";
                            break;
                        case 3:
                            sundayName = "Fourth Sunday of Advent";
                            break;
                        case 4:
                            sundayName = "Sunday within the Octave of Christmas";
                            break;
                    }
                }
            }


            return sundayName;
        }

        public string ReturnPreHTML()
        {
            return "<!DOCTYPE html><html><head><meta name=\"viewport\" content=\"width = device-width, initial-scale=1\"><style>p{margin:0;}.special{font-weight:bold;} table {font-family: \"Century Schoolbook L\", \"Century Schoolbook\", serif; font-size: 10px; border-collapse:collapse; text-align: right; vertical-align: bottom; break-before: page; page-break-before: always;}tr.h {text-align:center;}tr.h, tr.nos {font-size: 2rem;}tr.nos td {border-top: 1px solid black; vertical-align: top;} *{font - size: 1em!important;line - height: 1!important;} tr.ss td, tr.nos td {border-left: 1px solid black; border-right: 1px solid black; height: 7vh; width: 14vw;}tr.ss {border-bottom: 1px solid black; vertical-align: bottom;}tr.wd {}</style></head><body><table style=\"break-before: page-avoid; page-break-before: avoid;\">";
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
                                (i != 1 &&
                                ((m.MovableDays.ContainsKey(monthDay - 1) && m.MovableDays[monthDay - 1].IsFastDay) ||
                                 m.SaintsList[monthDay - 1].IsFastDay)
                                ) HTML += "&#x1F37D;";

                            //if it's a abstinence day and not a Friday, show the fish symbol
                            if
                                (i != 1 && ((((currentBlockNumbers + 1) % 7 != 0) && m.MovableDays.ContainsKey(monthDay - 1) && m.MovableDays[monthDay - 1].IsAbstinenceDay) || m.SaintsList[monthDay - 1].IsAbstinenceDay)) HTML += "&#x1f41f;&#xfe0e;";

                            //if it's a Friday, show fish symbol unless its a holy day
                            else if((currentBlockNumbers + 1) % 7 == 0 && !m.SaintsList[monthDay - 1].IsHolyDay) HTML += "&#x1f41f;&#xfe0e;";
                            HTML += monthDay.ToString();
                        }
                        HTML += "</td>";
                        currentBlockNumbers++;
                    }
                    HTML += "</tr>";

                    //subrow for saints title
                    HTML += "<tr class='ss'>";
                    for (int i = 1; i <= 7; i++)
                    {
                        int monthDay = currentBlockSaints - m.FirstDay - 1;
                        HTML += "<td>";
                        //
                        if (currentBlockSaints >= m.FirstDay + 1 && monthDay < m.DaysInMonth)
                        {
                            //only show the pretitle if it's not a sunday
                            if(i != 1)
                            {
                                if (m.MovableDays.ContainsKey(monthDay) && m.MovableDays[monthDay].PreTitle.Length > 0)
                                {
                                    HTML += "<p class='special'>" + m.MovableDays[monthDay].PreTitle + "</p>";
                                }
                                if (m.SaintsList[monthDay].PreTitle.Length > 0)
                                {
                                    HTML += "<p class='special'>" + m.SaintsList[monthDay].PreTitle + "</p>";
                                }
                            }

                            string tempHTML = "";
                            bool previousTitleExists = false;
                            bool currentTitleExists = false;

                            for(int c = 1; c < 4; c++)
                            {
                                tempHTML = "";

                                if (m.MovableDays.ContainsKey(monthDay) && m.MovableDays[monthDay].Title.Length > 0 && m.MovableDays[monthDay].ImportanceLevel == c)
                                {
                                    tempHTML += m.MovableDays[monthDay].Title;
                                    currentTitleExists = true;
                                }
                                else if (m.SaintsList[monthDay].Title.Length > 0 && m.SaintsList[monthDay].ImportanceLevel == c)
                                {
                                    tempHTML += m.SaintsList[monthDay].Title;
                                    currentTitleExists = true;
                                }
                                else
                                {
                                    currentTitleExists = false;
                                }

                                if (c == 2 && i == 1)
                                {
                                    tempHTML += GetSundayFromMonthAndDay(m.MonthNumber, monthDay + 1);
                                    currentTitleExists = true;
                                }
                                if (currentTitleExists && previousTitleExists) HTML += "; ";

                                if (currentTitleExists) previousTitleExists = true;

                                HTML += tempHTML;
                            }

                           
                            //if (i == 1)
                            //{
                            //    if (!m.SaintsList[monthDay].IsHolyDay)
                            //    {
                            //        HTML += GetSundayFromMonthAndDay(m.MonthNumber, monthDay + 1);
                            //    }
                            //    if (m.SaintsList[monthDay].Title.Length > 0 && !m.SaintsList[monthDay].IsHolyDay)
                            //    {
                            //        HTML += "; ";
                            //    }
                            //}
                            //else
                            //{
                            //    if (m.MovableDays.ContainsKey(monthDay) && m.MovableDays[monthDay].PreTitle.Length > 0)
                            //    {
                            //        HTML += "<p class='special'>" + m.MovableDays[monthDay].PreTitle + "</p>";
                            //    }
                            //    if (m.SaintsList[monthDay].PreTitle.Length > 0)
                            //    {
                            //        HTML += "<p class='special'>" + m.SaintsList[monthDay].PreTitle + "</p>";
                            //    }
                            //}

                            //if (m.MovableDays.ContainsKey(monthDay) && m.MovableDays[monthDay].Title.Length > 0)
                            //{
                            //    HTML += m.MovableDays[monthDay].Title;
                            //    if (m.SaintsList[monthDay].Title.Length > 0) HTML += "; ";
                            //}

                           // HTML += m.SaintsList[monthDay].Title;
                        }
                        HTML += "</td>";
                        currentBlockSaints++;
                    }
                    HTML += "</tr>";
                }
                HTML += "</table>";
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
            AllDates[AshWednesday.Month - 1].MovableDays.Add(AshWednesday.Day - 1, new BasicCalendarDate(AshWednesday.Day, "ASH WEDNESDAY", false, true, true, 1));

            //set holy thursday - holy saturday
            DateTime HolyThursday = Easter.AddDays(-3);
            AllDates[HolyThursday.Month - 1].MovableDays.Add(HolyThursday.Day - 1, new BasicCalendarDate(HolyThursday.Day, "HOLY THURSDAY", false, true, false, 1));

            DateTime GoodFriday = Easter.AddDays(-2);
            AllDates[GoodFriday.Month - 1].MovableDays.Add(GoodFriday.Day - 1, new BasicCalendarDate(GoodFriday.Day, "GOOD FRIDAY", false, true, true, 1));

            DateTime HolySaturday = Easter.AddDays(-1);
            AllDates[HolySaturday.Month - 1].MovableDays.Add(HolySaturday.Day - 1, new BasicCalendarDate(HolySaturday.Day, "HOLY SATURDAY", false, true, true, 1));

            //set first ember day of year
            DateTime emberDay = new DateTime(Year, Easter.AddDays(-39).Month, Easter.AddDays(-39).Day);
            
            //Set ember days
            for (int i = 1; i <= 4; i++)
            {
                
                switch (i)
                {
                    case 2:
                        //the week after Pentecost
                        emberDay = new DateTime(Year, Easter.AddDays(45).Month, Easter.AddDays(45).Day);
                        break;
                    case 3:
                        //the third week of September
                        emberDay = NthWeekDayOfMonthYear(9, Year, 0, 3).AddDays(3);
                        break;
                    case 4:
                        //the third week of Advent
                        emberDay = new DateTime(Year, FirstSundayAdvent.AddDays(17).Month, FirstSundayAdvent.AddDays(17).Day);
                        break;
                }
                //set ember wednesday
                AllDates[emberDay.Month - 1].MovableDays.Add(emberDay.Day - 1, new BasicCalendarDate(emberDay.Day, "", false, true, true, 2, "Ember Wednesday"));
                //set ember friday
                AllDates[emberDay.Month - 1].MovableDays.Add(emberDay.Day + 1, new BasicCalendarDate(emberDay.Day, "", false, true, true, 2, "Ember Friday"));
                //set ember saturday
                AllDates[emberDay.Month - 1].MovableDays.Add(emberDay.Day + 2, new BasicCalendarDate(emberDay.Day, "", false, true, true, 2, "Ember Saturday"));
            }

            //Ascension Thursday
            DateTime Ascension = Easter.AddDays(39);
            AllDates[Ascension.Month - 1].MovableDays.Add(Ascension.Day - 1, new BasicCalendarDate(Ascension.Day, "ASCENSION DAY", true, false, false, 1));

            //Vigil of Pentecost
            DateTime VigilPentecost = Easter.AddDays(48);
            if(!AllDates[VigilPentecost.Month - 1].MovableDays.ContainsKey(VigilPentecost.Day - 1)) AllDates[VigilPentecost.Month - 1].MovableDays.Add(VigilPentecost.Day - 1, new BasicCalendarDate(VigilPentecost.Day, "Vigil Pentecost", false, true, true, 2));

            //Corpus Christi (Thursday after Trinity Sunday)
            DateTime CorpusChristi = Easter.AddDays(60);
            AllDates[CorpusChristi.Month - 1].MovableDays.Add(CorpusChristi.Day - 1, new BasicCalendarDate(CorpusChristi.Day, "Corpus Christi", false, false, false, 2));

            //Sacred Heart
            DateTime SacredHeart = Easter.AddDays(68);
            AllDates[SacredHeart.Month - 1].MovableDays.Add(SacredHeart.Day - 1, new BasicCalendarDate(SacredHeart.Day, "Sacred Heart of Jesus", false, false, false, 2));

            //Christ The King
            DateTime CK = new DateTime(Year, 10, 1);
            CK = CK.AddMonths(1).AddDays(-1);
            while (CK.DayOfWeek != DayOfWeek.Sunday) CK = CK.AddDays(-1);
            AllDates[CK.Month - 1].MovableDays.Add(CK.Day - 1, new BasicCalendarDate(CK.Day, "Christ The King", false, false, false, 1));

            //set all days of Lent as fast days
            setDaysOfLentAsFastDays();

        }

        private void SetVigilDaysForFeasts()
        {
            //All saints
            DateTime AllSaints = new DateTime(Year, 10, 31);
            if (AllSaints.DayOfWeek == DayOfWeek.Sunday) AllSaints = AllSaints.AddDays(-1);
            AllDates[AllSaints.Month - 1].MovableDays.Add(AllSaints.Day - 1, new BasicCalendarDate(AllSaints.Day, "Vigil of All Saints", false, true, true, 1));

            //Immaculate Conception
            DateTime ImmConception = new DateTime(Year, 12, 7);
            if (ImmConception.DayOfWeek == DayOfWeek.Sunday) ImmConception = ImmConception.AddDays(-1);
            AllDates[ImmConception.Month - 1].MovableDays.Add(ImmConception.Day - 1, new BasicCalendarDate(ImmConception.Day, "Vigil of Immaculate Conception", false, true, true, 1));
        }

        private void setDaysOfLentAsFastDays()
        {
            DateTime currentLentDay = Easter.AddDays(-46);
            for(int i = 0; i < 44; i++)
            {
                if (currentLentDay.DayOfWeek != 0) AllDates[currentLentDay.Month - 1].SaintsList[currentLentDay.Day - 1].IsFastDay = true;
                currentLentDay = currentLentDay.AddDays(1);
            }
        }

        private DateTime NthWeekDayOfMonthYear(int monthNumber, int year, int givenWeekDay, int whichWeek)
        {
            DateTime first = new DateTime(year, monthNumber, 1);
            DateTime returnDate = first;
            int firstWeekDay = (int)first.DayOfWeek - 1;

            if (firstWeekDay < givenWeekDay)
            {
                returnDate = first.AddDays(givenWeekDay - firstWeekDay);
            }
            else if(firstWeekDay > givenWeekDay)
            {
                returnDate = first.AddDays(6 + (givenWeekDay - firstWeekDay));
            }
            return returnDate.AddDays((whichWeek - 1) * 7);
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
