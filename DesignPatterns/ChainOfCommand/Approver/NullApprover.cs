using System.ComponentModel;

namespace ChainOfCommand
{
    public class NullApprover : IApprover
    {
        public static NullApprover Instance = new NullApprover();

        private NullApprover()
        {
        }

        public ApprovalState Approve(decimal ammount)
        {
            return ApprovalState.LimitReached;
        }
    }
}