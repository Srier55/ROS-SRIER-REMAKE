
using UnityEngine;

public class MobileWeaponInput : MonoBehaviour
{
    public WeaponController currentWeapon;
    public Transform cameraTransform;

    void Update()
    {
        if (MobileInput.FirePressed)
        {
            if (currentWeapon != null &&
                cameraTransform != null)
            {
                currentWeapon.Fire(cameraTransform);
            }
        }
    }

    public void ReloadWeapon()
    {
        if (currentWeapon != null)
        {
            currentWeapon.Reload();
        }
    }
}
