namespace ChainOfCommand
{
    public interface IApprover
    {
        ApprovalState Approve(decimal ammount);
    }
}