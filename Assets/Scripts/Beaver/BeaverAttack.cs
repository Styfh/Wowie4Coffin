using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaverAttack : MonoBehaviour
{

    public int damage;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        DamageScript enemy = hitInfo.GetComponent<DamageScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }
}
