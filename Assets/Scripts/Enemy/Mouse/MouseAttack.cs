using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject cheese;
    [SerializeField] private float travelTime;

    private GameObject cheeseInstance;

    private void OnEnable()
    {
        //Debug.Log("Instantiating cheese");
        Instantiate(cheese, transform.position, Quaternion.identity);
    }

}
