using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ITurnManager
{
    public event Action TurnChanged;
    
    public Player CurrentPlayer { get; }
    
    public void EndTurn();

    public void Init(List<Player> players);
}
