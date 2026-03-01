using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blueprint/EnemyData")]
public class EnemyData : EntityData
{
    public Dictionary<EnemyActionData, int> actionPool;
}