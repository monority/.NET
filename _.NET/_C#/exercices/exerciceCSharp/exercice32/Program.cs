int[] values = new int[10];
Random random = new Random();


for (int i = 0; i < values.Length; i++)
{
    int randomNumber = random.Next(1, 50);
    values[i] = randomNumber;
    string empty = new string(' ', i * 6);
    Console.WriteLine(empty + values[i]);
}