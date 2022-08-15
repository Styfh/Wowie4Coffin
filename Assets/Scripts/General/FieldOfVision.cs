using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVision : MonoBehaviour
{

    [SerializeField] private float range;
    [SerializeField] private string aggroTag;

    private Collider2D[] colliderArr;
    
    private GameObject aggro;

    private void Update()
    {
        colliderArr = Physics2D.OverlapCircleAll(transform.position, range);
    }

    public GameObject getAggro()
    {
        foreach (Collider2D collider in colliderArr)
        {
            //Debug.Log(collider);
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
