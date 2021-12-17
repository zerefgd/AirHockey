using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    [SerializeField]
    float up, down, left, right;

    private void Update()
    {
        Vector3 temp = transform.position;
        if (temp.x > right)
            temp.x = right;
        if (temp.x < left)
            temp.x = left;
        if (temp.y < down)
            temp.y = down;
        if (temp.y > up)
            temp.y = up;
        transform.position = temp;
    }
}
