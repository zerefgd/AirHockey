using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canMove;

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        if(Input.GetMouseButton(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (!GetComponent<CircleCollider2D>().OverlapPoint(mousPos))
                return;
            GetComponent<Rigidbody2D>().MovePosition(mousPos);
        }
    }
}
