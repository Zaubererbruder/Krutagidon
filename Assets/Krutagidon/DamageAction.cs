public class DamageAction : ICardActionDefinition
{
    private TargetData _targetData;
    private int _damage;

    public DamageAction(int damage)
    {
        _damage = damage;
        _targetData = new TargetData(PlayerTargetType.ChosenEnemy);
    }

    public TargetData TargetData => _targetData;

    public ActionResult Execute(ActionData args)
    {
        args.Target.TakeDamage(_damage);
        return ActionResult.Empty;
    }
}
