using UnityEngine;

[CreateAssetMenu(menuName = "Cards/ClaudeCodeCard")]
public class ClaudeCodeCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        if (Random.Range(0.0f, 1.0f) < 0.1)
        {
            player.ApplyEffect(EffectType.AISlop, 3);
        }
        else
        {
            target.ApplyEffect(EffectType.AgenticAI, 3);
        }
    }
}