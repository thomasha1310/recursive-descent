using UnityEngine;

[CreateAssetMenu(menuName = "Cards/PrintfCard")]
public class PrintfCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ReceiveAttack(player.CalculateOutgoingDamage(8));
    }
}