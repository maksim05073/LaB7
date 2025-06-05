using System.Text;
namespace LB7_3;

public class BCipher:ICipher
{
    private const string Alphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
    public string encode(string input)
    {
        var result = new StringBuilder();
        foreach (char ch in input.ToUpper())
        {
            int index = Alphabet.IndexOf(ch);
            result.Append(index == -1 ? ch : Alphabet[Alphabet.Length - 1 - index]);
        }
        return result.ToString();
    }
    public string decode(string input)
    {
        return encode(input);
    }
}