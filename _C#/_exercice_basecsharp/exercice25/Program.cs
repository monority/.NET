int choice;
int notes = 0;
int input_notes = 0;
int max = -1;
int min = 21;
double average = 0;
List<int> all_notes = new List<int>();

do
{
    Console.WriteLine("\nNote Manager");
    Console.WriteLine("-----------------------");
    Console.WriteLine("1. Add notes");
    Console.WriteLine("2. Best note");
    Console.WriteLine("3. Worst note");
    Console.WriteLine("4. Average of all notes");
    Console.WriteLine("0. Exit");
    Console.WriteLine("\nYour choice :");
    choice = Convert.ToInt16(Console.ReadLine());
    if (choice == 1)
    {
        do
        {
            Console.WriteLine($"Enter note #{all_notes.Count + 1} (/20) or 999 to stop:");
            input_notes = Convert.ToInt32(Console.ReadLine());
            if (input_notes >= 0 && input_notes <= 20)
            {
                all_notes.Add(input_notes);
                if (input_notes > max)
                {
                    max = input_notes;
                }

                if (input_notes < min)
                {
                    min = input_notes;
                }
                average += input_notes;
            }
            else
            {
                Console.WriteLine("Invalid input, please enter a note between 0 and 20.");
            }
        } while (input_notes != 999);

        Console.Clear();
    }
    else if (choice == 2)
    {
        if (all_notes.Count == 0)
        {
            Console.WriteLine("\nYou need to enter at least one note.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"--------- Best note -----------\n");
            Console.WriteLine($"Best note: {max}");
            Console.ResetColor();
        }
    }
    else if (choice == 3)
    {
        if (all_notes.Count == 0)
        {
            Console.WriteLine("\nYou need to enter at least one note.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"--------- Worst note -----------\n");
            Console.WriteLine($"Worst note: {min}");
            Console.ResetColor();
        }
    }
    else if (choice == 4)
    {
        if (all_notes.Count == 0)
        {
            Console.WriteLine("\nYou need to enter at least one note.");
        }
        else
        {
            double avg = (double)average / all_notes.Count;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"--------- Average notes -----------\n");
            Console.WriteLine($"Average note: {avg:F2}");
            Console.ResetColor();
        }
    }
} while (choice != 0);

Environment.Exit(0);