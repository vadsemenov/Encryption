namespace CaesarEncryption;

public class Program
{
    private static readonly char[] Alphabet = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };

    static void Main(string[] args)
    {
        Console.WriteLine("Введите строку для шифрования:");

        var sourceString = string.Empty;

        while (sourceString == string.Empty)
        {
            sourceString = Console.ReadLine();
        }

        Console.WriteLine("Введите смещение алфавита:");

        if (!int.TryParse(Console.ReadLine(), out var slideNumber))
        {
            return;
        }

        var encryptedString = CryptString(sourceString!, slideNumber);
        Console.WriteLine("Строка после шифрования:");
        Console.WriteLine(encryptedString);

        var decryptedString = DecryptString(encryptedString, slideNumber);
        Console.WriteLine("Расшифрованная строка:");
        Console.WriteLine(decryptedString);
    }

    private static string CryptString(string sourceString, int slideNumber)
    {
        var encryptedString = string.Empty;

        foreach (var ch in sourceString)
        {
            if (Alphabet.Contains(ch))
            {
                var positionNumber = GetCharPosition(ch);
                positionNumber += slideNumber % Alphabet.Length;

                if (positionNumber >= Alphabet.Length)
                {
                    positionNumber -= Alphabet.Length;
                }

                encryptedString += Alphabet[positionNumber];

                continue;
            }

            encryptedString += ch;
        }

        return encryptedString;
    }

    private static string DecryptString(string? sourceString, int slideNumber)
    {
        var decryptedString = string.Empty;

        foreach (var ch in sourceString)
        {
            if (Alphabet.Contains(ch))
            {
                var charPosition = GetCharPosition(ch);

                charPosition -= slideNumber % Alphabet.Length;

                if (charPosition < 0)
                {
                    charPosition += Alphabet.Length;
                }

                decryptedString += Alphabet[charPosition];

                continue;
            }

            decryptedString += ch;
        }

        return decryptedString;
    }

    private static int GetCharPosition(char ch)
    {
        for (int i = 0; i < Alphabet.Length; i++)
        {
            if (ch == Alphabet[i])
            {
                return i;
            }
        }

        return -1;
    }
}