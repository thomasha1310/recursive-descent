using UnityEngine;

public class MissingSemicolonAction : EnemyActionData
{
    public new string actionName = "Missing Semicolon";
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ReceiveAttack(self.CalculateOutgoingDamage(Random.Range(6, 8)));
    }
}
