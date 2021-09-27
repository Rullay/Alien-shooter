    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
    public class SpawnEnemies : MonoBehaviour
    {
        public List<GameObject> Enamies_List = new List<GameObject>();

        void Start()
        {

        }


        void Update()
        {
            Spawn_Enamies();
        }


        void Spawn_Enamies()
        {

            for (int i = 0; Enamies_List.Count > i; i++)
            {
                if (Enamies_List[i].activeInHierarchy == true)
                {
                    if (Enamies_List[i].transform.position.x - transform.position.x <= 2.5 && Enamies_List[i].transform.position.z - transform.position.z <= 2.5)
                    {
                        break;
                    }
                }
                if (Enamies_List.Count == i + 1)
                {
                    for (int j = 0; Enamies_List.Count > j; j++)
                    {
                        if (Enamies_List[j].activeInHierarchy != true)
                        {
                            Enamies_List[j].SetActive(true);
                            Enamies_List[j].transform.position = transform.position;
                            break;
                        }
                    }
                }
            }


            /* for (int j = 0; Enamies_List.Count > j; j++)
             {
                 if (Enamies_List[j].activeInHierarchy != true)
                 {
                     Enamies_List[j].SetActive(true);
                     Enamies_List[j].transform.position = transform.position;
                     break;
                 }
             }*/



        }
    }
}
