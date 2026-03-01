using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Blueprint/EnemyData")]
public class EnemyData : EntityData
{
    public List<WeightedEnemyAction> actionPool;
}