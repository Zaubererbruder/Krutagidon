using System;

namespace Assets.Scripts.Krutagidon
{
    public class IntStat : IStat<int>
    {
        public string Name { get; private set; }
        public int Value { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public IntStat(string name, int defaultValue = 0, int minValue = 0, int maxValue = 100)
        {
            Name = name;
            Value = defaultValue;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public void Add(int val)
        {
            Value = Math.Clamp(Value + val, MinValue, MaxValue);
        }

        public void Sub(int val)
        {
            Value = Math.Clamp(Value - val, MinValue, MaxValue);
        }
    }
}
