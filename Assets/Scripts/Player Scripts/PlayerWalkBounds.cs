using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkBounds : MonoBehaviour
{
    public float min_X, max_X;
    void Update()
    {
        MovementBounds();
    }

    // Update is called once per frame
    void MovementBounds()
    {
        Vector3 temp = transform.position;
        // we cannot go below the minimun x position
        if (temp.x < min_X)
        {
            temp.x = min_X;
        }
        //we cannot go above the maximum x position
        if (temp.x > max_X)
        {
            temp.x = max_X;
        }
        transform.position = temp;
    }
}
