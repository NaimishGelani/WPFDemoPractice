using Dapper;
using System;
using System.Collections.Generic;
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

namespace WPFDemoPractice.ViewModel
{
    internal class ForgotPasswordViewModel : IDataErrorInfo, INotifyPropertyChanged
    {

        private GetConnection getConnection;
        public event EventHandler? ChangeWindowEvent;
        protected virtual void OnChangeWindowEvent(EventArgs e)
        {
            ChangeWindowEvent?.Invoke(this, e);
        }

        public ForgotPasswordViewModel()
        {
            getConnection = new GetConnection();
        }

        private string password = string.Empty;

        public string Password
        {
            get { return password; }
            set { password = value; }

        }

        private string confirmPassword = string.Empty;

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; }
        }

        private string email = string.Empty;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Error => string.Empty;

        public string this[string propertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (propertyName)
                {
                    case "Email":
                        if (string.IsNullOrEmpty(Email)) errors = "email can not be empty";
                        if (!IsValidEmailAddress(Email)) errors = "not a valid email address";
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

        private ICommand? forgotPasswordCommand { get; set; }

        public ICommand? ForgotPasswordCommand
        {
            get
            {
                if (forgotPasswordCommand == null)
                {
                    forgotPasswordCommand = new RelayCommand(ResetExecute, CanResetExecute, false);
                }
                return forgotPasswordCommand;
            }
        }

        private bool CanResetExecute(object arg)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(ConfirmPassword) || !string.Equals(Password, ConfirmPassword) || !IsValidPassword(Password) || !IsValidEmailAddress(Email))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ResetExecute(object obj)
        {

            DynamicParameters parameters = new();
            parameters.Add("@EmailId", Email);
            parameters.Add("@Password", Password);
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            getConnection.ExecuteStoredProcedureSingle<int>("sp_UpdatePassword", parameters);
            int result = parameters.Get<int>("@Result");
            if (result == 1)// password update success fully.
            {
                OnChangeWindowEvent(EventArgs.Empty);
                MessageBox.Show("Password updated successfully");
            }
            else if (result == 2) // email id not found.
            {
                MessageBox.Show("Email ID not found in data base");
            }
            else// error updating the data base.
            {
                MessageBox.Show("Error updating password");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}