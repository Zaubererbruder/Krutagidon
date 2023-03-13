using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class KrutagidonStats
{
    public static void InitStats()
    {
        StatType.CreateStat(((int)KrutagidonStatType.Health), KrutagidonStatType.Health.ToString());
        StatType.CreateStat(((int)KrutagidonStatType.Cost), KrutagidonStatType.Cost.ToString());
        StatType.CreateStat(((int)KrutagidonStatType.VictoryPoints), KrutagidonStatType.VictoryPoints.ToString());
        StatType.CreateStat(((int)KrutagidonStatType.Power), KrutagidonStatType.Power.ToString());
        StatType.CreateStat(((int)KrutagidonStatType.Damage), KrutagidonStatType.Damage.ToString());
    }

    public static StatType GetStatType(KrutagidonStatType typeEnum)
    {
        return StatType.StatsTypes[((int)typeEnum)];
    }

    public static StatType HealthStatType => GetStatType(KrutagidonStatType.Health);

    public static StatType CostStatType => GetStatType(KrutagidonStatType.Cost);
    public static StatType VictoryPointsStatType => GetStatType(KrutagidonStatType.VictoryPoints);
    public static StatType PowerStatType => GetStatType(KrutagidonStatType.Power);
    public static StatType DamageStatType => GetStatType(KrutagidonStatType.Damage);
}

public enum KrutagidonStatType
{
    Health = 0,
    Cost = 100,
    VictoryPoints = 101,
    Power = 102,
    Damage = 103
}
