using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerGoal"))
        {
            GameManager.instance.UpdateScore(true);
            transform.position = Vector3.zero + Vector3.up * 2f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        if (collision.CompareTag("AIGoal"))
        {
            GameManager.instance.UpdateScore(false);
            transform.position = Vector3.zero - Vector3.up * 2f;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
