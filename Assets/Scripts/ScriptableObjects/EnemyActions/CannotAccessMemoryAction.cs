using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/CannotAccessMemoryAction")]
public class CannotAccessMemoryAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(Random.Range(16, 21)));
    }
}
