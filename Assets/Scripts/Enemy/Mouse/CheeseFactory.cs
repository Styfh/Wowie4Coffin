using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseFactory : MonoBehaviour
{

    public GameObject GetCheese(GameObject cheeseTemplate, Vector2 position, Quaternion rotation, GameObject target)
    {
        GameObject cheese = Instantiate(cheeseTemplate, position, rotation);
        cheese.GetComponent<AutoProjectile>().target = target.transform;
        return cheese;
    }

}
