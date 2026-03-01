[System.Serializable]
public class Effect
{
    public EffectType type;
    public int remainingTurns;

    public Effect(EffectType type, int duration)
    {
        this.type = type;
        remainingTurns = duration;
    }
}
