using Lab01.Manager;
using System;
using System.Windows;

namespace Lab01.Models
{
    class LoginModel
    {
        public readonly Storage _storage;
        public event Action<Info> UInfoChanged;

        public LoginModel(Storage storage)
        {
            _storage = storage;
            storage.InfoChanged += OnInfoChanged;
        }

        private void OnInfoChanged(Info info)
        {
            UInfoChanged?.Invoke(info);
        }

        public bool isBirthday(DateTime date)
        {
            if (DateTime.Today.Date.Day == date.Date.Day && DateTime.Today.Date.Month == date.Date.Month)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        enum WestZodiacSigns
        {
            Aries = 1,
            Taurus,
            Gemini,
            Cancer,
            Leo,
            Virgo,
            Libra,
            Scorpio,
            Sagittarius,
            Capricorn,
            Aquarius,
            Pisces
        };

        public string FindWestZodiac(DateTime date) {
            var day = date.Day;
            var month = date.Month;
            WestZodiacSigns Zodiac;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20))
            {
                Zodiac = WestZodiacSigns.Aries;
            }
            else if ((month == 4 && day >= 21) || (month == 5 && day <= 20))
            {
                Zodiac = WestZodiacSigns.Taurus;
            }
            else if ((month == 5 && day >= 21) || (month == 6 && day <= 21))
            {
                Zodiac = WestZodiacSigns.Gemini;
            }
            else if ((month == 6 && day >= 22) || (month == 7 && day <= 22))
            {
                Zodiac = WestZodiacSigns.Cancer;
            }
            else if ((month == 7 && day >= 23) || (month == 8 && day <= 23))
            {
                Zodiac = WestZodiacSigns.Leo;
            }
            else if ((month == 8 && day >= 24) || (month == 9 && day <= 23))
            {
                Zodiac = WestZodiacSigns.Virgo;
            }
            else if ((month == 9 && day >= 24) || (month == 10 && day <= 22))
            {
                Zodiac = WestZodiacSigns.Libra;
            }
            else if ((month == 10 && day >= 23) || (month == 11 && day <= 22))
            {
                Zodiac = WestZodiacSigns.Scorpio;
            }
            else if ((month == 11 && day >= 23) || (month == 12 && day <= 21))
            {
                Zodiac = WestZodiacSigns.Sagittarius;
            }
            else if((month == 12 && day >= 22) || (month == 1 && day <= 20))
            {
                Zodiac = WestZodiacSigns.Capricorn;
            }
            else if((month == 1 && day >= 21) || (month == 2 && day <= 19))
            {
                Zodiac = WestZodiacSigns.Aquarius;
            }
            else if ((month == 2 && day >= 20) || (month == 3 && day <= 20))
            {
                Zodiac = WestZodiacSigns.Pisces;
            }
            else
            {
                return "Error!";
            }
            return Zodiac.ToString();
        }

        enum AsianZodiacSigns
        {
            Monkey = 1,
            Rooster,
            Dog,
            Pig,
            Rat,
            Ox,
            Tiger,
            Rabbit,
            Dragon,
            Snake,
            Horse,
            Ram
        };

        public string FindChineseZodiac(int year) {
            var modY = year % 12;
            AsianZodiacSigns Zodiac;
            switch (modY) {
                case 0: Zodiac = AsianZodiacSigns.Monkey; break;
                case 1: Zodiac = AsianZodiacSigns.Rooster; break;
                case 2: Zodiac = AsianZodiacSigns.Dog; break;
                case 3: Zodiac = AsianZodiacSigns.Pig; break;
                case 4: Zodiac = AsianZodiacSigns.Rat; break;
                case 5: Zodiac = AsianZodiacSigns.Ox; break;
                case 6: Zodiac = AsianZodiacSigns.Tiger; break;
                case 7: Zodiac = AsianZodiacSigns.Rabbit; break;
                case 8: Zodiac = AsianZodiacSigns.Dragon; break;
                case 9: Zodiac = AsianZodiacSigns.Snake; break;
                case 10: Zodiac = AsianZodiacSigns.Horse; break;
                case 11: Zodiac = AsianZodiacSigns.Ram; break;
                default: return "Error!";
            }
            return Zodiac.ToString();
        }
    }
}
