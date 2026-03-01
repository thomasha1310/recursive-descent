using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/Hate6.102Action")]
public class Hate6102Action : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        self.ApplyEffect(EffectType.Enraged, 1);
    }
}
