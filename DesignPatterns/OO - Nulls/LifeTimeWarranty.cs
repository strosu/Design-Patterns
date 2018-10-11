using System;

namespace OO___Nulls
{
    public class LifeTimeWarranty : Warranty
    {
        private readonly DateTime _issuingDate;

        public LifeTimeWarranty(DateTime issuingDate)
        {
            _issuingDate = issuingDate;
        }

        protected override bool IsValidOn(DateTime date) => date.Date > _issuingDate.Date;

    }
}