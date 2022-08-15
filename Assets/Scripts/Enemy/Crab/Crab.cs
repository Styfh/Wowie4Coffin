using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crab : MonoBehaviour
{

    [SerializeField] AudioSource audio;
    [SerializeField] float attackCooldown;

    private FollowPlayer fp;
    private Animator anim;
    private GameObject target;
    private FieldOfVision fov;

    private bool isAttacking = false;
    private bool attackOnCooldown = false;

    private enum State {idling, moving, attacking};

    private void Start()
    {
        audio.volume = 0.1f;
        anim = GetComponent<Animator>();
        fov = GetComponent<FieldOfVision>();
        fp = GetComponent<FollowPlayer>();
    }

    private void Update()
    {
        GameObject aggro = fov.getAggro();

        if(aggro == null)
        {
            return;
        }

        if(!fp.targetIsSet())
        {
            fp.setTarget(aggro.transform);
        }

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
        audio.Play();
        yield return new WaitForSeconds(1);
        Debug.Log("Cooling down");
        isAttacking = false;
        attackOnCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        attackOnCooldown = false;
    }

}
