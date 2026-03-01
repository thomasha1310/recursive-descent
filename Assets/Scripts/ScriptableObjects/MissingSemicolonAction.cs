using UnityEngine;

public class MissingSemicolonAction : EnemyActionData
{
    public string actionName = "Missing Semicolon";
    public override void PerformAction(Enemy self, Entity target, GameManager manager) {
        target.ReceiveAttack(Random.Range(6, 8));
    }
}
