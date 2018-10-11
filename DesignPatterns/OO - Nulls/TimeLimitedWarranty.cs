using System;

namespace OO___Nulls
{
    public class TimeLimitedWarranty : Warranty
    {
        private DateTime DateIssued { get; }
        private TimeSpan Duration { get; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            DateIssued = dateIssued.Date;
            Duration = TimeSpan.FromDays(duration.Days);
        }

        protected override bool IsValidOn(DateTime date) => date.Date >= DateIssued.Date && date.Date < DateIssued + Duration;
    }
}