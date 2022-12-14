using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private AudioSource sound;

    public Transform FirePoint;
    public GameObject arrowPrefab;

    public float arrowForce = 20f;

    public float cooldown;
    float lastShot;

    private void Start()
    {
        sound.volume = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            arrowShoot();
        }
    }

    void arrowShoot()
    {
        if(Time.time - lastShot < cooldown)
        {
            return;
        }
        lastShot = Time.time;
        sound.Play();
        GameObject Arrow = Instantiate(arrowPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * arrowForce, ForceMode2D.Impulse);
    }
}
