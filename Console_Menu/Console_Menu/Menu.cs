using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Menu
{
    class Menu
    {
        string prompt;
        string[] options;
        int selectedIndex;
        string prefix;

        public Menu(string Prompt , string[] Options)
        {
            this.prompt = Prompt;
            this.options = Options;
            selectedIndex = 0;
        }

        private void DisplayInfo()
        {
            //Console Color
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "Bribeless Vaccine System";

            Console.WriteLine(prompt);
            for (int i = 0; i < options.Length; i++)
            {
                if(i == selectedIndex)
                {
                   
                    prefix = "*";
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                   
                    prefix = " ";
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition((Console.WindowWidth - "{prefix} << {options[i]} >>".Length) / 2, Console.CursorTop + 1);
                Console.WriteLine($"{prefix} << {options[i]} >>");
            }
            Console.ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayInfo();

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                keyPressed = keyInfo.Key;

                if(keyPressed == ConsoleKey.UpArrow)
                {
                    selectedIndex--;
                    if (selectedIndex == -1)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }
                else if(keyPressed == ConsoleKey.DownArrow)
                {
                    selectedIndex++;
                    if(selectedIndex > options.Length - 1)
                    {
                        selectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return selectedIndex;
        }


    }
}
