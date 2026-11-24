
using UnityEngine;

public enum LootType
{
    Ammo,
    Health,
    Weapon
}

public class LootItem : MonoBehaviour
{
    public LootType itemType = LootType.Ammo;
    public int amount = 30;

    public void Collect(GameObject player)
    {
        if (player == null) return;

        switch (itemType)
        {
            case LootType.Ammo:
                Debug.Log("Collected " + amount + " ammo");
                break;

            case LootType.Health:
                PlayerHealth health =
                    player.GetComponent<PlayerHealth>();

                if (health != null)
                {
                    health.Heal(amount);
                }
                break;

            case LootType.Weapon:
                Debug.Log("Collected weapon");
                break;
        }

        Destroy(gameObject);
    }
}
