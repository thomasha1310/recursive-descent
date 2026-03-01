using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/OnePlusTwoAction")]
public class OnePlusTwoAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(12));
    }
}
