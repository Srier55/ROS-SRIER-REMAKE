
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MobilePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 8f;
    public float rotationSpeed = 12f;
    public Transform cameraTransform;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector2 input = MobileInput.MoveInput;

        Vector3 forward = cameraTransform != null
            ? cameraTransform.forward
            : Vector3.forward;

        Vector3 right = cameraTransform != null
            ? cameraTransform.right
            : Vector3.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 direction =
            forward * input.y + right * input.x;

        float speed = MobileInput.SprintPressed
            ? sprintSpeed
            : moveSpeed;

        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(direction),
                rotationSpeed * Time.deltaTime
            );
        }

        controller.Move(
            direction * speed * Time.deltaTime
        );
    }
}
