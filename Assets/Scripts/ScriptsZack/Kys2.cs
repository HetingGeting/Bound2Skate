using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kys2 : MonoBehaviour
{
    public static bool Bought2 = false;
    void Update()
    {
        if (Bought2 && transform.position == new Vector3(-11.9499998f, 1.24109936f, -3.47000003f))
        {
            Destroy(gameObject);
        }
    }
}
