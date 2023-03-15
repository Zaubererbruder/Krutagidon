public interface ICardActionDefinition
{
    public TargetData TargetData { get; }
    public ActionResult Execute(ActionData args);
}

