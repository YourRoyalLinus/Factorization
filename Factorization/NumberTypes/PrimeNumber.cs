using Factorization.NumberTypes.Interfaces;

namespace Factorization.NumberTypes
{
    public class PrimeNumber : IFactor
    {
        private long _value;

        public PrimeNumber()
        {
            _value = 0;
        }

        public PrimeNumber(long number)
        {
            _value = number;
        }
        
        public long Value
        {
            get => _value;
            set => _value = value;
        }
        
        public static implicit operator long(PrimeNumber number) => number.Value;

        public static implicit operator PrimeNumber(long number) => new PrimeNumber(number);

    }
}