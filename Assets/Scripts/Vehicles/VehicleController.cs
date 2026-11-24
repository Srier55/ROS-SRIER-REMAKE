
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Vehicle Settings")]
    public float acceleration = 15f;
    public float maxSpeed = 25f;
    public float steeringSpeed = 80f;
    public float brakeStrength = 20f;

    private float currentSpeed;
    private bool isOccupied;

    void Update()
    {
        if (!isOccupied) return;

        float throttle = Input.GetAxis("Vertical");
        float steering = Input.GetAxis("Horizontal");

        currentSpeed += throttle * acceleration * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed, maxSpeed);

        if (Mathf.Abs(throttle) < 0.1f)
        {
            currentSpeed = Mathf.MoveTowards(
                currentSpeed, 0f, brakeStrength * Time.deltaTime
            );
        }

        transform.Translate(
            Vector3.forward * currentSpeed * Time.deltaTime
        );

        transform.Rotate(
            Vector3.up * steering * steeringSpeed *
            Time.deltaTime * Mathf.Sign(currentSpeed == 0 ? 1 : currentSpeed)
        );
    }

    public void EnterVehicle()
    {
        isOccupied = true;
    }

    public void ExitVehicle()
    {
        isOccupied = false;
    }
}
