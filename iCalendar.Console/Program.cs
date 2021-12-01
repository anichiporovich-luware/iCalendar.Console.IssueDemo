using System;
using iCalendar.BLL;

namespace iCalendar.Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var now = DateTimeOffset.Parse("2020-08-09");
            var demo = new Demo();
            var daysShifted = 0;
            var maxDaysShifted = 15;
            while (daysShifted < maxDaysShifted)
            {
                System.Console.WriteLine($"{now.Date.ToShortDateString()} - {demo.GetStatus(now)}");
                now = now.AddDays(1);
                daysShifted++;
            }
            System.Console.WriteLine("Press [Enter] to exit.");
            System.Console.ReadLine();
        }
    }
}
