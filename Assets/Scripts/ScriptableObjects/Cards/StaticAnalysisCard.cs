using UnityEngine;

[CreateAssetMenu()]
public class StaticAnalysisCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        foreach (Enemy enemy in manager.CurrentEnemies)
        {
            enemy.ReceiveAttack(player.CalculateOutgoingDamage(4));
        }
        target.ApplyEffect(EffectType.Analyzed, 1);
    }
}