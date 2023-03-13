using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class KrutagidonCardDefinition : CardDefinition
{
    public KrutagidonCardDefinition(string name, int cost, int victoryPoints, int power, int damage)
    {
        Name = name;
        Stats.Add(
            new Stat(KrutagidonStats.CostStatType, cost)
            );

        Stats.Add(
            new Stat(KrutagidonStats.VictoryPointsStatType, victoryPoints)
            );

        Stats.Add(
            new Stat(KrutagidonStats.PowerStatType, power)
            );

        Stats.Add(
            new Stat(KrutagidonStats.DamageStatType, damage)
            );
    }

    public void AddDamageAction(int damage)
    {
        Actions.Add(new CardAction((sender, e) => 
        {
            var Player = (KrutagidonPlayer)e.Target;
            Player.TakeDamage(damage);
        }));

        NeedTarget = true;
    }

    public override void ActivateCard(Player cardOwner, ITarget target)
    {
        foreach(CardAction action in Actions)
        {
            CardActionEventArgs e = new CardActionEventArgs(cardOwner, target);
            action(cardOwner, e);
        }
    }
}
