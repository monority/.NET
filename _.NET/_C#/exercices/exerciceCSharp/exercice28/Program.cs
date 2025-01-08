int[] values = new int[26];
int start = 65;

for (int i = 0; i < values.Length; i++)
{
    values[i] = start++;
    char text = (char)(values[i]);
    string empty = new string(' ', i * 2);
    Console.WriteLine(empty + text);
}