using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{

    [SerializeField] private float invincibilityDuration;
    private bool canBeDamaged = true;
    
    public int health;

    public void TakeDamage(int damage)
    {

        if (canBeDamaged)
        {
            StartCoroutine(IFrames());
            health -= damage;

            if(isDead())
            {
                Death();
            }
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

    private IEnumerator IFrames()
    {
        canBeDamaged = false;
        yield return new WaitForSeconds(invincibilityDuration);
        canBeDamaged = true;
    }
}
