using Factorization.NumberTypes.Interfaces;

namespace Factorization.NumberTypes
{
    public class CompositeNumber : IFactor
    {
        private long _value;
        
        public CompositeNumber()
        {
            _value = 0;
        }
        public CompositeNumber(long number)
        {
            _value = number;
        }

        public long Value
        {
            get => _value;
            set => _value = value;
        }
        
        public static implicit operator long(CompositeNumber number) => number.Value;

        public static implicit operator CompositeNumber(long number) => new CompositeNumber(number);
        
    }
}