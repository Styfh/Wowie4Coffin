using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    
    private Transform target;

    public float getStopDistance()
    {
        return stopDistance;
    }

    public bool CheckAtDistance()
    {
        //Debug.Log(getDistanceToTarget());
        if(getDistanceToTarget() <= stopDistance)
        {
            return true;
        }
        return false;
    }

    public void MoveTowardsTarget()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void MoveAwayFromTarget()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, - speed * Time.deltaTime);
        }
    }

    public float getDistanceToTarget()
    {
        if(target != null)
        {
            return Vector2.Distance(target.position, transform.position);
        }
        return float.PositiveInfinity;
    }

    public Transform GetTarget()
    {
        return target;
    }

    public void setTarget(Transform newTarget)
    {
        target = newTarget;
    }

    public bool targetIsSet()
    {
        return target != null;
    }

}
