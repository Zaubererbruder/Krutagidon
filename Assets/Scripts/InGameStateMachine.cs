using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class InGameStateMachine : StateMachineBase<InGameState>
    {
        public InGameStateMachine()
        {
            SetState(InGameState.PreInit);
        }

        public override void SetState(InGameState state)
        {
            if (state == InGameState.CheckGameOverConditions)
                base.SetState(InGameState.PassingTheTurn);
            else
                base.SetState(state);
        }
    }

    public enum InGameState
    {
        PreInit,
        Init,
        PropertySelection,
        FamiliarSelection,
        PassingTheTurn,
        TheTurn,
        CheckGameOverConditions,
        GameOver
    }
}
