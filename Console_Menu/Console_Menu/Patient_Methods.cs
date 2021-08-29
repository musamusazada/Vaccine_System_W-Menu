using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Menu
{
    partial class Patient
    {
        //Register Method
        public static void Register(Patient patient)
        {
            temp = Array.FindAll(patients, e => e._Registration == patient._Registration);

            if (temp.Length != 0)
            {
                CenterTXT("__________________________________________________________________________________________________________");
                CenterTXT("REGISTERED PATIENT!!!");
                CenterTXT("__________________________________________________________________________________________________________");
            }
            else
            {
                Array.Resize(ref patients, patients.Length + 1);
                patients[patients.Length - 1] = patient;
                CenterTXT("__________________________________________________________________________________________________________");
                CenterTXT("NEW PATIENT HAS BEEN REGISTERED");
                CenterTXT("__________________________________________________________________________________________________________");
            }

        }

        //Search Method
        public static void Search(string Name)
        {
            temp = Array.FindAll(patients, e => e.name == Name);

            if (temp.Length != 0)
            {
                foreach (Patient item in temp)
                {
                    if (item.SecondDose)
                    {
                        CenterTXT("__________________________________________________________________________________________________________");
                        CenterTXT($@"ID/License: {item._Registration} | Name: {item.name} | Surname: {item.surname} | Age: {item.age} 
                        | Contact: {item.phonenumber}, {item.email}  
                        --{item.FirstDoseName} | {item.FirstDoseDate} -- {item.SecondDoseName} | {item.SecondDoseDate} --");
                    }
                    else
                    {
                        CenterTXT("__________________________________________________________________________________________________________");
                        CenterTXT($@"ID/License: {item._Registration} | Name: {item.name} | Surname: {item.surname} | Age: {item.age} 
                    | Contact: {item.phonenumber}, {item.email}  
                    --{item.FirstDoseName} | {item.FirstDoseDate}");
                    }
                    CenterTXT("__________________________________________________________________________________________________________");
                }
            }
            else
            {
                CenterTXT("No Such Patient...");
                CenterTXT("__________________________________________________________________________________________________________");
            }

            temp = Array.Empty<Patient>();

        }

        // Displaying All Patients
        public static void ShowList()
        {
            if (patients.Length != 0)
            {
                foreach (Patient item in patients)
                {
                    if (item.SecondDose)
                    {
                        CenterTXT("__________________________________________________________________________________________________________");
                        CenterTXT($"ID/License: {item._Registration} | Name: {item.name} | Surname: {item.surname} | Age: {item.age} | Contact: {item.phonenumber}, {item.email}  --{item.FirstDoseName} | {item.FirstDoseDate} -- {item.SecondDoseName} | {item.SecondDoseDate} --");
                    }
                    else
                    {
                        CenterTXT("__________________________________________________________________________________________________________");
                        CenterTXT($"ID/License: {item._Registration} | Name: {item.name} | Surname: {item.surname} | Age: {item.age} | Contact: {item.phonenumber}, {item.email}  --{item.FirstDoseName} | {item.FirstDoseDate}");
                    }
                    CenterTXT("__________________________________________________________________________________________________________");
                }
            }
            else
            {
                CenterTXT("__________________________________________________________________________________________________________");
                CenterTXT("0 registered Patients");
                CenterTXT("__________________________________________________________________________________________________________");
            }

        }

        //Update Method -- Second Vaccine.
        public static void Update(string registration, string vaccine_name)
        {
            Array.Resize(ref temp, temp.Length + 1);
            temp[0] = Array.Find(patients, e => e._Registration == registration);

            if (temp.Length != 0)
            {

                foreach (Patient item in temp)
                {
                    if (item._Registration == registration)
                    {
                        item.SecondDose = true;
                        item.SecondDoseDate = DateTime.Now.ToString("dd/MM/yyyy");
                        item.SecondDoseName = vaccine_name;
                    }
                }
            }
            else
            {
                CenterTXT("__________________________________________________________________________________________________________");
                CenterTXT("No Such Patient");
                CenterTXT("__________________________________________________________________________________________________________");
            }
        }

        public static void CenterTXT(string str)
        {

            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop + 1);
            Console.WriteLine(str);
        }

    }
}
