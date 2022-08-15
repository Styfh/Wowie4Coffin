using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject cheese;
    [SerializeField] private float travelTime;

    private FieldOfVision fov;

    private void OnEnable()
    {
        fov = GetComponent<FieldOfVision>();
        GameObject cheeseInstance = Instantiate(cheese, transform.position, Quaternion.identity);
        Cheese cheeseScript = cheeseInstance.GetComponent<Cheese>();
        cheeseScript.Launch(fov.getAggro());

    }

}
