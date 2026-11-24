
using UnityEngine;

public class SafeZoneController : MonoBehaviour
{
    [Header("Zone Settings")]
    public float initialRadius = 1000f;
    public float finalRadius = 50f;
    public float shrinkDuration = 600f;
    public float damageOutsideZone = 5f;
    public float damageInterval = 1f;

    private float currentRadius;
    private float elapsedTime;
    private float nextDamageTime;

    void Start()
    {
        currentRadius = initialRadius;
        UpdateZoneVisual();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float progress = Mathf.Clamp01(
            elapsedTime / shrinkDuration
        );

        currentRadius = Mathf.Lerp(
            initialRadius,
            finalRadius,
            progress
        );

        UpdateZoneVisual();
    }

    void UpdateZoneVisual()
    {
        transform.localScale = new Vector3(
            currentRadius * 2f,
            1f,
            currentRadius * 2f
        );
    }

    public void CheckPlayer(GameObject player)
    {
        if (player == null) return;

        Vector3 offset = player.transform.position - transform.position;
        offset.y = 0f;

        if (offset.magnitude > currentRadius &&
            Time.time >= nextDamageTime)
        {
            PlayerHealth health =
                player.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damageOutsideZone);
            }

            nextDamageTime = Time.time + damageInterval;
        }
    }
}
