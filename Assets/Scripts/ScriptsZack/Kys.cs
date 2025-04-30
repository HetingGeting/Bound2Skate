using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kys : MonoBehaviour
{
    public static bool Bought1 = false;
    void Update()
    {
        if (Bought1 && transform.position == new Vector3(-6.53999996f, 2.25f, -17.2199993f)) 
        { 
            Destroy(gameObject); 
        }
    }
}
