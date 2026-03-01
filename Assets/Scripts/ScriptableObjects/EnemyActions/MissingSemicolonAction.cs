using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/MissingSemicolonAction")]
public class MissingSemicolonAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(Random.Range(6, 9)));
    }
}
