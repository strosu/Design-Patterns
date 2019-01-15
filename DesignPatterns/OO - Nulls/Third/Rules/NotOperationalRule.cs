using System;

namespace OO___Nulls
{
    class NotOperationalRule : ChainedRule
    {
        private readonly Action<Action> _claimAction;

        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next) : base(next)
        {
            _claimAction = claimAction;
        }

        protected override void HandleOperational()
        {
            Claim = Forward;
        }

        protected override void HandleNotOperational()
        {
            Claim = _claimAction;
        }
    }
}