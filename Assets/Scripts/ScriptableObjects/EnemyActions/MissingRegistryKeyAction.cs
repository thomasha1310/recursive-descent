using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/MissingRegistryKeyAction")]
public class MissingRegistryKeyAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(10));
    }
}
