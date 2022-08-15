using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        DamageScript hero = hitInfo.GetComponent<DamageScript>();
        if (hero != null)
        {
            hero.TakeDamage(damage);
        }
    }

}
