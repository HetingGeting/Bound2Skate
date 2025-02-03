using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kys2 : MonoBehaviour
{
    public static bool Bought2 = false;
    void Update()
    {
        if (Bought2 && transform.position == new Vector3(-2.93f, 1.4819f, -13.76f))
        {
            Destroy(gameObject);
        }
    }
}
