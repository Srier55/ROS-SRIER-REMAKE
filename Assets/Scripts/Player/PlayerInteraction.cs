
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactionRange = 3f;
    public Camera playerCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (playerCamera == null) return;

        Ray ray = new Ray(
            playerCamera.transform.position,
            playerCamera.transform.forward
        );

        if (Physics.Raycast(
            ray,
            out RaycastHit hit,
            interactionRange))
        {
            LootItem loot =
                hit.collider.GetComponentInParent<LootItem>();

            if (loot != null)
            {
                loot.Collect(gameObject);
                return;
            }

            VehicleController vehicle =
                hit.collider.GetComponentInParent<VehicleController>();

            if (vehicle != null)
            {
                vehicle.EnterVehicle();
                Debug.Log("Entered vehicle");
            }
        }
    }
}
