using UnityEngine;

[CreateAssetMenu(menuName = "Cards/WhiteMonsterCard")]
public class WhiteMonsterCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ApplyEffect(EffectType.Motivated, 1);
    }
}