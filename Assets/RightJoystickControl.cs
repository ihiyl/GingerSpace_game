using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlatPlanet
{
    internal class RightJoystickControl : MonoBehaviour, IDragHandler, IBeginDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        private Vector2 pos;
        private Vector2 inputVector;
        private Vector2 startPos;
        private Image rightJoystickBg;
        private Image rightJoystickImg;

        private ShootingRayController shootingRayController;

        private void Awake()
        {
            rightJoystickBg = GetComponent<Image>();
            rightJoystickImg = transform.GetChild(0).GetComponent<Image>();

            shootingRayController = GetComponent<ShootingRayController>();
        }

        private void Start()
        {
            startPos = rightJoystickBg.rectTransform.localPosition;
        }

        public virtual void OnDrag(PointerEventData ped)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rightJoystickBg.rectTransform, ped.position, ped.pressEventCamera, out pos))
            {
                pos.x /= rightJoystickBg.rectTransform.sizeDelta.x;
                pos.y /= rightJoystickBg.rectTransform.sizeDelta.y;

                inputVector = new Vector2(pos.x * 2.5f, pos.y * 2.5f);
                inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

                // Движение грибка джойстика
                rightJoystickImg.rectTransform.anchoredPosition = RJIancoredPosition();
            }
        }

        public virtual void OnBeginDrag(PointerEventData ped)
        {
            shootingRayController.ActivateShootingRay();
        }

        public virtual void OnPointerDown(PointerEventData ped)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rightJoystickBg.rectTransform, ped.position, ped.pressEventCamera, out Vector2 tapPos))
            {
                rightJoystickBg.rectTransform.localPosition += (Vector3)tapPos;
            }
            shootingRayController.PrepairingShootingRay();
            OnDrag(ped);
        }

        public virtual void OnPointerUp(PointerEventData ped)
        {
            shootingRayController.DeactivateShootingRay();
            inputVector = Vector2.zero;
            rightJoystickBg.rectTransform.localPosition = startPos;
            rightJoystickImg.rectTransform.localPosition = Vector2.zero;
        }

        public Vector2 RJIancoredPosition() // RJI - это скорее всего Right Joystick Image, я уже и сам не помню
        {
            // Движение грибка джойстика
            return new Vector2(inputVector.x * (rightJoystickBg.rectTransform.sizeDelta.x / 3),
                                inputVector.y * (rightJoystickBg.rectTransform.sizeDelta.y / 3));
        }
    }
}
