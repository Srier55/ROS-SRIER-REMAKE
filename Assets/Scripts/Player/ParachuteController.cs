
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class ParachuteController : MonoBehaviour
{
    [Header("Parachute Settings")]
    public float normalFallSpeed = 25f;
    public float parachuteFallSpeed = 5f;
    public float horizontalSpeed = 12f;

    private CharacterController controller;
    private bool parachuteOpen;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OpenParachute();
        }

        if (parachuteOpen)
        {
            Glide();
        }
    }

    public void OpenParachute()
    {
        parachuteOpen = true;
    }

    public void CloseParachute()
    {
        parachuteOpen = false;
    }

    void Glide()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(
            horizontal,
            0f,
            vertical
        );

        Vector3 movement =
            direction * horizontalSpeed +
            Vector3.down * parachuteFallSpeed;

        controller.Move(movement * Time.deltaTime);
    }

    public bool IsParachuteOpen()
    {
        return parachuteOpen;
    }
}
