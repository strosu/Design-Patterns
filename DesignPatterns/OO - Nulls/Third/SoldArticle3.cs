using System;
using OO___Nulls.Common;

namespace OO___Nulls
{
    public class SoldArticle3
    {
        private Warranty _moneyBackGuarantee;
        private Warranty _notOperationalWarranty;
        private Warranty _circuitWarranty;

        private Option<Part> _circuitry = Option<Part>.None();

        private IWarrantyRules WarrantyRules { get; }

        public SoldArticle3(Warranty moneyBack, Warranty express, IWarrantyRulesFactory rulesFactory)
        {
            _moneyBackGuarantee = moneyBack ?? throw new ArgumentNullException();
            _notOperationalWarranty = express ?? throw new ArgumentNullException();
            _circuitWarranty = VoidWarranty.Instance;

            WarrantyRules = rulesFactory.Create(ClaimMoneyBack, ClaimNotOperational, ClaimCircuitry);
        }

        private void ClaimMoneyBack(Action action)
        {
            _notOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimNotOperational(Action action)
        {
            _notOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimCircuitry(Action action)
        {
            //_circuitry
            //    .WhenSome()
            //    .Do(c => _circuitWarranty.Claim(c.DefectedOn, action))
            //    .Execute();
        }

        public void InstallCircuitry(Part circuit, Warranty extendedWarranty)
        {
            _circuitry = Option<Part>.Some(circuit);
            _circuitWarranty = extendedWarranty;
            WarrantyRules.CircuitryOperational();
        }

        public void CircuitNotOperational(DateTime detectedOn)
        {
            WarrantyRules.CircuitFailed(detectedOn);
        }

        public void VisibleDamage()
        {
            WarrantyRules.VisibleDamage();
        }

        public void NotOperational()
        {
            WarrantyRules.NotOperational();
        }

        public void Repaired()
        {
            WarrantyRules.Operational();
        }
        public void Claim(Action onValidClaim)
        {
            WarrantyRules.Claim(onValidClaim);
        }
    }
}