//the base class for the player and the enemy

using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [Header("Identity")]
    [SerializeField] private string entityName;
    [SerializeField] private string flavorText;

    [Header("Stats")]
    [SerializeField] private int maxHealth;
    private int health;
    private int overconfidence;

    [Header("Status Effects")]
    protected List<Effect> activeEffects = new List<Effect>();

    // some properties

    public string EntityName => entityName;
    public string FlavorText => flavorText;
    public int Health => health;
    public int MaxHealth => maxHealth;
    public int Overconfidence => overconfidence;

    // Initialization

    public virtual void Initialize(string name, int maxHP)
    {
        // Set entityName, maxHealth, health
        // Clear effects
        // TODO
    }

    // health related stuff

    public void ReceiveAttack(int damage)
    {
        // Check for Depressed (double damage)
        // Check for BurntOut on attacker? (handled by caller)
        // Subtract overconfidence first, then health
        // Clamp health to 0
        // TODO
    }

    public void Heal(int amount)
    {
        // Clamp to maxHealth
        // TODO
    }

    // Overconfidence related 

    public void GainOverconfidence(int amount)
    {
        // TODO
    }

    public void ResetOverconfidence()
    {
        // Called at start of each turn
        // TODO
    }

    // status effects

    public void ApplyEffect(EffectType type, int duration)
    {
        // Check if effect already exists — refresh or stack?
        // Add new Effect to activeEffects
        // TODO
    }

    public bool HasEffect(EffectType type)
    {
        // TODO
        return false;
    }

    public void TickEffects()
    {
        // Call Tick() on each effect
        // Remove expired effects
        // Handle BurntOut -> Motivated transition
        // TODO
    }

    public void ClearEffects()
    {
        // TODO
    }

    // modifes the damage dealt

    public float GetDamageMultiplier()
    {
        // 2.0 if Motivated or Enraged
        // 0.5 if BurntOut
        // 1.5 if Strengthened
        // 1.0 otherwise
        // TODO
        return 1.0f;
    }

    // check for special effects

    public bool IsDead()
    {
        // TODO
        return false;
    }

    public bool IsSuppressed()
    {
        // TODO
        return false;
    }
}
