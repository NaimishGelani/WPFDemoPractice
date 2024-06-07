using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Interop;
using WPFDemoPractice.Commands;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using WPFDemoPractice.DataBase;
using System.Windows;
using System.Collections.ObjectModel;
using WPFDemoPractice.Model;

namespace WPFDemoPractice.ViewModel
{
    internal class StudentFormViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        private GetConnection getConnection;


        public StudentFormViewModel()
        {
            getConnection = new GetConnection();
            StudentList = StudentData();
        }

        private DateTime _today = DateTime.Now.Date;
        public DateTime Today
        {
            get
            { return _today; }

            set { _today = value; }
        }

        private string _studentName = string.Empty;

        public string StudentName
        {
            get { return _studentName; }
            set { _studentName = value; }
        }

        private string _fatherName = string.Empty;

        public string FatherName
        {
            get { return _fatherName; }
            set { _fatherName = value; }
        }

        private string _surname = string.Empty;
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private DateTime _dob = DateTime.Now.Date;
        public DateTime Dob
        {
            get { return _dob; }
            set { _dob = value; }
        }

        private int _age = 0;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private string _gender = "Male";
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _contactNo = string.Empty;
        public string ContactNo
        {
            get { return _contactNo; }
            set { _contactNo = value; }
        }

        private int _standard = 0;
        public int Standard
        {
            get { return _standard; }
            set { _standard = value; }
        }


        /// <summary>
        /// Validation .
        /// </summary>
        public string Error => string.Empty;

        public string this[string propertyName]
        {
            get
            {
                string errors = string.Empty;
                switch (propertyName)
                {
                    case "StudentName":
                        if (string.IsNullOrEmpty(StudentName)) errors = "firstname can not be empty";
                        if (!IsValidName(StudentName)) errors = "StudentName must be between 2 to 15";
                        break;
                    case "Surname":
                        if (string.IsNullOrEmpty(Surname)) errors = "Surname can not be empty";
                        if (!IsValidName(Surname)) errors = "Surname must be between 2 to 15";
                        break;
                    case "FatherName":
                        if (string.IsNullOrEmpty(FatherName)) errors = "Fathername can not be empty";
                        if (!IsValidName(FatherName)) errors = "Fathername must be between 2 to 15";
                        break;
                    case "Age":
                        if (Age == 0) errors = "Age can not be empty";
                        if (!IsValidAge(Age)) errors = "Age must be between 5 to 17 ";
                        break;
                    case "ContactNo":
                        if (string.IsNullOrEmpty(ContactNo)) errors = "Contact No can not be empty";
                        if (!IsValidNumber(ContactNo)) errors = "Please enter valid contact number.";
                        break;
                    case "Address":
                        if (string.IsNullOrEmpty(Address)) errors = "Address can not be empty";
                        if (!IsValidAddress(Address)) errors = "address must be between 3 t0 50 characters";
                        break;
                    case "Standard":
                        if (Standard == 0) errors = "Standard can not be empty";
                        if (!IsValidStandard(Standard)) errors = "Standard must be between 1 to 12";
                        break;
                }
                return errors;
            }
        }

        private bool IsValidName(string name)
        {
            return (name.Length >= 2 && name.Length <= 15);
        }

        private bool IsValidAge(int age)
        {
            return (age >= 5 && age <= 17);
        }

        private bool IsValidNumber(string number)
        {
            string regexPattern = @"^[6-9]\d{9}$";
            return (Regex.IsMatch(number, regexPattern));
        }

        private bool IsValidStandard(int standard)
        {
            return (standard > 0 && standard <= 12);
        }

        private bool IsValidAddress(string address)
        {
            return (address.Length >= 3 && address.Length <= 50);
        }



        /// <summary>
        /// student List
        /// </summary>

        private ObservableCollection<StudentsModel> studentList = new() ;

        public ObservableCollection<StudentsModel> StudentList
        {
            get
            {
                return studentList;
            }
            set
            {
                studentList = value;
                OnChangedProperty("StudentList");
            }
        }


        public ObservableCollection<StudentsModel> StudentData()
        {
            DynamicParameters dynamicParameters = new();
            return getConnection.ExecuteStoredProcedure<StudentsModel>("sp_GetStudentDataList", dynamicParameters);
        }

        /// <summary>
        /// Create command for Save Butoon.
        /// </summary>
        private ICommand? addStudentCommand { get; set; }
        public ICommand? AddStudentCommand
        {
            get
            {
                addStudentCommand = new RelayCommand(SaveExecute, CanSaveExecute, false);
                return addStudentCommand;
            }
        }

        private void SaveExecute(object param)
        {
            DynamicParameters parameters = new();
            parameters.Add("@StudentName", StudentName);
            parameters.Add("@Surname", Surname);
            parameters.Add("@FatherName", FatherName);
            parameters.Add("@Age", Age);
            parameters.Add("@Dob", Dob);
            parameters.Add("@Gender", Gender);
            parameters.Add("@Address", Address);
            parameters.Add("@ContactNo", ContactNo);
            parameters.Add("@Standard", Standard);
            parameters.Add("@Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 3);
            getConnection.ExecuteStoredProcedureSingle<string>("sp_InsertStudentData", parameters);
            string result = parameters.Get<string>("@Result");
            if (result == "Yes")
            {
                MessageBox.Show("Successfully Added Data.");
                studentList = StudentData();
                OnChangedProperty("StudentList");
            }
            else
            {
                MessageBox.Show("error while storing data in database.");
            }
        }

        private bool CanSaveExecute(object parameter)
        {
            if (string.IsNullOrEmpty(StudentName) || string.IsNullOrEmpty(Surname) || string.IsNullOrEmpty(FatherName) || string.IsNullOrEmpty(ContactNo) || string.IsNullOrEmpty(Address) || !IsValidNumber(ContactNo) || !IsValidStandard(Standard) || !IsValidAge(Age) || !IsValidAddress(Address) || !IsValidName(Surname) || !IsValidName(FatherName) || !IsValidName(StudentName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnChangedProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
