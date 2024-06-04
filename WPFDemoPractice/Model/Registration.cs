using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoPractice.Model
{
    internal class Registration  :INotifyPropertyChanged
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }

            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName;

        public string LastName
        {
            get { return lastName; }

            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }

        }

        private string password;

        public string Password
        {
            get { return password; }

            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string confirmPassword;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                OnPropertyChanged(nameof(ConfirmPassword));
            }
        }


        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler ph = PropertyChanged;
            if (ph != null)
            {
                ph(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
