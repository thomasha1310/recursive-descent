using UnityEngine;

[CreateAssetMenu(menuName = "Cards/BananaCard")]
public class BananaCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ApplyEffect(EffectType.Strengthened, 1);
    }
}