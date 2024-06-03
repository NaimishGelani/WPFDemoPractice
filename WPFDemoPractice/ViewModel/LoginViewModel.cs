using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WPFDemoPractice.ViewModel
{
    internal class LoginViewModel : IDataErrorInfo
    {

        private string email= string.Empty;

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



        public string Error => string.Empty;

        public string this[string PropertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (PropertyName)
                {
                    case "Password":
                        if (string.IsNullOrEmpty(Password)) errors = "password can not be empty";
                        if (Password.Length < 8) errors = "password must be longer than 8 characters";
                        if (password.Length > 20) errors = "password maximum limit reached";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "email can not be Empty";
                        if (!IsValidEmailAddress(Email)) errors = "not a valid email address";
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
