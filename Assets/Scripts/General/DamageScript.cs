using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int health;

    //public int invulnerable;
    //private int count;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(isDead())
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

    public bool isDead()
    {
        if(health <= 0)
        {
            return true;
        }

        return false;
    }
}
