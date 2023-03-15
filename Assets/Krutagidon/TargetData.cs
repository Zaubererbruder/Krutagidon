public struct TargetData
{
    public PlayerTargetType TargetType;

    public TargetData(PlayerTargetType targetType)
    {
        TargetType = targetType;
    }

    public bool NeedChoosing
    { get
        {
            return TargetType == PlayerTargetType.Chosen ||
                TargetType == PlayerTargetType.ChosenEnemy ||
                TargetType == PlayerTargetType.Chosens ||
                TargetType == PlayerTargetType.ChosensEnemies;
        }
    }
}

public enum PlayerTargetType
{
    None,
    Self,
    All,
    AllEnemies,
    Left,
    Right,
    Close,
    Chosen,
    ChosenEnemy,
    Chosens,
    ChosensEnemies
}
