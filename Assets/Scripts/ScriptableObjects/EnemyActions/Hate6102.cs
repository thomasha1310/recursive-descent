using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/Hate6.102")]
public class Hate6102 : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        self.ApplyEffect(EffectType.Enraged, 1);
    }
}
