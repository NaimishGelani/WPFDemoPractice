using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFDemoPractice.Commands;
using WPFDemoPractice.DataBase;
using WPFDemoPractice.Model;

namespace WPFDemoPractice.ViewModel
{
    internal partial class RegistrationViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private InsertData insertData;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }

        public RegistrationViewModel()
        {
            insertData = new InsertData();
        }

        private string firstName = string.Empty;

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        private string lastName = string.Empty;

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        private string email = string.Empty;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private string password = string.Empty;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string confirmPassword = string.Empty;

        public string ConfirmPassword
        {
            get
            {
                return confirmPassword;
            }
            set
            {
                confirmPassword = value;
                NotifyPropertyChanged("ConfirmPassword");
            }
        }

        private string address = string.Empty;


        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
                NotifyPropertyChanged("Address");
            }
        }

        public string Error => string.Empty;

        public string this[string PropertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (PropertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) errors = "firstname can not be empty";
                        if (FirstName.Length < 3) errors = "firstname can not less then 3 characters";
                        if (FirstName.Length > 15) errors = "firstname can not be more than 15 characters";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName)) errors = "lastname can not be empty";
                        if (LastName.Length < 3) errors = "lastname can not less then 3 characters";
                        if (LastName.Length > 15) errors = "lastname can not be more than 15 characters";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password)) errors = "password can not be empty";
                        if (Password.Length < 8) errors = "password must be longer than 8 characters";
                        if (password.Length > 20) errors = "password maximum limit reached";
                        break;
                    case "ConfirmPassword":
                        if (string.IsNullOrEmpty(ConfirmPassword)) errors = "confirmpassword can not be empty";
                        if (!ConfirmPassword.Equals(Password)) errors = "does not match with your password";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "email can not be Empty";
                        if (!IsValidEmailAddress(Email)) errors = "not a valid email address";
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address)) errors = "Address can not be empty";
                        if (Address.Length < 3) errors = "address can not less then 3 characters";
                        if (Address.Length > 50) errors = "address can not more then 50 characters";
                        break;
                    default:
                        errors = string.Empty;
                        break;
                }

                return errors;
            }
        }

        private bool IsValidEmailAddress(string emailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(emailAddress, regexPattern);
        }


        //private Registration registration;

        //public Registration Registration
        //{
        //    get { return registration; }
        //    set
        //    {
        //        registration = value;
        //        NotifyPropertyChanged("Registration");
        //    }
        //}

        //private ObservableCollection<Registration> registrations;

        //public ObservableCollection<Registration> Registrations
        //{
        //    get { return registrations; }
        //    set
        //    {
        //        registrations = value;
        //        NotifyPropertyChanged("Registrations");
        //    }
        //}




        private ICommand? addRegistrationCommand { get; set; }

        public ICommand? AddRegistrationCommand
        {
            get
            {
                addRegistrationCommand ??= new RelayCommand(SubmitExecute, canSubmitExecute, false);
                return addRegistrationCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            Registration registration = new()
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Address = Address,
                Password = Password
            };
            bool isSave = insertData.RegistrationData(registration);
            if (isSave)
            {
                OnChangeWindowEvent(EventArgs.Empty);
            }
        }

        private bool canSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrEmpty(Address))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged;


        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

