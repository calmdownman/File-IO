using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise03 : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        int[] array = new int[5];

        Debug.Log("수정 전");
        for (int x=0; x<array.Length;x++)
        {
            array[x] = UnityEngine.Random.Range(1,100);
            Debug.Log(array[x]);
        }
        
        Array.Sort(array);
        
        Debug.Log("수정 후");
        for (int x = 0; x < array.Length; x++)
        {
            Debug.Log(array[x]);
        }

    }




    }


