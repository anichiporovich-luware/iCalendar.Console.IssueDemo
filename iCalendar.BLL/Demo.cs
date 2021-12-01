using System;
using System.Linq;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;

namespace iCalendar.BLL
{
    public class Demo
    {
        private const string LocalTimeZone = "Europe/Minsk";
        private readonly CalendarEvent calendarEvent;

        public Demo()
        {
            var startDate = DateTimeOffset.Parse("2020-08-10");
            var localStartDate = ToCal(startDate).ToTimeZone(LocalTimeZone);
            var endDate = DateTimeOffset.Parse("2020-11-06");
            var localEndDate = ToCal(endDate).ToTimeZone(LocalTimeZone);
            
            calendarEvent = new CalendarEvent
            {
                Status = "Holiday",
                Start = localStartDate,
                // if uncomment this line then starting from 2020-08-10 method 'GetStatus'
                // will return always this Holiday event even though not for Mondays
                //End = localEndDate,
                IsAllDay = true,
            };

            // RRULE for Monthly each Monday
            calendarEvent.RecurrenceRules.Add(
                new RecurrencePattern("RRULE:FREQ=MONTHLY;INTERVAL=1;BYDAY=MO;BYSETPOS=1;UNTIL=2020-11-06"));
        }

        public string GetStatus(DateTimeOffset now)
        {
            var localNow = ToCal(now).ToTimeZone(LocalTimeZone);

            var found = calendarEvent.GetOccurrences(localNow, localNow);

            return ExtractStatus(found.FirstOrDefault());
        }

        private IDateTime ToCal(DateTimeOffset o) =>
            new CalDateTime(o.UtcDateTime);

        private string ExtractStatus(Occurrence x) =>
            ((CalendarEvent) x?.Source)?.Status ?? "<None>";
    }
}
