//PEAKNESS game manager

using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("References")]
    [SerializeField] private Player player;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private RoomManager roomManager;

    [Header("Battle State")]
    private List<Enemy> currentEnemies = new List<Enemy>();
    private bool isPlayerTurn;

    [Header("Run Stats — for end screen")]
    private int enemiesDefeated;
    private int totalDamageDealt;
    private int totalDamageTaken;
    private int cardsPlayed;

    // properties 

    public Player CurrentPlayer => player;
    public List<Enemy> CurrentEnemies => currentEnemies;
    public bool IsPlayerTurn => isPlayerTurn;

    // Singleton

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // the GAME FLOW METHODS

    public void StartNewRun(PlayerClassData selectedClass)
    {
        // Initialize player from class data
        // Reset all run stats
        // Tell RoomManager to start at room 0
        // TODO
    }

    public void StartBattle(List<EnemyData> enemyDatas)
    {
        // Instantiate enemies from data
        // Initialize each enemy
        // Start player turn
        // TODO
    }

    // different turns

    public void StartPlayerTurn()
    {
        // player.StartTurn()
        // isPlayerTurn = true
        // Update UI
        // TODO
    }

    public void OnEndTurnPressed()
    {
        // isPlayerTurn = false
        // player.DiscardHand()
        // Start enemy turn
        // TODO
    }

    public void StartEnemyTurn()
    {
        // For each enemy (if not dead, not suppressed):
        //   enemy.ExecuteAction(player)
        //   Update UI
        //   Check if player is dead
        // After all enemies act, start player turn
        // TODO
    }

    // platying the cards

    public void PlayCard(Card card, Enemy target)
    {
        // Check if player has enough energy
        // Spend energy
        // Resolve card effects:
        //   - Handle RNG cards (failChance check)
        //   - Apply damage (single or all enemies)
        //   - Apply healing
        //   - Apply status effects
        //   - Draw cards
        //   - Gain energy
        //   - Gain overconfidence
        //   - Special: Crash Out (lose all overconfidence)
        // Move card from hand to discard
        // Update stats (cardsPlayed++, totalDamageDealt)
        // Check if all enemies are dead
        // Update UI
        // TODO
    }

    // manage the battle (whether it ended and stuff)

    private void CheckBattleEnd()
    {
        // If all enemies dead → OnBattleWon()
        // If player dead → OnPlayerDied()
        // TODO
    }

    private void OnBattleWon()
    {
        // Increment enemiesDefeated
        // Show card reward screen (unless boss)
        // If boss → show victory screen
        // TODO
    }

    private void OnPlayerDied()
    {
        // Show game over screen with stats
        // TODO
    }

    // --- Stats ---

    public RunStats GetRunStats()
    {
        // Return stats for end screen
        // TODO
        return new RunStats();
    }
}

[System.Serializable]
public class RunStats
{
    public int enemiesDefeated;
    public int totalDamageDealt;
    public int totalDamageTaken;
    public int cardsPlayed;
    public PlayerClass playerClass;
}
