using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CastleAdventure
{
    public abstract class Menu
    {
        //Declare global variables within class
        private static readonly Dictionary<string, bool> MenuSelections = new Dictionary<string, bool>()
        {
            {"Start", true}, {"Settings", false}, {"Quit", false}
        };

        //Draws the menu screen
        public static void DrawMenu()
        {
            //Declare local variables
            var counter = 0; //Adds values to "top"
            const int top = 30; //Refers to where the console cursor should be positioned on the y axis

            //Change size of console window
            Console.WindowWidth = 93;
            Console.WindowHeight = 43;

            //Draw title
            var reader = new StreamReader("title.txt");
            var line = reader.ReadLine();
            Console.SetCursorPosition(0, 3);
            while (line != null)
            {
                Console.WriteLine(line);
                line = reader.ReadLine();
            }
            reader.Close();

            //Draw menu selection items
            foreach (var (key, value) in MenuSelections)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 3, top + counter);
                if (value) Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(key);
                Console.ResetColor();
                counter += 2;
            }
        }

        //Get the highlighted menu selection
        public static void GetMenuSelection()
        {
            //Declare local variables
            var pressedKey = Console.ReadKey(true);
            var selectionPosition = 0; // Refers to which selection the user is currently on
            var awaitingSelection = true;

            //By default, if the user presses enter before changing selection, it will start the program
            if (pressedKey.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                return;
            }

            //Loop until user selects an option
            while (awaitingSelection)
            {
                switch (pressedKey.Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.W:
                        HighlightSelection(selectionPosition, false); //Remove selection that is currently highlighted
                        if (selectionPosition == 0) selectionPosition = 2;
                        else selectionPosition--;
                        HighlightSelection(selectionPosition, true); //Highlights selected option
                        break;
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.S:
                        HighlightSelection(selectionPosition, false); //Remove selection that is currently highlighted
                        if (selectionPosition == 2) selectionPosition = 0;
                        else selectionPosition++;
                        HighlightSelection(selectionPosition, true); //Highlights selected option
                        break;
                }

                //Get new user input
                pressedKey = Console.ReadKey(true);

                //Check if user pressed enter
                if (pressedKey.Key != ConsoleKey.Enter) continue;

                //Execute specified code based on selection
                switch (selectionPosition)
                {
                    case 0:
                        Console.Clear();
                        awaitingSelection = false;
                        break;
                    case 1:
                        //Console.Clear();
                        //Settings.DrawSettings();
                        //Settings.GetSettingsSelection();
                        break;
                    case 2:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                }
            }

            //highlight refers to if the selection should be highlighted or removed
            void HighlightSelection(int position, bool highlight)
            {
                //Declare local variables
                var key = "Start"; //Refers to the key for the MenuSelections dictionary

                //Set the cursor to the appropriate position based on selection
                switch (selectionPosition)
                {
                    case 0:
                        key = "Start";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 3, 30);
                        break;
                    case 1:
                        key = "Settings";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 3, 32);
                        break;
                    case 2:
                        key = "Quit";
                        Console.SetCursorPosition(Console.WindowWidth / 2 - 3, 34);
                        break;
                }

                //Removes currently highlighted selection and highlights new selection
                if (highlight)
                {
                    MenuSelections[key] = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(MenuSelections.ElementAt(position).Key);
                    Console.ResetColor();
                }
                else
                {
                    MenuSelections[key] = false;
                    Console.ResetColor();
                    Console.Write(MenuSelections.ElementAt(position).Key);
                }
            }
        }
    }
}