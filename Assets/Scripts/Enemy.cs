using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : Entity
{
    private EnemyData enemyData;
    private EnemyActionData intent;

    public EnemyData EnemyData => enemyData;
    public EnemyActionData Intent => intent;

    // setup

    public override void Initialize(int id, EntityData entityData)
    {
        base.Initialize(id, entityData);
        enemyData = entityData as EnemyData;
        DecideNextIntent();
    }

    // dumbass AI 

    public void DecideNextIntent()
    {
        int totalWeight = 0;
        foreach (var action in EnemyData.actionPool)
        {
            totalWeight += action.Value;
        }
        int roll = Random.Range(0, totalWeight);
        totalWeight = 0;
        foreach (var action in EnemyData.actionPool)
        {
            totalWeight += action.Value;
            if (totalWeight > roll)
            {
                intent = action.Key;
                return;
            }
        }
    }

    public void TakeAction(GameManager manager)
    {
        if (HasEffect(EffectType.Suppressed))
        {
            DecideNextIntent();
            return;
        }

        intent.PerformAction(this, manager);
        DecideNextIntent();
    }
}
