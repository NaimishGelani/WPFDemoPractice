using Dapper;
using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
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
        private GetConnection getConnection;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }

        public RegistrationViewModel()
        {
            getConnection = new GetConnection();
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

        public string this[string propertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (propertyName)
                {
                    case "FirstName":
                        if (string.IsNullOrEmpty(FirstName)) errors = "firstname can not be empty";
                        //if (FirstName.Length < 3) errors = "firstname can not less then 3 characters";
                        //if (FirstName.Length > 15) errors = "firstname can not be more than 15 characters";
                        if (!IsValidName(FirstName)) errors = "FirstName must be between 2 to 15";
                        break;
                    case "LastName":
                        if (string.IsNullOrEmpty(LastName)) errors = "lastname can not be empty";
                        //if (LastName.Length < 3) errors = "lastname can not less then 3 characters";
                        //if (LastName.Length > 15) errors = "lastname can not be more than 15 characters";
                        if (!IsValidName(LastName)) errors = "LastName must be between 2 to 15";
                        break;
                    case "Password":
                        if (string.IsNullOrEmpty(Password)) errors = "password can not be empty";
                        //if (Password.Length < 8) errors = "password must be longer than 8 characters";
                        //if (password.Length > 20) errors = "password maximum limit reached";
                        if (!IsValidPassword(Password)) errors = "password must be between 8 to 20";
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

        private bool IsValidPassword(string password)
        {
            if (password.Length >= 8 && password.Length <= 20)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsValidName(string name)
        {
            if (name.Length >= 2 && name.Length <= 15)
            {
                return true;
            }
            else
            {
                return false;
            }
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
                addRegistrationCommand ??= new RelayCommand(SubmitExecute, CanSubmitExecute, false);
                return addRegistrationCommand;
            }
        }

        private void SubmitExecute(object parameter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@FirstName", FirstName);
            parameters.Add("@LastName", LastName);
            parameters.Add("@EmailId", Email);
            parameters.Add("@Password", Password);
            parameters.Add("@Address", Address);
            parameters.Add("@Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 3);

            getConnection.ExecuteStoredProcedureSingle<string>("sp_InsertUserData", parameters);
            string result = parameters.Get<string>("@Result");
            if (result == "Yes")
            {
                OnChangeWindowEvent(EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("register not successfull.");
            }
        }

        private bool CanSubmitExecute(object parameter)
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword) || string.IsNullOrEmpty(Address) || !string.Equals(Password, ConfirmPassword) || !IsValidPassword(Password) || !IsValidName(FirstName) || !IsValidName(LastName))
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

