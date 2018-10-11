using System;

namespace OO___Nulls
{
    public class VoidWarranty : Warranty
    {
        public static VoidWarranty Instance => new VoidWarranty();

        private VoidWarranty() { }

        protected override bool IsValidOn(DateTime date) => false;
    }
}