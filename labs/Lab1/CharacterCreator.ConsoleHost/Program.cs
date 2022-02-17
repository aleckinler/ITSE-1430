using System;

namespace CharacterCreator.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var done = false;
            do
            {
                char input = DisplayMenu();

                switch (input)
                {
                    case '1': NewCharacter(); break;

                    case '2': ViewCharacter(); break;

                    case '3': EditCharacter(); break;

                    case '4': DeleteCharacter(); break;

                    case '0':
                    {
                            if (ConfirmQuit())
                                done = true;

                            break;
                        };
                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (!done);
        }

        private static void EditCharacter ()
        {
            //TODO: edit character functionality
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No character to edit");
                return;
            };

            var done = false;
            do
            {
                Console.WriteLine("What would you like to edit?");

                char input = EditMenu();

                switch (input)
                {
                    case 'n': name = ReadString("Enter your character's name", true); break;

                    case 'r': race = ReadRace("Choose your character's race - 1. Human - 2. Elf - 3. Dwarf - 4. Tiefling - 5. Gnome", true); break;

                    case 'p': profession = ReadProfession("Enter your character's profession - 1. Fighter - 2. Ranger - 3. Cleric - 4. Wizard - 5. Rogue", true); break;

                    case '1': strength = ReadInt32("Enter your character's strength value (1-100)", 1, 100); break;

                    case '2': constitution = ReadInt32("Enter your character's constitution value (1-100)", 1, 100); break;

                    case '3': intellect = ReadInt32("Enter your character's intellegence value (1-100)", 1, 100); break;

                    case '4': charisma = ReadInt32("Enter your character's charisma value (1-100)", 1, 100); break;

                    case '5': agility = ReadInt32("Enter your character's dexterity value (1-100)", 1, 100); break;

                    case 'd': description = ReadString("Enter a description of your character (optional)", false); break;

                    case '0': done = true; break;

                    default: Console.WriteLine("Unknown option"); break;
                };
            } while (!done);
        }


        private static void DeleteCharacter ()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No character to delete");
                return;
            };

            if (ReadBoolean($"Are you sure you wish to delete '{name}' ? (y/n)"))
            name = "";
        }

        private static void ViewCharacter ()
        {
            if (String.IsNullOrEmpty(name))
            {
                Console.WriteLine("No character to view");
                return;
            };

            Console.WriteLine("".PadLeft(80, '~'));
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine(name);
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine($"{race} - {profession}");
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine($"Strength: {strength} - Constitution: {constitution} - Intellegnce: {intellect} - Charisma: {charisma} - Dexterity: {agility}");
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine(description);
            Console.WriteLine("".PadLeft(80, '-'));
            Console.WriteLine("".PadLeft(80, '~'));
        }

        static bool ConfirmQuit ()
        {
            return ReadBoolean("Are you sure you want to quit? (y/n)");
        }

        private static void NewCharacter ()
        {
            name = ReadString("Enter your character's name", true);
            race = ReadRace("Choose your character's race - 1. Human - 2. Elf - 3. Dwarf - 4. Tiefling - 5. Gnome", true);
            profession = ReadProfession("Enter your character's profession - 1. Fighter - 2. Ranger - 3. Cleric - 4. Wizard - 5. Rogue", true);
            strength = ReadInt32("Enter your character's strength value (1-100)", 1, 100);
            constitution = ReadInt32("Enter your character's constitution value (1-100)", 1, 100);
            intellect = ReadInt32("Enter your character's intellegence value (1-100)", 1, 100);
            charisma = ReadInt32("Enter your character's charisma value (1-100)", 1, 100);
            agility = ReadInt32("Enter your character's dexterity value (1-100)", 1, 100);
            description = ReadString("Enter a description of your character (optional)", false);
        }

        static string name;
        static string race;
        static string profession;
        static int strength;
        static int intellect;
        static int charisma;
        static int agility;
        static int constitution;
        static string description;

        static bool ReadBoolean ( string message )
        {
            Console.Write(message);

            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Y)
                {
                    Console.WriteLine('Y');
                    return true;
                }
                else if (key.Key == ConsoleKey.N)
                {
                    Console.WriteLine('N');
                    return false;
                };
            } while (true);
        }

        private static int ReadInt32 ( string message, int minimumValue, int maximumValue )
        {
            Console.Write(message);

            while (true)
            {
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out int result) && result >= minimumValue && result <= maximumValue)
                return result;

                Console.WriteLine("Value must be between >= " + minimumValue + "and <=" + maximumValue);
            };
        }

        private static string ReadString ( string message, bool required )
        {
            Console.WriteLine (message);

            do
            {
                string input = Console.ReadLine();

                if (!required || !String.IsNullOrEmpty(input))
                    return input;

                Console.WriteLine("Value is not required");
            } while (true);
        }

        private static string ReadRace ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                string input = Console.ReadLine();

                if (!required || !String.IsNullOrEmpty(input) && input == "1")
                    return "Human";
                else if (!required || !String.IsNullOrEmpty(input) && input == "2")
                    return "Elf";
                else if (!required || !String.IsNullOrEmpty(input) && input == "3")
                    return "Dwarf";
                else if (!required || !String.IsNullOrEmpty(input) && input == "4")
                    return "Tiefling";
                else if (!required || !String.IsNullOrEmpty(input) && input == "5")
                    return "Gnome";
                else Console.WriteLine("Please choose 1-5");

            } while (true);
        }

        private static string ReadProfession ( string message, bool required )
        {
            Console.WriteLine(message);

            do
            {
                string input = Console.ReadLine();

                if (!required || !String.IsNullOrEmpty(input) && input == "1")
                    return "Fighter";
                else if (!required || !String.IsNullOrEmpty(input) && input == "2")
                    return "Ranger";
                else if (!required || !String.IsNullOrEmpty(input) && input == "3")
                    return "Cleric";
                else if (!required || !String.IsNullOrEmpty(input) && input == "4")
                    return "Wizard";
                else if (!required || !String.IsNullOrEmpty(input) && input == "5")
                    return "Rogue";
                else Console.WriteLine("Please choose 1-5");

            } while (true);
        }

        static char DisplayMenu ()
        {
            Console.WriteLine("Fantasy Character Creator");
            Console.WriteLine("".PadLeft(20, '~'));
            Console.WriteLine("1. New Character");
            Console.WriteLine("2. View Character");
            Console.WriteLine("3. Edit Character");
            Console.WriteLine("4. Delete Character");
            Console.WriteLine("".PadLeft(20, '~'));
            Console.WriteLine("0. Quit");

            do
            {
                string input = Console.ReadLine ();

                if (String.Compare(input, "1", true) == 0)
                    return '1';
                else if (String.Compare(input, "2", true) == 0)
                    return '2';
                else if (String.Compare(input, "3", true) == 0)
                    return '3';
                else if (String.Compare(input, "4", true) == 0)
                    return '4';
                else if (String.Compare(input, "0", true) == 0)
                    return '0';
                else
                {
                    return 'X';
                };
            } while (true);
        }

        static char EditMenu ()
        {
            Console.WriteLine("1. Edit character name");
            Console.WriteLine("2. Edit character race");
            Console.WriteLine("3. Edit character profession");
            Console.WriteLine("4. Edit character Strength score");
            Console.WriteLine("5. Edit character Constitution score");
            Console.WriteLine("6. Edit character Intellegence score");
            Console.WriteLine("7. Edit character Charisma score");
            Console.WriteLine("8. Edit character Dexterity score");
            Console.WriteLine("9. Edit character description");
            Console.WriteLine("0. Return to menu");

            do
            {
                string editInput = Console.ReadLine();

                if (String.Compare(editInput, "1", true) == 0)
                    return 'n';
                else if (String.Compare(editInput, "2", true) == 0)
                    return 'r';
                else if (String.Compare(editInput, "3", true) == 0)
                    return 'p';
                else if (String.Compare(editInput, "9", true) == 0)
                    return 'd';
                //the numbers as return value refer to ability scores since some of them start with the same letter
                else if (String.Compare(editInput, "4", true) == 0)
                    return '1';
                else if (String.Compare(editInput, "5", true) == 0)
                    return '2';
                else if (String.Compare(editInput, "6", true) == 0)
                    return '3';
                else if (String.Compare(editInput, "7", true) == 0)
                    return '4';
                else if (String.Compare(editInput, "8", true) == 0)
                    return '5';
                //quit is consistently 0 though (dunno if thats bad practice)
                else if (String.Compare(editInput, "0", true) == 0)
                    return '0';
                else
                {
                    return 'X';
                }
            } while (true);
        }
    }
}
