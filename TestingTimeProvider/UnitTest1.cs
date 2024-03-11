using Microsoft.Extensions.Time.Testing;

namespace TestingTimeProvider
{
    public class UnitTest1
    {

        [Fact]
        public void Can_Find_Next_Monday()
        {
            var fake = new FakeTimeProvider();

            //This is a Wednesday
            fake.SetUtcNow(DateTime.Parse("2023-06-28"));

            var result = fake.FindNext(DayOfWeek.Monday);

            Assert.Equal("2023-07-03", result.ToString("yyyy-MM-dd"));
        }


        [Fact]
        public void Can_Find_Next_Monday2()
        {

            DateTimeExtensions2 dateTimeExtensions2 = new DateTimeExtensions2();


            var fake = new FakeTimeProvider();

            //This is a Wednesday
            fake.SetUtcNow(DateTime.Parse("2023-06-28"));

            var result = dateTimeExtensions2.FindNext(fake, DayOfWeek.Monday);

            Assert.Equal("2023-07-03", result.ToString("yyyy-MM-dd"));
        }

        [Fact]
        public void Can_Find_Next_Monday_But_Not_Really()
        {

            DateTimeExtensions2 dateTimeExtensions2 = new DateTimeExtensions2();

            var result = dateTimeExtensions2.FindNext(TimeProvider.System, DayOfWeek.Monday);


            Assert.Equal("2024-03-11", result.ToString("yyyy-MM-dd"));
        }








        [Fact]
        public void Can_tick_when_asked()
        {
            var fake = new FakeTimeProvider();
            var now = DateTime.Now;
            fake.SetUtcNow(now);

            var result = false;

            fake.CreateTimer(
                _ => result = !result,
                state: null,
                // time to delay before invoking the callback method
                // if TimeSpan.Zero will get immediately invoked
                dueTime: TimeSpan.FromSeconds(1),
                // time between callback invocations
                period: TimeSpan.FromMinutes(1)
            );

            Assert.False(result);

            // Change the fabric of space & time...
            // well not really.
            fake.SetUtcNow(now.AddMinutes(1));

            Assert.True(result);
        }
    }
}