
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [Header("UI Text")]
    public Text healthText;
    public Text playersText;
    public Text killsText;
    public Text timerText;

    [Header("Player")]
    public PlayerHealth playerHealth;

    void Update()
    {
        if (playerHealth != null && healthText != null)
        {
            healthText.text =
                "HP: " + Mathf.CeilToInt(
                    playerHealth.currentHealth
                );
        }

        if (MatchManager.Instance == null) return;

        MatchManager match = MatchManager.Instance;

        if (playersText != null)
            playersText.text = "Alive: " + match.playersAlive;

        if (killsText != null)
            killsText.text = "Kills: " + match.totalKills;

        if (timerText != null)
        {
            int seconds = Mathf.CeilToInt(
                match.TimeRemaining
            );

            timerText.text = string.Format(
                "{0:00}:{1:00}",
                seconds / 60,
                seconds % 60
            );
        }
    }
}
