using UnityEngine;

[CreateAssetMenu()]
public class WhiteMonsterCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ApplyEffect(EffectType.Motivated, 1);
    }
}