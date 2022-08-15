using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Skull : MonoBehaviour
{

    [SerializeField] private AudioSource sound;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashPower;
    [SerializeField] private float dashTime;

    private FollowPlayer fp;
    private FieldOfVision fov;
    private Transform target;
    private Rigidbody2D rb;

    private float timeBetweenDash;
    private bool canDash = true;
    private bool isDashing;


    void Start()
    {
        sound.volume = 0.1f;
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
        rb = GetComponent<Rigidbody2D>();
        timeBetweenDash = dashCooldown;
    }

    void Update()
    {

        GameObject aggro = fov.getAggro();

        if (aggro == null)
        {
            return;
        }

        if (!fp.targetIsSet())
        {
            target = aggro.transform;
            fp.setTarget(aggro.transform);
        }

        if (canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }

    }

    private IEnumerator Dash()
    {
        // Debug.Log("Dashing");

        canDash = false;
        isDashing = true;

        Vector2 direction = (target.position - transform.position).normalized * dashPower;

        rb.velocity = new Vector2(direction.x, direction.y);
        tr.emitting = true;

        sound.Play();

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
