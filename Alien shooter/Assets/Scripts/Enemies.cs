using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace game
{
    public class Enemies : MonoBehaviour
    {
        public float health;
        public Text TextHealth;
        public GameObject character;
        public RaycastHit hit;
        private bool noticed;
        private Vector3 MoveVectorAlien;
        public new Rigidbody rigidbody;
        public bool AlienLook;
        public NavMeshAgent agent;
        public GameObject Bullet_list;


        [Header("Alien Settings")]
        public float AlienSpeed;







        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();

        }


        void Update()
        {
            //TargetAlien();
            TargetAlienGlobal();
            enamyHealth();
            Noticed();
            TextHealth.GetComponent<Text>().text = "" + health;


        }

        void enamyHealth()
        {
            if (health <= 0)
            {
                noticed = false;
                gameObject.SetActive(false);
                health = 10;
                SpawnBullet();

            }

        }

        void TargetAlienGlobal()
        {
            if (gameObject.activeInHierarchy == true)
            {
                noticed = true;
                AlienLook = true;
            }
        }

        void Noticed()
        {
            if (noticed == true)
            {
                /*MoveVectorAlien = new Vector3 ((character.transform.position.x - transform.position.x) * AlienSpeed, 0 ,(character.transform.position.z - transform.position.z)  * AlienSpeed);
                rigidbody.velocity = MoveVectorAlien;*/
                agent.SetDestination(character.transform.position);
            }

            if (AlienLook == true)
            {
                transform.LookAt(character.transform);
            }
        }


        void TargetAlien()
        {

            if (character.transform.position.x - transform.position.x <= 15 && character.transform.position.z - transform.position.z <= 15)
            {
                AlienLook = true;

                if (RayTargetAlien())
                {

                    if (hit.transform.tag == "Player")
                    {
                        noticed = true;

                    }
                }
            }


            if (character.transform.position.x - transform.position.x >= 20 && character.transform.position.z - transform.position.z >= 20)
            {
                noticed = false;
                AlienLook = false;
            }
        }


        bool RayTargetAlien()
        {
            Debug.DrawRay(transform.position, character.transform.position - transform.position, Color.yellow);
            return (Physics.Raycast(transform.position, character.transform.position - transform.position, out hit, 20));
        }

        void OnGUI()
        {
            //GUI.Label(new Rect(Screen.width*0.5f,Screen.height*0.5f,1000,2000) , "blablabla");
        }


        void SpawnBullet()
        {
            float CurrentPercentage = Random.Range(0, 100);
            if (character.GetComponent<Weapon>().AmmoDropRate >= CurrentPercentage)
            {
                for (int i = 0; Bullet_list.GetComponent<BulletList>().Bullet_List.Count > i; i++)
                {
                    if (Bullet_list.GetComponent<BulletList>().Bullet_List[i].activeInHierarchy != true)
                    {
                        Bullet_list.GetComponent<BulletList>().Bullet_List[i].SetActive(true);
                        Bullet_list.GetComponent<BulletList>().Bullet_List[i].transform.position = transform.position;
                        Bullet_list.GetComponent<BulletList>().Bullet_List[i].GetComponent<SpawnBullet>().Weaponpriority();
                        break;
                    }

                }

            }

        }

    }
}
