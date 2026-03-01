using UnityEngine;

[CreateAssetMenu()]
public class RefactorCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        foreach (Enemy enemy in manager.CurrentEnemies)
        {
            enemy.ReceiveAttack(player.CalculateOutgoingDamage(8));
        }
    }
}