﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BillingManagement.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private string name;
        private string lastName;
        private string address;
        private string city;
        private string province;
        private string postalCode;
        private string picturePath;
        private string contactInfo;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        public string LastName { get => lastName; 
            set
            {
                lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }
        public string Address { get => address; 
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public string City { get => city;
            set
            {
                city = value;
                OnPropertyChanged();
            }
        }
        public string Province { get => province;
            set
            {
                province = value;
                OnPropertyChanged();
            }
        }
        public string PostalCode { get => postalCode;
            set
            {
                postalCode = value;
                OnPropertyChanged();
            }
        }
        public string PicturePath { get => picturePath;
            set
            {
                picturePath = value;
                OnPropertyChanged();
            }
        }

        public string ContactInfo
        {
            get => contactInfo;
            set
            {
                contactInfo = value;
                OnPropertyChanged();
            }
        }

        public string Info => $"{LastName}, {Name}";

        public Customer()
        {
            PicturePath = "images/user.png";
        }

        public ObservableCollection<ContactInfo> ContactInfos { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
