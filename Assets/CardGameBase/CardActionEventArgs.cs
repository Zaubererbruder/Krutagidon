using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CardActionEventArgs : EventArgs
{

    public CardActionEventArgs(Player cardOwner, ITarget target)
    {
        CardOwner = cardOwner;
        Target = target;
    }

    public Player CardOwner { get; set; }
    public ITarget Target { get; set; }
}

