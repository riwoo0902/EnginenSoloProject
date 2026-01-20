using System;

namespace _1.Script.DataStructure.NotifyValueScript
{
    public class NotifyValue<T>
    {
        public NotifyValue(T value)
        {
            _value = value;
        }
        
        private T _value;

        public event Action<T> OnValueChanged;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                _value = value;
                OnValueChanged?.Invoke(value);
            }
        }
    }
}