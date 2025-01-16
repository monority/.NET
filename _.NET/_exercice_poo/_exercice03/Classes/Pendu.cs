namespace _exercice03.Classes;

internal class Pendu
{
    private int _tries { get;  set; } = 0;
    private string _userinput;
    private static string _selectedword;
    private static List<string> _listWord = new List<string>
    {
        "Blanc",
        "Rouge",
        "Garage",
        "Parking",
    };

    private static string _mask;
    private int _maxtries;

    public Pendu(string userinput)
    {
        _userinput = userinput;
    }

    public static void GenerateWords()
    {
        Random random = new Random(); 
        int value = random.Next(0, _listWord.Count);
        _selectedword = _listWord[value];
        for (int i = 0; i < _selectedword.Length; i++)
        {
            _mask += "*";
        }
    }

  
    public void TestChar(string userchar)
    {
        userchar = userchar.ToLower();
    
        if (userchar.Contains(_selectedword))
        {
            _mask += userchar;
        }

    }

    public void TestWin()
    {
        
    }

     public void GenerateMask()
    {
        
    }
}