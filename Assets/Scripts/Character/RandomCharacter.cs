using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.U2D.Animation;
using UnityEngine.U2D;
using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;


public class RandomCharacter : MonoBehaviour
{
    public float SpawnTime;
    public GameObject Object1;
    public GameObject Object2;
    private int i;



    void SpawnRandomObject()
    {
        int i = Random.Range(1, 6);
        GameObject obj;
        if (i > 3)
        {
            obj = Object1;
        }
        else
        {
            obj = Object2;
        }
        Instantiate(obj, new Vector3(transform.position.x, 0, 0), Quaternion.identity);
    }

}

