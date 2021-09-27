using UnityEngine;


public class Drobovik : Weapon
{

    public Drobovik(int damage, float percent) : base(damage, percent) {}

 

    public override void Display()
    {
        Debug.Log("hui 3");
    }
}
