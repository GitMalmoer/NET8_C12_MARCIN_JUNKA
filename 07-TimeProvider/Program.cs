
/*
 *Handling date and time correctly in .NET can be a challenging task.

*DateTimeOffset, with stored UTC offset and time zone, provides more accuracy for date and time storage than the DateTime structure.

*Although you can mock external structures like DateTime and DateTimeOffset in unit tests with .NET Fakes, this feature is only available in the Enterprise version of Visual Studio.

*In .NET 8 Preview 4, Microsoft introduced TimeProvider and ITimer as universal time abstractions for dependency injections and unit testing.

*TimeProvider is overloaded with properties and methods, providing extensive functionality for managing time-related operations.

Time plays a critical role in software applications. Tracking time zones and testing time-dependent flows bring challenges to developers. 

 */

using Microsoft.Extensions.Time.Testing;



// in this code sample we are using FakeTimeProvider() and we are setting GetLocalTimeNow(SetUtcNow) to our needs.
// DateTimeExtensions.FindNext method is using taking timeProvider as parameter and call methhod GetLocalNow WHICH WILL BE AS WE SET IT UP IN FAKER

var faker = new FakeTimeProvider();

faker.SetUtcNow(DateTime.Parse("2024-03-07"));

Console.WriteLine("The fake date now is: " + faker.GetUtcNow());

var date = faker.FindNext(DayOfWeek.Monday);

Console.WriteLine("The next monday is:" + date);


public static class DateTimeExtensions
{
    public static DateTime FindNext(this TimeProvider provider, DayOfWeek dayOfWeek)
    {
        var now = provider.GetLocalNow();
        var daysUntilNextWeekDay = ((int)dayOfWeek - (int)now.DayOfWeek + 7) % 7;
        return now.DateTime.AddDays(daysUntilNextWeekDay);
    }
}

































public  class DateTimeExtensions2
{
    public  DateTime FindNext(TimeProvider provider, DayOfWeek dayOfWeek)
    {
        var now = provider.GetLocalNow();
        var daysUntilNextWeekDay = ((int)dayOfWeek - (int)now.DayOfWeek + 7) % 7;
        return now.DateTime.AddDays(daysUntilNextWeekDay);
    }
}











// https://www.infoq.com/articles/dotnet-unit-tests-time-timezone/