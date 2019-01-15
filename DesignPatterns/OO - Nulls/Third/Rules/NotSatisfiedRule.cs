using System;

namespace OO___Nulls
{
    public class NotSatisfiedRule : IWarrantyRules
    {
        public Action<Action> Claim => action => { };

        public void Operational()
        {
        }

        public void CircuitryOperational()
        {
        }

        public void CircuitFailed(DateTime detectedOn)
        {
        }

        public void VisibleDamage()
        {
        }

        public void NotOperational()
        {
        }
    }
}