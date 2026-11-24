
using UnityEngine;
using System;

public class MatchManager : MonoBehaviour
{
    public static MatchManager Instance { get; private set; }

    [Header("Match Settings")]
    public int maxPlayers = 100;
    public int playersAlive = 100;
    public float matchDuration = 1800f;

    public int totalKills { get; private set; }
    public bool matchStarted { get; private set; }

    public float TimeRemaining { get; private set; }

    public event Action OnMatchEnded;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        TimeRemaining = matchDuration;
    }

    void Update()
    {
        if (!matchStarted) return;

        TimeRemaining -= Time.deltaTime;

        if (TimeRemaining <= 0f || playersAlive <= 1)
        {
            EndMatch();
        }
    }

    public void StartMatch()
    {
        playersAlive = maxPlayers;
        totalKills = 0;
        TimeRemaining = matchDuration;
        matchStarted = true;

        Debug.Log("Battle Royale match started!");
    }

    public void RegisterElimination()
    {
        playersAlive = Mathf.Max(0, playersAlive - 1);
    }

    public void RegisterKill()
    {
        totalKills++;
    }

    void EndMatch()
    {
        if (!matchStarted) return;

        matchStarted = false;
        Debug.Log("Match finished!");
        OnMatchEnded?.Invoke();
    }
}
