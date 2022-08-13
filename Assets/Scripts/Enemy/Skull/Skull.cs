using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skull : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;

    private FollowPlayer fp;
    private Transform target;
    private Rigidbody2D rb;

    private float timeBetweenDash;
    private float dirX;
    private float dirY;
    private bool canDash = true;
    private bool isDashing;


    void Start()
    {
        fp = GetComponent<FollowPlayer>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetweenDash = dashCooldown;
    }

    void Update()
    {

        if(canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash()
    {
        // Debug.Log("Dashing");

        canDash = false;
        isDashing = true;
        dirX = target.position.x - transform.position.x;
        dirY = target.position.y - transform.position.y;

        float hyp = (float) System.Math.Sqrt(dirX * dirX + dirY * dirY);
        dirX /= hyp;
        dirY /= hyp;

        rb.velocity = new Vector2(dirX * dashPower, dirY * dashPower);
        tr.emitting = true;

        yield return new WaitForSeconds(dashTime);
        
        // Debug.Log("Dash Time End");

        rb.velocity = Vector2.zero;

        tr.emitting = false;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        
        // Debug.Log("Dash Cooldown End");

        canDash = true;
    }
}
