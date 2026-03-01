using UnityEngine;

public abstract class CardData : ScriptableObject
{
    public string cardName;
    public int energyCost;
    public string flavorText;
    public Sprite icon;
    public CardRarity rarity;
    public abstract void PerformAction(Player player, Entity target, GameManager manager);
}