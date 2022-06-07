using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace NotebookWPF
{
    public class NoteViewModel : INotifyPropertyChanged
    {
        private PersonContact? selectedContact; // contact which is selected in contact-list
        public PersonContact? SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged("SelectedContact");
            }
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        PersonContact contact = new();
                        Contacts?.Insert(0, contact);
                        SelectedContact = contact;
                    }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        PersonContact? contact = obj as PersonContact;
                        if (contact != null)
                        {
                            Contacts?.Remove(contact);
                        }
                    },
                    (obj) => Contacts?.Count > 0));
            }
        }

        public ObservableCollection<PersonContact>? Contacts { get; set; }

        public NoteViewModel()
        {
            Contacts = new ObservableCollection<PersonContact>()
            {
                new PersonContact
                {
                    FirstName = "Andrew",
                    LastName = "Johnson",
                    LivingAddress = "5230 Newell Road",
                    Email = "anjohnson@gmail.com",
                    PhoneNumber = "+7-955-789-4564",
                    BirthDate = DateTime.Parse("05.03.1999")
                },
                new PersonContact
                {
                    FirstName = "Ann",
                    LastName = "Weissman",
                    LivingAddress = "5234 West Boulevard",
                    Email = "aweiss@somemail.com",
                    PhoneNumber = "+1-945-001-2928",
                    BirthDate = DateTime.Parse("11.02.1978")
                },
                new PersonContact
                {
                    FirstName = "Robert",
                    LastName = "Marston",
                    LivingAddress = "4342 Maxwell Avenue",
                    Email = "robertmarst@gmail.com",
                    PhoneNumber = "+5-323-656-8682",
                    BirthDate = DateTime.Parse("11.11.1998")
                }
            };
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
