namespace Algoritma;
class Program
{
    static string[] allWords;
    static int number;
    static string justWord = "";

    static void Main(string[] args)
    {
        completedMethod();
    }

    private static void completedMethod()
    {
        Back:
        string word = getString();
        if (spaceControl(word) == true)
        {
            goto Back;
        }

        foreach (var item in allWords)
        {
            if (!commaControl(item))
            {
                string[] element = item.Split(',');
                if(numberControl(element[1])){
                    RemoveMethod(element[0],number);
                }else{
                    goto Back;
                }
            }else{
                goto Back;
            }
        }
    }

    private static string getString()
    {
        System.Console.Write("Please, enter a word and a number, separated by a comma (Like word,3) : ");
        string word = Console.ReadLine();
        return word.Trim();
    }

    private static void RemoveMethod(string word,int number)
    {
        if (number < word.Length){
            justWord = (word.Remove(number,1) + " ");
        }else{
            justWord = (word + " ");
        }
        System.Console.Write(justWord);
    }

    private static bool spaceControl(string word)
    {
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == ' ' && word[i+1] == ' ')
            {
                System.Console.WriteLine("You entered wrong. Please enter only one space between each element.");
                return true;
            }
        }

        allWords = word.Split(' ');
        return false;
    }

    private static bool commaControl(string word)
    {
        int count =0;
        foreach (var chars in word)
        {
            if (chars == ',')
            {
                count++;
            }
        }
        
        if (count == 1)
        {
            return false;
        }
        else
        {
            System.Console.WriteLine("You entered wrong. Please, enter only one comma between each word and number.");
            return true;
        }
    }

    private static bool numberControl(string numberString)
    {
        if (Int32.TryParse(numberString, out number) && number>=0)
        {
            return true;
        }
        
        System.Console.WriteLine("You entered wrong. Please, enter the number after the comma.");
        return false;
    }
}
