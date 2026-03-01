using UnityEngine;

public abstract class EnemyActionData : ScriptableObject
{
    public string actionName;
    public abstract void PerformAction(Enemy self, Entity target, GameManager manager);
}
