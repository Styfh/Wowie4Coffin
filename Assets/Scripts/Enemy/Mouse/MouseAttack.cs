using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject cheese;
    [SerializeField] private float travelTime;

    private Detect detect;

    private void OnEnable()
    {
        detect = GetComponent<Detect>();
        GameObject cheeseInstance = Instantiate(cheese, transform.position, Quaternion.identity);
        Cheese cheeseScript = cheeseInstance.GetComponent<Cheese>();
        cheeseScript.Launch(detect.getAggro());

    }

}
