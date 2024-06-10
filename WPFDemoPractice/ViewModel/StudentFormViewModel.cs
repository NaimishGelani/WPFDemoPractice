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
using System.Runtime.CompilerServices;

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

        private int _studentId = 0;

        public int StudentId
        {
            get { return _studentId; }
            set
            {
                _studentId = value;
                OnChangedProperty("StudentId");
            }
        }

        private string _studentName = string.Empty;

        public string StudentName
        {
            get { return _studentName; }
            set
            {
                _studentName = value;
                OnChangedProperty("StudentName");
            }
        }

        private string _fatherName = string.Empty;

        public string FatherName
        {
            get { return _fatherName; }
            set
            {
                _fatherName = value;
                OnChangedProperty("FatherName");
            }
        }

        private string _surname = string.Empty;
        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnChangedProperty("Surname");
            }
        }

        private DateTime _dob = DateTime.Now.Date;
        public DateTime Dob
        {
            get { return _dob; }
            set
            {
                _dob = value;

            }
        }

        private int _age = 0;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnChangedProperty("Age");
            }
        }

        private string _gender = "Male";
        public string Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnChangedProperty("Gender");
            }
        }

        private string _address = string.Empty;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnChangedProperty("Address");
            }
        }

        private string _contactNo = string.Empty;
        public string ContactNo
        {
            get { return _contactNo; }
            set
            {
                _contactNo = value;
                OnChangedProperty("ContactNo");
            }
        }

        private int _standard = 0;
        public int Standard
        {
            get { return _standard; }
            set
            {
                _standard = value;
                OnChangedProperty("Standard");
            }
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


        public StudentsModel Student { get; set; }

        /// <summary>
        /// student List
        /// </summary>

        private ObservableCollection<StudentsModel> studentList = new();

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
        /// clear command.
        /// </summary>
        private ICommand? clearCommand { get; set; }

        public ICommand? ClearCommand
        {
            get
            {
                clearCommand = new RelayCommand(ClearExecute, CanClearExecute, false);
                return clearCommand;
            }
        }

        private void ClearExecute(object parameter)
        {
            StudentId = 0;
            StudentName = string.Empty;
            FatherName = string.Empty;
            Surname = string.Empty;
            Age = 0;
            ContactNo = string.Empty;
            Address = string.Empty;
            Standard = 0;
            Gender = "Male";
            Dob = DateTime.Now.Date;
        }

        private bool CanClearExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Create Or Update Data command  for Save Butoon.
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
            parameters.Add("@StudentId", StudentId);
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
            getConnection.ExecuteStoredProcedureSingle<string>("sp_InsertOrUpdateStudentData", parameters);
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
            if (string.IsNullOrEmpty(StudentName) || string.IsNullOrEmpty(Surname) || string.IsNullOrEmpty(FatherName) || string.IsNullOrEmpty(ContactNo) || string.IsNullOrEmpty(Address) || Standard == 0 || !IsValidNumber(ContactNo) || !IsValidStandard(Standard) || !IsValidAge(Age) || !IsValidAddress(Address) || !IsValidName(Surname) || !IsValidName(FatherName) || !IsValidName(StudentName))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Update Command.
        /// </summary>
        private ICommand? updateCommand { get; set; }

        public ICommand? UpdateCommand
        {
            get
            {
                updateCommand = new RelayCommand(UpdateExecute, CanUpdateExecute, false);
                return updateCommand;
            }
        }

        private void UpdateExecute(object parameter)
        {
            EditData();
        }

        private bool CanUpdateExecute(object parameter)
        {
            return true;
        }


        public void EditData()
        {
            var student = StudentData().Where(x => x.StudentId == Student.StudentId).FirstOrDefault();
            if (student != null)
            {
                StudentId = student.StudentId;
                StudentName = student.StudentName;
                FatherName = student.FatherName;
                Surname = student.Surname;
                Age = student.Age;
                ContactNo = student.ContactNo;
                Address = student.Address;
                Standard = student.Standard;
                Gender = student.Gender;
                Dob = student.Dob;
            }
        }

        /// <summary>
        /// Delete student record command.
        /// </summary>
        private ICommand? deleteCommand { get; set; }

        public ICommand? DeleteCommand
        {
            get
            {
                deleteCommand = new RelayCommand(DeleteExecute, CanDeleteExecute, false);
                return deleteCommand;
            }
        }

        private void DeleteExecute(object parameter)
        {
            DynamicParameters parameters = new();
            parameters.Add("@Id", Student.StudentId);
            parameters.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
            getConnection.ExecuteStoredProcedureSingle<string>("sp_DeleteStudentRecord", parameters);
            int result = parameters.Get<Int32>("@Result");
            switch (result)
            {
                case 0:
                    MessageBox.Show("error while delete data in database.");
                    break;
                case 1:
                    MessageBox.Show("delete successfully....");
                    break;
                case 2:
                    MessageBox.Show("Id Not Found...");
                    break;
            }
            studentList = StudentData();
            OnChangedProperty("StudentList");
        }

        private bool CanDeleteExecute(object parameter)
        {
            return true;
        }

        private ICommand? multipleDeleteCommand { get; set; }

        public ICommand? MultipleDeleteCommand
        {
            get
            {
                multipleDeleteCommand = new RelayCommand(MultipleDeleteExecute, CanMutipleDeleteExecute, false);
                return multipleDeleteCommand;
            }
        }

        private bool CanMutipleDeleteExecute(object arg)
        {
            return true;
        }

        private void MultipleDeleteExecute(object obj)
        {

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


        private bool _isSelectAll;

        public bool IsSelectAll
        {
            get { return _isSelectAll; }
            set
            {
                _isSelectAll = value;
                OnChangedProperty("IsSelectAll");
                SelectAllItems(value);
            }
        }

        private void SelectAllItems(bool selectAll)
        {
            foreach (var item in StudentList)
            {
                item.IsChecked = selectAll;
            }
        }

    }
}
