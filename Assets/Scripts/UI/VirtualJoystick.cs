
using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour,
    IPointerDownHandler,
    IPointerUpHandler,
    IDragHandler
{
    public RectTransform joystickArea;
    public RectTransform joystickHandle;

    public float handleRange = 60f;

    private Vector2 input;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (joystickArea == null || joystickHandle == null)
            return;

        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            joystickArea,
            eventData.position,
            eventData.pressEventCamera,
            out position
        );

        Vector2 halfSize = joystickArea.rect.size / 2f;

        input = new Vector2(
            position.x / halfSize.x,
            position.y / halfSize.y
        );

        input = Vector2.ClampMagnitude(input, 1f);

        joystickHandle.anchoredPosition = input * handleRange;

        MobileInput.MoveInput = input;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        input = Vector2.zero;
        MobileInput.MoveInput = Vector2.zero;

        if (joystickHandle != null)
            joystickHandle.anchoredPosition = Vector2.zero;
    }
}
