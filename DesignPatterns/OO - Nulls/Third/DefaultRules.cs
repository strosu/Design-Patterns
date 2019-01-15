using System;

namespace OO___Nulls
{
    public class DefaultRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(Action<Action> claimMoneyBack, Action<Action> claimNotOperational, Action<Action> claimCircuitry)
            => new NotOperationalRule(claimNotOperational,
                new CircuitryRule(claimCircuitry,
                    new MoneyBackRule(claimMoneyBack,
                        new NotSatisfiedRule())));
    }
}