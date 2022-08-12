using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    private enum State {idling, moving, attacking};

    private FollowPlayer fp;
    private Animator anim;
    private Transform target; 
    private float stopDistance;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        fp = GetComponent<FollowPlayer>();
        anim = GetComponent<Animator>();
        stopDistance = fp.getStopDistance();
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= stopDistance)
        {
            anim.SetInteger("state", (int) State.attacking);
        } else{
            anim.SetInteger("state", (int) State.moving);
        }
    }
 
}
