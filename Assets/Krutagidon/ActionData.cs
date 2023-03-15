
using System.Collections.Generic;

public class ActionData
{

    public ActionData(Player caster)
    {
        Caster = caster;
    }

    public Player Caster { get; private set; }
    public List<Player> Targets { get; set; } = new List<Player>();

    public Player Target
    {
        get { return Targets[0]; }
        set { Targets.Clear(); Targets.Add(value); }
    }

    public ActionData WithTarget(Player target)
    {
        Target = target;
        return this;
    }
}
