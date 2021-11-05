using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

internal class LeftJoystickControl : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler,  IBeginDragHandler
{

    public FireSystem fireSystem;
    private Vector2 pos;
    private static Vector2 inputVector;
    private Vector2 startPos;
    private Image leftJoystickBg;
    private Image leftJoystickImg;

    private void Awake()
    {
        leftJoystickBg = GetComponent<Image>();
        leftJoystickImg = transform.GetChild(0).GetComponent<Image>();
    }
    private void Start()
    {
        startPos = leftJoystickBg.rectTransform.localPosition;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(leftJoystickBg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / leftJoystickBg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / leftJoystickBg.rectTransform.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2.5f, pos.y * 2.5f);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            // Движение грибка джойстика
            leftJoystickImg.rectTransform.anchoredPosition =
                new Vector2(inputVector.x * (leftJoystickBg.rectTransform.sizeDelta.x / 3),
                            inputVector.y * (leftJoystickBg.rectTransform.sizeDelta.y / 3));

            //Debug.Log(leftJoystickImg.rectTransform.anchoredPosition);3
        }
    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        Vector2 tapPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(leftJoystickBg.rectTransform, ped.position, ped.pressEventCamera, out tapPos))
        {
            leftJoystickBg.rectTransform.localPosition += (Vector3)tapPos;
        }
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        leftJoystickBg.rectTransform.localPosition = startPos;
        leftJoystickImg.rectTransform.localPosition = Vector2.zero;
        fireSystem.DeActevate();
    }

    public virtual void OnBeginDrag(PointerEventData ped)
    {
        fireSystem.ActivateShootingRay();
    }

    public static float Horizontal()
    {
        if (inputVector.x != 0)
            return inputVector.x;
        else
            return Input.GetAxis("Horizontal");
    }

    public static float Vertical()
    {
        if (inputVector.y != 0)
            return inputVector.y;
        else
            return Input.GetAxis("Vertical");
    }
}