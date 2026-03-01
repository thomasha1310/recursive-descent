using UnityEngine;

[CreateAssetMenu()]
public class PrintfCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ReceiveAttack(player.CalculateOutgoingDamage(8));
    }
}