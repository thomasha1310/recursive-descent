using UnityEngine;

[CreateAssetMenu(menuName = "Cards/CrashOutCard")]
public class CrashOutCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ResetOverconfidence();
        player.ApplyEffect(EffectType.BurntOut, 2);
    }
}