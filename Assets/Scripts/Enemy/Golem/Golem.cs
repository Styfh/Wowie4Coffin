using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private enum State {idling, moving, attacking};

    private FieldOfVision fov;
    private FollowPlayer fp;
    private Animator anim;


    private void Start()
    {
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        GameObject aggro = fov.getAggro();

        if (aggro == null)
        {
            return;
        }

        if(!fp.targetIsSet())
        {
            fp.setTarget(aggro.transform);
        }

        if (fp.CheckAtDistance())
        {
            anim.SetInteger("state", (int) State.attacking);
        } 
        else
        {
            fp.MoveTowardsTarget();
            anim.SetInteger("state", (int) State.moving);
        }
    }

}
