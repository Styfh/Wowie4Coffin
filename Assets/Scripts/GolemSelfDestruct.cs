using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemSelfDestruct : MonoBehaviour
{

    [SerializeField] private GameObject explosion;

    private void Start()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
