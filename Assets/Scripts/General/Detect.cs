using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour
{

    private GameObject aggro;

    public GameObject getAggro()
    {
        return aggro;
    }

    public void setAggro(GameObject enemy)
    {
        aggro = enemy;
    }

    public bool isAggro()
    {
        return aggro != null;
    }

}
