using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    
    private Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public float getStopDistance()
    {
        return stopDistance;
    }

    public bool CheckAtDistance()
    {
        if(getDistanceToTarget() <= stopDistance)
        {
            return true;
        }
        return false;
    }

    public void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void MoveAwayFromTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, - speed * Time.deltaTime);
    }

    public float getDistanceToTarget()
    {
        return Vector2.Distance(target.position, transform.position);
    }

}
