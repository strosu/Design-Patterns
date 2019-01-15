using System;

namespace OO___Nulls
{
    public class EasterRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(Action<Action> claimMoneyBack, Action<Action> claimNotOperational, Action<Action> claimCircuitry)
            => new ConditionalRule(IsAroundEaster, claimNotOperational, new XmasRules().Create(claimMoneyBack, claimNotOperational, claimCircuitry));

        private static bool IsAroundEaster() => DateTime.Today.Month == 4;
    }
}