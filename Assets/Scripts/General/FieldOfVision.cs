using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfVision : MonoBehaviour
{

    [SerializeField] private float range;
    [SerializeField] private string targetTag;

    private Collider2D[] colliderArr;
    private Detect detect;

    private void Start()
    {
        detect = gameObject.GetComponent<Detect>();
    }

    private void Update()
    {

        if(detect.getAggro() != null)
        {
            return;
        }

        colliderArr = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (Collider2D collider in colliderArr)
        {
            if(collider.CompareTag(targetTag))
            {
                Debug.Log(gameObject.name + " aggroed");
                detect.setAggro(collider.gameObject);
            }
        }
    }

}
