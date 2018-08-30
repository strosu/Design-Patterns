using System;

namespace OO.After
{
    public class Account
    {
        private readonly Action _onUnfreeze;
        private bool _isverified;
        private bool _isClosed;
        private bool _isFrozen;


        public Account(Action onUnfreeze)
        {
            _onUnfreeze = onUnfreeze;
            this.ManageUnfreezing = StayUnfrozen;
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (_isClosed)
            {
                return;
            }

            ManageUnfreezing();

            Balance += amount;
        }

        private Action ManageUnfreezing { get; set; }

        private void StayUnfrozen()
        {
        }

        private void Unfreeze()
        {
            _isFrozen = false;
            _onUnfreeze();
            ManageUnfreezing = StayUnfrozen;
        }

        public void Withdraw(decimal amount)
        {
            if (!_isverified)
            {
                return;
            }

            if (_isClosed)
            {
                return;
            }

            ManageUnfreezing();

            Balance -= amount;
        }

        public void Verify()
        {
            _isverified = true;
        }

        public void Close()
        {
            _isClosed = true;
        }

        public void Freeze()
        {
            if (!_isverified)
            {
                return;
            }

            if (_isClosed)
            {
                return;
            }

            _isFrozen = true;
            this.ManageUnfreezing = Unfreeze;
        }
    }
}