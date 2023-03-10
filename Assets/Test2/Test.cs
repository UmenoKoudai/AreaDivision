using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    int[,] _nums = new int[5, 6];
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                _nums[i, j] = i + j;
            }
        }
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                Debug.Log(_nums[i, j]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
