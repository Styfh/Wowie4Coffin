using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageScript : MonoBehaviour
{
    [SerializeField] private AudioSource sound;
    public int health;

    //public int invulnerable;
    //private int count;

    private void Start()
    {
        sound.volume = 0.1f;
    }

    public void TakeDamage(int damage)
    {
        sound.Play();
        health -= damage;

        if(isDead())
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);

        if(gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }

    public bool isDead()
    {
        if(health <= 0)
        {
            return true;
        }

        return false;
    }
}
