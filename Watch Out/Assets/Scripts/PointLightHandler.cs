using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightHandler : MonoBehaviour
{
    float reduceRangeRate = 3;
    float nextTimeToReduce = 0;
    Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
        reduceRangeRate = 3;
        nextTimeToReduce = 0;
    }

    void Update()
    {
        if (pointLight.range > 1 && Time.time >= nextTimeToReduce)
        {
            pointLight.range -= 0.02f;
            nextTimeToReduce = Time.time + (1 / reduceRangeRate);
        }
    }
}
