using System;

namespace OO___Nulls
{
    public interface IWarrantyRulesFactory
    {
        IWarrantyRules Create(Action<Action> claimMoneyBack, Action<Action> claimNotOperational, Action<Action> claimCircuitry);
    }
}