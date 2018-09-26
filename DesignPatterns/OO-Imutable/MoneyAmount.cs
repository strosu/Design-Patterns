using System;

namespace OO_Imutable
{
    public sealed class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public MoneyAmount(decimal amount, string currency)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount negative");
            }

            Amount = amount;
            Currency = currency;
        }

        public MoneyAmount Scale(decimal factor) => new MoneyAmount(Amount * factor, Currency);

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        public override string ToString() => $"{Amount} {Currency}";

        public override bool Equals(object obj) =>
            Equals(obj as MoneyAmount);

        public override int GetHashCode()
        {
            // return Amount.GetHashCode() ^ Currency.GetHashCode();
            return new {Amount, Currency}.GetHashCode();
        }

        public static bool operator ==(MoneyAmount a, MoneyAmount b) => 
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) || 
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public bool Equals(MoneyAmount other) =>
            other != null &&
            Amount == other.Amount &&
            Currency == other.Currency;
    }
}