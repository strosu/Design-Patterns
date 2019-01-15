using System;

namespace OO___Nulls
{
    public class MoneyBackRule : ChainedRule
    {
        private readonly Action<Action> _claimAction;

        public MoneyBackRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            _claimAction = claimAction;
        }

        protected override void HandleNotOperational()
        {
            Claim = Forward;
        }

        protected override void HandleVisibleDamage()
        {
            Claim = Forward;
        }

        protected override void HandleCircuitFailed()
        {
            Claim = Forward;
        }
    }
}