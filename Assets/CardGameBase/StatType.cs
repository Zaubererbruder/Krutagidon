using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class StatType
{
    private static Dictionary<int, StatType> _statsTypes = new Dictionary<int, StatType>();

    private StatType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }

    public static IReadOnlyDictionary<int, StatType> StatsTypes => _statsTypes;

    public static StatType CreateStat(int id, string name)
    {
        if (_statsTypes.ContainsKey(id))
        {
            throw new ArgumentException($"Stat Type with id {id} already exists");
        }

        var statType = new StatType(id, name);
        _statsTypes.Add(id, statType);
        return statType;
    }

    public void ClearStats()
    {
        _statsTypes.Clear();
    }
}
