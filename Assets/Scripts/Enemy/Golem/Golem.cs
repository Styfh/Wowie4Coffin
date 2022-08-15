using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private enum State {idling, moving, attacking};

    private Detect detect;
    private FollowPlayer fp;
    private Animator anim;

    private float stopDistance;


    private void Start()
    {
        detect = GetComponent<Detect>();
        fp = GetComponent<FollowPlayer>();
        anim = GetComponent<Animator>();
        stopDistance = fp.getStopDistance();
    }

    private void Update()
    {
        if (!detect.isAggro())
        {
            return;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Golem hit!");
    }

}
