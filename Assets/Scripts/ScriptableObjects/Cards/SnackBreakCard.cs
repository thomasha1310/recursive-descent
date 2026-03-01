using UnityEngine;

[CreateAssetMenu(menuName = "Cards/SnackBreakCard")]
public class SnackBreakCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.DrawCards(2);
        player.GainOverconfidence(5);
    }
}