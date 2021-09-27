using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class WeaponStat : MonoBehaviour
    {
        public string weaponName;
        public float shootingDistance;
        public float weaponDamage;
        public float weaponRateFire;
        public int weaponClip;
        public int MinDropBullet;
        public int MaxDropBullet;


        void Start()
        {

        }


        void Update()
        {

        }

        public void wasteOfBullets()
        {
            weaponClip -= 1;
        }

        public void addingBullets(int count)
        {
            weaponClip += count;
        }
    }

}

