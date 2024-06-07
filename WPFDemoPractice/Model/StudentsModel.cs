using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFDemoPractice.Model
{
    internal class StudentsModel : INotifyPropertyChanged
    {
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string? studentName;

        public string? StudentName
        {
            get { return studentName; }

            set
            {
                studentName = value;
                OnPropertyChanged("StudentName");
            }
        }

        private string? surname;

        public string? Surname
        {
            get { return surname; }

            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        private string? fatherName;

        public string? FatherName
        {
            get { return fatherName; }

            set
            {
                fatherName = value;
                OnPropertyChanged("FatherName");
            }
        }

        private DateTime dob;
        public DateTime Dob
        {
            get { return dob; }
            set
            {
                dob = value;
                OnPropertyChanged("Dob");
            }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        private string? gender;
        public string? Gender
        {
            get { return gender; }
            set
            {
                gender = value;
                OnPropertyChanged("Gender");
            }
        }

        private string? address;
        public string? Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }

        private string? contactNo;
        public string? ContactNo
        {
            get { return contactNo; }
            set
            {
                contactNo = value;
                OnPropertyChanged("ContactNo");
            }
        }

        private int standard;
        public int Standard
        {
            get { return standard; }
            set
            {
                standard = value;
                OnPropertyChanged("Standard");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
