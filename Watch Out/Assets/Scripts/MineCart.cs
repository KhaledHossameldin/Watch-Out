using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineCart : MonoBehaviour
{
    [SerializeField] List<GameObject> path;
    float speed = 0.2f;
    int pathIndex;

    void Start()
    {
        pathIndex = 0;
        speed = 0.2f;
    }

    void Update()
    {
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, path[pathIndex].transform.position, speed * Time.deltaTime);
        if (Vector2.Distance(gameObject.transform.position, path[pathIndex].transform.position) < 0.01f)
        {
            pathIndex++;
            if (pathIndex >= path.Count)
            {
                pathIndex = 0;
            }
        }
    }
}
