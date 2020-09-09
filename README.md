# iCalendar.Console.IssueDemo
Sample example that demonstrates issue with RRULE parse by  ical.net library

Application creates `CalendarEvent` with `IsAllDay` flag, `Start` and `End` date.
And then adds `RecurrenceRules` as following: `"RRULE:FREQ=MONTHLY;INTERVAL=1;BYDAY=MO;BYSETPOS=1"` (RRULE).

Expects that this RRULE should create an event that happens each monday. 

But when I use `CalendarEvent.GetOccurrences` it gives me always this event event for days when it should not happen.
In application I start from Start day and tries to use `CalendarEvent.GetOccurrences` on each next day.

I tried to find online parsers for RRULE (because it might be that my rule is wrong).
And found this one http://worthfreeman.com/projects/online-icalendar-recurrence-event-parser/
And if I specify the following
```
DTSTART:20200805T000000
DTEND:20201106T115900
RRULE:FREQ=MONTHLY;INTERVAL=1;BYDAY=MO;BYSETPOS=1
```
It specifies correct days when event happens. Only mondays.

# Prerequisites 
[.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1)

# How to run
```
dotnet build iCalendar.Console.sln
dotnet run --project iCalendar.Console/iCalendar.Console.csproj
```