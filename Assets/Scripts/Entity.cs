using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int id;
    [SerializeField] private EntityData data;

    private int health;
    private int overconfidence;

    protected List<Effect> activeEffects = new();

    public int Id => id;
    public EntityData Data => data;
    public int Health => health;
    public int Overconfidence => overconfidence;

    // Initialization

    public virtual void Initialize(int id, EntityData entityData)
    {
        this.id = id;
        data = entityData;
        health = data.maxHealth;
    }

    public void ReceiveAttack(float damage)
    {
        float multiplier = 1.0f;
        if (HasEffect(EffectType.Depressed) || HasEffect(EffectType.Analyzed))
        {
            multiplier += 1.0f;
        }

        int effectiveDamage = Mathf.RoundToInt(damage * multiplier);
        if (effectiveDamage <= overconfidence)
        {
            overconfidence -= effectiveDamage;
            return;
        }

        effectiveDamage -= overconfidence;
        overconfidence = 0;
        health -= effectiveDamage;
        if (health < 0)
        {
            health = 0;
            Die();
        }
    }

    public void Heal(int amount)
    {
        health = Math.Min(data.maxHealth, health + amount);
    }

    public void GainOverconfidence(int amount)
    {
        overconfidence += amount;
    }

    public void ResetOverconfidence()
    {
        overconfidence = 0;
    }

    public void ApplyEffect(EffectType type, int duration)
    {
        activeEffects.Add(new Effect(type, duration));
    }

    public bool HasEffect(EffectType type)
    {
        foreach (Effect effect in activeEffects)
        {
            if (effect.type == type)
            {
                return true;
            }
        }
        return false;
    }

    // Called at the beginning of the Entity's turn.
    public void TickEffects()
    {
        // Iterate backwards to safely remove expired effects while iterating.
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            Effect effect = activeEffects[i];

            switch (effect.type)
            {
                case EffectType.AISlop:
                case EffectType.AgenticAI:
                    if (UnityEngine.Random.Range(0.0f, 1.0f) < 0.5)
                    {
                        Heal(5);
                    }
                    else
                    {
                        ReceiveAttack(10);
                    }
                    break;
                default:
                    break;
            }

            effect.remainingTurns--;
            if (effect.remainingTurns == 0)
            {
                if (effect.type == EffectType.BurntOut)
                {
                    ApplyEffect(EffectType.Motivated, 1);
                }
                activeEffects.RemoveAt(i);
            }
        }
    }

    public void ClearEffects()
    {
        activeEffects.Clear();
    }

    // modifes the damage dealt

    public float GetDamageMultiplier()
    {
        float multiplier = 1.0f;
        if (HasEffect(EffectType.BurntOut))
        {
            multiplier -= 0.5f;
        }
        if (HasEffect(EffectType.Motivated) || HasEffect(EffectType.Enraged))
        {
            multiplier += 2.0f;
        }
        if (HasEffect(EffectType.Strengthened))
        {
            multiplier += 0.5f;
        }
        return multiplier;
    }

    public float CalculateOutgoingDamage(int baseDamage)
    {
        return GetDamageMultiplier() * baseDamage;
    }

    // check for special effects

    public bool IsDead()
    {
        return health == 0;
    }

    public bool IsSuppressed()
    {
        // TODO
        return false;
    }

    protected virtual void Die()
    {

    }
}
