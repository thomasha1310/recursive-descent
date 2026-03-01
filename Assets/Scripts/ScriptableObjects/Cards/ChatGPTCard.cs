using UnityEngine;

[CreateAssetMenu()]
public class ChatGPTCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        if (Random.Range(0.0f, 1.0f) < 0.2)
        {
            player.ApplyEffect(EffectType.AISlop, 3);
        }
        else
        {
            target.ReceiveAttack(player.CalculateOutgoingDamage(20));
        }
    }
}