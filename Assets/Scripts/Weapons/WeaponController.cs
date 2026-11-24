
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Weapon Settings")]
    public float damage = 25f;
    public float fireRate = 0.15f;
    public float range = 150f;
    public int magazineSize = 30;

    private int currentAmmo;
    private float nextFireTime;

    void Start()
    {
        currentAmmo = magazineSize;
    }

    public void Fire(Transform cameraTransform)
    {
        if (cameraTransform == null) return;
        if (Time.time < nextFireTime) return;
        if (currentAmmo <= 0) return;

        nextFireTime = Time.time + fireRate;
        currentAmmo--;

        Ray ray = new Ray(
            cameraTransform.position,
            cameraTransform.forward
        );

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            PlayerHealth health =
                hit.collider.GetComponentInParent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        Debug.Log("Ammo: " + currentAmmo);
    }

    public void Reload()
    {
        currentAmmo = magazineSize;
        Debug.Log("Weapon reloaded");
    }
}
