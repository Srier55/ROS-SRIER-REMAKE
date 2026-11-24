
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    [Header("Camera Settings")]
    public Vector3 offset = new Vector3(0f, 3f, -5f);
    public float followSpeed = 10f;
    public float lookHeight = 1.5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition =
            target.position + target.rotation * offset;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            followSpeed * Time.deltaTime
        );

        Vector3 lookTarget =
            target.position + Vector3.up * lookHeight;

        transform.LookAt(lookTarget);
    }
}
