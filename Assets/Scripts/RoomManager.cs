//room managment

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomManager : MonoBehaviour
{
    [Header("Enemy Data — assign in Inspector")]
    [SerializeField] private EnemyData mosquitoData;
    [SerializeField] private EnemyData cockroachData;
    [SerializeField] private EnemyData spiderData;
    [SerializeField] private EnemyData mothData;
    [SerializeField] private EnemyData bossData;

    [Header("Card Reward Pool")]
    [SerializeField] private List<CardData> rewardPool;

    private int currentRoomIndex = 0;

    // button names in order matching the room sequence
    private readonly string[] roomButtonNames = {
        "battle_1", "battle_2", "chest", "battle_3", "battle_4", "bonfire", "boss"
    };

    private Button[] roomButtons;

    private void Awake()
    {
        roomButtons = new Button[roomButtonNames.Length];
        for (int i = 0; i < roomButtonNames.Length; i++)
        {
            GameObject go = GameObject.Find(roomButtonNames[i]);
            if (go != null)
            {
                roomButtons[i] = go.GetComponent<Button>();
                int index = i; // capture for closure
                roomButtons[i].onClick.AddListener(() => OnRoomButtonClicked(index));
            }
        }
    }

    public void StartRun()
    {
        currentRoomIndex = 0;
        UpdateMapButtons();
    }

    private void UpdateMapButtons()
    {
        for (int i = 0; i < roomButtons.Length; i++)
        {
            if (roomButtons[i] == null) continue;
            roomButtons[i].interactable = (i == currentRoomIndex);
        }
    }

    private void OnRoomButtonClicked(int index)
    {
        if (index != currentRoomIndex) return;
        LoadRoom(index);
    }

    private void LoadRoom(int index)
    {
        switch (index)
        {
            case 0: // battle_1: 2 mosquitos
                GameManager.Instance.StartBattle(new List<EnemyData> { mosquitoData, mosquitoData });
                break;
            case 1: // battle_2: 1 mosquito + 1 cockroach
                GameManager.Instance.StartBattle(new List<EnemyData> { mosquitoData, cockroachData });
                break;
            case 2: // chest: pick 1 of 3 cards
                GameManager.Instance.ShowChestReward();
                break;
            case 3: // battle_3: 1 spider
                GameManager.Instance.StartBattle(new List<EnemyData> { spiderData });
                break;
            case 4: // battle_4: 1 moth
                GameManager.Instance.StartBattle(new List<EnemyData> { mothData });
                break;
            case 5: // bonfire: heal to full
                GameManager.Instance.ShowBonfire();
                break;
            case 6: // boss: Timmy
                GameManager.Instance.StartBattle(new List<EnemyData> { bossData });
                break;
        }
    }

    public void AdvanceToNextRoom()
    {
        currentRoomIndex++;
        if (currentRoomIndex >= roomButtonNames.Length)
        {
            GameManager.Instance.OnVictory();
            return;
        }
        GameManager.Instance.ShowMap();
        UpdateMapButtons();
    }

    public List<CardData> GetCardRewards(int count, bool isChest)
    {
        if (rewardPool == null || rewardPool.Count == 0) return new List<CardData>();

        List<CardData> rewards = new List<CardData>();
        List<CardData> pool = new List<CardData>(rewardPool);

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            rewards.Add(pool[index]);
            pool.RemoveAt(index);
        }
        return rewards;
    }
}