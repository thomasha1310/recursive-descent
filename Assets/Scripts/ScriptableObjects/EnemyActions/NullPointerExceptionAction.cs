using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/NullPointerExceptionAction")]
public class NullPointerExceptionAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(Random.Range(12, 17)));
        self.GainOverconfidence(6);
    }
}
