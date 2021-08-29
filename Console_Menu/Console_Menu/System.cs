using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Console_Menu
{
    class System
    {
       
        public void Start()
        {


            RunMainMenu();






        }
        //Declaring registartion variables before hand

        string registration;
        string name;
        string surname;
        int phonenumber;
        string company;
        string email;
        string address;
        byte age;
        string vaccine_name;
        //Declaring String for Update Method
        string updateRegistration;
        string updateVaccine;

        //Error Handling
        bool phoneNum;
        bool ageCheck;

        // Waiting before cleaning
        int milliseconds = 2000;

        //MAIN MENU START---------------------
        private void RunMainMenu()
        {
            string prompt = @"     _______. __    __  .______    _______ .______     ____    ____  ___       ______   ______  __  .__   __.  _______ 
    /       ||  |  |  | |   _  \  |   ____||   _  \    \   \  /   / /   \     /      | /      ||  | |  \ |  | |   ____|
   |   (----`|  |  |  | |  |_)  | |  |__   |  |_)  |    \   \/   / /  ^  \   |  ,----'|  ,----'|  | |   \|  | |  |__   
    \   \    |  |  |  | |   ___/  |   __|  |      /      \      / /  /_\  \  |  |     |  |     |  | |  . `  | |   __|  
.----)   |   |  `--'  | |  |      |  |____ |  |\  \----.  \    / /  _____  \ |  `----.|  `----.|  | |  |\   | |  |____ 
|_______/     \______/  | _|      |_______|| _| `._____|   \__/ /__/     \__\ \______| \______||__| |__| \__| |_______|
                                                                                                                        ";
            string[] options = { "Register", "Update", "Search", "List", "Exit" };

            Menu vaccine_menu = new Menu(prompt, options);
            int selectedIndex = vaccine_menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Register();
                    break;
                case 1:
                    Update();
                    break;
                case 2:
                    Search();
                    break;
                case 3:
                    ShowList();
                    break;
                case 4:
                    Exit();
                    break;

            }

        }

        //MAIN MENU END--------------------
        public void Register()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            CenterWRITE_TXT("Enter Registration Number: ");
            registration = Console.ReadLine();


            CenterWRITE_TXT("Enter Name: ");
            name = Console.ReadLine();


            CenterWRITE_TXT("Enter Surname: ");
            surname = Console.ReadLine();


            CenterWRITE_TXT("Enter Age: ");
            ageCheck = Byte.TryParse(Console.ReadLine(), out age);
            if (!ageCheck)
            {
                Patient.CenterTXT("Invalid Age!!");
                age = 0;
            }


            CenterWRITE_TXT("Enter Phone Number: ");
            phoneNum = Int32.TryParse(Console.ReadLine(), out phonenumber);
            if (!phoneNum)
            {
                Patient.CenterTXT("Invalid Phone Number!!");
                phonenumber = 0;
            }

            CenterWRITE_TXT("Enter eMail: ");
            email = Console.ReadLine();

            CenterWRITE_TXT("Enter Address: ");
            address = Console.ReadLine();

            CenterWRITE_TXT("Enter Company: ");
            company = Console.ReadLine();

            CenterWRITE_TXT("Vaccine Name: ");
            vaccine_name = Console.ReadLine();

            Patient patient = new Patient(registration, name, surname, age, phonenumber.ToString("(000) 000-00-00"), email, address, company, vaccine_name);

            Patient.Register(patient);
           
            Thread.Sleep(milliseconds);
            RunMainMenu();



        }

        public void Update()
        {
            CenterWRITE_TXT("Enter Patient Name: ");
            Patient.Search(Console.ReadLine());

            CenterWRITE_TXT("Enter Registration: ");
            updateRegistration = Console.ReadLine();

            CenterWRITE_TXT("Enter Vaccine Name: ");
            updateVaccine = Console.ReadLine();
            Patient.Update(updateRegistration, updateVaccine);
            Thread.Sleep(milliseconds);
            RunMainMenu();
        }

        public void Search()
        {
            CenterWRITE_TXT("Enter Patient Name: ");
            Patient.Search(Console.ReadLine());
            Thread.Sleep(milliseconds);
            RunMainMenu();
        }

        public void ShowList()
        {
            Patient.ShowList(); 
            Thread.Sleep(milliseconds);
            RunMainMenu();
        }
        public void Exit()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.Clear();
            CenterWRITE_TXT("Exiting..");
            CenterWRITE_TXT("Stay Hydrated :)");
            Console.ReadKey(true);
          
        }

        public static void CenterWRITE_TXT(string str)
        {
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop + 1);
            Console.Write(str);
        }

    }
    
}
