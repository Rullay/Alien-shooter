using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class SpawnBullet : MonoBehaviour
    {

        private List<float> BulletPrioritet = new List<float>();
        private float MinPriorityBullet;
        private float CofPriorityBullet;
        public GameObject _character;
       
        public List<GameObject> BulletModel = new List<GameObject>();

        //[Header("Min Max DropBullet")]





        void Start()
        {

        }


        void Update()
        {

        }

        public void Weaponpriority()
        {
            CofPriorityBullet = 0;
            MinPriorityBullet = 0;
            Weapon _Weapon = _character.GetComponent<Weapon>();
            for (int i = 1;  _Weapon.Ammo.Count > i; i++)
            {
                if (MinPriorityBullet <= _Weapon.Ammo[i].GetComponent<WeaponStat>().weaponClip * _Weapon.Ammo[i].GetComponent<WeaponStat>().weaponDamage)
                {
                    MinPriorityBullet = _Weapon.Ammo[i].GetComponent<WeaponStat>().weaponClip * _Weapon.Ammo[i].GetComponent<WeaponStat>().weaponDamage;
                }
            }

            for (int i = 1; _Weapon.Ammo.Count > i; i++)
            {
                BulletPrioritet.Add(Random.Range(0.5f, 1f * MinPriorityBullet / (_Weapon.Ammo[i].GetComponent<WeaponStat>().weaponClip * _Weapon.Ammo[i].GetComponent<WeaponStat>().weaponDamage)));
            }

            for (int i = 0; BulletPrioritet.Count > i; i++)
            {
                if (CofPriorityBullet <= BulletPrioritet[i])
                {
                    CofPriorityBullet = BulletPrioritet[i];
                    //Debug.Log("Дробавик" + BulletPrioritet[0]);
                    //Debug.Log("Автомат" + BulletPrioritet[1]);
                }
            }

            for (int i = 0; BulletPrioritet.Count > i; i++)
            {
                if (BulletPrioritet[i] == CofPriorityBullet)
                {
                    //Debug.Log(CofPriorityBullet);
                    for (int n = 0; n < BulletModel.Count; n++)
                    {
                        if (n != i)
                        {
                            BulletModel[n].SetActive(false);
                        }
                        if (n == i)
                        {
                            Debug.Log(1);
                            BulletModel[n].SetActive(true);
                            GetComponent<BulletStat>().WeaponWinner = n + 1;
                        }
                    }

                }
            }

            BulletPrioritet.Clear();
        }

    }
}
