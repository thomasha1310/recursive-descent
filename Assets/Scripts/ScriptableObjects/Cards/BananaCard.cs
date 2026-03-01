using UnityEngine;

[CreateAssetMenu()]
public class BananaCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ApplyEffect(EffectType.Strengthened, 1);
    }
}