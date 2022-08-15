using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float stopDistance;
    
    private GameObject target;
    private DamageScript targetDmg;
    private Detect detect;

    private void Start()
    {
        detect = gameObject.GetComponent<Detect>();
    }

    private void Update()
    {
        if (!detect.isAggro() || target != null)
        {
            return;
        }
 
        else
        {
            target = detect.getAggro();
            targetDmg = target.GetComponent<DamageScript>();
        }
    }

    public float getStopDistance()
    {
        return stopDistance;
    }

    public bool CheckAtDistance()
    {
        Debug.Log(getDistanceToTarget());
        if(getDistanceToTarget() <= stopDistance)
        {
            return true;
        }
        return false;
    }

    public void MoveTowardsTarget()
    {
        if(target == null)
        {
            return;
        }

        if(!detect.isAggro() || targetDmg.isDead())
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    public void MoveAwayFromTarget()
    {
        if(target == null)
        {
            return;
        }
        if(!detect.isAggro() || targetDmg.isDead())
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, - speed * Time.deltaTime);
    }

    public float getDistanceToTarget()
    {
        if(target == null)
        {
            return float.NegativeInfinity;
        }
        if(!detect.isAggro() || targetDmg.isDead() )
        {
            return float.PositiveInfinity;
        }

        return Vector2.Distance(target.transform.position, transform.position);
    }

}
