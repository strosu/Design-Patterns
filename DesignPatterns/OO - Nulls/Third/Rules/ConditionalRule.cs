using System;

namespace OO___Nulls
{
    public class ConditionalRule : IWarrantyRules
    {
        private readonly Func<bool> _predicate;
        private readonly Action<Action> _claimAction;
        private readonly IWarrantyRules _next;

        public ConditionalRule(Func<bool> predicate, Action<Action> claimAction, IWarrantyRules next)
        {
            _predicate = predicate;
            _claimAction = claimAction;
            _next = next;
        }

        public Action<Action> Claim
        {
            get
            {
                if (_predicate())
                {
                    return AttemptClaim;
                }

                return Forward;
            }
        }

        private void AttemptClaim(Action onValidClaim)
        {
            Action<Action> subsequentAction = Forward;

            _claimAction(() =>
            {
                onValidClaim();
                subsequentAction = (action) => { };
            });

            subsequentAction(onValidClaim);
        }

        private void Forward(Action onValidClaim)
        {
            _next.Claim(onValidClaim);
        }

        public void Operational() => _next.Operational();

        public void CircuitryOperational() => _next.CircuitryOperational();

        public void CircuitFailed(DateTime detectedOn) => _next.CircuitFailed(detectedOn);

        public void VisibleDamage() => _next.VisibleDamage();

        public void NotOperational() => _next.NotOperational();
    }
}