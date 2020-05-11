using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCartStartScene : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.right * 0.5f * Time.deltaTime;
        if (transform.position.x >= 3)
        {
            transform.position = new Vector2(-3, transform.position.y);
        }
    }
}
