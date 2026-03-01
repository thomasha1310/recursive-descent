using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DebuggerCard")]
public class DebuggerCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ReceiveAttack(player.CalculateOutgoingDamage(6));
    }
}