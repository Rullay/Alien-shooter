using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace game
{
    public class Character : MonoBehaviour
    {
        public float speed;
        private Vector3 MoveVector3;
        public new Rigidbody rigidbody;
        private Vector3 mousePosition;
        public float speedRotate = 10f;
        public RaycastHit hit;
        public Text monstrsHealth;
        public GameObject testHealth;
        private bool shotDelay;
        public int wastedBullets;
        public GameObject Weapon;







        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
            shotDelay = true;
        }


        void Update()
        {

            MoveLogic();
            LookOnCursor();


            shot();

        }

        void MoveLogic()
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            MoveVector3 = new Vector3(Horizontal * speed, MoveVector3.y, Vertical * speed);

            rigidbody.velocity = MoveVector3;

        }


        void LookOnCursor()
        {
            Plane playerPlane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float hitdist = 0;
            if (playerPlane.Raycast(ray, out hitdist))
            {
                Vector3 targetPoint = ray.GetPoint(hitdist);
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speedRotate * Time.deltaTime);
            }
        }


        bool shotRay()
        {
            Weapon _Weapon = GetComponent<Weapon>();
            Debug.DrawRay(transform.position, transform.forward, Color.yellow);
            return (Physics.Raycast(transform.position, transform.forward, out hit, _Weapon.Ammo[_Weapon.ActualWeapon].GetComponent<WeaponStat>().shootingDistance));
        }

        void shot()
        {

            if (shotRay() && shotDelay == true && hit.transform.tag == "enemy" && Input.GetMouseButton(0))
            {

                Weapon _Weapon = GetComponent<Weapon>();
                if (_Weapon.Ammo[_Weapon.ActualWeapon].GetComponent<WeaponStat>().weaponClip > 0)
                {
                    _Weapon.Ammo[_Weapon.ActualWeapon].GetComponent<WeaponStat>().wasteOfBullets();
                    testHealth = hit.transform.gameObject;
                    testHealth.GetComponent<Enemies>().health -= _Weapon.Ammo[_Weapon.ActualWeapon].GetComponent<WeaponStat>().weaponDamage;
                    shotDelay = false;
                    _Weapon.Ammo[0].GetComponent<WeaponStat>().weaponClip = 99999;
                    Invoke("shotInvoke", _Weapon.Ammo[_Weapon.ActualWeapon].GetComponent<WeaponStat>().weaponRateFire);
                }
            }


        }

        void shotInvoke()
        {
            shotDelay = true;
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Bullet")
            {
                Weapon _Weapon = GetComponent<Weapon>();
                BulletStat _other = other.GetComponent<BulletStat>();
                _Weapon.Ammo[_other.WeaponWinner].GetComponent<WeaponStat>().addingBullets(Random.Range(_Weapon.Ammo[_other.WeaponWinner].GetComponent<WeaponStat>().MinDropBullet, _Weapon.Ammo[_other.WeaponWinner].GetComponent<WeaponStat>().MaxDropBullet));
                other.gameObject.SetActive(false);
            }

        }

    }


}

