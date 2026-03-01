// the PlAyer

using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [Header("Player Config")]
    [SerializeField] private PlayerClassData classData;

    [Header("Runtime State")]
    private int energy;
    private int maxEnergy = 3;

    private List<CardData> deck = new List<CardData>();
    private List<CardData> hand = new List<CardData>();
    private List<CardData> drawPile = new List<CardData>();
    private List<CardData> discardPile = new List<CardData>();

    // properties

    public int Energy => energy;
    public int MaxEnergy => maxEnergy;
    public List<CardData> Hand => hand;
    public List<CardData> Deck => deck;

    // initialization

    public void InitializeFromClass(PlayerClassData classData)
    {
        // Set health from classData.maxHP
        // Copy classData.startingDeck into deck
        // TODO
    }

    // manage the energy

    public void ResetEnergy()
    {
        // energy = maxEnergy at start of turn
        // TODO
    }

    public bool SpendEnergy(int amount)
    {
        // Return false if not enough
        // TODO
        return false;
    }

    public void GainEnergy(int amount)
    {
        // TODO
    }

    // card manageenmtn

    public void StartBattle()
    {
        // Move all deck cards into drawPile
        // Shuffle drawPile
        // Clear hand and discardPile
        // TODO
    }

    public void DrawCards(int count)
    {
        // For each card to draw:
        //   If drawPile is empty, shuffle discardPile into drawPile
        //   Move top card from drawPile to hand
        // TODO
    }

    public void PlayCard(CardData card)
    {
        // Remove from hand
        // Add to discardPile
        // TODO
    }

    public void DiscardHand()
    {
        // Move all hand cards to discardPile
        // Called at end of turn
        // TODO
    }

    public void AddCardToDeck(CardData card)
    {
        // Called when player picks a reward card
        // TODO
    }

    // turn management

    public void StartTurn()
    {
        // ResetEnergy()
        // ResetOverconfidence()
        // DrawCards(5)
        // TickEffects()
        // TODO
    }
}
