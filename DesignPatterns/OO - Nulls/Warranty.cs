using System;

namespace OO___Nulls
{
    public abstract class Warranty
    {
        protected abstract bool IsValidOn(DateTime onDate);

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate)) return;
            onValidClaim();
        }
    }
}