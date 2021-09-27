using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    [System.Serializable]
    public class Weapon : MonoBehaviour
    {
        public GameObject character;
        //public List<WeaponStat> Ammo = new List<WeaponStat>();
        public int ActualWeapon;
        public List<GameObject> Ammo = new List<GameObject>();
        public float AmmoDropRate;

        /* public int GetCurrunt() { return Ammo[ActualWeapon].weaponClip; }
         public Weapon() { Debug.Log(5); }
         public GameObject fr12345;
         public string _weaponName;
         public float _shootingDistance;
         public float _weaponDamage;
         public float _weaponRateFire;
         public int _weaponClip;*/



        void Start()
        {

        }


        void Update()
        {

            if (Input.GetKeyDown("1"))
            {
                ActualWeapon = 0;
                //character.GetComponent<Transform>().transform.GetChild(1).gameObject.SetActive(true);
            }

            if (Input.GetKeyDown("2"))
            {
                ActualWeapon = 1;

            }

            if (Input.GetKeyDown("3"))
            {
                ActualWeapon = 2;
            }


            MoselWeaponActive();


        }




        void MoselWeaponActive()
        {
            if (Input.GetKeyDown("1") || Input.GetKeyDown("2") || Input.GetKeyDown("3"))
            {
                for (int i = 0; i < Ammo.Count; i++)
                {
                    if (i != ActualWeapon)
                    {
                        Ammo[i].SetActive(false);
                    }
                    if (i == ActualWeapon)
                    {
                        Ammo[i].SetActive(true);
                    }
                }
            }
        }

        /* public void _wasteOfBullets()
         {
             Debug.Log(" залупа 0" + Ammo.Count);
             Debug.Log(" залупа 1" + Ammo[ActualWeapon].weaponClip);

             Ammo[ActualWeapon].wasteOfBullets();
             Debug.Log(" залупа 2" + Ammo[ActualWeapon].weaponClip);

         }


         [System.Serializable]
         public struct WeaponStat
         {

             public string weaponName;
             public float shootingDistance;
             public float weaponDamage;
             public float weaponRateFire;
             public int weaponClip;
             public GameObject WeaponModel;

             public WeaponStat(string weapon_name, float shooting_distance, float weapon_damage, float weapon_ratefire, int weapon_clip, GameObject weaponModel)
             {
                 Debug.Log("конструктор");
                 weaponName = weapon_name;
                 shootingDistance = shooting_distance;
                 weaponDamage = weapon_damage;
                 weaponRateFire = weapon_ratefire;
                 weaponClip = weapon_clip;
                 WeaponModel = weaponModel;

             }

             public void wasteOfBullets()
             {

                 Debug.Log(" хуй 1" + weaponName);
                 Debug.Log(" хуй 1" + weaponClip);
                 weaponClip = 4;
                 Debug.Log(" хуй 2" + weaponClip);
             }

             public void addingBullets(int count)
             {
                 // weaponClip += count;
             }


         }*/

    }
}


