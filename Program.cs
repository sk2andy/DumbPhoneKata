using System;

namespace CodingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Console.WriteLine(WordValidator.Validate(input) ? "good" : "not good");
        }
    }
}