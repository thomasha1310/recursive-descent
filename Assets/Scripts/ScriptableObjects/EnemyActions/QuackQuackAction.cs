using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/QuackQuackAction")]
public class QuackQuackAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        self.GainOverconfidence(12);
        manager.CurrentPlayer.ApplyEffect(EffectType.AISlop, 3);
    }
}
