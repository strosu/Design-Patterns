using System;

namespace OO___Nulls
{
    public class SoldArticle
    {
        public Warranty MoneyBackGuarantee { get; private set; }

        public Warranty ExpressTimeLimitedWarranty { get; private set; }

        private Warranty NotOperationalWarranty { get; }

        public SoldArticle(Warranty moneyBackGuarantee, Warranty expressTimeLimitedWarranty)
        {
            MoneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            ExpressTimeLimitedWarranty = VoidWarranty.Instance;
            NotOperationalWarranty = expressTimeLimitedWarranty ?? throw new ArgumentNullException(nameof(expressTimeLimitedWarranty));
        }

        public void VisibleDamage()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
            ExpressTimeLimitedWarranty = NotOperationalWarranty;
        }
    }
}