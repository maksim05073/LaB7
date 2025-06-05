namespace LB7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            ICipher cipherA = new ACipher();
            ICipher cipherB = new BCipher();
            
            string text = "ПРИВІТ СВІТ";
            Console.WriteLine("Оригінал: " + text);
            
            string encodedA = cipherA.encode(text);
            Console.WriteLine("ACipher (шифр): " + encodedA);
            Console.WriteLine("ACipher (дешифр): " + cipherA.decode(encodedA));
            
            string encodedB = cipherB.encode(text);
            Console.WriteLine("BCipher (шифр): " + encodedB);
            Console.WriteLine("BCipher (дешифр): " + cipherB.decode(encodedB));
            Console.ReadKey();
        }
    }
}