//all the enums

public enum EffectType
{
    Depressed,      // Takes 100% more damage for 1 turn
    Analyzed,
    AISlop,         // Random heal/damage for 3 turns
    AgenticAI,
    Suppressed,     // Cannot act for 1 turn
    BurntOut,       // 50% less damage for 2 turns, then apply Motivated
    Motivated,      // 200% more damage for 1 turn
    Enraged,        // 200% more damage for 1 turn (enemy version)
    Strengthened    // 50% more damage for 1 turn
}

public enum RoomType
{
    Battle,
    Chest,
    Bonfire,
    Boss
}

public enum PlayerClass
{
    Programmer,     // 80 HP
    Hacker,         // 75 HP
    VibeCoder       // 67 HP
}

public enum CardRarity
{
    Common,
    Uncommon,
    Rare
}

public enum TargetType
{
    SingleEnemy,
    AllEnemies,
    Self,
    None
}
