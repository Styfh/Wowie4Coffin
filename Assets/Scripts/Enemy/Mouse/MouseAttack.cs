using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAttack : MonoBehaviour
{

    [SerializeField] private AudioSource attackSound;
    [SerializeField] private GameObject cheese;
    [SerializeField] private float travelTime;

    private FieldOfVision fov;

    private void Start()
    {
        attackSound.volume = 0.1f;
    }

    private void OnEnable()
    {
        attackSound.Play();
        fov = GetComponent<FieldOfVision>();
        GameObject cheeseInstance = Instantiate(cheese, transform.position, Quaternion.identity);
        AutoProjectile cheeseScript = cheeseInstance.GetComponent<AutoProjectile>();
        cheeseScript.Launch(fov.getAggro());

    }

}
