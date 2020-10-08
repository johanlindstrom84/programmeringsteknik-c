using System;

namespace leapyearcalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstYear = int.Parse(args[0]);
            int secondYear = int.Parse(args[1]);

            int maxYear = Math.Max(firstYear,secondYear);
            int minYear = Math.Min(firstYear, secondYear);

            int leapYearCount = 0;

            for (int year = minYear; year < maxYear; year++)
            {
                bool isLeapYear = DateTime.IsLeapYear(year);

                if (isLeapYear)
                {
                    leapYearCount++;
                }
            }
            Console.WriteLine($"Encountered {leapYearCount} leap years from {minYear} to {maxYear}");
            
            
            
            
            
            
            
            
            
            
            
            
            
            //räkna ut hår många skottår det är mellan två värden.

           //for (int i = 1984; i < 2020; i++)
            //{
                //DateTime.IsLeapYear(i).ToString();

                //if (true)
                //{
                    //Console.WriteLine(i + "is a leapyer");
                //}
                
            //}

            



        }
    }
}
