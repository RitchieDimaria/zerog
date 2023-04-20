using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    private Vector3 Offset = new Vector3(0,3,0);
    private Vector3 RandomizeIntensity = new Vector3(3f,0,0);
    void Start() 
    {
        transform.localPosition +=Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x,RandomizeIntensity.x),
        Random.Range(-RandomizeIntensity.y,RandomizeIntensity.y),
        Random.Range(-RandomizeIntensity.z,RandomizeIntensity.z));

    }
}
