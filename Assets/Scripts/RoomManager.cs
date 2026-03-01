//room managment

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomConfig
{
    public RoomType type;
    public int enemyHPBudget;   // Only used for Battle rooms
}

public class RoomManager : MonoBehaviour
{
    [Header("Room Sequence")]
    // fight -> fight -> chest -> fight -> fight -> bonfire -> boss
    [SerializeField] private List<RoomConfig> roomSequence;

    [Header("Enemy Pool")]
    [SerializeField] private List<EnemyData> smallEnemies;  // Mosquito, Moth
    [SerializeField] private List<EnemyData> bigEnemies;    // Spider, Cockroach
    [SerializeField] private EnemyData bossEnemy;           // Timmy

    [Header("Card Reward Pool")]
    [SerializeField] private List<Card> rewardPool;

    private int currentRoomIndex = 0;

    // define room progresssions

    public void StartRun()
    {
        // Reset to room 0
        // Load first room
        // TODO
    }

    public void AdvanceToNextRoom()
    {
        // currentRoomIndex++
        // If past last room → victory
        // Otherwise load the next room
        // TODO
    }

    private void LoadRoom(RoomConfig room)
    {
        // Switch on room.type:
        //   Battle → GenerateEnemies(room.enemyHPBudget) → GameManager.StartBattle()
        //   Chest  → ShowChestReward()
        //   Bonfire → ShowBonfire()
        //   Boss   → GameManager.StartBattle(bossEnemy)
        // TODO
    }

    // generate enemies for room

    private List<EnemyData> GenerateEnemies(int hpBudget)
    {
        // Fill the budget with enemies from the pool
        // Strategy: pick random enemy, if it fits in budget, add it
        // Repeat until budget is full or nearly full
        // Example: budget 30 → 2x Mosquito (13+13=26) 
        // Example: budget 50 → 1x Spider (38) + can't fit another big one
        // TODO
        return new List<EnemyData>();
    }

    // grab the rewards

    public List<Card> GetCardRewards(int count, bool isChest)
    {
        // Pick 'count' random cards from rewardPool
        // If isChest, weight towards rarer cards
        // Return list for UI to display
        // TODO
        return new List<Card>();
    }

    // bonfire room for heals

    public void RestAtBonfire()
    {
        // Heal player to full HP
        // AdvanceToNextRoom()
        // TODO
    }
}
