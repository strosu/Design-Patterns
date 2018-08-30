using System;

namespace OO.Initial
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
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (_isClosed)
            {
                return;
            }

            if (_isFrozen)
            {
                _isFrozen = false;
                _onUnfreeze();
            }

            Balance += amount;
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

            if (_isFrozen)
            {
                _isFrozen = false;
                _onUnfreeze();
            }

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
        }
    }
}