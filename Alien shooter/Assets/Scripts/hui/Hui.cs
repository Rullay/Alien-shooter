using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Weapon hui = new Weapon(11);
        List<Weapon> weapons = new List<Weapon>() { new Pistol(22, 44.22f), new Drobovik(33, 42) };

        foreach (Weapon weapon in weapons)
        {
            weapon.Display();
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
