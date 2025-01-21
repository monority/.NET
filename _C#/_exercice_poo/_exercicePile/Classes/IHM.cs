namespace _exercicePile.Classes
{
    public static class IHM
    {
        private static Pile<string?> ListPile = new Pile<string?>();

        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("___________");
                Console.WriteLine("1. Stack");
                Console.WriteLine("2. UnStack");
                Console.WriteLine("3. Get element at x");
                Console.WriteLine("4. Display Elements");
                Console.WriteLine("5. Leave");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("Enter Name to stack: ");
                        string name = Console.ReadLine();
                        Console.WriteLine($"Value to stack - {ListPile.Add(name)} \n{name} was added");
                        break;

                    case "2":
                        Console.Clear();
                        try
                        {
                            Console.WriteLine($"Value to Unstack - {ListPile.Remove()}");
                        }
                        catch (IndexOutOfRangeException error)
                        {
                            Console.WriteLine(error.Message);
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.WriteLine("Enter index to get element: ");
                        if (int.TryParse(Console.ReadLine(), out int index))
                        {
                            try
                            {
                                Console.WriteLine($"Index {index} is: {ListPile.GetIndex(index)}");
                            }
                            catch (IndexOutOfRangeException error) 
                            {
                                Console.WriteLine(error.Message);   
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid index format.");
                        }
                        break;

                    case "4":
                        Console.Clear();
                        Console.WriteLine(ListPile.ShowTableau());
                        break;

                    case "5":
                        Console.WriteLine("Exiting...");
                        return; 

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
        
    }
}
