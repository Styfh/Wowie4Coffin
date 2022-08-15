using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    public int health;

    //public int invulnerable;
    //private int count;

    private void Start()
    {
        sound.volume = 0.1f;
    }

    public void TakeDamage(int damage)
    {
        sound.Play();
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
