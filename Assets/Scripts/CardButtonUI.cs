//displaying card UI

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardButtonUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image cardBackground;
    [SerializeField] private Button button;

    private CardData cardData;

    public void Setup(CardData data, bool canAfford)
    {
        // Set texts from card data
        // Grey out if canAfford is false
        // TODO
    }

    public CardData GetCardData()
    {
        return cardData;
    }
}
