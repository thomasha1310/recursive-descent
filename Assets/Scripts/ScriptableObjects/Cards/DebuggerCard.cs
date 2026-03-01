using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DebuggerCard")]
public class DebuggerCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ReceiveAttack(player.CalculateOutgoingDamage(6));
    }
}