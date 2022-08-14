using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //public GameObject hitEffect;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player"))
        {
            return;
        }
        DamageScript enemy = hitInfo.GetComponent<DamageScript>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        if (enemy.health <= 0){
            Destroy(gameObject);
        }
    }
}
