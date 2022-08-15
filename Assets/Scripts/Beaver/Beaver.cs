using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Beaver : MonoBehaviour
{

    [SerializeField] private AudioSource sound;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private GameObject projectile;

    private FollowPlayer fp;
    private FieldOfVision fov;
    private GameObject target;
    private GameObject player;
    private Animator anim;

    private bool isMoving;
    private bool onCooldown = false;

    void Start()
    {
        sound.volume = 0.1f;
        player = GameObject.FindGameObjectWithTag("Player");
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
        isMoving = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        isMoving = false;

        Collider2D[] detects = fov.getDetects();
        GameObject aggro = fov.getAggro();

        Debug.Log(detects);

        if(aggro != null)
        {
            target = aggro;
        }

        else if(detects != null)
        {
            target = player;
        }

        if(target == null)
        {
            Debug.Log("No target");
            return;
        }

        if(fp.GetTarget() != target.transform)
        {
            fp.setTarget(target.transform);
        }

        Debug.Log(target);

        if(target == player)
        {

            if (!fp.CheckAtDistance())
            {
                isMoving = true;
                fp.MoveTowardsTarget();
            }

        }
        else
        {
            float distanceToRange = fp.getDistanceToTarget() - fp.getStopDistance();

            if (distanceToRange >= .5f)
            {
                isMoving = true;
                fp.MoveTowardsTarget();
            }

            else if (distanceToRange <= -.5f)
            {
                isMoving = true;
                fp.MoveAwayFromTarget();
            }

            else if (distanceToRange < .5f && distanceToRange > -.5f)
            {
                if (!onCooldown)
                {
                    Debug.Log("Attacking");
                    sound.Play();
                    GameObject pebble = Instantiate(projectile, transform.position, Quaternion.identity);
                    AutoProjectile pebbleScript = pebble.GetComponent<AutoProjectile>();
                    pebbleScript.Launch(target);
                    StartCoroutine(Attack());
                }
            }
        }

        anim.SetBool("moving", isMoving);

    }

    private IEnumerator Attack()
    {
        Debug.Log("Cooling down");
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;
    }
}
