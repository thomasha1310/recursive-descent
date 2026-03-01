using UnityEngine;

[CreateAssetMenu(menuName = "Cards/CoffeeCard")]
public class CoffeeCard : CardData
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.ModifyEnergy(2);
    }
}