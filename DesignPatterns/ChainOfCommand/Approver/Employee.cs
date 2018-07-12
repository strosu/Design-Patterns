namespace ChainOfCommand
{
    public class Employee : IApprover
    {
        private readonly string _name;
        private readonly decimal _approvalLimit;
        
        public Employee(string name, decimal approvalLimit)
        {
            _name = name;
            _approvalLimit = approvalLimit;
        }

        public ApprovalState Approve(decimal ammount)
        {
            if (ammount <= _approvalLimit)
            {
                return ApprovalState.Approved;
            }

            return ApprovalState.LimitReached;
        }
    }
}