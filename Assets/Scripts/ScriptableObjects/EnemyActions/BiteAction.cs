using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/BiteAction")]
public class BiteAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(12));
    }
}
