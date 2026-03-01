using UnityEngine;

public class MissingSemicolonAction : EnemyActionData
{
    public string actionName = "Missing Semicolon";
    public abstract void PerformAction(Enemy self, Entity target, GameManager manager) {

    }
}
