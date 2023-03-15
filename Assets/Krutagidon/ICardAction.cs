using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ICardAction
{
    public Card Card { get; }
    public ICardActionDefinition Definition { get; }
    public ActionResult Execute(ActionData args);
}
