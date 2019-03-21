using Lab01.Manager;
using System;
using System.Windows;

namespace Lab01.Models {
    class LoginModel {
        private readonly Storage _storage;
        public event Action<Basic> UInfoChanged;

        public LoginModel(Storage storage) {
            _storage = storage;
            storage.InfoChanged += OnInfoChanged;
        }

        private void OnInfoChanged(Basic info) {
            UInfoChanged?.Invoke(info);
        }

        bool isBirthday(DateTime date) {
            if (DateTime.Today.Date.Day == date.Date.Day && DateTime.Today.Date.Month == date.Date.Month) return true;
            else return false;
        }

        public void CheckDate(DateTime date) {
            var age = DateTime.Today.Date.Year - date.Date.Year;
            if (date > DateTime.Today.AddYears(-age)) age--;
            if (age < 0) MessageBox.Show("Помилка. Ви ще не народилися.");
            else if (age >= 135) MessageBox.Show("Помилка. Ви вже повинні були померти.");
            else {
                if (isBirthday(date.Date)) MessageBox.Show("Вітаємо з днем народження!");
                Basic info = new Basic {
                    Age = age,
                    WesternZodiac = FindWestZodiac(date),
                    ChineseZodiac = FindChineseZodiac(date.Year),
                    isBirthdayToday = isBirthday(date.Date)
                };
                
                _storage.ChangeInfo(info);
            }
        }

        private string FindWestZodiac(DateTime date) {
            var day = date.Day;
            var month = date.Month;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 20)) return "Овен";
            if ((month == 4 && day >= 21) || (month == 5 && day <= 20)) return "Тілець";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 21)) return "Близнюки";
            if ((month == 6 && day >= 22) || (month == 7 && day <= 22)) return "Рак";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 23)) return "Лев";
            if ((month == 8 && day >= 24) || (month == 9 && day <= 23)) return "Діва";
            if ((month == 9 && day >= 24) || (month == 10 && day <= 22)) return "Терези";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 22)) return "Скорпіон";
            if ((month == 11 && day >= 23) || (month == 12 && day <= 21)) return "Стрілець";
            if ((month == 12 && day >= 22) || (month == 1 && day <= 20)) return "Козеріг";
            if ((month == 1 && day >= 21) || (month == 2 && day <= 19)) return "Водолій";
            if ((month == 2 && day >= 20) || (month == 3 && day <= 20)) return "Риби";
            return "Error!";
        }

        private string FindChineseZodiac(int year) {
            var modY = year % 12;
            switch (modY) {
                case 0: return "Мавпа";
                case 1: return "Півень";
                case 2: return "Собака";
                case 3: return "Свиня";
                case 4: return "Пацюк";
                case 5: return "Бик";
                case 6: return "Тигр";
                case 7: return "Кролик";
                case 8: return "Дракон";
                case 9: return "Змія";
                case 10: return "Кінь";
                case 11: return "Вівця";
                default: return "Error!";
            }
        }
    }
}