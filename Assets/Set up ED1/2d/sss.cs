using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sss : MonoBehaviour {
    private float[] noiseValues;
    void Start()
    {
        Random.InitState(42);
        noiseValues = new float[10];
        for (int i = 0; i < noiseValues.Length; i++)
        {
            noiseValues[i] = Random.Range(1, 11);
            print(noiseValues[i]);
        }
    }
}
