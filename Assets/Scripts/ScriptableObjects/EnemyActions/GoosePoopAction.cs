using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Actions/GoosePoopAction")]
public class GoosePoopAction : EnemyActionData
{
    public override void PerformAction(Enemy self, GameManager manager)
    {
        manager.CurrentPlayer.ApplyEffect(EffectType.Depressed, 1);
    }
}
