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
    [SerializeField] private List<PlayerData> playerDatas; // assign in Inspector: Programmer, Hacker, VibeCoder

    [Header("Battle State")]
    [SerializeField] private GameObject enemyPrefab;
    private List<Enemy> currentEnemies = new List<Enemy>();
    private bool isPlayerTurn;
    private CardData selectedCard;

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

        uiManager = FindFirstObjectByType<UIManager>();
        roomManager = FindFirstObjectByType<RoomManager>();
        player = FindFirstObjectByType<Player>();
    }

    // the GAME FLOW METHODS

    public void OnStartButtonPressed()
    {
        uiManager.ShowScreen("character");
    }

    public void StartNewRun(PlayerClass selectedClass)
    {
        PlayerData data = playerDatas.Find(d => d.playerClass == selectedClass);
        player.Initialize(0, data);

        enemiesDefeated = 0;
        totalDamageDealt = 0;
        totalDamageTaken = 0;
        cardsPlayed = 0;

        roomManager.StartRun();
        uiManager.ShowScreen("map");
    }

    public void StartBattle(List<EnemyData> enemyDatas)
    {
        // clean up previous enemies
        foreach (Enemy e in currentEnemies)
        {
            if (e != null) Destroy(e.gameObject);
        }
        currentEnemies.Clear();
        selectedCard = null;

        // spawn enemies
        for (int i = 0; i < enemyDatas.Count; i++)
        {
            GameObject go = Instantiate(enemyPrefab, uiManager.EnemyContainer);
            Enemy enemy = go.GetComponent<Enemy>();
            enemy.Initialize(i, enemyDatas[i]);
            currentEnemies.Add(enemy);
        }

        uiManager.ShowScreen("battle");
        StartPlayerTurn();
    }

    // different turns

    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        selectedCard = null;
        player.StartTurn();
        uiManager.UpdatePlayerUI(player);
        uiManager.UpdateEnemyUI(currentEnemies);
        uiManager.RefreshHand(player.Hand, OnCardClicked);
    }

    public void OnEndTurnPressed()
    {
        if (!isPlayerTurn) return;
        isPlayerTurn = false;
        selectedCard = null;
        uiManager.CancelTargeting();

        // discard remaining hand
        while (player.Hand.Count > 0)
        {
            CardData c = player.Hand[0];
            player.Hand.RemoveAt(0);
            player.DiscardPile.Add(c);
        }

        StartEnemyTurn();
    }

    public void StartEnemyTurn()
    {
        for (int i = currentEnemies.Count - 1; i >= 0; i--)
        {
            Enemy enemy = currentEnemies[i];
            if (enemy.IsDead()) continue;

            enemy.TickEffects();
            enemy.TakeAction(this);
            uiManager.UpdatePlayerUI(player);

            if (player.IsDead())
            {
                OnPlayerDied();
                return;
            }
        }

        uiManager.UpdateEnemyUI(currentEnemies);
        CheckBattleEnd();
        if (!player.IsDead() && !AllEnemiesDead())
        {
            StartPlayerTurn();
        }
    }

    // card selection flow

    private void OnCardClicked(CardData card)
    {
        if (!isPlayerTurn) return;
        if (player.Energy < card.energyCost) return;

        selectedCard = card;
        // for cards that need a target, highlight enemies
        uiManager.HighlightEnemies(OnEnemyClicked);
    }

    private void OnEnemyClicked(Enemy target)
    {
        if (selectedCard == null) return;
        PlayCard(selectedCard, target);
        selectedCard = null;
        uiManager.CancelTargeting();
    }

    public void PlayCard(CardData card, Enemy target)
    {
        if (player.Energy < card.energyCost) return;
        player.ModifyEnergy(-card.energyCost);

        // card does its own effect logic
        player.PlayCard(card, target, this);
        cardsPlayed++;

        uiManager.UpdatePlayerUI(player);
        uiManager.UpdateEnemyUI(currentEnemies);

        CheckBattleEnd();
        if (!AllEnemiesDead() && !player.IsDead())
        {
            uiManager.RefreshHand(player.Hand, OnCardClicked);
        }
    }

    // manage the battle

    private bool AllEnemiesDead()
    {
        foreach (Enemy e in currentEnemies)
        {
            if (!e.IsDead()) return false;
        }
        return true;
    }

    private void CheckBattleEnd()
    {
        if (AllEnemiesDead()) OnBattleWon();
        else if (player.IsDead()) OnPlayerDied();
    }

    private void OnBattleWon()
    {
        enemiesDefeated += currentEnemies.Count;
        // show reward or advance
        List<CardData> rewards = roomManager.GetCardRewards(3, false);
        if (rewards.Count > 0)
        {
            uiManager.ShowCardRewards(rewards, OnRewardCardPicked);
        }
        else
        {
            roomManager.AdvanceToNextRoom();
        }
    }

    private void OnRewardCardPicked(CardData card)
    {
        player.AddCardToDeck(card);
        roomManager.AdvanceToNextRoom();
    }

    private void OnPlayerDied()
    {
        uiManager.ShowGameOverScreen(GetRunStats());
    }

    // non-battle rooms

    public void ShowChestReward()
    {
        List<CardData> rewards = roomManager.GetCardRewards(3, true);
        uiManager.ShowScreen("chest");
        uiManager.ShowCardRewards(rewards, OnRewardCardPicked);
    }

    public void ShowBonfire()
    {
        uiManager.ShowScreen("bonfire");
        uiManager.ShowBonfire(() =>
        {
            player.Heal(player.Data.maxHealth);
            uiManager.UpdatePlayerUI(player);
            roomManager.AdvanceToNextRoom();
        });
    }

    public void ShowMap()
    {
        uiManager.ShowScreen("map");
    }

    public void OnVictory()
    {
        uiManager.ShowVictoryScreen(GetRunStats());
    }

    // --- Stats ---

    public RunStats GetRunStats()
    {
        return new RunStats
        {
            enemiesDefeated = this.enemiesDefeated,
            totalDamageDealt = this.totalDamageDealt,
            totalDamageTaken = this.totalDamageTaken,
            cardsPlayed = this.cardsPlayed,
            playerClass = player.PlayerData.playerClass
        };
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
