﻿using Lab01.Models;
using Lab01.Tools;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Lab01.ViewModels {
    class LoginViewModel : INotifyPropertyChanged {
        public LoginModel LModel { get; private set; }
        private ICommand _loginCommand;
        private DateTime _birthDate;

        public LoginViewModel(Storage storage) {
            LModel = new LoginModel(storage);
            BirthDate = DateTime.Today.Date;
            LModel.UInfoChanged += UIOnDateChanged;
        }

        public DateTime BirthDate {
            get { return _birthDate; }
            set {
                _birthDate = value;
                InvokePropertyChanged("BirthDate");
            }
        }

        public ICommand LoginCommand {
            get {
                if (_loginCommand == null) _loginCommand = new RelayCommand<object>(LoginExecute, LoginCanExecute);
                return _loginCommand;
            }
            set { _loginCommand = value; }
        }

        private bool LoginCanExecute(object obj) {
            return true;
        }

        private void LoginExecute(object obj) {
            LModel.CheckDate(Date);
        }

        public DateTime Date {
            get { return _birthDate; }
            set {
                if (_birthDate != value) {
                    _birthDate = value;
                    InvokePropertyChanged("Date");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void InvokePropertyChanged(string propertyName) {
            var e = new PropertyChangedEventArgs(propertyName);
            PropertyChanged?.Invoke(this, e);
        }

        private int _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        private Visibility _birthdayVisib;

        private void UIOnDateChanged(Basic info) {
            Age = info.Age;
            WesternZodiac = info.WesternZodiac;
            ChineseZodiac = info.ChineseZodiac;
            BirthdayVisib = info.isBirthdayToday ? Visibility.Visible : Visibility.Collapsed;
        }

        public Visibility BirthdayVisib {
            get { return _birthdayVisib; }
            set {
                if (_birthdayVisib != value) {
                    _birthdayVisib = value;
                    InvokePropertyChanged("BirthdayVisib");
                }
            }
        }

        public int Age {
            get { return _age; }
            set {
                if (_age != value) {
                    _age = value;
                    InvokePropertyChanged("Age");
                }
            }
        }

        public string WesternZodiac {
            get { return _westernZodiac; }
            set {
                if (_westernZodiac != value) {
                    _westernZodiac = value;
                    InvokePropertyChanged("WesternZodiac");
                }
            }
        }

        public string ChineseZodiac {
            get { return _chineseZodiac; }
            set {
                if (_chineseZodiac != value) {
                    _chineseZodiac = value;
                    InvokePropertyChanged("ChineseZodiac");
                }
            }
        }
    }
}