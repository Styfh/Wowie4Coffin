using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beaver : MonoBehaviour
{

    [SerializeField] private float cooldownDuration;

    private FollowPlayer fp;
    private FieldOfVision fov;
    private GameObject target;
    private GameObject player;

    private bool isAttacking;
    private bool onCooldown;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
    }

    void Update()
    {

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

        Debug.Log(target);

        if(target == null)
        {
            Debug.Log("No target");
            return;
        }

        if(fp.GetTarget() != target.transform)
        {
            fp.setTarget(target.transform);
        }

        if(target == player && !fp.CheckAtDistance())
        {
            fp.MoveTowardsTarget();
        }
        else
        {
            float distanceToRange = fp.getDistanceToTarget() - fp.getStopDistance();

            if (distanceToRange >= .5f && !isAttacking)
            {
                fp.MoveTowardsTarget();
            }

            else if (distanceToRange <= -.5f && !isAttacking)
            {
                fp.MoveAwayFromTarget();
            }

            else if (distanceToRange < .5f && distanceToRange > -.5f)
            {
                if (onCooldown)
                {
                }
                else if (!isAttacking && !onCooldown)
                {
                }
            }
        }



    }
}
