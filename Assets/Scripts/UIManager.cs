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
    [SerializeField] private GameObject battleScreen;
    [SerializeField] private GameObject rewardScreen;
    [SerializeField] private GameObject bonfireScreen;
    [SerializeField] private GameObject chestScreen;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject gameOverScreen;

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
        // TODO
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

    public void RefreshHand(List<CardData> hand, System.Action<CardData> onCardClicked)
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

    public void ShowCardRewards(List<CardData> cards, System.Action<CardData> onCardPicked)
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
