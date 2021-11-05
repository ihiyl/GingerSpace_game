// Этот GameObject вешается на Image самого луча выстрела

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlatPlanet
{
    internal class RotationShootingRay : MonoBehaviour
    {
        private RightJoystickControl joystickControl;
        public Image shootingRayImage;
        public Transform startPos;
        public float speedRotation = 9.0F;
        public bool startInterpolate;

        private void Awake()
        {
            joystickControl = GameObject.Find("RightJoystickBg").GetComponent<RightJoystickControl>();
        }

        private void Update()
        {
            // Поворот луча выстрела
            // Сделал тут потому что в OnDrag с данной скоростью у Lerp не успевает повернуться

            if (startInterpolate)
            {
                shootingRayImage.rectTransform.localRotation = Quaternion.Lerp(shootingRayImage.rectTransform.localRotation,
                                                                        Quaternion.Euler(0, 0, AngleShootingRay()),
                                                                        Time.deltaTime * speedRotation);
                startPos.rotation = Quaternion.Lerp(startPos.rotation,
                                                        Quaternion.Euler(0, 0, AngleShootingRay()),
                                                        Time.deltaTime * speedRotation);
            }
            else
            {
                shootingRayImage.rectTransform.localRotation = Quaternion.Euler(0, 0, AngleShootingRay());
                startPos.rotation = Quaternion.Euler(0, 0, AngleShootingRay());
            }
        }

        public void StartWaitRateInterpolate()
        {
            StartCoroutine(RateInterpolateRotation());
        }

        private IEnumerator RateInterpolateRotation()
        {
            startInterpolate = false;
            yield return new WaitForSeconds(0.15f);
            startInterpolate = true;
        }

        private float AngleShootingRay()
        {
            float angle = Vector2.Angle(Vector2.up, joystickControl.RJIancoredPosition());
            if (joystickControl.RJIancoredPosition().x > 0)
            {
                angle = -angle;
                return angle;
            }
            return angle;
        }
    }
}
