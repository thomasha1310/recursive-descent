using UnityEngine;

[CreateAssetMenu()]
public class BobaCard : Card
{
    public override void PerformAction(Player player, Entity target, GameManager manager)
    {
        player.Heal(player.PlayerData.maxHealth);
    }
}