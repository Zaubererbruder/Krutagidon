
using System.Collections.Generic;

public class KrutagidonGame : Game<KrutagidonPlayer>
{
    public KrutagidonGame(List<KrutagidonPlayer> players) : base(players)
    {
        KrutagidonStats.InitStats();
        KrutagidonCards.InitCards();
        UseDefaultTurnManager();
    }

    public override void Start()
    {
        base.Start();
    }
}
