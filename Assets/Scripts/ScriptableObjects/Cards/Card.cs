using UnityEngine;

public abstract class Card : ScriptableObject
{
    [SerializeField] public string cardName;
    public int energyCost;
    public string flavorText;
    public Sprite icon;
    public abstract void PerformAction(Player player, Entity target, GameManager manager);
}