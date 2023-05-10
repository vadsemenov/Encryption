namespace XorEncryption;

public class Program
{
    static void Main(string[] args)
    {
        var path = @"C:\Users\55873\OneDrive\Desktop\1.txt";

        var bytes = File.ReadAllBytes(path);

        //Key - random bytes
        var maskList = new List<byte>();
        maskList.Add(0b_0001_0100);
        maskList.Add(0b_0001_0110);
        maskList.Add(0b_0101_0100);

        var j = 0;

        for (int i = 0; i < bytes.Length; i++)
        {
            if (j >= maskList.Count - 1)
            {
                j = 0;
            }

            bytes[i] ^= maskList[j];

            j++;
        }

        File.WriteAllBytes(path, bytes);

        Console.Read();
    }
}
