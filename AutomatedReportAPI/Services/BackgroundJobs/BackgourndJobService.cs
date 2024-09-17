using Hangfire;

namespace AutomatedReportAPI.Services.BackgroundJobs
{
    public class BackgourndJobService : IBackgourndJobService
    {
        public BackgourndJobService() { }       
        public async Task SendBirthDayMessage(string Message, DateTime birthdayDate)
        {
            DateTime today = DateTime.Now;
            // Calculate the next occurrence of the birthday date this year
            DateTime nextBirthday = new DateTime(today.Year, birthdayDate.Month, birthdayDate.Day);
            Console.WriteLine(nextBirthday);
            // If the birthday has already occurred this year, schedule it for next year
            if (nextBirthday < today)
                nextBirthday = nextBirthday.AddYears(1);
            //Console.WriteLine(nextBirthday - today);
            Console.WriteLine(nextBirthday);
            Console.WriteLine((nextBirthday - today).TotalDays);
            Console.WriteLine((nextBirthday - today).Days);
            // Schedule the job to run on the next birthday date
            BackgroundJob.Schedule(() => Console.WriteLine(Message),
                TimeSpan.FromDays((nextBirthday - today).TotalDays));
        }
    }
}
