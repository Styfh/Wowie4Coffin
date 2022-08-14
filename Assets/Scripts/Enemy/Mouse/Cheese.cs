using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    
    [SerializeField] private float speed;
    [SerializeField] private float travelTime;

    private Rigidbody2D rb;
    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (target.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(direction.x, direction.y);
        Destroy(gameObject, travelTime);
    }

}
