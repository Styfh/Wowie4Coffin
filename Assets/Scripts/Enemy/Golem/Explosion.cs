using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    [SerializeField] private AudioSource sound;

    private void Start()
    {
        sound.volume = 0.1f;
    }

    private void OnEnable()
    {
        sound.Play();
    }

}
