using System;
using System.Collections.Generic;
using System.Linq;
using OO___Nulls.Common;

namespace OO___Nulls
{
    public class SoldArticle
    {
        public Warranty MoneyBackGuarantee { get; private set; }

        public Warranty ExpressTimeLimitedWarranty { get; private set; }

        private readonly Warranty _notOperationalWarranty;

        private Option<Part> _circuits = Option<Part>.None();
        private Warranty _circuitExtendedWarranty;
        private Warranty _failedCircuitWarranty;

        public SoldArticle(Warranty moneyBackGuarantee, Warranty expressTimeLimitedWarranty)
        {
            MoneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            ExpressTimeLimitedWarranty = VoidWarranty.Instance;
            _notOperationalWarranty = expressTimeLimitedWarranty ?? throw new ArgumentNullException(nameof(expressTimeLimitedWarranty));
            _circuitExtendedWarranty = VoidWarranty.Instance;
        }

        public void VisibleDamage()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGuarantee = VoidWarranty.Instance;
            ExpressTimeLimitedWarranty = _notOperationalWarranty;
        }

        public void InstallCircuit(Part circuit, Warranty extendedWarranty)
        {
            _circuits = Option<Part>.Some(circuit);
            _failedCircuitWarranty = extendedWarranty;
        }

        public void CircuitNotOperational(DateTime breakDate)
        {
            _circuits.Do(circuit =>
            {
                circuit.MarkDefective(breakDate);
                _circuitExtendedWarranty = _failedCircuitWarranty;
            });
        }

        public void ClaimCircuitWarranty(Action onValidClaim)
        {
            _circuits.Do(circuit => _circuitExtendedWarranty.Claim(circuit.BreakDate, onValidClaim));
        }
    }
}