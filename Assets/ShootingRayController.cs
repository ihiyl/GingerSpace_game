// Этот GameObject вешается на грибок джойстика, который управляет стрельбой, так как тут часть логики прошлого контроллера джойстика (что странно, ну да ладно, я не знал, был маленький и глупый)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlatPlanet
{
    internal class ShootingRayController : MonoBehaviour
    {
        private RotationShootingRay rotationShootingRay;
        private PlayerFiringSystem playerFiringSystem;
        private GameObject shootingRayGO;
        public GameObject player;

        private void Awake()
        {
            rotationShootingRay = GameObject.Find("ShootingRayContainer").GetComponent<RotationShootingRay>();
            shootingRayGO = GameObject.Find("ShootingRayPlanetContainer");
        }

        private void Start() 
        {
            playerFiringSystem = player.GetComponent<PlayerFiringSystem>();
            rotationShootingRay.gameObject.SetActive(false); // Чтобы изначально не было видно луча выстела
            shootingRayGO.SetActive(false);
        }

        internal void ActivateShootingRay()
        {
            //shootingRay.rectTransform.localRotation = Quaternion.Euler(0, 0, AngleShootingRay()); // Поворот луча выстрела
            //rotationShootingRay.gameObject.SetActive(true);
            rotationShootingRay.enabled = true;
            rotationShootingRay.StartWaitRateInterpolate();
            playerFiringSystem.StartShooting();
        }

        internal void PrepairingShootingRay()
        {
            shootingRayGO.SetActive(true);
            rotationShootingRay.gameObject.SetActive(true);
            rotationShootingRay.enabled = true;
            rotationShootingRay.StartWaitRateInterpolate();
        }

        internal void DeactivateShootingRay()
        {
            playerFiringSystem.StopShooting();
            rotationShootingRay.startInterpolate = false;
            rotationShootingRay.enabled = false;
            rotationShootingRay.gameObject.SetActive(false);
            shootingRayGO.SetActive(false);
        }
    }
}
