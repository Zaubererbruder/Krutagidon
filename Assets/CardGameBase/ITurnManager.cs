using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface ITurnManager<TPlayer> where TPlayer:Player
{
    public event Action TurnChanged;
    
    public TPlayer CurrentPlayer { get; }
    
    public void NextTurn();

    public void Init(List<TPlayer> players);
}
