using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    //public GameObject hitEffect;
    public int damage = 40;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // EnemiScript enemy = hitInfo.GetComponent<EnemiScript>();
        // if (enemy != null)
        // {
        //     enemy.TakeDamage(damage);
        // }
    }
}
