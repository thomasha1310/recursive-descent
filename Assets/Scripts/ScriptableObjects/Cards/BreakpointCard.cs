using UnityEngine;

[CreateAssetMenu()]
public class BreakpointCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ApplyEffect(EffectType.Suppressed, 1);
        player.GainOverconfidence(4);
    }
}