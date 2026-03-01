using UnityEngine;

[CreateAssetMenu(menuName = "Cards/BreakpointCard")]
public class BreakpointCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        manager.CurrentEnemies[Random.Range(0, manager.CurrentEnemies.Count)].ApplyEffect(EffectType.Suppressed, 1);
        player.GainOverconfidence(4);
    }
}