using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerData playerData;

    private int energy;
    private const int MAX_ENERGY = 3;

    private readonly List<CardData> hand = new();
    private readonly List<CardData> drawPile = new();
    private readonly List<CardData> discardPile = new();

    // properties

    public int Energy => energy;
    public PlayerData PlayerData => playerData;
    public List<CardData> Hand => hand;
    public List<CardData> DrawPile => drawPile;
    public List<CardData> DiscardPile => discardPile;

    // initialization

    public override void Initialize(int id, EntityData entityData)
    {
        base.Initialize(id, entityData);
        playerData = entityData as PlayerData;
        energy = 3;
        foreach (CardData card in playerData.startingDeck)
        {
            drawPile.Add(card);
        }
        Shuffle(drawPile);
    }

    public void ResetEnergy()
    {
        energy = MAX_ENERGY;
    }

    public void ModifyEnergy(int amount)
    {
        energy += amount;
    }

    public void DrawCards(int count)
    {
        for (int n = 0; n < count; n++)
        {
            if (drawPile.Count == 0)
            {
                foreach (CardData card in discardPile)
                {
                    drawPile.Add(card);
                }
                discardPile.Clear();

                Shuffle(drawPile);
            }

            hand.Add(drawPile[^1]);
            drawPile.RemoveAt(drawPile.Count - 1);
        }
    }

    private void Shuffle(List<CardData> cards)
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }

    public void PlayCard(CardData card, Entity target, GameManager manager)
    {
        hand.Remove(card);
        discardPile.Add(card);
        card.PerformAction(this, target, manager);
    }

    public void ResetCards()
    {
        foreach (CardData card in hand)
        {
            drawPile.Add(card);
        }
        foreach (CardData card in discardPile)
        {
            drawPile.Add(card);
        }
        hand.Clear();
        discardPile.Clear();
        Shuffle(drawPile);
    }

    public void AddCardToDeck(CardData card)
    {
        drawPile.Add(card);
    }

    public void StartTurn()
    {
        ResetEnergy();
        ResetOverconfidence();
        DrawCards(5 - hand.Count);
        TickEffects();
    }
}
