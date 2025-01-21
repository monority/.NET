Console.WriteLine("Enter an integer ?");
int input = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter an integer to divide the first");
int input_divider = Convert.ToInt32(Console.ReadLine());


    if (input % input_divider == 0)
    {
        if (input > 0 && input < 10) { 
            Console.WriteLine($"Figure : {input} is divible by {input_divider}");
    }
        else
        {
            Console.WriteLine($"Number : {input} is divible by {input_divider}");

        }
    }
    else
    {
        if (input > 0 && input < 10)
        {
            Console.WriteLine($"Figure : {input} is not divible by {input_divider}");
        }
        else
        {
            Console.WriteLine($"Number : {input} is not divible by {input_divider}");

        }
    }

