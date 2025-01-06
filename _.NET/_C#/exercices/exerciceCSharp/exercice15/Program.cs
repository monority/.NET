Console.Write("Drinks avaible : \n " +
              "1. Water" + "\n"  +
              "2. Sparkling WATER " + "\n"  +
              "3. Coca " + "\n"  + 
              "4. Fanta" + "\n"  + 
              "5. Sprite " + "\n"  + 
              "6. Orangina" + "\n"  + 
              "7. 7UP \n") ;
Console.WriteLine("Your choice ? 1 to 7");
int choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1: Console.WriteLine("You took Water"); break;
    case 2: Console.WriteLine("You took Sparkling"); break;
    case 3: Console.WriteLine("You took Coca"); break;
    case 4: Console.WriteLine("You took Fanta"); break;
    case 5: Console.WriteLine("You took Sprite"); break;
    case 6: Console.WriteLine("You took Orangina"); break;
    case 7: Console.WriteLine("You took 7UP"); break;
    default : Console.WriteLine("Invalid choice"); break;
}