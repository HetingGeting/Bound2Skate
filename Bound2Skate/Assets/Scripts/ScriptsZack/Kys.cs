using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kys : MonoBehaviour
{
    public static bool Bought1 = false;
    void Update()
    {
        if (Bought1 && transform.position == new Vector3(-1.33f, 1.38f, -14.54f)) 
        { 
            Destroy(gameObject); 
        }
    }
}
