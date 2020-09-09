using System;
using iCalendar.BLL;

namespace iCalendar.Console
{
    public static class Program
    {
        static void Main(string[] args)
        {
            // not a Monday (see RRULE below), then why this date is a part of GetOccurrences result?
            var now = DateTimeOffset.Parse("2020-08-07T11:31:38.1222194+00:00");
            var demo = new Demo();
            var count = 0;
            var maxCount = 100;
            while (count < maxCount)
            {
                System.Console.WriteLine($"{now.Date.ToShortDateString()} - {demo.GetStatus(now)}");
                now = now.AddDays(1);
                count++;
            }
            System.Console.WriteLine("Press [Enter] to exit.");
            System.Console.ReadLine();
        }
    }
}
