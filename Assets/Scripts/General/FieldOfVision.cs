using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVision : MonoBehaviour
{

    [SerializeField] private float range;
    [SerializeField] private string aggroTag;

    private Collider2D[] colliderArr;

    private void Start()
    {
        colliderArr = Physics2D.OverlapCircleAll(transform.position, range);
    }

    private void Update()
    {
        colliderArr = Physics2D.OverlapCircleAll(transform.position, range);
    }

    public GameObject getAggro()
    {

        if(colliderArr == null)
        {
            return null;
        }

        foreach (Collider2D collider in colliderArr)
        {
            if(collider == null)
            {
                continue;
            }

            if (collider.CompareTag(aggroTag))
            {
                return collider.gameObject;
            }
        }

        return null;
    }

    public Collider2D[] getDetects()
    {
        return colliderArr;
    }

}
