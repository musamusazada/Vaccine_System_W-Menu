using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Menu
{
    partial class Patient
    {
        //Personal Details
        private string _Registration;
        public string name;
        public string surname;
        public byte age;
        public string phonenumber;
        public string email;
        public string address;
        public string company;

        //Vaccine Details
        private bool FirstDose = false;
        private string FirstDoseDate;
        public string FirstDoseName;

        private bool SecondDose = false;
        private string SecondDoseDate;
        public string SecondDoseName;


        //Patient Array
        public static Patient[] patients = Array.Empty<Patient>();

        //Temp array for Search, List and Update
        public static Patient[] temp = Array.Empty<Patient>();


        //Constructor;
        public Patient(string Registration, string Name, string Surname, byte Age, string phoneNumber, string eMail, string Address, string Company, string firstDoseName)
        {
            //Personal Info
            this._Registration = Registration;
            this.name = Name;
            this.surname = Surname;
            this.age = Age;
            this.phonenumber = phoneNumber;
            this.email = eMail;
            this.address = Address;
            this.company = Company;

            //Vaccine info
            this.FirstDose = true;
            this.FirstDoseName = firstDoseName;
            this.FirstDoseDate = DateTime.Now.ToString("dd/MM/yyyy");
        }


    }
}
