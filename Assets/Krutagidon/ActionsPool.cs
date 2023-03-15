using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ActionsPool
{
    private Stack<ICardAction> _cardActions = new Stack<ICardAction>();

    public void Add(params ICardAction[] actions)
    {
        foreach (ICardAction action in actions)
        {
            _cardActions.Push(action);
        }
    }

    public ActionData RequiredActionData { get; set; }

    public IEnumerator Execute()
    {
        RequiredActionData = null;

        for (; _cardActions.Count > 0;)
        {
            ICardAction action = _cardActions.Pop();
            if (action.Definition.TargetData.NeedChoosing)
            {
                while (RequiredActionData == null)
                {
                    yield return null;
                }
                action.Execute(RequiredActionData);
                RequiredActionData = null;
                continue;
            }

            ActionData actionData = new ActionData(action.Card.PlayerOwner);
            action.Execute(actionData);
        }
    }
}
