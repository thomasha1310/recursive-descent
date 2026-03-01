//displaying card UI

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image cardIcon;
    [SerializeField] private Button button;

    private CardData card;

    public void Setup(CardData card, bool canAfford, System.Action<CardData> onClick)
    {
        this.card = card;
        nameText.text = card.cardName;
        costText.text = card.energyCost.ToString();
        if (descriptionText != null) descriptionText.text = card.description;
        if (cardIcon != null && card.icon != null) cardIcon.sprite = card.icon;

        // grey out if can't afford
        button.interactable = canAfford;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() => onClick(card));
    }

    public CardData GetCard()
    {
        return card;
    }
}