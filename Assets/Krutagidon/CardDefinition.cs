using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CardDefinition
{
    private List<ICardActionDefinition> _actionsOnPlay = new List<ICardActionDefinition>();
    private List<TargetData> _requiredTargetsDataOnPlay = new List<TargetData>();


    public string Name { get; private set; }
    public int Cost { get; private set; }
    public int VictoryPoints { get; private set; }
    public IReadOnlyList<ICardActionDefinition> ActionsOnPlay => _actionsOnPlay;
    public IReadOnlyList<TargetData> RequiredTargetsDataOnPlay => _requiredTargetsDataOnPlay;
    public bool NeedTargetOnPlay => _requiredTargetsDataOnPlay.Count > 0;
    


    public CardDefinition(string name, int cost, int victoryPoints)
    {
        Name = name;
        Cost = cost;
        VictoryPoints = victoryPoints;
    }

    public void AddActionOnPlay(ICardActionDefinition action)
    {
        _actionsOnPlay.Add(action);
        if (action.TargetData.TargetType == PlayerTargetType.Chosen ||
            action.TargetData.TargetType == PlayerTargetType.ChosenEnemy ||
            action.TargetData.TargetType == PlayerTargetType.Chosens ||
            action.TargetData.TargetType == PlayerTargetType.ChosensEnemies)
        {
            _requiredTargetsDataOnPlay.Add(action.TargetData);
        }
    }

    public void AddActionOnAttack()
    {
        throw new NotImplementedException();
    }

    public void AddActionOnDefense()
    {
        throw new NotImplementedException();
    }
}
