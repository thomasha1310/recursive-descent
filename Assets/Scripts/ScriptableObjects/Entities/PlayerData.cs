using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blueprint/PlayerData")]
public class PlayerData : EntityData
{
    public List<Card> startingHand;
    public List<Card> startingDeck;

}