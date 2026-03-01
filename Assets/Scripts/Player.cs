using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private PlayerData playerData;

    private int energy;
    private const int MAX_ENERGY = 3;

    private readonly List<Card> hand = new();
    private readonly List<Card> drawPile = new();
    private readonly List<Card> discardPile = new();

    // properties

    public int Energy => energy;
    public List<Card> Hand => hand;
    public List<Card> DrawPile => drawPile;
    public List<Card> DiscardPile => discardPile;

    // initialization

    public override void Initialize(int id, EntityData entityData)
    {
        base.Initialize(id, entityData);
        playerData = entityData as PlayerData;
        energy = 3;
        foreach (Card card in playerData.startingDeck)
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
                foreach (Card card in discardPile)
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

    private void Shuffle(List<Card> cards)
    {
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            (cards[n], cards[k]) = (cards[k], cards[n]);
        }
    }

    public void PlayCard(Card card)
    {
        hand.Remove(card);
        discardPile.Add(card);
    }

    public void ResetCards()
    {
        foreach (Card card in hand)
        {
            drawPile.Add(card);
        }
        foreach (Card card in discardPile)
        {
            drawPile.Add(card);
        }
        hand.Clear();
        discardPile.Clear();
        Shuffle(drawPile);
    }

    public void AddCardToDeck(Card card)
    {
        drawPile.Add(card);
    }

    // turn management

    public void StartTurn()
    {
        ResetEnergy();
        ResetOverconfidence();
        DrawCards(5 - hand.Count);
        TickEffects();
    }
}
