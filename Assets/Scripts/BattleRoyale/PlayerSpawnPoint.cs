
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    [Header("Player")]
    public GameObject playerPrefab;

    [Header("Spawn Settings")]
    public bool spawnOnStart = false;

    private GameObject spawnedPlayer;

    void Start()
    {
        if (spawnOnStart)
        {
            SpawnPlayer();
        }
    }

    public GameObject SpawnPlayer()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab is missing!");
            return null;
        }

        if (spawnedPlayer != null)
        {
            Destroy(spawnedPlayer);
        }

        spawnedPlayer = Instantiate(
            playerPrefab,
            transform.position,
            transform.rotation
        );

        Debug.Log("Player spawned!");

        return spawnedPlayer;
    }
}
