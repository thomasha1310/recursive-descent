//the enemies class

using System.Collections.Generic;
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

[CreateAssetMenu(fileName = "NewEnemy", menuName = "Enemies/EnemyData")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    [TextArea] public string flavorText;
    public Sprite artwork;
    public int minHP;
    public int maxHP;
    public int hpBudgetCost;                // For room generation algorithm
    public List<EnemyAttack> attacks;
}

//kind of define the AI of the enemy

public class Enemy : Entity
{
    private EnemyData data;

    // What the enemy intends to do next (shown to player)
    private EnemyAttack nextAction;

    // properties of the enemy

    public EnemyData Data => data;
    public EnemyAttack NextAction => nextAction;

    // setup

    public void InitializeFromData(EnemyData enemyData)
    {
        // Randomize HP between minHP and maxHP
        // Set name, flavorText from data
        // Pick first intended action
        // TODO
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
