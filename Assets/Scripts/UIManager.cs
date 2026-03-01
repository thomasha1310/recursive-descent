//the actual UI manager, really rough draft

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject mainMenuScreen;
    [SerializeField] private GameObject classSelectScreen;
    [SerializeField] private GameObject mapSelectScreen;
    [SerializeField] private GameObject battleScreen;
    [SerializeField] private GameObject rewardScreen;
    [SerializeField] private GameObject bonfireScreen;
    [SerializeField] private GameObject chestScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gameOverScreen;

    private void Awake()
    {
        mainMenuScreen = GameObject.Find("MainMenu");
        classSelectScreen = GameObject.Find("SelectCharacter");
        mapSelectScreen = GameObject.Find("Map");
        battleScreen = GameObject.Find("Battle");
        rewardScreen = GameObject.Find("Reward");
        bonfireScreen = GameObject.Find("Bonfire");
        chestScreen = GameObject.Find("Chest");
        victoryScreen = GameObject.Find("Victory");
        gameOverScreen = GameObject.Find("GameOver");

        // Start button
        GameObject.Find("Start").GetComponent<Button>().onClick.AddListener(
            () => GameManager.Instance.OnStartButtonPressed()
        );

        // Class select buttons
        GameObject.Find("Programmer").GetComponent<Button>().onClick.AddListener(
            () => GameManager.Instance.StartNewRun(PlayerClass.Programmer)
        );
        GameObject.Find("Hacker").GetComponent<Button>().onClick.AddListener(
            () => GameManager.Instance.StartNewRun(PlayerClass.Hacker)
        );
        GameObject.Find("VibeCoder").GetComponent<Button>().onClick.AddListener(
            () => GameManager.Instance.StartNewRun(PlayerClass.VibeCoder)
        );

        // End turn button
        endTurnButton = GameObject.Find("EndTurnButton")?.GetComponent<Button>();
        if (endTurnButton != null)
        {
            endTurnButton.onClick.AddListener(() => GameManager.Instance.OnEndTurnPressed());
        }
    }

    private void Start()
    {
        ShowScreen("menu");
    }

    [Header("Battle UI")]
    [SerializeField] private TMP_Text playerHPText;
    [SerializeField] private Slider playerHPBar;
    [SerializeField] private TMP_Text energyText;
    [SerializeField] private TMP_Text overconfidenceText;
    [SerializeField] private Transform cardHandContainer;   // Horizontal Layout Group
    [SerializeField] private GameObject cardButtonPrefab;
    [SerializeField] private Transform enemyContainer;
    [SerializeField] private GameObject enemyUIPrefab;

    public Transform EnemyContainer => enemyContainer;
    [SerializeField] private Button endTurnButton;

    [Header("Boss Dialogue")]
    [SerializeField] private TMP_Text bossDialogueText;

    [Header("Reward UI")]
    [SerializeField] private Transform rewardCardContainer;

    [Header("End Screen")]
    [SerializeField] private TMP_Text statsText;

    // screen management

    public void ShowScreen(string screenName)
    {
        mainMenuScreen.SetActive(false);
        classSelectScreen.SetActive(false);
        mapSelectScreen.SetActive(false);
        battleScreen.SetActive(false);
        rewardScreen.SetActive(false);
        bonfireScreen.SetActive(false);
        chestScreen.SetActive(false);
        victoryScreen.SetActive(false);
        gameOverScreen.SetActive(false);

        switch (screenName)
        {
            case "menu": mainMenuScreen.SetActive(true); break;
            case "character": classSelectScreen.SetActive(true); break;
            case "map": mapSelectScreen.SetActive(true); break;
            case "battle": battleScreen.SetActive(true); break;
            case "reward": rewardScreen.SetActive(true); break;
            case "bonfire": bonfireScreen.SetActive(true); break;
            case "chest": chestScreen.SetActive(true); break;
            case "victory": victoryScreen.SetActive(true); break;
            case "gameOver": gameOverScreen.SetActive(true); break;
        }
    }

    // battle UI

    public void UpdatePlayerUI(Player player)
    {
        if (playerHPText != null)
            playerHPText.text = player.Health + " / " + player.Data.maxHealth;
        if (playerHPBar != null)
        {
            playerHPBar.maxValue = player.Data.maxHealth;
            playerHPBar.value = player.Health;
        }
        if (energyText != null)
            energyText.text = "Energy: " + player.Energy;
        if (overconfidenceText != null)
            overconfidenceText.text = "Shield: " + player.Overconfidence;
    }

    public void UpdateEnemyUI(List<Enemy> enemies)
    {
        // for now just log — full enemy UI needs enemyUIPrefab setup
        // TODO: instantiate enemy UI panels if not done yet
    }

    public void RefreshHand(List<CardData> hand, System.Action<CardData> onCardClicked)
    {
        // clear old cards
        foreach (Transform child in cardHandContainer)
        {
            Destroy(child.gameObject);
        }

        int playerEnergy = GameManager.Instance.CurrentPlayer.Energy;

        foreach (CardData card in hand)
        {
            GameObject go = Instantiate(cardButtonPrefab, cardHandContainer);
            CardButtonUI cardUI = go.GetComponent<CardButtonUI>();
            bool canAfford = playerEnergy >= card.energyCost;
            cardUI.Setup(card, canAfford, onCardClicked);
        }
    }

    public void HighlightEnemies(System.Action<Enemy> onEnemyClicked)
    {
        // for now, auto-target first alive enemy since enemy UI isn't built yet
        List<Enemy> enemies = GameManager.Instance.CurrentEnemies;
        foreach (Enemy enemy in enemies)
        {
            if (!enemy.IsDead())
            {
                onEnemyClicked(enemy);
                return;
            }
        }
    }

    public void CancelTargeting()
    {
        // nothing to clean up until enemy UI targeting is built
    }

    // timmy's dialogues

    public void ShowBossDialogue(string quote)
    {
        if (bossDialogueText != null)
            bossDialogueText.text = quote;
    }

    // reward screen

    public void ShowCardRewards(List<CardData> cards, System.Action<CardData> onCardPicked)
    {
        ShowScreen("reward");

        // clear old reward cards
        if (rewardCardContainer != null)
        {
            foreach (Transform child in rewardCardContainer)
            {
                Destroy(child.gameObject);
            }

            foreach (CardData card in cards)
            {
                GameObject go = Instantiate(cardButtonPrefab, rewardCardContainer);
                CardButtonUI cardUI = go.GetComponent<CardButtonUI>();
                cardUI.Setup(card, true, onCardPicked);
            }
        }
    }

    // bonfire room

    public void ShowBonfire(System.Action onRest)
    {
        // find and wire the rest button inside the bonfire screen
        Button restButton = bonfireScreen.GetComponentInChildren<Button>();
        if (restButton != null)
        {
            restButton.onClick.RemoveAllListeners();
            restButton.onClick.AddListener(() => onRest());
        }
    }

    // win/loss screens

    public void ShowVictoryScreen(RunStats stats)
    {
        ShowScreen("victory");
        if (statsText != null)
            statsText.text = "Enemies Defeated: " + stats.enemiesDefeated
                + "\nDamage Dealt: " + stats.totalDamageDealt
                + "\nCards Played: " + stats.cardsPlayed;
    }

    public void ShowGameOverScreen(RunStats stats)
    {
        ShowScreen("gameOver");
        if (statsText != null)
            statsText.text = "Enemies Defeated: " + stats.enemiesDefeated
                + "\nDamage Dealt: " + stats.totalDamageDealt
                + "\nCards Played: " + stats.cardsPlayed;
    }
}