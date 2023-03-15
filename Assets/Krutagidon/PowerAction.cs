using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PowerAction : ICardActionDefinition
{
    private TargetData _targetData;
    private int _power;

    public PowerAction(int power)
    {
        _power = power;
        _targetData = new TargetData(PlayerTargetType.Self);
    }

    public TargetData TargetData => _targetData;

    public Card Owner => throw new NotImplementedException();

    public ActionResult Execute(ActionData args)
    {
        args.Caster.RaisePower(_power);
        return ActionResult.Empty;
    }
}