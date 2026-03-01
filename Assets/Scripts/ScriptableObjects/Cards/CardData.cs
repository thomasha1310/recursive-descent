//card definitions 

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Cards/CardData")]
public class CardData : ScriptableObject
{
    [Header("Basic Info")]
    public string cardName;
    public int energyCost;
    [TextArea] public string flavorText;
    public Sprite artwork;

    [Header("Classification")]
    public CardRarity rarity;
    public TargetType targetType;

    [Header("Effects")]
    public int damage;
    public int damageToAll;
    public int healing;              // For potions like Boba
    public int overconfidenceGain;
    public int cardsToDraw;
    public int energyGain;

    [Header("Status Effects")]
    public EffectType appliedEffect;
    public bool appliesEffect;
    public int effectDuration;
    public bool effectTargetsSelf;   // true = self, false = enemy

    [Header("RNG Cards (ChatGPT, Claude Code)")]
    public bool hasFailChance;
    [Range(0f, 1f)] public float failChance;
    public EffectType failEffect;
    public int failEffectDuration;

    [Header("Special")]
    public bool losesAllOverconfidence;  // For Crash Out
}
