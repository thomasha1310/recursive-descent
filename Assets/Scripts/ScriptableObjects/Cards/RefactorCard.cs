using UnityEngine;

[CreateAssetMenu(menuName = "Cards/RefactorCard")]
public class RefactorCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        foreach (Enemy enemy in manager.CurrentEnemies)
        {
            enemy.ReceiveAttack(player.CalculateOutgoingDamage(8));
        }
    }
}