//the enemies class

using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class EnemyAttack
{
    public string attackName;
    [Range(0f, 1f)] public float weight;    // Probability of using this attack
    public int minDamage;
    public int maxDamage;
    public int overconfidenceGain;
    public bool appliesEffect;
    public EffectType effect;
    public int effectDuration;
    public bool effectTargetsSelf;          // Enraged targets self
}

//kind of define the AI of the enemy

public class Enemy : Entity
{
    private EnemyData enemyData;

    // What the enemy intends to do next (shown to player)
    private EnemyAttack nextAction;

    // properties of the enemy

    public EnemyData EnemyData => enemyData;
    public EnemyAttack NextAction => nextAction;

    // setup

    public override void Initialize(int id, EntityData entityData)
    {

    }

    // dumbass AI 

    public void DecideNextAction()
    {
        // Weighted random selection from data.attacks
        // Store in nextAction so UI can show intent
        // TODO
    }

    public void ExecuteAction(Player player, GameManager manager)
    {
        // If Suppressed, skip turn
        // Calculate damage with GetDamageMultiplier()
        // Randomize between minDamage and maxDamage
        // Apply damage to player
        // Apply any effects
        // Gain overconfidence if attack grants it
        // Pick next intended action
        // TODO
    }
}
