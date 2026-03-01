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
        // Hide all screens, show the requested one
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

    // diplaying teh battle UI

    public void UpdatePlayerUI(Player player)
    {
        // Update HP text/bar, energy, overconfidence
        // Update active effects display
        // TODO
    }

    public void UpdateEnemyUI(List<Enemy> enemies)
    {
        // Update each enemy's HP, intent, effects
        // Remove dead enemies from display
        // TODO
    }

    public void RefreshHand(List<Card> hand, System.Action<Card> onCardClicked)
    {
        // Clear existing card buttons
        // For each card in hand:
        //   Instantiate cardButtonPrefab in cardHandContainer
        //   Set card name, cost, description text
        //   Add onClick listener → onCardClicked(card)
        //   Grey out if not enough energy
        // TODO
    }

    public void HighlightEnemies(System.Action<Enemy> onEnemyClicked)
    {
        // Show targeting indicators on enemies
        // Set onClick for each enemy → onEnemyClicked(enemy)
        // Called after player clicks a single-target card
        // TODO
    }

    public void CancelTargeting()
    {
        // Remove targeting indicators
        // TODO
    }

    // timmy's idalogues

    public void ShowBossDialogue(string quote)
    {
        // Display Timmy's quote with some flair
        // Maybe flash the text or shake the screen
        // TODO
    }

    // reward screen

    public void ShowCardRewards(List<Card> cards, System.Action<Card> onCardPicked)
    {
        // Display 3 cards to choose from
        // onClick → onCardPicked(card) → advance room
        // TODO
    }

    // the bonfire room

    public void ShowBonfire(System.Action onRest)
    {
        // Show "Rest" button
        // onClick → onRest() (heals and advances)
        // TODO
    }

    // win/loss screen

    public void ShowVictoryScreen(RunStats stats)
    {
        // Display run stats
        // Show "Back to Menu" button
        // TODO
    }

    public void ShowGameOverScreen(RunStats stats)
    {
        // Display run stats
        // Show "Back to Menu" button
        // TODO
    }

    // shwoing the damage number

    public void ShowDamageNumber(Vector3 position, int damage)
    {
        // Optional: floating damage text
        // Skip this if running low on time
        // TODO
    }
}
