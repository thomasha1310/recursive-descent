// the effects class

[System.Serializable]
public class Effect
{
    public EffectType type;
    public int remainingTurns;

    public Effect(EffectType type, int duration)
    {
        // TODO
    }

    public void Tick()
    {
        // Decrement remainingTurns
        // If BurntOut expires, apply Motivated
        // TODO
    }

    public bool IsExpired()
    {
        // TODO
        return false;
    }
}
