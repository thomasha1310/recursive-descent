using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/TypoAction")]
public class TypoAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(6));
    }
}
