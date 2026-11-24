
using UnityEngine;

public class MobileInput : MonoBehaviour
{
    public static Vector2 MoveInput { get; private set; }

    public static bool FirePressed { get; private set; }
    public static bool AimPressed { get; private set; }
    public static bool SprintPressed { get; private set; }

    public void SetMovement(Vector2 input)
    {
        MoveInput = Vector2.ClampMagnitude(input, 1f);
    }

    public void StopMovement()
    {
        MoveInput = Vector2.zero;
    }

    public void FireDown() { FirePressed = true; }
    public void FireUp() { FirePressed = false; }

    public void AimDown() { AimPressed = true; }
    public void AimUp() { AimPressed = false; }

    public void SprintDown() { SprintPressed = true; }
    public void SprintUp() { SprintPressed = false; }
}
