public class Stat
{
    public StatType StatType { get; private set; }
    public int Value { get; private set; }
    public int BaseValue { get; private set; }

    public Stat(StatType statType, int baseValue)
    {
        BaseValue = baseValue;
        Value = baseValue;
    }

    public void ChangeValue(int changeValue)
    {
        Value += changeValue;
    }
}
