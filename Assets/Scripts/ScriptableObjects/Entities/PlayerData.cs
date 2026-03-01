using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blueprint/PlayerData")]
public class PlayerData : EntityData
{
    public List<CardData> startingHand;
    public List<CardData> startingDeck;
    public PlayerClass playerClass;
    public Sprite avatar;

}