public class BaseCardAction : ICardAction
{
    private Card _owner;
    private ICardActionDefinition _definition;

    public BaseCardAction(Card owner, ICardActionDefinition definition)
    {
        _owner = owner;
        _definition = definition;
    }

    public Card Card => _owner;

    public ICardActionDefinition Definition => _definition;

    public ActionResult Execute(ActionData args)
    {
        return _definition.Execute(args);
    }
}
