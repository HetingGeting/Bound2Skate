using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] Trash;
    void Start()
    {
        for (int i = 0; i < Trash.Length; i++) 
        {
            Instantiate(Trash[i], Trash[i].transform.position, Trash[i].transform.rotation);
        }
    }

}
