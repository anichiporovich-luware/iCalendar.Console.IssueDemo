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
            // start day is Wednesday 
            var startDate = DateTimeOffset.Parse("2020-08-05T21:00:00.0000000+00:00");
            var localStartDate = ToCal(startDate).ToTimeZone(LocalTimeZone);
            var endDate = DateTimeOffset.Parse("2020-11-06T20:59:59.0000000+00:00");
            var localEndDate = ToCal(endDate).ToTimeZone(LocalTimeZone);
            
            calendarEvent = new CalendarEvent
            {
                Status = "Holiday",
                Start = localStartDate,
                End = localEndDate,
                IsAllDay = true,
            };

            // RRULE for Monthly each Monday
            calendarEvent.RecurrenceRules.Add(
                new RecurrencePattern("RRULE:FREQ=MONTHLY;INTERVAL=1;BYDAY=MO;BYSETPOS=1"));
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
            ((CalendarEvent) x?.Source)?.Status;
    }
}
