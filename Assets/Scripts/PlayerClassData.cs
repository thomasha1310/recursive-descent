//player class data

using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewClass", menuName = "Player/ClassData")]
public class PlayerClassData : ScriptableObject
{
    public string className;
    public PlayerClass classType;
    public int maxHP;
    public Sprite portrait;
    [TextArea] public string description;
    public List<CardData> startingDeck;
}

// Create 3 assets in Unity Inspector:
// - Programmer Duck:  80 HP
// - Hacker Duck:      75 HP
// - Vibe Coder Duck:  67 HP
