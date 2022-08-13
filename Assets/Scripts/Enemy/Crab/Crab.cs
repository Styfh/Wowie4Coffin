using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{

    [SerializeField] float attackCooldown;

    private FollowPlayer fp;
    private Animator anim;
    private Transform target;

    private bool isAttacking = false;
    private bool attackOnCooldown = false;

    private enum State {idling, moving, attacking};

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        fp = GetComponent<FollowPlayer>();
    }

    private void Update()
    {
        if(!fp.CheckAtDistance() && !isAttacking)
        {
            fp.MoveTowardsTarget();
            anim.SetInteger("state", (int) State.moving);        
        } 
        else if(fp.CheckAtDistance())
        {
            if(!isAttacking && !attackOnCooldown)
            {
                anim.SetInteger("state", (int) State.attacking);
                StartCoroutine(Attack());
            } else if(attackOnCooldown) {
                anim.SetInteger("state", (int) State.idling);
            }
        } 

    }
    
    private IEnumerator Attack()
    {
        Debug.Log("Attacking");
        isAttacking = true;
        yield return new WaitForSeconds(1);
        Debug.Log("Cooling down");
        isAttacking = false;
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

}
