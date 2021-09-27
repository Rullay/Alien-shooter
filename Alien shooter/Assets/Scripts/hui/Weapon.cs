using UnityEngine;

public class Weapon {
    

    private int damage = 0;
    private float percentBullets = 0;

    public Weapon(int damage, float percentBullets)
    {
        this.damage = damage;
        this.percentBullets = percentBullets;

    }

    public int getDamage()
    {

        return damage;

    }

    public virtual void Display()
    {
        Debug.Log("hui");
    }

}
