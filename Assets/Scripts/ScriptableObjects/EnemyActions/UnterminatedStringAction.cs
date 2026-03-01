using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/UnterminatedStringAction")]
public class UnterminatedStringAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(Random.Range(10, 13)));
    }
}
