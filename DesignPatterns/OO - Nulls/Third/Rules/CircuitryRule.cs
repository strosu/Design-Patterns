using System;

namespace OO___Nulls
{
    public class CircuitryRule : ChainedRule
    {
        private readonly Action<Action> _claimAction;

        public CircuitryRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            _claimAction = claimAction;
        }

        protected override void HandleCircuitFailed()
        {
            Claim = _claimAction;
        }

        protected override void HandleCircuitryOperational()
        {
            Claim = Forward;
        }
    }
}