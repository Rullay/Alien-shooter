using UnityEngine;

public class Pistol : Weapon
{

    public Pistol(int damage, float percentBullets) : base(damage, percentBullets) { }


    public override void Display()
    {
        Debug.Log("hui 2");
    }
}
