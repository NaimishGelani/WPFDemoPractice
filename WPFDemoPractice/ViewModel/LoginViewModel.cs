using Dapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WPFDemoPractice.Commands;
using WPFDemoPractice.DataBase;
using WPFDemoPractice.UserControls;

namespace WPFDemoPractice.ViewModel
{
    internal class LoginViewModel : IDataErrorInfo
    {
        private GetConnection getConnection;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }

        //constructor
        public LoginViewModel()
        {
            getConnection = new GetConnection();
        }

        //property
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


        //IDataErrorInfo For The Validation.
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
                        //if (Password.Length < 8) errors = "password must be longer than 8 characters";
                        //if (password.Length > 20) errors = "password maximum limit reached";
                        if (!IsValidPassword(Password)) errors = "password must be between 8 to 20";
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

        //command 
        private ICommand? loginCommand { get; set; }

        public ICommand? LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new RelayCommand(LoginExecute, CanLoginExecute, false);
                }
                return loginCommand;
            }
        }

        private bool CanLoginExecute(object parameter)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || !IsValidPassword(Password) || !IsValidEmailAddress(Email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void LoginExecute(object parameter)
        {
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Email", Email);
                parameters.Add("@Password", Password);
                string emailId = getConnection.ExecuteStoredProcedureSingle<string>("sp_ExecuteLogin", parameters);
                if (!string.IsNullOrEmpty(emailId)) ///There's an user exist with this username and password.
                {
                    OnChangeWindowEvent(EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Please enter correct credential..");
                }
            }
        }
    }
}
