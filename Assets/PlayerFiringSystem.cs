using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FlatPlanet
{
    internal class PlayerFiringSystem : MonoBehaviour
    {
        public bool fire;
        public float rateOfFire; // Default = 0.5f
        public GameObject startBulletPos; 
        private RotationShootingRay rotationShootingRay;
        public bool fireBlocked = false;
        public int weaponLvl;

        private void Awake() 
        {
            rotationShootingRay = GameObject.Find("ShootingRayContainer").GetComponent<RotationShootingRay>();
        }


        public void StartShooting()
        {
            if (fireBlocked == false)
            {
                fire = true;
                StartCoroutine(ShootingLoop());
            }
        }

        public void StopShooting()
        {
            fire = false;
            StopCoroutine(ShootingLoop());
        }

        private IEnumerator ShootingLoop()
        {
            if (fire == true)
            {
                yield return new WaitForSeconds(0.05f);


                yield return new WaitForSeconds(rateOfFire);
                StartCoroutine(ShootingLoop());
            }
            else
                yield return null;
        }

    }
}
