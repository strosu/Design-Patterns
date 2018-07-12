namespace ChainOfCommand
{
    public class ApprovalHandler : IApprover
    {
        private readonly IApprover _approver;
        private IApprover _next;

        public ApprovalHandler(IApprover approver)
        {
            _approver = approver;
            _next = NullApprover.Instance;
        }

        public void AddNext(IApprover next)
        {
            _next = next;
        }

        public ApprovalState Approve(decimal ammount)
        {
            var result = _approver.Approve(ammount);

            if (result == ApprovalState.LimitReached)
            {
                return _next.Approve(ammount);
            }

            return result;
        }
    }
}