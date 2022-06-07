using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotebookWPF
{
    // model
    public class PersonContact : INotifyPropertyChanged
    {
        private string? firstName;
        private string? lastName;
        private string? livingAddress;
        private string? email;
        private string? phoneNumber;
        private DateTime birthDate;

        public string? FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string? LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string? LivingAddress
        {
            get => livingAddress;
            set
            {
                livingAddress = value;
                OnPropertyChanged("LivingAddress");
            }
        }

        public string? Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string? PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set
            {
                birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
