using System;

namespace tgif
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime Dob;
            Console.WriteLine("Enter date of Birth in format MM/DD/YYYY: ");
            //accepts date in MM/dd/yyyy format
            Dob = DateTime.Parse(Console.ReadLine());

        }
    }
}
