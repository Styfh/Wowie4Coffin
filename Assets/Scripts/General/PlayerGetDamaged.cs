using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGetDamaged : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (isDead())
        {
            Death();
        }

        healthBar.SetHealth(currentHealth);
    }

    void Death()
    {
        Destroy(gameObject);
    }

    public bool isDead()
    {
        if (currentHealth <= 0)
        {
            return true;
        }

        return false;
    }
}
