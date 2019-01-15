using System;

namespace OO___Nulls
{
    public interface IWarrantyRules
    {
        Action<Action> Claim { get; }
        void Operational();
        void CircuitryOperational();
        void CircuitFailed(DateTime detectedOn);
        void VisibleDamage();
        void NotOperational();
    }
}