using UnityEngine;

[CreateAssetMenu(menuName = "Cards/CodeProfilerCard")]
public class CodeProfilerCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        target.ApplyEffect(EffectType.Analyzed, 1);
    }
}