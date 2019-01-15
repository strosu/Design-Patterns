using System;

namespace OO___Nulls
{
    public abstract class ChainedRule : IWarrantyRules
    {
        private readonly IWarrantyRules _next;
        public Action<Action> Claim { get; protected set; }

        protected ChainedRule(IWarrantyRules next)
        {
            _next = next;
            Claim = Forward;
        }

        protected void Forward(Action onValidClaim) => _next.Claim(onValidClaim);

        public void CircuitryOperational()
        {
            _next.CircuitryOperational();
            HandleCircuitryOperational();
        }

        public void CircuitFailed(DateTime detectedOn)
        {
            _next.CircuitFailed(detectedOn);
            HandleCircuitFailed();
        }

        public void VisibleDamage()
        {
            _next.VisibleDamage();
            HandleVisibleDamage();
        }
        
        public void NotOperational()
        {
            _next.NotOperational();
            HandleNotOperational();
        }
        
        public void Operational()
        {
            _next.Operational();
            HandleOperational();
        }

        protected virtual void HandleVisibleDamage() { }
        protected virtual void HandleCircuitryOperational() { }
        protected virtual void HandleCircuitFailed() { }
        protected virtual void HandleNotOperational() { }
        protected virtual void HandleOperational() { }

    }
}