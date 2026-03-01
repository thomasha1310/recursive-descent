using UnityEngine;

[CreateAssetMenu()]
public class CodeProfilerCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ApplyEffect(EffectType.Analyzed, 1);
    }
}