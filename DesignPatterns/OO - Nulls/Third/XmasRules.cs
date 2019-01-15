using System;

namespace OO___Nulls
{
    public class XmasRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(Action<Action> claimMoneyBack, Action<Action> claimNotOperational, Action<Action> claimCircuitry) 
            => new ConditionalRule(IsAroundXmas, claimMoneyBack,
                new DefaultRules().Create(claimMoneyBack, claimNotOperational, claimCircuitry));

        private static bool IsAroundXmas() => DateTime.Today.Month == 12;
    }
}