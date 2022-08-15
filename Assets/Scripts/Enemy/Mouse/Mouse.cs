using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    [SerializeField] private float cooldownDuration;

    private enum State {idling, moving, attacking};

    private FieldOfVision fov;
    private FollowPlayer fp;
    private Animator anim;

    private State state;
    private bool isAttacking = false;
    private bool onCooldown = false;

    void Start()
    {
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
        anim = GetComponent<Animator>();
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
            fp.setTarget(aggro.transform);
        }

        float distanceToRange = fp.getDistanceToTarget() - fp.getStopDistance();

        if(distanceToRange >= .5f && !isAttacking)
        {
            fp.MoveTowardsTarget();
            state = State.moving;
        } 

        else if(distanceToRange <= -.5f && !isAttacking)
        {
            fp.MoveAwayFromTarget();
            state = State.moving;
        }

        else if(distanceToRange < .5f && distanceToRange > -.5f)
        {
            if(onCooldown)
            {
                state = State.idling;
            }
            else if(!isAttacking && !onCooldown)
            {
                state = State.attacking;
                StartCoroutine(Attack());
            }
        }

        anim.SetInteger("state", (int) state);

    }

    private IEnumerator Attack()
    {
        //Debug.Log("Attacking");
        isAttacking = true;
        yield return new WaitForSeconds(1);
        //Debug.Log("Cooling down");
        isAttacking = false;
        onCooldown = true;
        yield return new WaitForSeconds(cooldownDuration);
        onCooldown = false;

    }

}
