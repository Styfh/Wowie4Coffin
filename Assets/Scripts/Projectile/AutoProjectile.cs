using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoProjectile : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float travelTime;

    private Rigidbody2D rb;
    public Transform target;

    public void Launch(GameObject aggroObj)
    {
        rb = GetComponent<Rigidbody2D>();
        target = aggroObj.transform;
        Vector2 direction = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);
        Destroy(gameObject, travelTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}
