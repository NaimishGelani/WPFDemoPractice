using Microsoft.Identity.Client.NativeInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WPFDemoPractice.ViewModel
{
    internal partial class RegistrationViewModel : IDataErrorInfo
    {
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
    }
}

